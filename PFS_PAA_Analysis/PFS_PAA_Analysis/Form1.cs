using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Configuration;
using PfsPaaDAL;
using OfficeOpenXml;
using System.IO;
using PFSFeed.Model;
using System.Threading;

namespace PFS_PAA_Analysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DataTable dataTable;
        private DataTable dataTableExport;
        private DataTable dataTableAnalysed;

        private void openFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK) // Test result.
                {
                    #region Read the xls file
                    fileName.Text = dialog.FileName;
                    //var s = ConfigurationManager.ConnectionStrings["xlsx"].ConnectionString;
                    var connStr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR=YES'", dialog.FileName);

                    //Excel.Application xlApp = new Excel.Application();
                    //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(dialog.FileName, 0, false);
                    //Excel.Worksheet xlWorkSheet = xlWorkbook.Worksheets[2];

                    dataTable = new DataTable();
                    var dtColumns = ReportColumnMap.NewDtColumnDict();
                    var sheetName = "ALL$";
                    try
                    {
                        using (OleDbConnection conn = new OleDbConnection(connStr))
                        {
                            conn.Open();

                            // Filter the columns read by intended hardcoded columns
                            var colNameArrayStr = string.Join(",", dtColumns.Keys.Select(k => "'" + k + "'"));
                            var filterStr = string.Format(@"[TABLE_NAME]='{0}' AND [COLUMN_NAME] IN({1})", sheetName, colNameArrayStr);
                            var schema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null)?.Select(filterStr).ToList().OrderBy(r => r["ORDINAL_POSITION"]);

                            var colMapped = schema?.Select(r => (string)r["COLUMN_NAME"]).ToList();
                            colNameArrayStr = string.Join(",", colMapped?.Select(m => "[" + m + "]"));

                            // Select only the intended columns
                            OleDbCommand comm = new OleDbCommand(string.Format("select {0} from [{1}] where PositionId > 0", colNameArrayStr, sheetName), conn);
                            OleDbDataAdapter adapter = new OleDbDataAdapter() { SelectCommand = comm };

                            // Populate the datatable with mapped columns in order read
                            colMapped?.ForEach(c => dataTable.Columns.Add(dtColumns[c]));
                            adapter.Fill(dataTable);

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    #endregion
                    //var interestedPos = new[] { 3581874, 3581875, 3581876, 3581884, 3581885, 3581886, 3583129, 3583130,
                    //    3583131, 4260687, 4395271, 4969299, 4969300, 4969301, 5096217, 5172317, 5172318, 5172319, 5219314,
                    //    5269777, 5275676, 9957149, 10014344, 10014357, 10107257, 10107392, 10526409, 10526410, 10526413,
                    //    10766562, 10796052, 10796055, 10811540, 10811614, 10811769, 10886711, 10982243, 11003554, 11003555,
                    //    11003556, 11005210, 11005211, 11005212, 11005213, 11005214, 11005215, 11005219, 11005220, 11005221,
                    //    11007979, 11007980, 11007981, 11007982, 11007983, 11007984, 11031540, 11031554 };
                    var interestedPos = new[] { 4260687 };
                    var startingDate = dataTable.AsEnumerable().Min(d => d["EodDate"]);
                    var posGroup = dataTable.AsEnumerable().GroupBy(r => (int)r["PositionId"])
                               .OrderBy(g => g.Key)
                               .OrderBy(g => g.Select(dtRow => dtRow["Region"]).First())
                               .Where(p => interestedPos.Contains(p.Key));


                    //var posGroup = dataTable.AsEnumerable().GroupBy(r => (int)r["PositionId"])
                    //           .OrderBy(g => g.Key)
                    //           .OrderBy(g => g.Select(dtRow => dtRow["Region"]).First());                   

                    dataTableExport = new DataTable();
                    var dtExColumns = ReportColumnMap.NewDtColumnDict();
                    dataTableExport.Columns.AddRange(dtExColumns.Values.ToArray());
                    //var rowArray = posGroup.SelectMany(g => g).ToList();
                    //dataTableExport = rowArray.CopyToDataTable();

                    dataTableAnalysed = new DataTable();
                    var analysisColumns = ReportColumnMap.NewAnalysisDtColumns();
                    dataTableAnalysed.Columns.AddRange(analysisColumns);


                    #region Load pfs data


                    var load = new PfsDataLoad();
                    var summarizedRows = new List<DataRow>();
                    var analysedRows = new List<DataRow>();
                    foreach (var pos in posGroup)
                    {                        
                        if ((string)pos.FirstOrDefault()["Region"] == "APAC")
                            continue;

                        if (pos.Any(p => p["Reason"] != DBNull.Value && (string)p["Reason"] == "CB/FUT"))
                        {
                            pos.ToList().ForEach(p => p["Reason"] = "CB/FUT");
                            summarizedRows.AddRange(pos);
                            continue;
                        }

                        var eodDates = pos.GroupBy(r => (int)r["EodDate"]).ToList();
                        var eodDuplicates = eodDates.Where(d => d.Count() > 1).ToList();

                        var eodInconsistent = eodDuplicates.Where(d => d.ToList()[0]["Residual"] != d.ToList()[1]["Residual"]).ToList();
                        eodInconsistent.ForEach(d => d.ToList().ForEach(n => n["Comments"] = "Inconsistent residuals"));

                        foreach (var eod in eodDates)
                        {
                            try
                            {
                                if (eodInconsistent.Any(d => d.Key == eod.Key))
                                {
                                    summarizedRows.AddRange(eodInconsistent[eod.Key]);
                                    continue;
                                }

                                var dtRow = eod.First();
                                var itemArrayAnalysed = new object[]
                                {
                                    dtRow["Region"],
                                    dtRow["EodDate"],
                                    dtRow["PositionNode"],
                                    dtRow["PositionId"],
                                    dtRow["Delta_T_2"],
                                    dtRow["Quantity_T_1"],
                                    dtRow["Quantity_T_2"],
                                    dtRow["TradeQuantity"],
                                    dtRow["Theta"],
                                    dtRow["IntradayTradingPLUSD"],
                                    dtRow["Residual"],
                                    dtRow["AbsRes"],
                                    false, // Db_Inconsistency
                                    "", // Qty_Inconsistency
                                    "", // Avg_Inconsistency
                                    "", // Rls_Inconsistency
                                    "", // Comm_Inconsistency
                                    "", // Div_Inconsistency
                                    "", // Coupon_Inconsistency
                                    true, // MarkingOK
                                    "", // UCF_CT
                                    DBNull.Value, // UCF_Amt
                                    DBNull.Value, // UCF_Reset
                                    "", // SuddenUCF_CT
                                    DBNull.Value, // SuddenUCF_USDAmt
                                    "", // SuddenRCF_CT
                                    DBNull.Value, // SuddenRCF_USDAmt
                                    false //Cancelled
                                };
                                var dtRowAnalysed = dataTableAnalysed.NewRow();
                                dtRowAnalysed.ItemArray = itemArrayAnalysed;

                                PfsPaaDAL.Region region;
                                if (!Enum.TryParse((string)dtRow["Region"], out region))
                                    continue;

                                var t_1 = eod.Key;
                                var t_2 = Utility.DateToRover8(Utility.AddBusinessDays(Utility.Rover8ToDate(t_1), -1, null));
                                var tday = new Dictionary<int, string>
                                {
                                    {t_1, "T-1"},
                                    {t_2, "T-2"}
                                };

                                load.ShowHist(region: region, date: t_1, posId: (int)dtRow["PositionId"], goBack: 2, showFixes: false);

                                var inconsistency = load.ConsistencyDataSet.Where(pl => (!pl.Value.IsOk) && (pl.Key == t_1 || pl.Key == t_2));
                                var marking = load.PaaDataSet.Where(paa => (paa.Value.MOK == "M") && (paa.Key == t_1 || paa.Key == t_2));
                                var swap_T_1 = load.PfsDataSet[t_1];
                                var swap_T_2 = load.PfsDataSet[t_2];
                                var ucf = swap_T_1.UnrealisedCF;
                                var sddUcf = swap_T_1.UcfSudden;
                                var sddRcf = swap_T_1.RcfSudden;

                                // Inconsistency columns
                                if (inconsistency.Any())
                                {
                                    dtRow["Reason"] = Utility.AttachString(dtRow["Reason"], "Db inconsistency");
                                    dtRowAnalysed["Db_Inconsistency"] = true;
                                    foreach (var t in inconsistency)
                                    {
                                        // TODO : PfsDbConsistencyData 
                                        var types = new Dictionary<int, string>
                                         {
                                            { 0, t.Value.QtyOk == "" ? "" : "Qty" },
                                            { 1, t.Value.AvgOk == "" ? "" : "AvgCost" },
                                            { 2, t.Value.RlsdOk == "" ? "" : "RealisedCF" },
                                            { 3, t.Value.CommOk == "" ? "" : "Commision" },
                                            { 4, t.Value.DivOk == "" ? "" : "Dividend" },
                                            { 5, t.Value.CouponOk == "" ? "" : "Coupon" }
                                        }.Where(x => !string.IsNullOrEmpty(x.Value));

                                        var iQty = dataTableAnalysed.Columns.IndexOf("Qty_Inconsistency");
                                        types.ToList().ForEach(x =>
                                        {
                                            dtRow["SubReason"] = Utility.AttachString(dtRow["SubReason"], x.Value);
                                            dtRowAnalysed[iQty + x.Key] = Utility.AttachString(dtRowAnalysed[iQty + x.Key], tday[t.Key]);
                                        });
                                    }
                                }

                                // Marking error column
                                if (marking.Count() > 0)
                                {
                                    dtRow["Reason"] = Utility.AttachString(dtRow["Reason"], "Marking error");
                                    dtRowAnalysed["MarkingOK"] = false;
                                }

                                // UCF columns
                                if (ucf.Length > 0)
                                {
                                    double ucfAmt = 0;
                                    foreach (var u in ucf)
                                    {
                                        dtRowAnalysed["UCF_CT"] = Utility.AttachString(dtRowAnalysed["UCF_CT"], Enum.GetName(typeof(ShortCashFlowTypeEnum), u.ShortCashFlowType));
                                        ucfAmt += u.Amount;
                                    }
                                    dtRowAnalysed["UCF_Amt"] = ucfAmt;
                                }

                                // UCF_Reset column
                                var ucfReset = ucf.FirstOrDefault(u => u.ShortCashFlowType == ShortCashFlowTypeEnum.Reset)?.FinAmt;
                                dtRowAnalysed["UCF_Reset"] = (object)ucfReset ?? DBNull.Value;

                                // SudddenUCF columns 
                                if (sddUcf.Count() > 0)
                                {
                                    //var usdAmt = Convert.ToDouble(Utility.DBNullToNull(dtRowAnalysed["SuddenUCF_USDAmt"]) ?? 0.0);
                                    double usdAmt = 0;
                                    foreach (var s in sddUcf)
                                    {
                                        dtRowAnalysed["SuddenUCF_CT"] = Utility.AttachString(dtRowAnalysed["SuddenUCF_CT"], Enum.GetName(typeof(ShortCashFlowTypeEnum), s.ShortCashFlowType));
                                        usdAmt += s.USDAmt;
                                    }
                                    dtRowAnalysed["SuddenUCF_USDAmt"] = usdAmt;
                                }

                                // SuddenRCF columns
                                if (sddRcf.Count() > 0)
                                {
                                    //var usdAmt = Convert.ToDouble(Utility.DBNullToNull(dtRowAnalysed["SuddenRCF_USDAmt"]) ?? 0.0);
                                    double usdAmt = 0;
                                    foreach (var s in sddRcf)
                                    {
                                        dtRowAnalysed["SuddenRCF_CT"] = Utility.AttachString(dtRowAnalysed["SuddenRCF_CT"], s.CashType);
                                        usdAmt += s.USDAmt;
                                    }
                                    dtRowAnalysed["SuddenRCF_USDAmt"] = usdAmt;
                                }

                                // Cancelled column
                                if (swap_T_1.TQ == 0 && (swap_T_2.TQ + swap_T_1.IdayTQ == 0) && swap_T_1.SettQty == 0 && swap_T_1.SettPrice == 0)
                                {
                                    dtRow["Reason"] = Utility.AttachString(dtRow["Reason"], "Closed out position");
                                    dtRowAnalysed["Cancelled"] = true;
                                }

                                summarizedRows.Add(dtRow);
                                analysedRows.Add(dtRowAnalysed);
                            }
                            catch (Exception ex)
                            {
                                summarizedRows.Add(eod.First());
                                Console.WriteLine(ex.ToString());
                            }

                        }

                    }
                    #endregion

                    #region Export report
                    //dataTableExport.Rows.Clear();
                    dataTableAnalysed = analysedRows.CopyToDataTable();
                    dataTableExport = summarizedRows.CopyToDataTable();

                    dataGrid.DataSource = dataTableExport;
                    dataGrid2.DataSource = dataTableAnalysed;

                    //var outputPath = @"N:\Issues\High Residual\";
                    //var file = "ResSummary.GLOBAL.20161220_20170120.auto.xlsx";
                    //FileInfo newFile = new FileInfo(outputPath + file);

                    //ExportToExcel(newFile, dataTableExport, "All_Summary");
                    //ExportToExcel(newFile, dataTableAnalysed, "PFS_PAA_Analysis");
                    //var ds = new DataSet();
                    //ds.Tables.Add(dataTableExport);
                    // DataSetHelper.CreateWorkbook(outputPath + "ResSummaryAll.20161220_20170120.xlsx", ds); 


                    #endregion
                }
            }

        }


        public void ExportToExcelAsync(FileInfo file, DataTable dt, string sheetName)
        {
            //using (ExcelPackage pck = new ExcelPackage(file))
            //{
            //    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(sheetName);
            //    ws.Cells["A1"].LoadFromDataTable(dt, true);
            //    pck.Save();
            //}
            Console.WriteLine("Hello form thread '{0}', num #{1}.", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
        }

        private async void exportFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK) // Test result.
                {
                    var newFile = new FileInfo(dialog.FileName);
                    Console.WriteLine("Hello form thread '{0}', num #{1}.", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);

                    var vm = new ViewModel();
                    vm.ExportToExcelAsync(newFile, dataTableExport, "All_Summary");

                    try
                    {
                        await Task.Run(() =>
                        {
                            //var vm = new ViewModel();
                            Console.WriteLine("Hello form thread '{0}', num #{1}.", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
                            ExportToExcelAsync(newFile, dataTableExport, "All_Summary");
                            //ExportToExcelAsync(newFile, dataTableAnalysed, "PFS_PAA_Analysis");

                            //var vm = new ViewModel();
                            new ViewModel().ExportToExcelAsync(newFile, dataTableExport, "All_Summary");
                        });
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());

                    }
                }                
            }
        }
    }
}

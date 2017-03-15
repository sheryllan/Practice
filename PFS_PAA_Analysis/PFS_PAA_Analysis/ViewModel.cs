using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PfsPaaDAL;
using PFSFeed.Model;

namespace PFS_PAA_Analysis
{
    public class ViewModel
    {
        public DataTable DataTableAnalysed { get; set; }
        public PfsDataLoad Load { get; set; }
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

        public void StartDataLoad(DataTable dt)
        {
            // Initialisation
            Load = new PfsDataLoad();
            DataTableAnalysed = new DataTable();
            var analysisColumns = ReportColumnMap.NewAnalysisDtColumns();
            DataTableAnalysed.Columns.AddRange(analysisColumns);
            var summarizedRows = new List<DataRow>();
            var analysedRows = new List<DataRow>();

            // Loop through each dtRow
            var regionGroup = dt.AsEnumerable().GroupBy(r => (string)r["Region"]);
            var startingDate = dt.AsEnumerable().Min(d => (int)d["EodDate"]);
            foreach (var rg in regionGroup)
            {
                Region region;
                if (!Enum.TryParse(rg.Key, out region)) continue;
                var fxHist = Load.InitialiseFxHist(region, startingDate);

                var posGroup = rg.GroupBy(r => (int)r["PositionId"]).ToDictionary(g => g.Key, g => g);
                var extIdGroup = Load.GroupByExtId(region, posGroup.Select(p => p.Key));

                foreach(var ext in extIdGroup)
                {
                    var posEodDict = new Dictionary<int, IEnumerable<DataRow>>();
                    foreach(var pos in ext)
                    {
                        var eodDates = posGroup[pos].GroupBy(r => (int)r["EodDate"]).ToList();
                        var eodDuplicates = eodDates.Where(d => d.Count() > 1).ToList();

                        var eodInconsistent = eodDuplicates.Where(d => d.ToList()[0]["Residual"] != d.ToList()[1]["Residual"]).ToList();
                        eodInconsistent.ForEach(d => d.ToList().ForEach(n => n["Comments"] = "Inconsistent residuals"));
                        summarizedRows.AddRange(eodInconsistent.SelectMany(e => e));

                        var eodDistinct = eodDates.Where(eod => eodInconsistent.Any(d => d.Key != eod.Key)).Select(d => d.First());
                        posEodDict.Add(pos, eodDistinct);
                    }
                    // Group positions by the same eod and residual in a pfsId group
                    var eodResidualGroup =  posEodDict.GroupBy(pe => pe.Value.Select(row => new { eod = (int)row["EodDate"], res = (double)row["Residual"]}));

                    foreach (var g in eodResidualGroup)
                    {
                        var posRowDict = g.ToDictionary(kv => kv.Key, kv => kv.Value.ToDictionary(e => (int) e["EodDate"], e => e));
                        var eods = g.Key.Select(k => k.eod).ToList();

                        try
                        {
                            Load.GetOnePositionData(region: region, posId: g.First().Key, dates: eods, fxHist: fxHist);

                            foreach (var e in eods) // Loop through each day
                            {
                                Load.PopulateDateSets(e);
                                var dtRow = posRowDict[g.First().Key][e];

                                AnalyseRowData(dtRow: dtRow, dataTableAnalysed: DataTableAnalysed, eod: e, load: Load);

                                foreach (var p in g) // Loop through each position
                                {
                                    var row = posRowDict[p.Key][e];

                                    summarizedRows.Add(row);
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        
                        
                    }    

                }
            }
                
        }

        private DataRow NewAnalysedDtRow(DataRow dtRow, DataTable dataTableAnalysed)
        {
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
            return dtRowAnalysed;
        }

        private void AnalyseRowData(DataRow dtRow, DataTable dataTableAnalysed, int eod, PfsDataLoad load)
        {
            var dtRowAnalysed = NewAnalysedDtRow(dtRow, dataTableAnalysed);
            
            var t_1 = eod;
            var t_2 = Utility.DateToRover8(Utility.AddBusinessDays(Utility.Rover8ToDate(t_1), -1, null));
            var tday = new Dictionary<int, string>
                       {
                           {t_1, "T-1"},
                           {t_2, "T-2"}
                       };
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
            if (marking.Any())
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
            if (sddUcf.Any())
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
            if (sddRcf.Any())
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



        }

    }
}

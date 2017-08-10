using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TryAntlrAgain;
using Excel = Microsoft.Office.Interop.Excel;

namespace GetValuesFromColumn
{
    public class ExcelDump
    {
        public Excel.Application ExcelApp { get; }
        public Excel.Worksheet FirstTab { get; }
        public Excel.Worksheet SecondTab { get; }
        public Excel.Workbook WorkBook { get; set; }

        public ExcelDump(string filepath)
        {
            ExcelApp = new Excel.Application(); //starts Excel
            ExcelApp.Visible = true;            //visible to user            
            WorkBook = ExcelApp.Workbooks.Open(filepath, 0, false, 5, "", "", false,  //opens the file
                Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false); 
            FirstTab = (Excel.Worksheet) ExcelApp.Worksheets[1];  //set instance to first tab of the Excel file
            SecondTab = (Excel.Worksheet) ExcelApp.Worksheets[2];
        }
        public int NumberOfRows(Excel.Worksheet sheet)
        {
            int ret = sheet.Cells.Find(
                "*",
                System.Reflection.Missing.Value,
                Excel.XlFindLookIn.xlValues,
                Excel.XlLookAt.xlWhole,
                Excel.XlSearchOrder.xlByRows,
                Excel.XlSearchDirection.xlPrevious,
                false,
                System.Reflection.Missing.Value,
                System.Reflection.Missing.Value
                ).Row;

            return ret + 1; //need +1 else it will write over the previous record
        }
        public int NumberOfColumns(Excel.Worksheet sheet)
        {
            int ret = sheet.Cells.Find(
                "*",
                System.Reflection.Missing.Value,
                System.Reflection.Missing.Value,
                System.Reflection.Missing.Value,
                Excel.XlSearchOrder.xlByColumns,
                Excel.XlSearchDirection.xlPrevious,
                false,
                System.Reflection.Missing.Value,
                System.Reflection.Missing.Value
                ).Column;


            return ret + 1;
        }
        public string ConvertColumnToExcel(int n)
        {
            int dividend = n;
            string ret = string.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                ret = Convert.ToChar(65 + modulo) + ret;
                dividend = (dividend - modulo) / 26;
            }
            return ret;
        }
        public void WriteToExcel(ValuesDynamicDictionary cache, FileHeaderInfo fileHeader, List<Dictionary<string, Value>> formulas)
        {
            //1. Column headline
            Console.WriteLine(cache.Count());
            string[] rowHeadline = new string[fileHeader.ColumnsUsed.Count + formulas[0].Keys.Count];
            int maxLen = fileHeader.ColumnsUsed.Count + formulas[0].Keys.Count;
            int tabOneRowCounter = NumberOfRows(FirstTab);

            //1. a) merge the headline from raw cache and formulas cache into a single array
            int invariant = 0;
            while (invariant < maxLen)
            {
                for (int i = 0; i < fileHeader.ColumnsUsed.Count; i++)
                {
                    rowHeadline[invariant] = EQRMSRawColumns.ProcessedColumnIntAsKey[fileHeader.ColumnsUsed[i]];
                    ++invariant;
                }

                for (int i = 0; i < formulas[0].Count; i++)
                {
                    var lol = formulas.First().Keys;
                    rowHeadline[invariant] = lol.ElementAt(i);
                    ++invariant;
                }                
            }
            //1. b) write the headline
            Excel.Range h1 = FirstTab.Cells[tabOneRowCounter, 1];
            Excel.Range h2 = FirstTab.Cells[tabOneRowCounter, rowHeadline.Length];
            Excel.Range headerRange = FirstTab.get_Range(h1, h2);
            headerRange.Value2 = rowHeadline;
            tabOneRowCounter++;

            //2. a) merge two caches row at a time
            int rowsIndex = 0;          
            while (rowsIndex < cache.Count())
            {
                int columnIndex = 0;

                string[] row = new string[cache.ValuesUnbound.Count + formulas[0].Count];

                //Raw extracted data
                for (int i = 0; i < fileHeader.ColumnsUsed.Count; i++)
                {
                    row[columnIndex] = cache.GetValue(fileHeader.ColumnsUsed[i], rowsIndex).ToString();
                    ++columnIndex;
                }

                //Our re-calculated formulas using Antlr
                for (int i = 0; i < formulas[rowsIndex].Count; i++)
                {
                    row[columnIndex] = formulas[rowsIndex].Values.ElementAt(i).ToString();
                    ++columnIndex;
                }
                ++rowsIndex;

                //2b) Write the row
                Excel.Range c1 = FirstTab.Cells[tabOneRowCounter, 1];
                Excel.Range c2 = FirstTab.Cells[tabOneRowCounter, row.Length];
                Excel.Range firstTabRangeFormula = FirstTab.get_Range(c1, c2);
                firstTabRangeFormula.Value2 = row;
                ++tabOneRowCounter;       
            }
        }  
        public void WriteFormulas()
        {
            Excel.Range rng = FirstTab.Cells[1, NumberOfColumns(FirstTab)];
            Excel.Range searchRange = FirstTab.get_Range(rng);
        }
        public void SaveAndCloseExcel()
        {
            WorkBook.Save();
            WorkBook.Close(true);
        }
    }
}

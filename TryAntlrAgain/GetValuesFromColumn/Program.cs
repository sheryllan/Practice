using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using TryAntlrAgain;


namespace GetValuesFromColumn
{
    public class Program
    {
        //TO DO:
        //1) Redefine "string" in calculator to be able to accept numbers (as long as they are within quotes) i.e. "l33t"
        //2) Possibly add a queue for writing to .txt file so that reading + calculating can be parallelised and outputs place in queue
        //3) Unit test the following areas
        //      a) Formula Engine (Calculator, Expressions)
        //      b) Date Normalisation
        //      c) ValuesDynamicDictionary
        //4) Revamp ValuesDynamicDictionary to eliminate the dynamic keyword; instead maybe a wrapper around object like Value class
        //5) IsNumber(x) doesn't work as intended because NaN's are defaulted to zero in code (Antlr can't handle 1+NaN).
        //   Would need to propagate NaNs through and add handling everywhere for them in code.
        //6) =(1285.48958145409+0.150082808837906-0.150082808837906+IF(0=1,0+0,0)+0.00900720482549496)*1+-1267.80237622742 
        //PROBLEM WITH USING "e" in number
        //7) (306003.6875+11.4833679199219-11.4833679199219+if(0=1,0+0,0)+1.05500000000000e+000)*1+-305703.13
        //8) Add possibility to fetch formulas directly from DRMS, currently needIO  to manually input + layer them. The problem with this is
        //   that people miss type and spell formula names differently. Currently I just create a new formula each time
        //   but it's impractical to just keep adding the different possibilities to spell the same column name

        //File extract paremeters; location etc. 
        public static readonly string OutputExcelFilePath = @"C:\PAA\LR-639 Bucketing CF\ExcelDump.xlsx";
        public static readonly string OutputTxtFilePath = @"C:\PAA\LR-639 Bucketing CF\FORMULADUMP.";
        public static readonly string OutputTxtFileName = @"TestingNewColumnEMEA.txt";
        public static readonly string InputFilesDir = @"V:\ReportOutput\EMEA\May 2016 No hidden columns\Testing Formula Change"; //EMEA
        //public static readonly string InputFilesDir = @"V:\ReportOutput\APAC\May 2016 No hidden columns\Testing Formula Change With IntBc"; //APAC
        //public static readonly string InputFilesDir = @"V:\ReportOutput\NAM\May 2016 No hidden columns\Testing Formula Change"; //NAM
        public static readonly string InputFileNamesToBuffer = "*.txt";

        static void Main(string[] args)
        {
            string[] files = GetListOfTextFiles(InputFilesDir);

            foreach (var file in files)
            {
                //1. Read raw EQRMS .txt extracts into cache
                DataExtractor dataExtractor = new DataExtractor();
                KeyValuePair<FileHeaderInfo, ValuesDynamicDictionary> allFiles = dataExtractor.ReadSingleFileToFileCache(file);

                //2. apply formulas from values in cache into a new dictionary
                FormulaEngine formulaEngine = new FormulaEngine();
                DateTime beforeDt = DateTime.Now;
                List<Dictionary<string, Value>> manyCalculatedFormula = formulaEngine.FormulasCalculateSingleFile(allFiles.Value);
                DateTime afterDt = DateTime.Now;
                Console.WriteLine(beforeDt);
                Console.WriteLine(afterDt);
                //Console.ReadKey();

                //3 Dump formulas to TXT, there is possibility to dump straight to Excel but this is very slow in comparison
                int txtFilesIndex = 0;
                TxtDump txtDump = new TxtDump(OutputTxtFilePath);

                txtDump.WriteToTxtFile(allFiles.Value, allFiles.Key, manyCalculatedFormula);
                txtFilesIndex++;
                Console.WriteLine(manyCalculatedFormula.Count);
            }

            ////3.2 Dump formulas to Excel
            //int excelFilesIndex = 0;
            //foreach (var file in manyCalculatedFormula)
            //{
            //    ExcelDump excel = new ExcelDump(ExcelFilePath);
            //    excel.WriteToExcel(allFiles[excelFilesIndex].Value, allFiles[excelFilesIndex].Key, file);
            //    excel.SaveAndCloseExcel();
            //    excelFilesIndex++;
            //}
            //Console.WriteLine(allFiles.Count);
            //Console.WriteLine(manyCalculatedFormula.Count);

            //Parallel.ForEach(files, f =>
            //{                 //1. Read files to cache
            //    DataExtractor dataExtractor = new DataExtractor();
            //    KeyValuePair<FileHeaderInfo, ValuesDynamicDictionary> allFiles = dataExtractor.ReadSingleFileToFileCache(f);

            //    //2. apply formulas from cache into a new dictionary
            //    FormulaEngine formulaEngine = new FormulaEngine();
            //    DateTime beforeDt = DateTime.Now;
            //    List<Dictionary<string, Value>> manyCalculatedFormula = formulaEngine.FormulasCalculateSingleFile(allFiles.Value);
            //    DateTime afterDt = DateTime.Now;
            //    Console.WriteLine(beforeDt);
            //    Console.WriteLine(afterDt);
            //    //Console.ReadKey();

            //    //3.1 Dump formulas to TXT
            //    int txtFilesIndex = 0;
            //    TxtDump txtDump = new TxtDump(TxtFilePath);

            //    txtDump.WriteToTxtFile(allFiles.Value, allFiles.Key, manyCalculatedFormula);
            //    txtFilesIndex++;
            //    Console.WriteLine(manyCalculatedFormula.Count);
            //});
        }

        public static string[] GetListOfTextFiles(string filepath)
        {
            string[] ret = Directory.GetFiles(filepath, InputFileNamesToBuffer);
            return ret;
        }
        
        //EQRMS Columns(after normalisation), There are 2 options; accessing via Int key or directly the column itself (key lookups faster)
        static public string GetColumnName(int columnNumber)
        {
            string ret = EQRMSRawColumns.ProcessedColumnIntAsKey[columnNumber];
            return ret;
        }

    }
}

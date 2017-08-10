 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetValuesFromColumn
{
    public class FileHeaderInfo
    {

        private const int reportVersionIndex = 0; // example:   RiskPAASummaryBeta214.20160527.DELTA_ONE+ED_STRATEGY_OTHER_NEW 
        private const int dateIndex = 1;
        private const int accountIndex = 2;
        private const char fileNameDelimeter = '.'; // delimeter in the file name, usually always '.'

        public string FilePath { get; }     //  C:\\PAA\\Extracts\\RiskPAASummaryV2.14.txt
        public string ReportVersion { get; } // RiskPAASummaryV2.14
        public int AsOfDate { get; }        // 20160601
        public string AccountsUsed { get; } //  Delta_ONE_NEW
        public Dictionary<int, int> ColumnsUsed { get; set; }   //key = array index as of reading   value = position in my data strcuture

        public FileHeaderInfo(string filepath)
        {
            string[] split = filepath.Split(fileNameDelimeter);
            FilePath = filepath;
            ReportVersion = split[reportVersionIndex];
            int tryParseResult;
            if (int.TryParse(split[dateIndex], out tryParseResult))
                AsOfDate = tryParseResult;
            else
            {
                AsOfDate = 0;
            }
            AccountsUsed = split[accountIndex];
        }
    }
}

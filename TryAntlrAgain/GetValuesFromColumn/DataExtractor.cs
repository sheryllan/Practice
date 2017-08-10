using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetValuesFromColumn
{
    public class DataExtractor
    {
        private readonly char columnDelimeter = '\t'; // delimeter used in the file
        private readonly int numberOfRowsToSkip = 2;
        private int numberofRowsInTotal = 0; //++this while reading rows

        private readonly DateNormalisation dateNormalisation = new DateNormalisation();

        private string[] ReadFirstLineOfColumnsToStringArray(string filepath)
        {
            using (var sr = new StreamReader(filepath))
            {
                string[] ret = sr.ReadLine().Split(columnDelimeter);
                return ret;
            }
        }

        private Dictionary<int, int> FindColumnsInReport(IList<string> columns)
        {
            Dictionary<int, int> ret = new Dictionary<int, int>(); //<sr.readline[i], EQRMSColumn[i]>
            List<string> normalisedColumns = dateNormalisation.NormaliseColumns(columns); //Commission PL 24May2016 ---> Comission PL T-1

            dateNormalisation.CheckForDuplicateColumns(normalisedColumns); //need to remove duplicate column names; else the values will be added to a column twice

            for (int i = 0; i < normalisedColumns.Count(); i++)
            {
                if (EQRMSRawColumns.ProcessedColumnNameAsKey.ContainsKey(normalisedColumns[i]))
                {
                    ret.Add(i, EQRMSRawColumns.ProcessedColumnNameAsKey[normalisedColumns[i]]);
                }
                else
                {
                    throw new Exception("FindColumnsInReport(); Unable to map a column from EQRMS extract to key");
                }
            }
            return ret;
        }

        private Dictionary<int, int> ReadFirstLineOfColumnsToIntArray(string filepath)
        {
            string[] columns = ReadFirstLineOfColumnsToStringArray(filepath); //need to get the raw column names
            Dictionary<int, int> ret = FindColumnsInReport(columns); //normalised columns
            return ret;
        }

        public KeyValuePair<FileHeaderInfo, ValuesDynamicDictionary> ReadSingleFileToFileCache(string filepath)
        {
            FileHeaderInfo fileheaderinfo = new FileHeaderInfo(filepath); //file meta data
            fileheaderinfo.ColumnsUsed = ReadFirstLineOfColumnsToIntArray(filepath); //what particular columns are in that EQRMS extract

            //2. Read the contents of the file into cache
            //	 a) There are two invariants for the same loop
            //	    i) 				The indexer to keep track of where we are in the string[] from reading a line in the file
            //		columnNumber)	The current column we are upto as per the corresponding key(e.g. col #215) for the column's value we are populating
            ValuesDynamicDictionary values = new ValuesDynamicDictionary();
            using (var sr = new StreamReader(filepath))
            {
                for (int i = 0; i < numberOfRowsToSkip; i++) { sr.ReadLine(); } //skip the first x lines which contain column names and other useless info

                while (!sr.EndOfStream)
                {
                    string[] readLine = sr.ReadLine().Split(columnDelimeter); //get 1 row
                    numberofRowsInTotal++;
                    foreach (var columnsIndexes in fileheaderinfo.ColumnsUsed)
                    {
                        values.Add(columnsIndexes.Value, readLine[columnsIndexes.Key]);
                    }
                }
            }

            KeyValuePair<FileHeaderInfo, ValuesDynamicDictionary> ret = new KeyValuePair<FileHeaderInfo, ValuesDynamicDictionary>(fileheaderinfo, values);
            return ret;
        }

        public List<KeyValuePair<FileHeaderInfo, ValuesDynamicDictionary>> ReadBatchOfFilesToFilesCache(IList<string> filepaths)
        // try to keep one method doing one thing; split this down into two 1) to read everthing; call function 2) return array
        {
            List<KeyValuePair<FileHeaderInfo, ValuesDynamicDictionary>> ret = new List<KeyValuePair<FileHeaderInfo, ValuesDynamicDictionary>>();

            foreach (var filepath in filepaths)
            {
                ret.Add(ReadSingleFileToFileCache(filepath));
            }
            return ret;
        }
    }
}

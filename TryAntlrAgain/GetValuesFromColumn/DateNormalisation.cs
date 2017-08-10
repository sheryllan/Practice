using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GetValuesFromColumn
{
    public class DateNormalisation
    {
        private readonly Regex findWholeDateRegEx = new Regex("\\d{1,2}[A-Za-z]+[0-9][0-9][0-9][0-9]"); //format of dates is; 26May2016 1May2016 9May2016
        private const string TOne = "T-1";
        private const string TTwo = "T-2";

        //1. From the column headline; find both the smallest and largest date
        //2. Iterate through column headline and match to EQRMS column name (Dictionary<int, string>)
        //3. Return List<int> of columns

        public int DateToRover8(DateTime dt) { return dt.Year * 10000 + dt.Month * 100 + dt.Day; }

        public int FindAndConvertDateToInt(string column)
        {
            string fullDate = findWholeDateRegEx.Match(column).ToString();
            fullDate = Regex.Replace(fullDate, "\\b(\\d)([a-zA-Z]+)(\\d{4})", 0 + fullDate);
            if (fullDate == "") { return 0; } //does this column even have a date

            DateTime parsedToDateTime = DateTime.Parse(fullDate);
            int ret = DateToRover8(parsedToDateTime);

            return ret;
        }

        public string FindTheLargestDateValue(ref IList<string> columnHeadLine)
        {
            string ret = null;
            int dateToNumber = 0;

            foreach (string column in columnHeadLine)
            {
                if (dateToNumber < Math.Max(dateToNumber, FindAndConvertDateToInt(column)))
                {
                    ret = findWholeDateRegEx.Match(column).ToString();
                    dateToNumber = FindAndConvertDateToInt(column);
                }
            }
            if (ret == null)
            {
                ret = "No dated column found in FindTheLargestDateValue";
            }

            return ret;
        }

        public string FindTheSmallestDateValue(ref IList<string> columnHeadLine)
        {
            string ret = null;
            int dateToNumber = 99999999;

            foreach (string column in columnHeadLine)
            {
                if (FindAndConvertDateToInt(column) != 0 && dateToNumber > Math.Min(dateToNumber, FindAndConvertDateToInt(column)))
                {
                    ret = findWholeDateRegEx.Match(column).ToString();
                    dateToNumber = FindAndConvertDateToInt(column);

                }
            }

            if (ret == null)
            {
                ret = "No dated column found in FindTheSmallestDateValue";
            }

            return ret;
        }

        public List<string> NormaliseColumns(IList<string> columnHeadLine)
        {
            string largestDate = FindTheLargestDateValue(ref columnHeadLine);
            string smallestDate = FindTheSmallestDateValue(ref columnHeadLine);

            List<string> ret = new List<string>();
            foreach (string column in columnHeadLine)
            {
                if (column.Contains(largestDate))
                {
                    ret.Add(Regex.Replace(column, findWholeDateRegEx.ToString(), TOne));
                }
                else if (column.Contains(smallestDate))
                {
                    ret.Add(Regex.Replace(column, findWholeDateRegEx.ToString(), TTwo));
                }
                else
                {
                    ret.Add(column);
                }
            }
            return ret;
        }

        public void CheckForDuplicateColumns(IList<string> columns)
        {
            if (columns == null || columns.Count == 0) { return; }

            for (int outerIndex = 0; outerIndex < columns.Count; outerIndex++)
            {
                for (int innerIndex = 0; innerIndex < columns.Count; innerIndex++)
                {
                    if (innerIndex == outerIndex) continue;
                    if (columns[outerIndex].Equals(columns[innerIndex]) && !columns[outerIndex].Equals("DuplicateColumnDump"))
                    {
                        columns[outerIndex] = "DuplicateColumnDump";
                    }
                }
            }
        }
    }
}

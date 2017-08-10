using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetValuesFromColumn
{
    public class TxtDump
    {
        public string FilePath { get; }

        public TxtDump(string filepath)
        {
            FilePath = filepath;
        }

        public void WriteToTxtFile(ValuesDynamicDictionary cache, FileHeaderInfo fileHeader, List<Dictionary<string, Value>> formulas)
        {
            string completePath = FilePath + Program.OutputTxtFileName;

            string[] rowHeadline = new string[fileHeader.ColumnsUsed.Count + formulas[0].Keys.Count + 1];

            //1. a) merge the headline from raw cache and formulas cache into a single array
            int invariant = 0;
            while (invariant < fileHeader.ColumnsUsed.Count + formulas[0].Keys.Count)
            {

                rowHeadline[invariant] = "AsOfDate";
                invariant++;

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
            File.AppendAllText(completePath, string.Join("\t", rowHeadline) + "\n");

            int rowsIndex = 0;
            while (rowsIndex < cache.Count())
            {
                int columnIndex = 0;
                string[] row = new string[cache.ValuesUnbound.Count + formulas[0].Count + 1];
                row[columnIndex] = fileHeader.AsOfDate.ToString();
                columnIndex++;

                for (int i = 0; i < fileHeader.ColumnsUsed.Count; i++)
                {
                    row[columnIndex] = cache.GetValue(fileHeader.ColumnsUsed[i], rowsIndex).ToString();
                    ++columnIndex;
                }

                for (int i = 0; i < formulas[rowsIndex].Count; i++)
                {
                    row[columnIndex] = formulas[rowsIndex].Values.ElementAt(i).ToString();
                    ++columnIndex;
                }
                ++rowsIndex;

                File.AppendAllText(completePath, string.Join("\t", row) + "\n");
                //File.AppendText(FilePath).WriteLine(string.Join("\t", row));
            }
        }
    }
}

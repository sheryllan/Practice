using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
//using PFSFeed;
//using EQTG.Database;
using ResidualAnalysis;
using Microsoft.Office.Interop.Excel;
using System.Data.Odbc;
using System.Text.RegularExpressions;

namespace RiskPAA_EQRMS_Net
{
    class Program
    {
        enum Regions { EMEA, NAM, APAC };

        static readonly Dictionary<string, string> ConnStrDic = new Dictionary<string, string>()
        {
            { "EMEA" , "Driver={Adaptive Server Enterprise};server=eqrmsdb1d.eur.nsroot.net;port=4800;db=DRMS;uid=eqjobs;pwd=jobs99"},
            { "NAM" ,  "Driver={Adaptive Server Enterprise};server=nyeqrmsproddb.nam.nsroot.net;port=4096;db=DRMS;uid=cl31006;pwd=Jobs33king"},
            { "APAC" , "Driver={Adaptive Server Enterprise};server=hkdrmsprod.ap.ssmb.com;port=1024;db=DRMS;uid=cl31006;pwd=Jobs33king"}
        };

        static readonly Dictionary<int, string> SecTypeDic = new Dictionary<int, string>()
        {
            {5 , "Convertible Bonds" },
            {6 , "Futures" }
        };

        //static List<int> FilterPositionsOnCBFut(DBConnectionDetails conn, List<int> posIds, int eod)
        //{
        //    var query = string.Format(@"select ");
        //}

        //Could add encoding in the declaration of StreamReader

        static void WriteToFile(string file, List<ReportColumns> data)
        {
            if (data == null || data.Count == 0)
                return;
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                //var lineBldr = new StringBuilder();
                foreach (var row in data)
                {
                    var newLine = row.GetAllValues();
                    var len = newLine.Length;
                    var lineReordered = new string[len];
                    Array.Copy(newLine, len - 4, lineReordered, 0, 4);
                    Array.Copy(newLine, 0, lineReordered, 4, len - 4);
                    //lineBldr.Append(string.Join(",", lineReordered));
                    //csv.AppendLine(string.Join(",", lineReordered));
                    writer.WriteLine(string.Join(",", lineReordered));
                }
            }
        }


        static void Main(string[] args)
        {
            var directoryName = @"\\eqtrmseuapdv53.eur.nsroot.net\RiskPAA\ReportOutput";
            //var directoryName = @"C:\Users\sc93445\Documents\RiskPAA\High Residual\20161122";

            var folders = Directory.GetDirectories(directoryName);


            Console.WriteLine(@"Enter the mode numbers: 1.PFS Report(default)  2.CB/Fut Report  3.PFS Summary  4.CB/Fut Summary, combining multiple with '+'");
            var mode = Console.ReadLine().Split(new[] { '+', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int m = 0; mode.Length == 0 || m < mode.Length; m++)
            {                
                if (mode.Length == 0 || !Regex.IsMatch(mode[m], @"[1-4]+"))
                {                    
                    Console.WriteLine("Invalid mode number. Please enter again: ");
                    mode = Console.ReadLine().Split(new[] { '+', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    m = -1;
                }
            }     
            

            Console.WriteLine("Enter from date (yyyyMMdd): ");
            var fromDate = DateTime.ParseExact(Console.ReadLine(), "yyyyMMdd", CultureInfo.InvariantCulture,
                                    DateTimeStyles.None);

            Console.WriteLine("Enter to date (yyyyMMdd): ");
            var toDate = DateTime.ParseExact(Console.ReadLine(), "yyyyMMdd", CultureInfo.InvariantCulture,
                                    DateTimeStyles.None);

            Console.WriteLine("Enter the region: 1.EMEA  2.NAM  3.APAC  4.All");
            var regions = Console.ReadLine().Split(new[] { '+', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var reportChunk = new List<ReportColumns>();

            var outputDir = @"N:\Issues\High Residual\";

            var query = @"select pd.posId, fi.id, fi.secType, der.undId, und.secType as undSecType from ETSfinancialInstrument fi 
                        join positionDescription pd on pd.secId = fi.id 
                        join ETSderivative der on der.derId = fi.id 
                        join(select id, secType from ETSfinancialInstrument)und on und.id = der.undId 
                        where und.secType in (5, 6) 
                        and pd.posId in ({0})";

            //Application oXL = new Application();
            //oXL.Visible = true;

            //_Workbook oWB = oXL.work
            //_Worksheet oSheet;
            //Range oRng;


            if((new List<string>(mode)).Any(m => string.Equals(m, "1")))
            {
                
            }

            foreach (var folder in folders)
            {
                var region = (Enum.GetNames(typeof(Regions))).ToList().Find(r => folder.Contains(r));
                var headerDic = ReportColumns.DicRegionCol[region];

                var distinctPos = new Dictionary<int, ReportColumns>();

                if (region == null)
                    continue;

                // Write to a csv file for a region
                var outputFile = outputDir + "ResSummary." + region + "." + fromDate.ToString("yyyyMMdd") + "_" + toDate.ToString("yyyyMMdd") + ".csv";
                var outputFile2 = outputDir + "CBFutResSummary." + region + "." + fromDate.ToString("yyyyMMdd") + "_" + toDate.ToString("yyyyMMdd") + ".csv";
                //var csv = new StringBuilder();
                var headers = new StringBuilder();
                for (int i = 1; i <= headerDic.Count; i++)
                {
                    var extraCols = 5;
                    var header = i < extraCols ? (headerDic[headerDic.Count - extraCols + i] + ",") : (headerDic[i - extraCols] + ",");
                    headers.Append(header);
                }
                //csv.AppendLine(headers.ToString());
                using (StreamWriter csv = new StreamWriter(outputFile))
                {
                    csv.WriteLine(headers);
                }                
                
                // Loop through every eod file form that region
                for (var date = fromDate; date <= toDate; date = date.AddDays(1))
                {
                    string fileSubstring = date.ToString("yyyyMMdd") + ".txt";

                    var files = Directory.GetFiles(folder);

                    foreach (string fileName in files)
                    {
                        if (!fileName.Contains(fileSubstring) || !fileName.Contains("RiskPAASummary"))
                            continue;

                        Console.WriteLine(fileName);

                        var fileMetaData = fileName.Split('.');
                        string positionNode = @"/" + fileMetaData[fileMetaData.Length - 3];
                        string eodDate = fileMetaData[fileMetaData.Length - 2];

                        using (FileStream fStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (var reader = new StreamReader(fStream))
                            {                                
                                int i = 0;
                                int pfsFilter = 0;
                                int residualFilter = 0;
                                int percentageResFilter = 0;

                                try
                                {
                                    while (!reader.EndOfStream)
                                    {
                                        var line = reader.ReadLine();
                                        var values = line.Split('\t');
                                        i++;                                                                             

                                        if (i == 1)
                                        {
                                            //columns.DicIndexName = columns.MapColumnIndex2Name(values);
                                            //columns.DicIndexName.Add(values.Length, "Region");
                                            //columns.DicIndexName.Add(values.Length + 1, "PositionNode");
                                            //columns.DicIndexName.Add(values.Length + 2, "EodDate");
                                            //columns.DicNameIndex = columns.MapColumnName2Index(columns.DicIndexName);

                                            // filter for PFS swaps
                                            pfsFilter = (values.ToList()).FindIndex(v => string.Equals(v, "Security Type"));
                                            residualFilter = (values.ToList()).FindIndex(v => string.Equals(v, "Residual"));
                                            percentageResFilter = (values.ToList()).FindIndex(v => string.Equals(v, "%Residual"));
                                                                                        
                                            if (pfsFilter == -1)
                                            {
                                                Console.WriteLine("column [Security Type] not found.");
                                                continue;
                                            }

                                            if (residualFilter == -1)
                                            {
                                                Console.WriteLine("column [Residual] not found.");
                                                continue;
                                            }

                                            if (percentageResFilter == -1)
                                            {
                                                Console.WriteLine("column [% Residual] not found.");
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            if (string.IsNullOrEmpty(values[0]))
                                                continue;

                                            if ((!string.Equals(values[pfsFilter], "Portfolio")) && (!string.Equals(values[pfsFilter], "ExternalSecurity")))
                                                continue;

                                            double res, pRes;
                                            if ((!Double.TryParse(values[residualFilter], out res)) || (!Double.TryParse(values[percentageResFilter], out pRes)) ||
                                                (Math.Abs(res) <= 10000) || (pRes <= 10))
                                                continue;
                                            
                                            // Set values for columns 
                                            var columns = new ReportColumns();
                                            columns.Row = i;
                                            columns.Region = region;
                                            columns.PositionNode = positionNode;
                                            columns.EodDate = eodDate;
                                            for (int c = 0; c < values.Length; c++)
                                            {
                                                // Format exception handled inside TrySetValueByName when parsing the string
                                                if (!columns.TrySetValueByName(headerDic[c], values[c]))
                                                    Console.WriteLine("Could not set the value for column {0}", headerDic[c]);
                                            }

                                            reportChunk.Add(columns);
                                            if (!distinctPos.ContainsKey(columns.PositionId))
                                                distinctPos.Add(columns.PositionId, columns);
                                        }                                    
                                       
                                    }
                                }
                                catch (Exception e)// Catch any other exceptions when reading
                                {
                                    Console.WriteLine(e.Message);
                                }
                            }
                        }

                        if (reportChunk.Count >= 10000)
                        {
                            WriteToFile(outputFile, reportChunk);
                            reportChunk.Clear();
                        }

                    }

                }

                WriteToFile(outputFile, reportChunk);
                reportChunk.Clear();

                // Connect to DB to filter for PFS swaps on CB/Future
                
                List<int> posIdsCBFut = new List<int>();
                var posIds = new List<int>(distinctPos.Keys);
                var posIdsStr = string.Join<int>(",", posIds);             

                using (OdbcConnection conn = new OdbcConnection(ConnStrDic[region]))
                {
                    try
                    {
                        conn.Open();
                        OdbcCommand command = conn.CreateCommand();
                        command.CommandText = string.Format(query, posIdsStr);

                        OdbcDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            var p = reader.GetInt32(reader.GetOrdinal("posId"));
                            posIdsCBFut.Add(p);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }                                                                                           
                                                                               
                }
                     
                var report = new List<ReportColumns>(distinctPos.Values);                
                var reportCBFut = new List<ReportColumns>(posIdsCBFut.Select(id => distinctPos[id]));

                WriteToFile(outputFile2, reportCBFut);
            }
        }
    }

}
                                                                                                                                                                                                                                                                                                                                                                                                     
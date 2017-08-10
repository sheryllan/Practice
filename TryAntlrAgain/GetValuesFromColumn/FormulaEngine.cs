using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using TryAntlrAgain;

namespace GetValuesFromColumn
{
    public class FormulaEngine
    {
        public Value CalculateFormula(string formula)
        {
            AntlrInputStream input = new AntlrInputStream(formula); //2. parse is to AntlrIS            
            calculatorLexer lexer = new calculatorLexer(input); //3. lexer created from AntlrIS
            CommonTokenStream tokens = new CommonTokenStream(lexer); //4. want to save tokens from the lexer
            calculatorParser parser = new calculatorParser(tokens); //5. feed these tokens from lexer when creating the parser
            IParseTree tree = parser.block();                      //6. run parser using parser.prog() and save output in IParseTree
            //Console.WriteLine(tree.ToStringTree(parser));           //7. 
            CalcVisitor visitor = new CalcVisitor();                //8. CalcVisitor will do the evaluations         
            Value ret = visitor.Visit(tree.GetChild(0));
            //Console.WriteLine(ret);             //z. CalcVisitor performs the actual evaluations + then write output
            return ret;
        }

        private MatchCollection ExtractFormulaNames(string formula)
        {
            Regex column = new Regex("\"[^\"]+\"");
            MatchCollection ret = column.Matches(formula);
            return ret;
        }

        private Dictionary<string, Value> FormulasCalculateOneRow(int row, ValuesDynamicDictionary rawcache)
        {
            Dictionary<string, Value> ret = new Dictionary<string, Value>();
            List<string> noneMatches = new List<string>();

            EQRMSFormulaLayers formulasLayered = new EQRMSFormulaLayers();

            foreach (var layer in formulasLayered.FormulasLayered)
            {
                foreach (var kvp in layer)
                {
                    //0. Extract the formula into array....  Fair Economic (DTDS T-1) <USD> - Total PAA
                    string after = kvp.Value;
                    MatchCollection formulas = ExtractFormulaNames(kvp.Value);

                    //1. Replace column names with values...   150000 - 150000
                    foreach (Match match in formulas)
                    {
                        string str = match.ToString().Substring(1, match.Length - 2); //remove quotes

                        //1. a) Did we recalculate this formula already? If so use that
                        if (ret.ContainsKey(str))
                        {
                            string value = ret[str].ToString();
                            if (value == "") { value = "0.000000001337"; } //Empty cells confuse Antlr,
                            after = after.Replace(match.ToString(), value);
                        }
                        //1. b) If we didn't, then fetch the value from the raw cache instead (value in report extract)
                        else if (EQRMSRawColumns.ProcessedColumnNameAsKey.ContainsKey(str))
                        {
                            string value = rawcache.GetValue(EQRMSRawColumns.ProcessedColumnNameAsKey[str], row).ToString();
                            if (value == "") { value = "0.000000001337"; }
                            after = after.Replace(match.ToString(), value);
                        }
                        //1. c) Couldn't find as a column anywhere? Store this column, these could be "PFS" or "ExternalSecurity" etc. but cache them encase to aid debugging
                        else
                        {
                            noneMatches.Add(str);
                        }
                    }
                    //2. Now pass the valuefied formula to Antlr
                    Value result = CalculateFormula(after);
                    //3. Store result in a new cache, so that we can retain both the original + recalculated values for comparison
                    ret.Add(kvp.Key, result);
                }
            }
            return ret;
        }

        public List<Dictionary<string, Value>> FormulasCalculateSingleFile(ValuesDynamicDictionary cache)
        {
            List<Dictionary<string, Value>> ret = new List<Dictionary<string, Value>>();

            //Parallel.ForEach(cache.ValuesUnbound, e =>
            //{
            //    ret.Add(FormulasCalculateOneRow(i, cache));
            //});

            for (int i = 0; i < cache.Count(); i++)
            {
                ret.Add(FormulasCalculateOneRow(i, cache));
            }
            return ret;
        }

        public List<List<Dictionary<string, Value>>> FormulasCalculateManyFiles(List<KeyValuePair<FileHeaderInfo, ValuesDynamicDictionary>> files)
        {
            return files.Select(file => FormulasCalculateSingleFile(file.Value)).ToList();
        }



        //Obsolete parallelisation

        //static public Dictionary<string, Value> FormulasCalculateOneRow(int row, ValuesDynamicDictionary cache)
        //{
        //    //Parallel.ForEach(EQRMSFormulas, pair =>
        //    //{
        //    //    string before = pair.Value; //before
        //    //    string after = before; //after
        //    //    Regex column = new Regex("\"[^\"]+\"");
        //    //    MatchCollection test = column.Matches(before); //array purely of matched columns

        //    //    foreach (Match match in test) //replace "columns" with values
        //    //        {
        //    //        string str = match.ToString().Substring(1, match.Length - 2); //remove quotes
        //    //            if (str == "Upsize / Downsize")
        //    //        {
        //    //            Console.WriteLine(str);
        //    //        }
        //    //            if (ProcessedColumnNameAsKey.ContainsKey(str))
        //    //            {
        //    //                string emptyCheck = cache.GetValue(ProcessedColumnNameAsKey[str], row).ToString();
        //    //                if (emptyCheck == "")
        //    //                {
        //    //                    emptyCheck = "EMPTYCELL"; //empty cells confuse antlr
        //    //                }
        //    //                Console.WriteLine(str + " " + emptyCheck);
        //    //                after = after.Replace(match.ToString(), emptyCheck);
        //    //            }
        //    //            else continue;
        //    //        }
        //    //    Value result = CalculateFormula(after);
        //    //    ret.Add(pair.Key, result);
        //    //    Console.WriteLine(after);
        //    //});
        //    //return ret;
        //    //}
    }
}

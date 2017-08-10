using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;

namespace TryAntlrAgain
{
    public class Program
    {
        static void Main(string[] args)
        {
            StreamReader inputStream = new StreamReader(Console.OpenStandardInput()); //1. type in our expressions
            AntlrInputStream input = new AntlrInputStream(inputStream.ReadLine()); //2. parse is to AntlrIS
            calculatorLexer lexer = new calculatorLexer(input); //3. lexer created from AntlrIS
            CommonTokenStream tokens = new CommonTokenStream(lexer); //4. want to save tokens from the lexer
            calculatorParser parser = new calculatorParser(tokens); //5. feed these tokens from lexer when creating the parser
            IParseTree tree = parser.block();                   //6. run parser using parser.prog() and save output in IParseTree
            //Console.WriteLine(tree.ToStringTree(parser));           //7. 
            CalcVisitor visitor = new CalcVisitor();                //8. CalcVisitor will do the evaluations
            //Console.WriteLine("Tree: " + visitor.Visit(tree.GetChild(0)));             //z. CalcVisitor performs the actual evaluations + then write output
            //dont dropout before i can see return
            Console.ReadKey();
        }

        //public StreamWriter CalculateStuff(StreamReader istream)
        //{
        //    AntlrInputStream input = new AntlrInputStream(istream.ReadToEnd()); //2. parse is to AntlrIS
        //    calculatorLexer lexer = new calculatorLexer(input); //3. lexer created from AntlrIS
        //    CommonTokenStream tokens = new CommonTokenStream(lexer); //4. want to save tokens from the lexer
        //    calculatorParser parser = new calculatorParser(tokens); //5. feed these tokens from lexer when creating the parser
        //    IParseTree tree = parser.prog();                      //6. run parser using parser.prog() and save output in IParseTree
        //    Console.WriteLine(tree.ToStringTree(parser));           //7. 
        //    CalcVisitor visitor = new CalcVisitor();                //8. CalcVisitor will do the evaluations

        //    StreamWriter ostream = new StreamWriter(visitor.Visit(tree));

        //    Console.WriteLine(visitor.Visit(tree));             //z. CalcVisitor performs the actual evaluations + then write output

        //    return ostream;
        //}
        
    }
}

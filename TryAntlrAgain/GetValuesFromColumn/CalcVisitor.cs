using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GetValuesFromColumn;

namespace TryAntlrAgain
{
    public class CalcVisitor : calculatorBaseVisitor<Value>
    {
        //doubles comparator
        public readonly double epsilon = 0.0000000001; 

        //ATOM overrides
        public override Value VisitBooleanAtom(calculatorParser.BooleanAtomContext context)
        {
            string ret = context.GetText();

            switch (ret)
            {
                case "TRUE":
                case "true":
                case "T":
                case "t":
                case "YES":
                case "yes":
                case "Y":
                case "y":
                    return new Value(true);
                case "FALSE":
                case "false":
                case "F":
                case "f":
                case "NO":
                case "no":
                case "N":
                case "n":
                    return new Value(false);
                default:
                    throw new Exception("Entered boolean evaluator but cannot match expression to correlating case");
            }
        }

        public override Value VisitStringAtom(calculatorParser.StringAtomContext context)
        {
            string before = context.GetText();
            //need to remove the quotes
            string after = before.Replace("\"", "");
            return new Value(after.ToString());
        }

        public override Value VisitNumberAtom(calculatorParser.NumberAtomContext context)
        {
            return new Value(double.Parse(context.GetText()));
        }

        public override Value VisitDivZeroAtom(calculatorParser.DivZeroAtomContext context)
        {
            //Will need to think of a better way to handle this case; a string populating cell intended to be double
            return new Value(0.00000001);
        }

        //CALCULATOR EXPR
        public override Value VisitUnaryMinusExpr(calculatorParser.UnaryMinusExprContext context)
        {
            Value ret = Visit(context.atom());
            return new Value(-ret.asDouble());
        }

        public override Value VisitAddSubExpr(calculatorParser.AddSubExprContext context)
        {
            Value left = Visit(context.expr(0));
            Value right = Visit(context.expr(1));

            if (context.op.Type == calculatorParser.ADD)
            {
                double result;
                if (double.TryParse(left.ToString(), out result) && double.TryParse(right.ToString(), out result))
                {
                    return new Value(left.asDouble() + right.asDouble());
                }
                else
                    return new Value(left.ToString() + right.ToString());
            }
            else if (context.op.Type == calculatorParser.SUB)
            {
                return new Value(left.asDouble() - right.asDouble());
            }
            else throw new Exception("Cannot determine +- " + left + " " + right);
        }

        public override Value VisitMulDivExpr(calculatorParser.MulDivExprContext context)
        {
            Value left = Visit(context.expr(0));
            Value right = Visit(context.expr(1));
            if (context.op.Type == calculatorParser.MUL)
            {
                return new Value(left.asDouble() * right.asDouble());
            }
            else if (context.op.Type == calculatorParser.DIV)
            {
                return new Value(left.asDouble() / right.asDouble());
            }
            else throw new Exception("Cannot determine */ " + left + " " + right);
        }

        public override Value VisitRelationalExpr(calculatorParser.RelationalExprContext context)
        {
            Value left = Visit(context.expr(0));
            Value right = Visit(context.expr(1));
            if (context.op.Type == calculatorParser.LT)
            {
                return new Value(left.asDouble() < right.asDouble());
            }
            else if (context.op.Type == calculatorParser.LTEQ)
            {
                return new Value(left.asDouble() <= right.asDouble());
            }
            else if (context.op.Type == calculatorParser.GT)
            {
                return new Value(left.asDouble() > right.asDouble());
            }
            else if (context.op.Type == calculatorParser.GTEQ)
            {
                return new Value(left.asDouble() >= right.asDouble());
            }
            else throw new Exception("Cannot determine >=<= " + left + " " + right);
        }

        public override Value VisitEqualityExpr(calculatorParser.EqualityExprContext context)
        {
            Value left = Visit(context.expr(0));
            Value right = Visit(context.expr(1));
            if (context.op.Type == calculatorParser.EQ)
            {
                if (left.isDouble() && right.isDouble())
                {
                    bool result = Math.Abs(left.asDouble() - right.asDouble()) < epsilon;
                    return new Value(result);
                }
                else
                {
                    bool result = left.Equals(right);
                    return new Value(result);
                }
            }
            else if (context.op.Type == calculatorParser.NEQ)
            {
                if (left.isDouble() && right.isDouble())
                {
                    bool result = Math.Abs(left.asDouble() - right.asDouble()) >= epsilon;
                    return new Value(result);
                }
                else
                {
                    bool result = left.Equals(right);
                    return new Value(result);
                }
            }
            else throw new Exception("Could not resolve equality expressions:" + left.ToString() + " " + right.ToString());
        }

        public override Value VisitParExpr(calculatorParser.ParExprContext context)
        {
            return Visit(context.expr());
        }

        //STATEMENTS
        public override Value VisitAnd_stat(calculatorParser.And_statContext context)
        {
            IReadOnlyList<calculatorParser.Condition_blockContext> conditions = context.condition_block();
            Value evaluateFinal = Visit(context.expr());
            bool result = evaluateFinal.asBoolean();

            foreach (var condition in conditions)
            {
                Value evaluateBody = Visit(condition.expr());
                //if (evaluateBody.asBoolean() == true || evaluateFinal.asBoolean() == true) continue;
                if (!evaluateBody.asBoolean() || !result)
                {
                    result = false;
                    break;
                }
            }
            return new Value(result);
        }

        public override Value VisitOr_stat(calculatorParser.Or_statContext context)
        {
            IReadOnlyList<calculatorParser.Condition_blockContext> conditions = context.condition_block();
            Value evaluateFinal = Visit(context.rightstat_block().expr());
            bool result = false;

            foreach (var condition in conditions)
            {
                Value evaluateBody = Visit(condition.expr());
                //if (evaluateBody.asBoolean() == false) continue;
                if (evaluateBody.asBoolean() == true || evaluateFinal.asBoolean() == true)
                {
                    result = true;
                    break;
                }

            }
            return new Value(result);
        }

        public override Value VisitIf_stat(calculatorParser.If_statContext context)
        {
            Value evaluated = this.Visit(context.condition_block().expr());

            if (evaluated.asBoolean() == true)
            {
                return new Value(Visit(context.leftstat_block()));

            }
            else if (evaluated.asBoolean() == false)
            {
                return new Value(Visit(context.rightstat_block().expr()));
            }

            return new Value(false);
        }

        public override Value VisitIs_error(calculatorParser.Is_errorContext context)
        {
            Value ret = Visit(context.expr());
            if (ret.isDouble())
            {
                return new Value(false); //value is double and so not an error
            }
            else
            {
                return new Value(true); //value is 
            }
        }

        public override Value VisitIs_number(calculatorParser.Is_numberContext context)
        {
            Value ret = Visit(context.expr());
            if (ret.isDouble()) { return new Value(true); }
            else return new Value(false);
        }

        public override Value VisitIs_eqisnan(calculatorParser.Is_eqisnanContext context)
        {
            Value ret = Visit(context.expr());
            if (ret.isDouble())
            {
                if (double.IsNaN(ret.asDouble())) { return new Value(true); }
                if (double.IsInfinity(ret.asDouble())) { return new Value(true); }
            }
            return new Value(false);

        }

        public override Value VisitIs_not(calculatorParser.Is_notContext context)
        {
            Value ret = Visit(context.expr());
            if (ret.asBoolean() == true) { return new Value(false); }
            if (ret.asBoolean() == false) { return new Value(true); }
            return new Value(-1);
        }

        public override Value VisitAbs_stat(calculatorParser.Abs_statContext context)
        {
            Value ret = Visit(context.expr());
            if (ret.isDouble()) { return new Value(Math.Abs(ret.asDouble()));}
            else throw new Exception("ABS(not an int or double)");      
        }

        public override Value VisitInt_stat(calculatorParser.Int_statContext context)
        {
            Value value = Visit(context.expr());
            int ret;
            if (value.isDouble())
            {
                ret = (int) Math.Truncate(value.asDouble()); 
                return new Value(ret);
            }
            else throw new Exception("INT(not a number)");                  
        }
    }
}


//http://www.thestuffweuse.com/2016/05/07/antlr4-with-c-in-visual-studio-2015/
//https://programming-pages.com/2013/12/14/antlr-4-with-c-and-visual-studio-2012/
//http://stackoverflow.com/questions/15610183/if-else-statements-in-antlr-using-listeners
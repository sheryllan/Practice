using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetValuesFromColumn;
using NUnit.Framework;

namespace NUnitTests
{
    [TestFixture]
    public class StatementsTests
    {
        FormulaEngine fe = new FormulaEngine();

        [Test]
        public void IfStatNum()
        {
            Value result = fe.CalculateFormula("if(1=1,10,-1337)");
            Assert.That(result.asDouble(), Is.EqualTo(10));
        }
        [Test]
        public void IfStatString()
        {
            Value result = fe.CalculateFormula("if(\"Portfolio\"=\"Portfolio\",TRUE,FALSE)");
            Assert.That(result.ToString(), Is.EqualTo("TRUE"));
        }
        [Test]
        public void AndStatTrue()
        {
            Value result = fe.CalculateFormula("and(10=10,\"Portfolio\"=\"Portfolio\",1337.7=1337.7,1=1)");
            Assert.That(result.asBoolean, Is.True);
        }
        [Test]
        public void AndStatFalse()
        {
            //Testing final statement (evaluated seperately to the body)
            Value result = fe.CalculateFormula("and(10=10,\"Portfolio\"=\"Portfolio\",1=1,1337.7=1337.8)"); //Testing final statement (evaluated seperately to the body)
            Assert.That(result.asBoolean, Is.False);
        }
        [Test]
        public void AndStatFalseBody()
        {
            Value result = fe.CalculateFormula("and(10=100,\"Portfolio\"=\"Portfolioo\",1337.7=1337.7,1=1)"); //Testing body statements
            Assert.That(result.asBoolean, Is.False);
        }
        [Test]
        public void OrStatTrue()
        {
            Value result = fe.CalculateFormula("or(10=100,\"Portfolio\"=\"Portfolioo\",1337.7=1337.8,1=1)"); //Testing final statement (evaluated seperately to the body)
            Assert.That(result.asBoolean, Is.True);
        }
        [Test]
        public void OrStatTrueBody()
        {
            Value result = fe.CalculateFormula("or(10=100,\"Portfolio\"=\"Portfolio\",1337.7=1337.8,1=1.1)"); //Testing body statements
            Assert.That(result.asBoolean, Is.True);
        }
        [Test]
        public void OrStatFalse()
        {
            Value result = fe.CalculateFormula("or(10=100,\"Portfolio\"=\"Portfoliooo\",1337.7=1337.8,1=1.1)"); //All statements
            Assert.That(result.asBoolean, Is.False);
        }
        [Test]
        public void ComplexStatementsWithinStatements()
        {
            Value result = fe.CalculateFormula("if(and(or(10=10,\"Portfolio\"=\"Portfoliooo\",1=1.1),\"Portfolio\"=\"Portfolio\",10=10,1.1=1.1),2337.1337-1000,\"WRONG ANSWER!\")");
            Assert.That(result.asDouble(), Is.EqualTo(1337.1337));
        }
        [Test]
        public void EqualityTrue()
        {
            Value result = fe.CalculateFormula("1337.1337=1337.1337");
            Assert.That(result.asBoolean(), Is.True);
        }
        [Test]
        public void EqualityFalse()
        {
            Value result = fe.CalculateFormula("1337=1337.1337");
            Assert.That(result.asBoolean(), Is.False);
        }
        [Test]
        public void NotEqualityTrue()
        {
            Value result = fe.CalculateFormula("10!=1337");
            Assert.That(result.asBoolean(), Is.True);
        }
        [Test]
        public void NotEqualityFalse()
        {
            Value result = fe.CalculateFormula("1337!=1337");
            Assert.That(result.asBoolean(), Is.False);
        }  
        [Test]
        public void UnaryTrue()
        {
            Value result = fe.CalculateFormula("if(0,TRUE,FALSE)"); //0= false
            Assert.That(result.ToString(), Is.EqualTo("FALSE"));
        }
        [Test]
        public void UnaryFalse()
        {
            Value result = fe.CalculateFormula("if(1,TRUE,FALSE)"); //1= true
            Assert.That(result.ToString(), Is.EqualTo("TRUE"));
        }
    }
}

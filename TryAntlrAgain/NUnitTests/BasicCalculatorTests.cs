using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GetValuesFromColumn;
using NUnit.Framework;
using TryAntlrAgain;

namespace NUnitTests
{
    [TestFixture]
    public class BasicCalculatorTests
    {
        FormulaEngine fe = new FormulaEngine();

        //BASIC CALCULATOR FUNCTIONS
        [Test]
        public void AddNum()
        {
            Value result = fe.CalculateFormula("5.37+5.0");
            Assert.That(result.asDouble(), Is.EqualTo(10.37));
        }
        [Test]
        public void SubNum()
        {
            Value result = fe.CalculateFormula("1000.1337--10000.2337-1000000.1337");
            Assert.That(result.asDouble(), Is.EqualTo(-988999.7663));
        }
        [Test]
        public void MulNum()
        {
            Value result = fe.CalculateFormula("10*133.7");
            Assert.That(result.asDouble(), Is.EqualTo(1337.0));
        }
        [Test]
        public void DivNum()
        {
            Value result = fe.CalculateFormula("200/1000");
            Assert.That(result.asDouble(), Is.EqualTo(0.2));
        }
        [Test]
        public void AddStrings()
        {
            string secType = "\"Security Type\"";
            string porfolio = "\"Portfolio\"";
            Value result = fe.CalculateFormula(secType + "+" + porfolio);
            Assert.That(result.ToString(), Is.EqualTo("Security TypePortfolio"));
        }
        [Test]
        public void GreaterThan()
        {
            Value result = fe.CalculateFormula("10.777777777>10.6555555");
            Assert.That(result.asBoolean, Is.True);
        }
        [Test]
        public void GreaterThanOrEqualTo()
        {
            Value result = fe.CalculateFormula("10.777777777>=10.777777778");
            Assert.That(result.asBoolean, Is.False);
        }
        [Test]
        public void LessThan()
        {
            Value result = fe.CalculateFormula("1337<1337.1337");
            Assert.That(result.asBoolean, Is.True);
        }
        [Test]
        public void LessThanOrEqualTo()
        {
            Value result = fe.CalculateFormula("1337.1<=1337");
            Assert.That(result.asBoolean, Is.False);
        }
        [Test]
        public void AddNegativeToPositive()
        {
            Value result = fe.CalculateFormula("-10.1+15.5");
            Assert.That(result.asDouble(), Is.EqualTo(5.4));
        }
        [Test]
        public void MulDivSubAddNegatives()
        {
            Value result = fe.CalculateFormula("-10.5*-10.1/-10.9+-10.2--10.4");
            Assert.That(result.asDouble(), Is.EqualTo(-9.5293577981651));
        }
        [Test]
        public void Parens()
        {
            Value result = fe.CalculateFormula("(132.7+1)*10"); //132.7+1*10 = 142.7
            Assert.That(result.asDouble(), Is.EqualTo(1337.000));
        }
        [Test]
        public void ComplexCalculatorUsingEverything()
        {
            Value result = fe.CalculateFormula("");
            Assert.That(result.asDouble(), Is.EqualTo(1337));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFSFeed.Model;

namespace PfsPaaDAL
{
    public class UnrealisedCashFlow : IUnrealisedCashFlow
    {
        private IUnrealisedCashFlow _ucf;
        private double _amount;
        private double _finAmt;
        private double _usdAmt;
        public UnrealisedCashFlow(IUnrealisedCashFlow ucf, bool dtd = false, double fxRate = double.NaN, bool round = false)
        {
            _ucf = ucf;
            FxRate = fxRate;
            Amount = _ucf.Amount;
            FinAmt = dtd ? Amount : Amount * FxFix;
            USDAmt = FxRate == 0 ? double.NaN : FinAmt / FxRate;

            if (round)
                Round();         
        }

        public double Amount
        {
            get { return _amount; }
            private set { _amount = value; }
        }

        public string CashType { get { return _ucf.CashType; } }

        public string Currency { get { return _ucf.Currency; } }

        public int EffectiveDate { get { return _ucf.EffectiveDate; } }

        public int FinancingDate { get { return _ucf.FinancingDate; } }

        public double FxFix { get { return _ucf.FxFix; } }

        public int PayDate { get { return _ucf.PayDate; } }

        public int PostingDate { get { return _ucf.PostingDate; } }

        public ShortCashFlowTypeEnum ShortCashFlowType { get { return _ucf.ShortCashFlowType; } }

        public double FinAmt
        {
            get { return _finAmt; }
            private set { _finAmt = value; }
        }

        public double USDAmt
        {
            get { return _usdAmt; }
            private set { _usdAmt = value; }
        }

        public double FxRate { get; private set; }

        public void Round()
        {
            _amount = Utility.Round(Amount);
            _finAmt = Utility.Round(FinAmt);
            _usdAmt = Utility.Round(USDAmt);
        }
    }
}

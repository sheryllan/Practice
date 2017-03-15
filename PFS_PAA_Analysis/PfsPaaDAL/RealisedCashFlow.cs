using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFSFeed.Model;

namespace PfsPaaDAL
{
    public class RealisedCashFlow : IRealisedCashFlow
    {
        private IRealisedCashFlow _rcf;
        private double _finAmt;
        private double _usdAmt;
        private double _dtdAmount;
        private double _ltdAmount;

        public RealisedCashFlow(IRealisedCashFlow rcf, bool dtd = false, double fxRate = double.NaN, bool round = false)
        {
            _rcf = rcf;
            FxRate = fxRate;
            LtdAmount = _rcf.LtdAmount;
            DtdAmount = _rcf.DtdAmount;
            FinAmt = dtd ? DtdAmount : DtdAmount * FxFix;
            USDAmt = FxRate == 0 ? double.NaN : FinAmt / FxRate;

            if (round)
                Round();
        }

        public string CashType { get { return _rcf.CashType; } }
       

        public string Currency { get { return _rcf.Currency; } }

        public double DtdAmount
        {
            get { return _dtdAmount; }
            private set { _dtdAmount = value; }
        }
       
        public double FxFix { get { return _rcf.FxFix; } }
       

        public double LtdAmount
        {
            get { return _ltdAmount; }
            set { _ltdAmount = value; }

        }

        public ShortCashFlowTypeEnum ShortCashFlowType { get { return _rcf.ShortCashFlowType; } }
       

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
            _ltdAmount = Utility.Round(LtdAmount);
            _dtdAmount = Utility.Round(DtdAmount);
            _finAmt = Utility.Round(FinAmt);
            _usdAmt = Utility.Round(USDAmt);
        }
    }
}

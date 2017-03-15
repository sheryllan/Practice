using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PfsPaaDAL
{
    public class PaaData
    {
        public int EodDate { get; set; }
        public int PosId { get; set; }
        public double Quantity { get; set; }
        public double Spot { get; set; }
        public double Delta { get; set; }
        public double Theta { get; set; }
        public double FairValue { get; set; }
        public double AverageCost { get; set; }
        public int Interest { get; set; }
        public int Coupon { get; set; }
        public int Dividend { get; set; }
        public int Realised { get; set; }
        public int Commission { get; set; }
        public string MOK { get; set; }
        public string PLOK { get; set; }
        public double AvgCostA { get; set; }
        public int RlsdA { get; set; }
        public int CommA { get; set; }
        public int EOPL { get; set; }
        public int ThetaPL { get; set; }
        public int EOPLE { get; set; }
        public int AccIntPLRD { get; set; }
        public int CouponPLRD { get; set; }
        public int DivPLRD { get; set; }
        public string CCY { get; set; }
        public double DayCount { get; set; }
        public double LiborRate { get; set; }
        public double LiborPrem { get; set; }
        public double EquityPrem { get; set; }
        public double DivPrem { get; set; }
        public string PfsId { get; set; }


        public static PaaData UsdFied(PaaData fm, IDictionary<int, Dictionary<string, double>> fxHist)
        {
            if (!fxHist.ContainsKey(fm.EodDate)) return null;
            var fx = Utility.GetFxRate(fxHist[fm.EodDate], fm.CCY.Trim());
            return new PaaData
            {
                EodDate = fm.EodDate,
                PosId = fm.PosId,
                Quantity = fm.Quantity,
                Spot = Math.Round(fm.Spot / fx, 4),
                Delta = Utility.Round(fm.Delta / fx),
                Theta = Utility.Round(fm.Theta / fx),
                FairValue = Utility.Round(fm.FairValue / fx),
                AverageCost = Math.Round(fm.AverageCost / fx, 4),
                Interest = Utility.Round(fm.Interest / fx),
                Coupon = Utility.Round(fm.Coupon / fx),
                Dividend = Utility.Round(fm.Dividend / fx),
                Realised = Utility.Round(fm.Realised / fx),
                Commission = Utility.Round(fm.Commission / fx),
                MOK = fm.MOK,
                PLOK = fm.PLOK,
                AvgCostA = Math.Round(fm.AvgCostA / fx, 4),
                RlsdA = Utility.Round(fm.RlsdA / fx),
                CommA = Utility.Round(fm.CommA / fx),
                EOPL = Utility.Round(fm.EOPL / fx),
                ThetaPL = Utility.Round(fm.ThetaPL / fx),
                EOPLE = Utility.Round(fm.EOPLE / fx),
                AccIntPLRD = Utility.Round(fm.AccIntPLRD / fx),
                CouponPLRD = Utility.Round(fm.CouponPLRD / fx),
                DivPLRD = Utility.Round(fm.DivPLRD / fx),
                CCY = fm.CCY + "->USD",
                DayCount = fm.DayCount,
                LiborRate = fm.LiborRate / fx,
                LiborPrem = Utility.Round(fm.LiborPrem / fx),
                EquityPrem = Utility.Round(fm.EquityPrem / fx),
                DivPrem = Utility.Round(fm.DivPrem / fx),
                PfsId = fm.PfsId,
            };
        }
        public static PaaData DtdDiffed(PaaData fm, PaaData to)
        {
            return new PaaData
            {
                EodDate = to.EodDate,
                PosId = to.PosId,
                Quantity = to.Quantity - fm.Quantity,
                Spot = Math.Round(to.Spot - fm.Spot, 2),
                Delta = to.Delta - fm.Delta,
                Theta = to.Theta - fm.Theta,
                FairValue = to.FairValue - fm.FairValue,
                AverageCost = Math.Round(to.AverageCost - fm.AverageCost, 2),
                Interest = to.Interest - fm.Interest,
                Coupon = to.Coupon - fm.Coupon,
                Dividend = to.Dividend - fm.Dividend,
                Realised = to.Realised - fm.Realised,
                Commission = to.Commission - fm.Commission,
                MOK = fm.MOK,
                PLOK = fm.PLOK,
                AvgCostA = Math.Round(to.AvgCostA - fm.AvgCostA, 2),
                RlsdA = to.RlsdA - fm.RlsdA,
                CommA = to.CommA - fm.CommA,
                EOPL = to.EOPL - fm.EOPL,
                ThetaPL = to.ThetaPL - fm.ThetaPL,
                EOPLE = to.EOPLE - fm.EOPLE,
                AccIntPLRD = to.AccIntPLRD - fm.AccIntPLRD,
                CouponPLRD = to.CouponPLRD - fm.CouponPLRD,
                DivPLRD = to.DivPLRD - fm.DivPLRD,
                CCY = to.CCY,
                DayCount = to.DayCount - fm.DayCount,
                LiborRate = to.LiborRate - fm.LiborRate,
                LiborPrem = to.LiborPrem - fm.LiborPrem,
                EquityPrem = to.EquityPrem - fm.EquityPrem,
                DivPrem = to.DivPrem - fm.DivPrem,
                PfsId = to.PfsId,
            };
        }
    }
}

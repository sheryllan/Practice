using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFSFeed.Model;

namespace PfsPaaDAL
{
    public class PfsData
    {
        public PfsData(int date, ISwapDescription swap_T_1, ISwapDescription swap_T_2 = null, double fx = 1, bool showFixes = false)
        {
            Date = date;
            Swap_T_1 = swap_T_1;
            Swap_T_2 = swap_T_2;

            //fxRates = fxHist.ContainsKey(Date) ? fxHist[Date] : null;
            //fxRate = Utility.GetFxRate(fxRates, Swap_T_1.SwapCurrency);
            fxRate = fx;
            this.showFixes = showFixes;
            yesterdayUcf = swap_T_2?.Position?.UnrealisedCashFlows;
        }

        //private Dictionary<string,double> fxRates;
        private IUnrealisedCashFlow[] yesterdayUcf;
        private double fxRate;
        private bool showFixes;

        public ISwapDescription Swap_T_1 { get; set; }

        public ISwapDescription Swap_T_2 { get; set; }
        public int Date { get; set; }
        public string SCCY { get { return Swap_T_1?.SwapCurrency; } }
        public double? TQ { get { return Swap_T_1?.Position.TradedQuantity; } }
        public double? IdayTQ { get { return Swap_T_1?.Position.TradedQuantity - Swap_T_2.Position.TradedQuantity; } }
        public double? AvgCost { get { return Swap_T_1?.Position.ProfitLoss.AverageCost; } }
        public double? TrdFX { get { return Swap_T_1?.Position.TradedFX; } }
        public double? SettQty { get { return Swap_T_1?.Position.SettledQuantity; } }
        public double? SettPrice { get { return Swap_T_1?.Position.SettledPrice; } }
        public double? SettFX { get { return Swap_T_1?.Position.SettledFX; } }
        //public double? SettQ { get { return Swap?.Position.SettledQuantity; } }
        //public double? SettP { get { return Utility.Round(Swap?.Position.SettledPrice); } }
        //public double? FFix { get { returnSwap?.FloatingLeg.Schedule.First()?.Amount; } }
        public double? BC { get { return Swap_T_1?.Position.BorrowCost; } }
        //public double? AvgTrdCost { get{ return Swap?.Position.ProfitLosAverageTradedCost; }}
        //public double? SumUCF { get{ return (int?)Swap?.Position.UnrealisedCashFlowSum(cf => cf.Amount * cf.FxFix); }}
        //public double? UCFDiv { get{ return (int?)Swap?.Position.UnrealisedCashFlowWhere(cf => cf.CashType == "Dividend").Sum(cf => cf.Amount * cf.FxFix); }}
        //public double? SumUCFIntrt { get{ return (int?)Swap?.Position.UnrealisedCashFlowWhere(cf => cf.CashType == "Interest").Sum(cf => cf.Amount * cf.FxFix); }}
        //public double? SumUCFOth { get{ return (int?)Swap?.Position.UnrealisedCashFlowWhere(cf => cf.CashType != "Interest" && cf.CashType != "Dividend").Sum(cf => cf.Amount * cf.FxFix); }}
        public UnrealisedCashFlow[] UnrealisedCF
        {
            get{ return Swap_T_1?.Position.UnrealisedCashFlows.Select(cf => new UnrealisedCashFlow(ucf:cf, fxRate:fxRate, round:true)).ToArray(); }
        }
        public RealisedCashFlow[] RealisedCF
        {
           get { return Swap_T_1?.Position.RealisedCashFlows.Select(cf => new RealisedCashFlow(rcf:cf, fxRate:fxRate, round:true)).ToArray(); }
        }
        public UnrealisedCashFlow[] UcfDtd
        {
            get { return Swap_T_1?.GetUcfDtd(yesterdayUcf)?.Select(cf => new UnrealisedCashFlow(ucf:cf, dtd:true, fxRate:fxRate, round:true)).ToArray(); }
        }
        public UnrealisedCashFlow[] UcfSudden
        {
            get { return Swap_T_1?.GetUcfSudden(yesterdayUcf)?.Select(cf => new UnrealisedCashFlow(ucf: cf, dtd:true, fxRate: fxRate, round: true)).ToArray(); }
        }
        public RealisedCashFlow[] RcfSudden
        {
            get { return Swap_T_1?.GetRcfSudden(yesterdayUcf)?.Select(cf => new RealisedCashFlow(rcf: cf, dtd:true, fxRate: fxRate, round: true)).ToArray(); }
        }
        public FixSchedule[] EqFix { get { return showFixes ? Swap_T_1?.EquityLeg.Schedule.Select(f => new FixSchedule(f) ).ToArray() : null; } }
        public IScheduleRow[] FlFix { get { return showFixes ? Swap_T_1?.FloatingLeg.Schedule : null; } }
        //public double? DivFix { get{ return showFixes ? Swap?.DividendLeg.Schedule : null; }}

    }
}

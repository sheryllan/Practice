using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFSFeed.Model;


namespace PfsPaaDAL
{
    public static class CashFlowExtensions
    {
        public static bool UcfMatches(this IUnrealisedCashFlow lhs, IUnrealisedCashFlow other, bool isOoc)
        {
            if (isOoc) // eventually, logic should be simple and based on postingDate; but until PFS implements that ...
            {
                return lhs.ShortCashFlowType == other.ShortCashFlowType
                    && lhs.PayDate == other.PayDate
                    && lhs.CashType == other.CashType
                    && lhs.Currency == other.Currency; // ignore fxFix; PFS has some bug that sends different fx rate for different dates for same ooc transaction
            }
            return lhs.PostingDate == other.PostingDate
                && lhs.ShortCashFlowType == other.ShortCashFlowType
                && lhs.PayDate == other.PayDate
                && lhs.CashType == other.CashType
                && lhs.Currency == other.Currency
                //&& lhs.Amount==other.Amount // match except amount
                && lhs.FxFix == other.FxFix;

        }
        public static bool UcfMatches(this IUnrealisedCashFlow lhs, IRealisedCashFlow other, int valueDate, bool isOoc)
        {
            return lhs.ShortCashFlowType == other.ShortCashFlowType
                && lhs.PayDate == valueDate
                //&& lhs.CashType==other.CashType
                && lhs.Currency == (isOoc ? lhs.Currency : other.Currency);
            //&& lhs.Amount==other.Amount // match except amount and FX Fix
            //&& lhs.FxFix==other.FxFix;
        }
        public static bool DoesUcfDiffer(this ISwapDescription swap, IUnrealisedCashFlow[] rhsUcf)
        {   // iterates over today's UCF
            var lhsUcf = swap.Position.UnrealisedCashFlows;
            if (lhsUcf == null && rhsUcf == null) return false;
            if (lhsUcf == null || rhsUcf == null) return true;
            // now both are non-null
            if (lhsUcf.Length != rhsUcf.Length) return true;

            for (var i = 0; i < lhsUcf.Length; i++) // assume CFs are sorted
            {
                var lhs = lhsUcf[i]; var rhs = rhsUcf[i];
                if (lhs.PayDate != rhs.PayDate
                    || lhs.ShortCashFlowType != rhs.ShortCashFlowType
                    || lhs.CashType != rhs.CashType
                    || lhs.Currency != rhs.Currency
                    || lhs.Amount != rhs.Amount
                    || lhs.FxFix != rhs.FxFix)
                    return true;
            };
            return false;
        }
        public static IUnrealisedCashFlow[] GetUcfDtd(this ISwapDescription swap, IUnrealisedCashFlow[] yesterday)
        {   // iterates over today's UCF
            if (yesterday == null || yesterday.Length == 0) return swap.Position.UnrealisedCashFlows;
            return swap.Position.UnrealisedCashFlows.Select(t =>
            {
                var prevAmount = yesterday.FirstOrDefault(y => t.UcfMatches(y, swap.SwapCurrency != t.Currency))?.Amount ?? 0.0;
                return new PFSFeed.Model.UnrealisedCashFlow(t.PayDate, t.ShortCashFlowType, t.CashType, (t.Amount - prevAmount) * t.FxFix, t.Currency + "->" + swap.SwapCurrency, t.FxFix, 0, 0, 0);
            }).ToArray();
        }
        public static IUnrealisedCashFlow[] GetUcfSudden(this ISwapDescription swap, IUnrealisedCashFlow[] yesterday)
        {   // iterates over yesterday's UCF.  UCF Sudden is the amount that "disappeared".
            if (yesterday == null || yesterday.Length == 0) return new UnrealisedCashFlow[0];
            return yesterday
                .Where(y => !swap.Position.UnrealisedCashFlows.Any(t => y.UcfMatches(t, swap.SwapCurrency != y.Currency)) &&
                            !swap.Position.RealisedCashFlows.Any(r => y.UcfMatches(r, swap.ValueDate, swap.SwapCurrency == y.Currency))
                      ).ToArray();
        }
        public static IRealisedCashFlow[] GetRcfSudden(this ISwapDescription swap, IUnrealisedCashFlow[] yesterday)
        {   // iterates of today's RCF.  RCF Sudden is the amount that "appeared".
            return swap.Position.RealisedCashFlows
                .Where(r => r.DtdAmount != 0)
                .Select(r =>
                {
                    var prevAmount = yesterday?.Where(y => y.UcfMatches(r, swap.ValueDate, swap.SwapCurrency != y.Currency)).Sum(y => y.Amount * y.FxFix) ?? 0.0;
                    return new PFSFeed.Model.RealisedCashFlow(r.ShortCashFlowType, r.CashType, r.LtdAmount, r.DtdAmount * r.FxFix - prevAmount, r.Currency + "->" + swap.SwapCurrency, r.FxFix);                   
                })
                .ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFSFeed.Model;

namespace PfsPaaDAL
{
    public class PfsDbConsistencyData
    {
        public int EodDate { get; set; }
        public int PosId { get; set; }
        public bool IsOk { get { return string.IsNullOrEmpty(QtyOk + AvgOk + RlsdOk + CommOk + DivOk + CouponOk); } }
        public double PfsTQ { get; set; }
        public double DbTQ { get; set; }
        public double PfsAvgCost { get; set; }
        public double DbAvgCost { get; set; }
        public double DbAvgCostA { get; set; }
        public int PfsRlsd { get; set; }
        public int DbRlsd { get; set; }
        public int DbRlsdA { get; set; }
        public int PfsComm { get; set; }
        public int DbComm { get; set; }
        public int DbCommA { get; set; }
        public int PfsDiv { get; set; }
        public int DbDiv { get; set; }
        public int PfsCoupon { get; set; }
        public int DbCoupon { get; set; }        
        public string QtyOk { get { return Utility.DblEquals(PfsTQ, DbTQ) ? "" : "False"; } }
        public string AvgOk { get { return Utility.DblEquals(PfsAvgCost, DbAvgCost /*, DbAvgCostA*/) ? "" : "False"; } } // exclude pl archive cmp for now
        public string RlsdOk { get { return Utility.DblEquals(PfsRlsd, DbRlsd /*, DbRlsdA*/) ? "" : "False"; } }
        public string CommOk { get { return Utility.DblEquals(PfsComm, DbComm /*, DbCommA*/) ? "" : "False"; } }
        public string DivOk { get { return Utility.DblEquals(PfsDiv, DbDiv) ? "" : "False"; } }
        public string CouponOk { get { return Utility.DblEquals(PfsCoupon, DbCoupon) ? "" : "False"; } }
        public string PfsId { get; set; }


        public static PfsDbConsistencyData CreatePfsDbConsistencyData(ISwapDescription p, PaaData d)
        {

            return new PfsDbConsistencyData
            {
                EodDate = p.ValueDate,
                PosId = d.PosId,
                PfsTQ = p.Position.TradedQuantity,
                DbTQ = d.Quantity,
                PfsAvgCost = Math.Round(p.Position.ProfitLoss.AverageCost, 6),
                DbAvgCost = d.AverageCost,
                DbAvgCostA = d.AvgCostA,
                PfsRlsd = Utility.Round(p.Position.RealisedCashFlows.Where(cf => cf.ShortCashFlowType != ShortCashFlowTypeEnum.Distibution && cf.ShortCashFlowType != ShortCashFlowTypeEnum.Reset && cf.ShortCashFlowType != ShortCashFlowTypeEnum.TransactionFee)?.Sum(cf => cf.LtdAmount) ?? 0.0),
                DbRlsd = d.Realised,
                DbRlsdA = d.RlsdA,
                PfsComm = Utility.Round(p.Position.RealisedCashFlows.Where(cf => cf.ShortCashFlowType == ShortCashFlowTypeEnum.TransactionFee)?.Sum(cf => cf.LtdAmount) ?? 0.0),
                DbComm = d.Commission,
                DbCommA = d.CommA,
                PfsDiv = Utility.Round(p.Position.RealisedCashFlows.Where(cf => cf.ShortCashFlowType == ShortCashFlowTypeEnum.Distibution)?.Sum(cf => cf.LtdAmount) ?? 0.0),
                DbDiv = d.Dividend,
                PfsCoupon = Utility.Round(p.Position.RealisedCashFlows.Where(cf => cf.ShortCashFlowType == ShortCashFlowTypeEnum.Reset)?.Sum(cf => cf.LtdAmount) ?? 0.0),
                DbCoupon = d.Coupon,
                PfsId = d.PfsId,
            };
        }

    }
}

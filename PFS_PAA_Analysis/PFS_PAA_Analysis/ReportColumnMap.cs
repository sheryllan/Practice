using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFS_PAA_Analysis
{
    public class ReportColumnMap
    {
        private static Dictionary<string, DataColumn> dtColumnDict = new Dictionary<string, DataColumn>()
        {
            {"Region" , new DataColumn("Region" , typeof(string))},
            {"EodDate" , new DataColumn("EodDate" , typeof(int))},
            {"PositionNode" , new DataColumn("PositionNode" , typeof(string))},
            {"Row" , new DataColumn("Row" , typeof(int))},
            {"PositionId" , new DataColumn("PositionId" , typeof(int))},
            {"ComponentMnem" , new DataColumn("ComponentMnem" , typeof(string))},
            {"SecurityType" , new DataColumn("SecurityType" , typeof(string))},
            {"SecurityCurrency" , new DataColumn("SecurityCurrency" , typeof(string))},
            {"ModelName" , new DataColumn("ModelName" , typeof(string))},
            {"Account" , new DataColumn("Account" , typeof(string))},
            {"UnderlyingPriceT_2" , new DataColumn("UnderlyingPriceT_2" , typeof(double))},
            {"UnderlyingPriceT_1" , new DataColumn("UnderlyingPriceT_1" , typeof(double))},
            {"Gamma_1_T_2" , new DataColumn("Gamma_1_T_2" , typeof(double))},
            {"Vega_1_T_2" , new DataColumn("Vega_1_T_2" , typeof(double))},
            {"PV01_bp_T_2" , new DataColumn("PV01_bp_T_2" , typeof(double))},
            {"Delta_T_2" , new DataColumn("Delta_T_2" , typeof(double))},
            {"COB_Price_T_1" , new DataColumn("COB_Price_T_1" , typeof(double))},
            {"Quantity_T_1" , new DataColumn("Quantity_T_1" , typeof(double))},
            {"Quantity_T_2" , new DataColumn("Quantity_T_2" , typeof(double))},
            {"TradeQuantity" , new DataColumn("TradeQuantity" , typeof(double))},
            {"RiskPAA_DeltaPL" , new DataColumn("RiskPAA_DeltaPL" , typeof(double))},
            {"RiskPAA_GammaPL" , new DataColumn("RiskPAA_GammaPL" , typeof(double))},
            {"RiskPAA_FXDeltaPL" , new DataColumn("RiskPAA_FXDeltaPL" , typeof(double))},
            {"RiskPAA_FXDelta_DTDSAdj" , new DataColumn("RiskPAA_FXDelta_DTDSAdj" , typeof(double))},
            {"RiskPAA_VolatilityPL" , new DataColumn("RiskPAA_VolatilityPL" , typeof(double))},
            {"CommissionPL_DTD_T_1" , new DataColumn("CommissionPL_DTD_T_1" , typeof(double))},
            {"DividendPL_DTD_T_1" , new DataColumn("DividendPL_DTD_T_1" , typeof(double))},
            {"CouponPL_DTD_T_1" , new DataColumn("CouponPL_DTD_T_1" , typeof(double))},
            {"SecurityChangePAA" , new DataColumn("SecurityChangePAA" , typeof(double))},
            {"Carry_Theta" , new DataColumn("Carry_Theta" , typeof(double))},
            {"Theta" , new DataColumn("Theta" , typeof(double))},
            {"IntradayTradingPLUSD" , new DataColumn("IntradayTradingPLUSD" , typeof(double))},
            {"TotalPAA" , new DataColumn("TotalPAA" , typeof(double))},
            {"FairEconomicDTDS_T_1" , new DataColumn("FairEconomicDTDS_T_1" , typeof(double))},
            {"Residual" , new DataColumn("Residual" , typeof(double))},
            {"PercentageResidual" , new DataColumn("PercentageResidual" , typeof(double))},
            {"FairValue_T_1" , new DataColumn("FairValue_T_1" , typeof(double))},
            {"FairValue_T_2" , new DataColumn("FairValue_T_2" , typeof(double))},
            {"SecurityId" , new DataColumn("SecurityId" , typeof(int))},
            {"AbsRes" , new DataColumn("AbsRes" , typeof(double))},
            {"#" , new DataColumn("#" , typeof(int))},
            {"Reason" , new DataColumn("Reason" , typeof(string))},
            {"SubReason" , new DataColumn("SubReason" , typeof(string))},
            {"Comments" , new DataColumn("Comments" , typeof(string))}
        };

        private static DataColumn[] AnalysisColumns = new[]
        {
            new DataColumn("Region", typeof(string)),
            new DataColumn("EodDate", typeof(int)),
            new DataColumn("PositionNode", typeof(string)),
            new DataColumn("PositionId", typeof(int)),
            new DataColumn("Delta_T_2", typeof(double)),
            new DataColumn("Quantity_T_1", typeof(double)),
            new DataColumn("Quantity_T_2", typeof(double)),
            new DataColumn("TradeQuantity", typeof(double)),
            new DataColumn("Theta", typeof(double)),
            new DataColumn("IntradayTradingPLUSD", typeof(double)),
            new DataColumn("Residual", typeof(double)),
            new DataColumn("AbsRes", typeof(double)),
            new DataColumn("Db_Inconsistency", typeof(bool)),
            new DataColumn("Qty_Inconsistency", typeof(string)),
            new DataColumn("Avg_Inconsistency", typeof(string)),
            new DataColumn("Rls_Inconsistency", typeof(string)),
            new DataColumn("Comm_Inconsistency", typeof(string)),
            new DataColumn("Div_Inconsistency", typeof(string)),
            new DataColumn("Coupon_Inconsistency", typeof(string)),
            new DataColumn("MarkingOK", typeof(bool)),
            new DataColumn("UCF_CT", typeof(string)),
            new DataColumn("UCF_Amt", typeof(double)),
            new DataColumn("UCF_Reset", typeof(double)),
            new DataColumn("SuddenUCF_CT", typeof(string)),
            new DataColumn("SuddenUCF_USDAmt", typeof(double)),
            new DataColumn("SuddenRCF_CT", typeof(string)),
            new DataColumn("SuddenRCF_USDAmt", typeof(double)),
            new DataColumn("Cancelled", typeof(bool)),
        };

        public static Dictionary<string, DataColumn> NewDtColumnDict()
        {
            return dtColumnDict.Select(c => new KeyValuePair<string, DataColumn>(c.Key, new DataColumn(c.Value.ColumnName, c.Value.DataType)))
                .ToDictionary(p => p.Key, p => p.Value);
        }

        public static Dictionary<string, DataColumn> NewDtColumnDict(Dictionary<string, DataColumn> d)
        {
            return d.Select(c => new KeyValuePair<string, DataColumn>(c.Key, new DataColumn(c.Value.ColumnName, c.Value.DataType)))
                .ToDictionary(p => p.Key, p => p.Value);
        }

        public static DataColumn[] NewAnalysisDtColumns()
        {
            return AnalysisColumns.Select(c => new DataColumn(c.ColumnName, c.DataType)).ToArray();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ResidualAnalysis
{
    public class ReportColumns
    {

        #region EMEA column dictionary
        public static readonly Dictionary<int, string> DicEMEAColumn = new Dictionary<int, string>()
        {
            { 0 , "PositionId" },
            { 1 , "Expiry" },
            { 2 , "CompoundPositionId" },
            { 3 , "Cusipv2" },
            { 4 , "ComponentMnem" },
            { 5 , "Strike" },
            { 6 , "PackageNumber" },
            { 7 , "SecurityType" },
            { 8 , "PC" },
            { 9 , "SecurityCurrency" },
            { 10 , "ModelName" },
            { 11 , "Account" },
            { 12 , "AccountEntityCode" },
            { 13 , "UnderlyingPriceT_2" },
            { 14 , "UnderlyingPriceT_1" },
            { 15 , "Gamma_1_T_2" },
            { 16 , "Vega_1_T_2" },
            { 17 , "PV01_bp_T_2" },
            { 18 , "CR01_T_2" },
            { 19 , "Delta_T_2" },
            { 20 , "COB_Price_T_1" },
            { 21 , "Quantity_T_1" },
            { 22 , "Quantity_T_2" },
            { 23 , "TradeQuantity" },
            { 24 , "KOTrades" },
            { 25 , "RiskPAA_DeltaPL" },
            { 26 , "RiskPAA_GammaPL" },
            { 27 , "RiskPAA_FXDeltaPL" },
            { 28 , "RiskPAA_FXDelta_TradeCcyAdj" },
            { 29 , "RiskPAA_FXDelta_DTDSAdj" },
            { 30 , "RiskPAA_ASASPL" },
            { 31 , "RiskPAA_ASFXPL" },
            { 32 , "RiskPAA_RatePL" },
            { 33 , "RiskPAA_IRVolPL" },
            { 34 , "RiskPAA_VolatilityPL" },
            { 35 , "RiskPAA_VolGeoUndsPL" },
            { 36 , "RiskPAA_VolThetaAdj" },
            { 37 , "RiskPAA_BorrowCostPL" },
            { 38 , "RiskPAA_DividendPL" },
            { 39 , "RiskPAA_CrossGammaPL" },
            { 40 , "RiskPAA_VarSwap" },
            { 41 , "RiskPAA_VGVolAtm" },
            { 42 , "RiskPAA_VGSkew" },
            { 43 , "RiskPAA_VGSmile" },
            { 44 , "RiskPAA_VGCallWingA" },
            { 45 , "RiskPAA_VGCallWingB" },
            { 46 , "RiskPAA_VGPutWingA" },
            { 47 , "RiskPAA_VGPutWingB" },
            { 48 , "RiskPAA_VGRefForward" },
            { 49 , "NewTrades" },
            { 50 , "DayTrading" },
            { 51 , "Upsize_Downsize" },
            { 52 , "IntradayTradingPL" },
            { 53 , "TerminatedTrades" },
            { 54 , "CommissionPL_DTD_T_1" },
            { 55 , "FairVsMktDiff" },
            { 56 , "InterestPL_DTD_T_1" },
            { 57 , "DividendPL_DTD_T_1" },
            { 58 , "CouponPL_DTD_T_1" },
            { 59 , "ExtraordinaryPL_DTD_T_1" },
            { 60 , "NetAccruedInterest_DTD_T_1" },
            { 61 , "CreditPAA" },
            { 62 , "SecurityChangePAA" },
            { 63 , "Carry_Theta" },
            { 64 , "SecurityChangePAA2" },
            { 65 , "Theta" },
            { 66 , "IntradayTradingPLUSD" },
            { 67 , "KOPL" },
            { 68 , "TotalPAA" },
            { 69 , "FairEconomicDTDS_T_1" },
            { 70 , "Residual" },
            { 71 , "PercentageResidual" },
            { 72 , "StressingErrors" },
            { 73 , "IsVIXModel" },
            { 74 , "IsVanillaModel" },
            { 75 , "FairValue_T_1" },
            { 76 , "FairValue_T_2" },
            { 77 , "FinalCounterparty" },
            { 78 , "SecurityId" },
            { 79 , "RiskPAA_VGPutSlopeTW" },
            { 80 , "RiskPAA_VGPutConvexityTW" },
            { 81 , "RiskPAA_VGCallSlopeTW" },
            { 82 , "RiskPAA_VGCallConvexityTW" },
            { 83 , "IsTerminatedWithZeroFairValue" },
            { 84 , "VolGeoStressErrors" },
            { 85 , "ExchangeFeesPLDTD_T_1" },
            { 86 , "OtherFeesPLDTD_T_1" },
            //{ 87 , "FairEconomicDTD_T_1" },
            //{ 88 , "AverageCost_T_2" },
            //{ 89 , "AccountEntity" },
            { 87 , "WeightedVega_T_2" },
            { 88 , "ModelResults_DVegaDSpot_T_2" },
            { 89 , "ModelResults_VolGamma_T_2" },
            { 90 , "ModelResults_BusDayTheta_T_2" },
            { 91 , "Region" },
            { 92 , "EodDate" },
            { 93 , "PositionNode" },
            { 94 , "Row" }

        };
        #endregion

        #region NAM column dictionary
        public static readonly Dictionary<int, string> DicNAMColumn = new Dictionary<int, string>()
        {
            { 0 , "PositionId" },
            { 1 , "Expiry" },
            { 2 , "CompoundPositionId" },
            { 3 , "Cusipv2" },
            { 4 , "ComponentMnem" },
            { 5 , "Strike" },
            { 6 , "PackageNumber" },
            { 7 , "SecurityType" },
            { 8 , "PC" },
            { 9 , "SecurityCurrency" },
            { 10 , "ModelName" },
            { 11 , "Account" },
            { 12 , "AccountEntityCode" },
            { 13 , "UnderlyingPriceT_2" },
            { 14 , "UnderlyingPriceT_1" },
            { 15 , "Gamma_1_T_2" },
            { 16 , "Vega_1_T_2" },
            { 17 , "PV01_bp_T_2" },
            { 18 , "CR01_T_2" },
            { 19 , "Delta_T_2" },
            { 20 , "COB_Price_T_1" },
            { 21 , "Quantity_T_1" },
            { 22 , "Quantity_T_2" },
            { 23 , "TradeQuantity" },
            { 24 , "KOTrades" },
            { 25 , "RiskPAA_DeltaPL" },
            { 26 , "RiskPAA_GammaPL" },
            { 27 , "RiskPAA_FXDeltaPL" },
            { 28 , "RiskPAA_FXDelta_TradeCcyAdj" },
            { 29 , "RiskPAA_FXDelta_DTDSAdj" },
            { 30 , "RiskPAA_ASASPL" },
            { 31 , "RiskPAA_ASFXPL" },
            { 32 , "RiskPAA_RatePL" },
            { 33 , "RiskPAA_IRVolPL" },
            { 34 , "RiskPAA_VolatilityPL" },
            { 35 , "RiskPAA_VolGeoUndsPL" },
            { 36 , "RiskPAA_VolThetaAdj" },
            { 37 , "RiskPAA_BorrowCostPL" },
            { 38 , "RiskPAA_DividendPL" },
            { 39 , "RiskPAA_CrossGammaPL" },
            { 40 , "RiskPAA_VarSwap" },
            { 41 , "RiskPAA_VGVolAtm" },
            { 42 , "RiskPAA_VGSkew" },
            { 43 , "RiskPAA_VGSmile" },
            { 44 , "RiskPAA_VGCallWingA" },
            { 45 , "RiskPAA_VGCallWingB" },
            { 46 , "RiskPAA_VGPutWingA" },
            { 47 , "RiskPAA_VGPutWingB" },
            { 48 , "RiskPAA_VGRefForward" },
            { 49 , "NewTrades" },
            { 50 , "DayTrading" },
            { 51 , "Upsize_Downsize" },
            { 52 , "IntradayTradingPL" },
            { 53 , "TerminatedTrades" },
            { 54 , "CommissionPL_DTD_T_1" },
            { 55 , "FairVsMktDiff" },
            { 56 , "InterestPL_DTD_T_1" },
            { 57 , "DividendPL_DTD_T_1" },
            { 58 , "CouponPL_DTD_T_1" },
            { 59 , "ExtraordinaryPL_DTD_T_1" },
            { 60 , "NetAccruedInterest_DTD_T_1" },
            { 61 , "CreditPAA" },
            { 62 , "SecurityChangePAA" },
            { 63 , "Carry_Theta" },
            { 64 , "SecurityChangePAA2" },
            { 65 , "Theta" },
            { 66 , "IntradayTradingPLUSD" },
            { 67 , "KOPL" },
            { 68 , "TotalPAA" },
            { 69 , "FairEconomicDTDS_T_1" },
            { 70 , "Residual" },
            { 71 , "PercentageResidual" },
            { 72 , "StressingErrors" },
            { 73 , "IsVIXModel" },
            { 74 , "IsVanillaModel" },
            { 75 , "FairValue_T_1" },
            { 76 , "FairValue_T_2" },
            { 77 , "FinalCounterparty" },
            { 78 , "SecurityId" },
            { 79 , "RiskPAA_VGPutSlopeTW" },
            { 80 , "RiskPAA_VGPutConvexityTW" },
            { 81 , "RiskPAA_VGCallSlopeTW" },
            { 82 , "RiskPAA_VGCallConvexityTW" },
            { 83 , "IsTerminatedWithZeroFairValue" },
            { 84 , "VolGeoStressErrors" },
            { 85 , "ExchangeFeesPLDTD_T_1" },
            { 86 , "OtherFeesPLDTD_T_1" },
            { 87 , "Region" },
            { 88 , "EodDate" },
            { 89 , "PositionNode" },
            { 90 , "Row" }

        };

        #endregion


        #region APAC column dictionary
        public static readonly Dictionary<int, string> DicAPACColumn = new Dictionary<int, string>()
        {
            { 0 , "PositionId" },
            { 1 , "Expiry" },
            { 2 , "CompoundPositionId" },
            { 3 , "Cusipv2" },
            { 4 , "ComponentMnem" },
            { 5 , "Strike" },
            { 6 , "PackageNumber" },
            { 7 , "SecurityType" },
            { 8 , "PC" },
            { 9 , "SecurityCurrency" },
            { 10 , "ModelName" },
            { 11 , "Account" },
            { 12 , "UnderlyingPriceT_2" },
            { 13 , "UnderlyingPriceT_1" },
            { 14 , "Gamma_1_T_2" },
            { 15 , "Vega_1_T_2" },
            { 16 , "PV01_bp_T_2" },
            { 17 , "CR01_T_2" },
            { 18 , "Delta_T_2" },
            { 19 , "COB_Price_T_1" },
            { 20 , "Quantity_T_1" },
            { 21 , "Quantity_T_2" },
            { 22 , "TradeQuantity" },
            { 23 , "KOTrades" },
            { 24 , "RiskPAA_DeltaPL" },
            { 25 , "RiskPAA_GammaPL" },
            { 26 , "RiskPAA_FXDeltaPL" },
            { 27 , "RiskPAA_FXDelta_TradeCcyAdj" },
            { 28 , "RiskPAA_FXDelta_DTDSAdj" },
            { 29 , "RiskPAA_ASASPL" },
            { 30 , "RiskPAA_ASFXPL" },
            { 31 , "RiskPAA_RatePL" },
            { 32 , "RiskPAA_IRVolPL" },
            { 33 , "RiskPAA_VolatilityPL" },
            { 34 , "RiskPAA_VolGeoUndsPL" },
            { 35 , "RiskPAA_VGVolAtm" },
            { 36 , "RiskPAA_VGSkew" },
            { 37 , "RiskPAA_VGSmile" },
            { 38 , "RiskPAA_VGPutWingA" },
            { 39 , "RiskPAA_VGPutWingB" },
            { 40 , "RiskPAA_VGCallWingA" },
            { 41 , "RiskPAA_VGCallWingB" },
            { 42 , "RiskPAA_VGRefForward" },
            { 43 , "RiskPAA_VolThetaAdj" },
            { 44 , "RiskPAA_BorrowCostPL" },
            { 45 , "RiskPAA_DividendPL" },
            { 46 , "RiskPAA_CrossGammaPL" },
            { 47 , "RiskPAA_VarSwap" },
            { 48 , "CreditPAA" },
            { 49 , "NewTrades" },
            { 50 , "DayTrading" },
            { 51 , "Upsize_Downsize" },
            { 52 , "TerminatedTrades" },
            { 53 , "CommissionPL_DTD_T_1" },
            { 54 , "FairVsMktDiff" },
            { 55 , "InterestPL_DTD_T_1" },
            { 56 , "DividendPL_DTD_T_1" },
            { 57 , "ExtraordinaryPL_DTD_T_1" },
            { 58 , "SecurityChangePAA2" },
            { 59 , "Theta" },
            { 60 , "IntradayTradingPLUSD" },
            { 61 , "KOPL" },
            { 62 , "TotalPAA" },
            { 63 , "FairEconomicDTD_T_1" },
            { 64 , "FairEconomicDTDS_T_1" },
            { 65 , "Residual" },
            { 66 , "AverageCost_T_2" },
            { 67 , "PercentageResidual" },
            { 68 , "StressingErrors" },
            { 69 , "IsVIXModel" },
            { 70 , "IsVanillaModel" },
            { 71 , "FairValue_T_1" },
            { 72 , "AccountEntity" },
            { 73 , "AccountEntityCode" },
            { 74 , "SecurityId" },
            { 75 , "RiskPAA_VGPutSlopeTW" },
            { 76 , "RiskPAA_VGPutConvexityTW" },
            { 77 , "RiskPAA_VGCallSlopeTW" },
            { 78 , "RiskPAA_VGCallConvexityTW" },
            { 79 , "IsTerminatedWithZeroFairValue" },
            { 80 , "VolGeoStressErrors" },
            { 81 , "ExchangeFeesPLDTD_T_1" },
            { 82 , "OtherFeesPLDTD_T_1" },
            //{ 83 , "IntradayTradingPL" },
            //{ 84 , "CouponPL_DTD_T_1" },
            //{ 85 , "NetAccruedInterest_DTD_T_1" },
            //{ 86 , "SecurityChangePAA" },
            //{ 87 , "Carry_Theta" },
            //{ 88 , "FairValue_T_2" },
            //{ 89 , "FinalCounterparty" },
            { 83 , "Region" },
            { 84 , "EodDate" },
            { 85 , "PositionNode" },
            { 86 , "Row" }
        };

        #endregion

        public static readonly Dictionary<string, Dictionary<int, string>> DicRegionCol = new Dictionary<string, Dictionary<int, string>>()
        {
            {"EMEA" , DicEMEAColumn },
            {"NAM" , DicNAMColumn },
            {"APAC" , DicAPACColumn }
        };

        #region columns
        public int PositionId { get; set; }
        public string Expiry { get; set; }
        public string CompoundPositionId { get; set; }
        public string Cusipv2 { get; set; }
        public string ComponentMnem { get; set; }
        public double? Strike { get; set; }
        public string PackageNumber { get; set; }
        public string SecurityType { get; set; }
        public string PC { get; set; }
        public string SecurityCurrency { get; set; }
        public string ModelName { get; set; }
        public string Account { get; set; }
        public string AccountEntityCode { get; set; }
        public double? UnderlyingPriceT_2 { get; set; }
        public double? UnderlyingPriceT_1 { get; set; }
        public double? Gamma_1_T_2 { get; set; }
        public double? Vega_1_T_2 { get; set; }
        public double? PV01_bp_T_2 { get; set; }
        public double? CR01_T_2 { get; set; }
        public double? Delta_T_2 { get; set; }
        public double? COB_Price_T_1 { get; set; }
        public double? Quantity_T_1 { get; set; }
        public double? Quantity_T_2 { get; set; }
        public double? TradeQuantity { get; set; }
        public double? KOTrades { get; set; }
        public double? RiskPAA_DeltaPL { get; set; }
        public double? RiskPAA_GammaPL { get; set; }
        public double? RiskPAA_FXDeltaPL { get; set; }
        public double? RiskPAA_FXDelta_TradeCcyAdj { get; set; }
        public double? RiskPAA_FXDelta_DTDSAdj { get; set; }
        public double? RiskPAA_ASASPL { get; set; }
        public double? RiskPAA_ASFXPL { get; set; }
        public double? RiskPAA_RatePL { get; set; }
        public double? RiskPAA_IRVolPL { get; set; }
        public double? RiskPAA_VolatilityPL { get; set; }
        public double? RiskPAA_VolGeoUndsPL { get; set; }
        public double? RiskPAA_VolThetaAdj { get; set; }
        public double? RiskPAA_BorrowCostPL { get; set; }
        public double? RiskPAA_DividendPL { get; set; }
        public double? RiskPAA_CrossGammaPL { get; set; }
        public double? RiskPAA_VarSwap { get; set; }
        public double? RiskPAA_VGVolAtm { get; set; }
        public double? RiskPAA_VGSkew { get; set; }
        public double? RiskPAA_VGSmile { get; set; }
        public double? RiskPAA_VGCallWingA { get; set; }
        public double? RiskPAA_VGCallWingB { get; set; }
        public double? RiskPAA_VGPutWingA { get; set; }
        public double? RiskPAA_VGPutWingB { get; set; }
        public double? RiskPAA_VGRefForward { get; set; }
        public double? NewTrades { get; set; }
        public double? DayTrading { get; set; }
        public double? Upsize_Downsize { get; set; }
        public double? IntradayTradingPL { get; set; }
        public double? TerminatedTrades { get; set; }
        public double? CommissionPL_DTD_T_1 { get; set; }
        public double? FairVsMktDiff { get; set; }
        public double? InterestPL_DTD_T_1 { get; set; }
        public double? DividendPL_DTD_T_1 { get; set; }
        public double? CouponPL_DTD_T_1 { get; set; }
        public double? ExtraordinaryPL_DTD_T_1 { get; set; }
        public double? NetAccruedInterest_DTD_T_1 { get; set; }
        public double? CreditPAA { get; set; }
        public double? SecurityChangePAA { get; set; }
        public double? Carry_Theta { get; set; }
        public double? SecurityChangePAA2 { get; set; }
        public double? Theta { get; set; }
        public double? IntradayTradingPLUSD { get; set; }
        public double? KOPL { get; set; }
        public double? TotalPAA { get; set; }
        public double? FairEconomicDTDS_T_1 { get; set; }
        public double Residual { get; set; }
        public double PercentageResidual { get; set; }
        public string StressingErrors { get; set; }
        public int? IsVIXModel { get; set; }
        public int? IsVanillaModel { get; set; }
        public double? FairValue_T_1 { get; set; }
        public double? FairValue_T_2 { get; set; }
        public string FinalCounterparty { get; set; }
        public int? SecurityId { get; set; }
        public double? RiskPAA_VGPutSlopeTW { get; set; }
        public double? RiskPAA_VGPutConvexityTW { get; set; }
        public double? RiskPAA_VGCallSlopeTW { get; set; }
        public double? RiskPAA_VGCallConvexityTW { get; set; }
        public int? IsTerminatedWithZeroFairValue { get; set; }
        public string VolGeoStressErrors { get; set; }
        public double? ExchangeFeesPLDTD_T_1 { get; set; }
        public double? OtherFeesPLDTD_T_1 { get; set; }
        public double? FairEconomicDTD_T_1 { get; set; }
        public double? AverageCost_T_2 { get; set; }
        public string AccountEntity { get; set; }
        public double? WeightedVega_T_2 { get; set; }
        public double? ModelResults_DVegaDSpot_T_2 { get; set; }
        public double? ModelResults_VolGamma_T_2 { get; set; }
        public double? ModelResults_BusDayTheta_T_2 { get; set; }
        public string Region { get; set; }
        public string PositionNode { get; set; }
        public string EodDate { get; set; }
        public int Row { get; set; }

        #endregion


        public Dictionary<int, string> DicIndexName { get; set; }

        public Dictionary<string, int> DicNameIndex { get; set; }

        public Dictionary<int, string> MapColumnIndex2Name(string [] columnHeader)
        {
            // TODO: can simplify it with IEnumerable.ToDictionary()
            Dictionary<int, string> colDic = new Dictionary<int, string>();
            for(int c = 0; c < columnHeader.Length; c++)
            {
                colDic.Add(c, columnHeader[c]);
            }

            DicIndexName = colDic;
            return colDic;
        }

        public Dictionary<string, int> MapColumnName2Index(Dictionary<int, string> dic)
        {
            Dictionary<string, int> dicNew = new Dictionary<string, int>();
            foreach(var pair in dic)
            {
                dicNew.Add(pair.Value, pair.Key);
            }

            DicNameIndex = dicNew;
            return dicNew;

        }

        public bool TrySetValueByName(string name, string value)
        {
            switch (name)
            {
                case "PositionId":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            PositionId = Int32.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("PositionId: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "Expiry":
                    Expiry = value;
                    break;

                case "CompoundPositionId":
                    CompoundPositionId = value;
                    break;

                case "Cusipv2":
                    Cusipv2 = value;
                    break;

                case "ComponentMnem":
                    ComponentMnem = value;
                    break;

                case "Strike":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            Strike = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Strike: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "PackageNumber":
                    PackageNumber = value;
                    break;

                case "SecurityType":
                    SecurityType = value;
                    break;

                case "PC":
                    PC = value;
                    break;

                case "SecurityCurrency":
                    SecurityCurrency = value;
                    break;

                case "ModelName":
                    ModelName = value;
                    break;

                case "Account":
                    Account = value;
                    break;

                case "AccountEntityCode":
                    AccountEntityCode = value;
                    break;

                case "UnderlyingPriceT_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            UnderlyingPriceT_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("UnderlyingPriceT_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "UnderlyingPriceT_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            UnderlyingPriceT_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("UnderlyingPriceT_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "Gamma_1_T_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            Gamma_1_T_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Gamma_1_T_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "Vega_1_T_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            Vega_1_T_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Vega_1_T_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "PV01_bp_T_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            PV01_bp_T_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("PV01_bp_T_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "CR01_T_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            CR01_T_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("CR01_T_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "Delta_T_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            Delta_T_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Delta_T_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "COB_Price_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            COB_Price_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("COB_Price_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "Quantity_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            Quantity_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Quantity_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "Quantity_T_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            Quantity_T_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Quantity_T_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "TradeQuantity":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            TradeQuantity = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("TradeQuantity: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "KOTrades":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            KOTrades = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("KOTrades: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_DeltaPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_DeltaPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_DeltaPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_GammaPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_GammaPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_GammaPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_FXDeltaPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_FXDeltaPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_FXDeltaPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_FXDelta_TradeCcyAdj":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_FXDelta_TradeCcyAdj = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_FXDelta_TradeCcyAdj: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_FXDelta_DTDSAdj":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_FXDelta_DTDSAdj = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_FXDelta_DTDSAdj: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_ASASPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_ASASPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_ASASPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_ASFXPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_ASFXPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_ASFXPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_RatePL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_RatePL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_RatePL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_IRVolPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_IRVolPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_IRVolPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VolatilityPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VolatilityPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VolatilityPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VolGeoUndsPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VolGeoUndsPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VolGeoUndsPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VolThetaAdj":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VolThetaAdj = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VolThetaAdj: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_BorrowCostPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_BorrowCostPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_BorrowCostPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_DividendPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_DividendPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_DividendPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_CrossGammaPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_CrossGammaPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_CrossGammaPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VarSwap":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VarSwap = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VarSwap: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VGVolAtm":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VGVolAtm = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VGVolAtm: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VGSkew":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VGSkew = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VGSkew: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VGSmile":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VGSmile = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VGSmile: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VGCallWingA":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VGCallWingA = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VGCallWingA: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VGCallWingB":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VGCallWingB = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VGCallWingB: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VGPutWingA":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VGPutWingA = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VGPutWingA: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VGPutWingB":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VGPutWingB = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VGPutWingB: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VGRefForward":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VGRefForward = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VGRefForward: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "NewTrades":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            NewTrades = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("NewTrades: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "DayTrading":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            DayTrading = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("DayTrading: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "Upsize_Downsize":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            Upsize_Downsize = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Upsize_Downsize: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "IntradayTradingPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            IntradayTradingPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("IntradayTradingPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "TerminatedTrades":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            TerminatedTrades = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("TerminatedTrades: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "CommissionPL_DTD_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            CommissionPL_DTD_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("CommissionPL_DTD_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "FairVsMktDiff":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            FairVsMktDiff = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("FairVsMktDiff: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "InterestPL_DTD_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            InterestPL_DTD_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("InterestPL_DTD_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "DividendPL_DTD_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            DividendPL_DTD_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("DividendPL_DTD_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "CouponPL_DTD_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            CouponPL_DTD_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("CouponPL_DTD_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "ExtraordinaryPL_DTD_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            ExtraordinaryPL_DTD_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ExtraordinaryPL_DTD_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "NetAccruedInterest_DTD_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            NetAccruedInterest_DTD_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("NetAccruedInterest_DTD_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "CreditPAA":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            CreditPAA = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("CreditPAA: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "SecurityChangePAA":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            SecurityChangePAA = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("SecurityChangePAA: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "Carry_Theta":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            Carry_Theta = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Carry_Theta: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "SecurityChangePAA2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            SecurityChangePAA2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("SecurityChangePAA2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "Theta":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            Theta = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Theta: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "IntradayTradingPLUSD":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            IntradayTradingPLUSD = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("IntradayTradingPLUSD: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "KOPL":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            KOPL = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("KOPL: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "TotalPAA":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            TotalPAA = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("TotalPAA: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "FairEconomicDTDS_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            FairEconomicDTDS_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("FairEconomicDTDS_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "Residual":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            Residual = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Residual: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "PercentageResidual":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            PercentageResidual = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("PercentageResidual: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "StressingErrors":
                    StressingErrors = value;
                    break;

                case "IsVIXModel":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            IsVIXModel = Int32.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("IsVIXModel: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "IsVanillaModel":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            int IsVanillaModel = Int32.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("IsVanillaModel: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "FairValue_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            FairValue_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("FairValue_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "FairValue_T_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            FairValue_T_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("FairValue_T_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "FinalCounterparty":
                    FinalCounterparty = value;
                    break;

                case "SecurityId":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            SecurityId = Int32.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("SecurityId: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VGPutSlopeTW":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VGPutSlopeTW = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VGPutSlopeTW: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VGPutConvexityTW":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VGPutConvexityTW = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VGPutConvexityTW: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VGCallSlopeTW":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VGCallSlopeTW = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VGCallSlopeTW: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "RiskPAA_VGCallConvexityTW":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            RiskPAA_VGCallConvexityTW = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("RiskPAA_VGCallConvexityTW: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "IsTerminatedWithZeroFairValue":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            IsTerminatedWithZeroFairValue = Int32.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("IsTerminatedWithZeroFairValue: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "VolGeoStressErrors":
                    VolGeoStressErrors = value;
                    break;

                case "ExchangeFeesPLDTD_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            ExchangeFeesPLDTD_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ExchangeFeesPLDTD_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "OtherFeesPLDTD_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            OtherFeesPLDTD_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("OtherFeesPLDTD_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "FairEconomicDTD_T_1":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            FairEconomicDTD_T_1 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("FairEconomicDTD_T_1: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "AverageCost_T_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            AverageCost_T_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("AverageCost_T_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "AccountEntity":
                    AccountEntity = value;
                    break;

                case "WeightedVega_T_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            WeightedVega_T_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("WeightedVega_T_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "ModelResults_DVegaDSpot_T_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            ModelResults_DVegaDSpot_T_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ModelResults_DVegaDSpot_T_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "ModelResults_VolGamma_T_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            ModelResults_VolGamma_T_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ModelResults_VolGamma_T_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "ModelResults_BusDayTheta_T_2":
                    if (!string.IsNullOrEmpty(value))
                    {
                        try
                        {
                            ModelResults_BusDayTheta_T_2 = Double.Parse(value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("ModelResults_BusDayTheta_T_2: " + e.Message);
                            return false;
                        }
                    }
                    break;

                case "Region":
                    Region = value;
                    break;

                case "PositionNode":
                    PositionNode = value;
                    break;

                case "EodDate":
                    EodDate = value;
                    break;

                default:
                    return false;
            }
            return true;

        }


        public string GetValueByIndex(int index)
        {
            if (DicIndexName == null)
            {
                Console.WriteLine("The Index to Name Dictionary is not set.");
                return null;
            }
                

            var name = DicIndexName[index];
            object value;            
            switch (name)
            {
                case "PositionId":
                    value = PositionId;
                    break;

                case "Expiry":
                    value = Expiry;
                    break;

                case "CompoundPositionId":
                    value = CompoundPositionId;
                    break;

                case "Cusipv2":
                    value = Cusipv2;
                    break;

                case "ComponentMnem":
                    value = ComponentMnem;
                    break;

                case "Strike":
                    value = Strike;
                    break;

                case "PackageNumber":
                    value = PackageNumber;
                    break;

                case "SecurityType":
                    value = SecurityType;
                    break;

                case "PC":
                    value = PC;
                    break;

                case "SecurityCurrency":
                    value = SecurityCurrency;
                    break;

                case "ModelName":
                    value = ModelName;
                    break;

                case "Account":
                    value = Account;
                    break;

                case "AccountEntityCode":
                    value = AccountEntityCode;
                    break;

                case "UnderlyingPriceT_2":
                    value = UnderlyingPriceT_2;
                    break;

                case "UnderlyingPriceT_1":
                    value = UnderlyingPriceT_1;
                    break;

                case "Gamma_1_T_2":
                    value = Gamma_1_T_2;
                    break;

                case "Vega_1_T_2":
                    value = Vega_1_T_2;
                    break;

                case "PV01_bp_T_2":
                    value = PV01_bp_T_2;
                    break;

                case "CR01_T_2":
                    value = CR01_T_2;
                    break;

                case "Delta_T_2":
                    value = Delta_T_2;
                    break;

                case "COB_Price_T_1":
                    value = COB_Price_T_1;
                    break;

                case "Quantity_T_1":
                    value = Quantity_T_1;
                    break;

                case "Quantity_T_2":
                    value = Quantity_T_2;
                    break;

                case "TradeQuantity":
                    value = TradeQuantity;
                    break;

                case "KOTrades":
                    value = KOTrades;
                    break;

                case "RiskPAA_DeltaPL":
                    value = RiskPAA_DeltaPL;
                    break;

                case "RiskPAA_GammaPL":
                    value = RiskPAA_GammaPL;
                    break;

                case "RiskPAA_FXDeltaPL":
                    value = RiskPAA_FXDeltaPL;
                    break;

                case "RiskPAA_FXDelta_TradeCcyAdj":
                    value = RiskPAA_FXDelta_TradeCcyAdj;
                    break;

                case "RiskPAA_FXDelta_DTDSAdj":
                    value = RiskPAA_FXDelta_DTDSAdj;
                    break;

                case "RiskPAA_ASASPL":
                    value = RiskPAA_ASASPL;
                    break;

                case "RiskPAA_ASFXPL":
                    value = RiskPAA_ASFXPL;
                    break;

                case "RiskPAA_RatePL":
                    value = RiskPAA_RatePL;
                    break;

                case "RiskPAA_IRVolPL":
                    value = RiskPAA_IRVolPL;
                    break;

                case "RiskPAA_VolatilityPL":
                    value = RiskPAA_VolatilityPL;
                    break;

                case "RiskPAA_VolGeoUndsPL":
                    value = RiskPAA_VolGeoUndsPL;
                    break;

                case "RiskPAA_VolThetaAdj":
                    value = RiskPAA_VolThetaAdj;
                    break;

                case "RiskPAA_BorrowCostPL":
                    value = RiskPAA_BorrowCostPL;
                    break;

                case "RiskPAA_DividendPL":
                    value = RiskPAA_DividendPL;
                    break;

                case "RiskPAA_CrossGammaPL":
                    value = RiskPAA_CrossGammaPL;
                    break;

                case "RiskPAA_VarSwap":
                    value = RiskPAA_VarSwap;
                    break;

                case "RiskPAA_VGVolAtm":
                    value = RiskPAA_VGVolAtm;
                    break;

                case "RiskPAA_VGSkew":
                    value = RiskPAA_VGSkew;
                    break;

                case "RiskPAA_VGSmile":
                    value = RiskPAA_VGSmile;
                    break;

                case "RiskPAA_VGCallWingA":
                    value = RiskPAA_VGCallWingA;
                    break;

                case "RiskPAA_VGCallWingB":
                    value = RiskPAA_VGCallWingB;
                    break;

                case "RiskPAA_VGPutWingA":
                    value = RiskPAA_VGPutWingA;
                    break;

                case "RiskPAA_VGPutWingB":
                    value = RiskPAA_VGPutWingB;
                    break;

                case "RiskPAA_VGRefForward":
                    value = RiskPAA_VGRefForward;
                    break;

                case "NewTrades":
                    value = NewTrades;
                    break;

                case "DayTrading":
                    value = DayTrading;
                    break;

                case "Upsize_Downsize":
                    value = Upsize_Downsize;
                    break;

                case "IntradayTradingPL":
                    value = IntradayTradingPL;
                    break;

                case "TerminatedTrades":
                    value = TerminatedTrades;
                    break;

                case "CommissionPL_DTD_T_1":
                    value = CommissionPL_DTD_T_1;
                    break;

                case "FairVsMktDiff":
                    value = FairVsMktDiff;
                    break;

                case "InterestPL_DTD_T_1":
                    value = InterestPL_DTD_T_1;
                    break;

                case "DividendPL_DTD_T_1":
                    value = DividendPL_DTD_T_1;
                    break;

                case "CouponPL_DTD_T_1":
                    value = CouponPL_DTD_T_1;
                    break;

                case "ExtraordinaryPL_DTD_T_1":
                    value = ExtraordinaryPL_DTD_T_1;
                    break;

                case "NetAccruedInterest_DTD_T_1":
                    value = NetAccruedInterest_DTD_T_1;
                    break;

                case "CreditPAA":
                    value = CreditPAA;
                    break;

                case "SecurityChangePAA":
                    value = SecurityChangePAA;
                    break;

                case "Carry_Theta":
                    value = Carry_Theta;
                    break;

                case "SecurityChangePAA2":
                    value = SecurityChangePAA2;
                    break;

                case "Theta":
                    value = Theta;
                    break;

                case "IntradayTradingPLUSD":
                    value = IntradayTradingPLUSD;
                    break;

                case "KOPL":
                    value = KOPL;
                    break;

                case "TotalPAA":
                    value = TotalPAA;
                    break;

                case "FairEconomicDTDS_T_1":
                    value = FairEconomicDTDS_T_1;
                    break;

                case "Residual":
                    value = Residual;
                    break;

                case "PercentageResidual":
                    value = PercentageResidual;
                    break;

                case "StressingErrors":
                    value = StressingErrors;
                    break;

                case "IsVIXModel":
                    value = IsVIXModel;
                    break;

                case "IsVanillaModel":
                    value = IsVanillaModel;
                    break;

                case "FairValue_T_1":
                    value = FairValue_T_1;
                    break;

                case "FairValue_T_2":
                    value = FairValue_T_2;
                    break;

                case "FinalCounterparty":
                    value = FinalCounterparty;
                    break;

                case "SecurityId":
                    value = SecurityId;
                    break;

                case "RiskPAA_VGPutSlopeTW":
                    value = RiskPAA_VGPutSlopeTW;
                    break;

                case "RiskPAA_VGPutConvexityTW":
                    value = RiskPAA_VGPutConvexityTW;
                    break;

                case "RiskPAA_VGCallSlopeTW":
                    value = RiskPAA_VGCallSlopeTW;
                    break;

                case "RiskPAA_VGCallConvexityTW":
                    value = RiskPAA_VGCallConvexityTW;
                    break;

                case "IsTerminatedWithZeroFairValue":
                    value = IsTerminatedWithZeroFairValue;
                    break;

                case "VolGeoStressErrors":
                    value = VolGeoStressErrors;
                    break;

                case "ExchangeFeesPLDTD_T_1":
                    value = ExchangeFeesPLDTD_T_1;
                    break;

                case "OtherFeesPLDTD_T_1":
                    value = OtherFeesPLDTD_T_1;
                    break;

                case "FairEconomicDTD_T_1":
                    value = FairEconomicDTD_T_1;
                    break;

                case "AverageCost_T_2":
                    value = AverageCost_T_2;
                    break;

                case "AccountEntity":
                    value = AccountEntity;
                    break;

                case "WeightedVega_T_2":
                    value = WeightedVega_T_2;   
                    break;

                case "ModelResults_DVegaDSpot_T_2":
                    value = ModelResults_DVegaDSpot_T_2;
                    break;

                case "ModelResults_VolGamma_T_2":
                    value = ModelResults_VolGamma_T_2;
                    break;

                case "ModelResults_BusDayTheta_T_2":
                    value = ModelResults_BusDayTheta_T_2;                  
                    break;

                case "Region":
                    value = Region;
                    break;

                case "PositionNode":
                    value = PositionNode;
                    break;

                case "EodDate":
                    value = EodDate;
                    break;

                case "Row":
                    value = Row;
                    break;

                default:
                    value = string.Empty;
                    break;
            }
            return value?.ToString();
        }

        public string GetValueByIndex(int index, Dictionary<int, string> dic)
        {
            DicIndexName = dic;
            return GetValueByIndex(index);
        }

        public string[] GetAllValues()
        {
            var dic = DicRegionCol[Region];
            string[] values = new string[dic.Count];
            for(int i = 0; i < dic.Count; i++)
            {
                values[i] = GetValueByIndex(i, dic);
            }
            return values;
        }
    }
}

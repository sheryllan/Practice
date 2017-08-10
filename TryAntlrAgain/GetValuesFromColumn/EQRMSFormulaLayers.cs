using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TryAntlrAgain;

namespace GetValuesFromColumn
{
    public class EQRMSFormulaLayers
    {
        public readonly Dictionary<string, string> RawEQRMSFormulas = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            #region 97 lines dictionary
            //{ "Calculating MMult",  "IF(OR(\"Quantity T-1\"=0,\"COB Price T-1\"=0),\"Fair Value T-2 <DFX>\"/\"Quantity T-2\"/\"Fair Price T-2\",\"Fair Value T-1 <DFX>\"/\"Quantity T-1\"/\"COB Price T-1\")" },
            //{ "Calculating MMult Spot", "IF(\"Quantity T-1\"=0,IF(\"Cash Delta T-2\"=0,\"PV01 /bp T-2 <DFX>\"/\"Quantity T-2\"/\"Unit PV01 /bp T-2\",\"Delta T-2 <DFX>\"/\"Quantity T-2\"/\"Cash Delta T-2\"),IF(\"Cash Delta T-1\"=0,\"PV01ScalingFactorT1\",\"Delta T-1 <DFX>\"/\"Quantity T-1\"/\"Cash Delta T-1\"))" },
            //{ "PV01ScalingFactorT1",    "\"PV01 /bp T-1 <DFX>\"/\"Quantity T-1\"/\"Unit PV01 /bp T-1\"" },
            //{ "MMult",  "IF(ISERROR(\"Calculating MMult\"),\"Multiplier T-1\",\"Calculating MMult\")" },
            //{ "MMultSpot",  "IF(ISERROR(\"Calculating MMult Spot\"),\"Multiplier T-1\",\"Calculating MMult Spot\")" },
            //{ "Quantity for PAA",   "IF(\"IsTerminatedWithZeroFairValue\",0,IF(\"External Source\"=\"PFS\",1,\"MMult\" * \"Quantity T-2\"))" },
            //{ "Quantity for Spot",  "IF(\"IsTerminatedWithZeroFairValue\",0,IF(\"External Source\"=\"PFS\",1,\"MMultSpot\" * \"Quantity T-2\"))" },
            //{ "Trade Quantity", "\"Quantity T-1\"-\"Quantity T-2\"" },
            //{ "KO Trades",  "IF(\"IsKOEvent\"=\"yes\",\"Fair Economic (DTD T-1) <USD>\"-\"InterRiskPAA: Delta PLest PL (DTD T-1) <USD>\"-\"Intraday Trading PL USD\"-\"Fair-Vs-Mkt Diff\"-\"Dividend PL (DTD T-1) <USD>\",0)" },
            //{ "RiskPAA: Delta PL",  "\"Risk PAA: Delta PL T-1 <USD>\"*\"Quantity for Spot\"*\"KO Multiplier\"" },
            //{ "RiskPAA: Gamma PL",  "\"Risk PAA: Gamma PL T-1 <USD>\"*\"Quantity for Spot\"*\"KO Multiplier\"" },
            //{ "RiskPAA: FX Delta PL",   "\"Risk PAA: FX Delta PL T-1 <USD>\"*\"Quantity for Spot\"*\"KO Multiplier\"" },
            //{ "FXDelta(TradeCcyAdj)",   "IF(\"Security Type\"=\"Currency\",0,IF(OR(\"P&L FX /USD T-1\"=1,\"Fair Economic (DTD T-1) <USD>\"=0, \"Quantity T-2\"=0),0,(\"Fair Value T-2 <USD>\"/\"P&L FX /USD T-2\")*(\"P&L FX /USD T-1\"-\"P&L FX /USD T-2\")))*\"KO Multiplier\"" },
            //{ "FXDelta(DTDSAdj)",   "\"Fair Economic (DTDS T-1) <USD>\"-\"Fair Economic (DTD T-1) <USD>\"" },
            //{ "RiskPAA: ASAS PL",   "\"Risk PAA: Correlation PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: ASFX PL",   "\"Risk PAA: FX Correlation PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: Rate PL",   "\"Risk PAA: Rate PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: IR Vol PL", "\"Risk PAA: IR Vol PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: Volatility PL", "(\"Risk PAA: Equity Vega PL T-1 <USD>\"+\"Risk PAA: Skew Vega PL T-1 <USD>\")*\"WarrantMultiplier\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VolGeo Unds PL",    "\"RiskPAA: VG VolAtm\"+\"RiskPAA: VG Skew\"+\"RiskPAA: VG Smile\"+\"RiskPAA: VG PutWingA\"+\"RiskPAA: VG PutWingB\"+\"RiskPAA: VG CallWingA\"+\"RiskPAA: VG CallWingB\"+\"RiskPAA: VG RefForward\"+\"VolGeoSWParams\"" },
            //{ "VolGeoSWParams", "\"RiskPAA: VG PutSlopeTW\"+\"RiskPAA: VG PutConvexityTW\"+\"RiskPAA: VG CallSlopeTW\"+\"RiskPAA: VG CallConvexityTW\"" },
            //{ "Risk PAA: VolThetaAdj",  "\"Risk PAA: Theta Vol Adjustment T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: BorrowCostPL",  "\"Risk PAA: Borrow Cost PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: Dividend PL",   "\"Risk PAA: Dividend PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: CrossGammaPL",  "\"Risk PAA: Cross Gamma PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VarSwap",   "\"Risk PAA: VaR Swap Basis PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG VolAtm", "\"Risk PAA: VolGeo Vol Atm PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG Skew",   "\"Risk PAA: VolGeo Skew PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG Smile",  "\"Risk PAA: VolGeo Smile PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG CallWingA",  "\"Risk PAA: VolGeo Call Wing A PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG CallWingB",  "\"Risk PAA: VolGeo Call Wing B PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG PutWingA",   "\"Risk PAA: VolGeo Put Wing A PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG PutWingB",   "\"Risk PAA: VolGeo Put Wing B PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG RefForward", "\"Risk PAA: VolGeo Ref Forward PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "New Trades", "if(and(\"Quantity T-2\"=0,\"Quantity T-1\"!=0),\"Intraday Trading PL USD\",0)" },
            //{ "Day Trading",    "if(and(\"Quantity T-2\"=\"Quantity T-1\"),\"Intraday Trading PL USD\",0)" },
            //{ "Upsize / Downsize",  "if(and(\"Quantity T-2\"!=0,\"Quantity T-1\"!=0,\"Quantity T-2\"!=\"Quantity T-1\"),\"Intraday Trading PL USD\",0)" },
            //{ "Intraday Trading P&L",   "\"Intraday Trading PL USD\"" },
            //{ "Terminated Trades",  "if(\"IsTerminated\",IF(\"IsTerminatedWithZeroFairValue\", \"Intraday Trading PL (DTD T-1) <USD> <PAA Style>\", \"Intraday Trading PL (DTD T-1) <USD> <Trader Style>\"),0)" },
            //{ "Total Risk PAA", "\"Total Risk PAA1\"+\"RiskPAA: VolGeo Unds PL\"" },
            //{ "Total Risk PAA1",    "\"RiskPAA: Delta PL\"+\"RiskPAA: Gamma PL\"+\"RiskPAA: FX Delta PL\"+\"RiskPAA: Rate PL\"+\"RiskPAA: ASAS PL\"+\"RiskPAA: ASFX PL\"+\"RiskPAA: IR Vol PL\"+\"RiskPAA: Volatility PL\"+\"RiskPAA: BorrowCostPL\"+\"RiskPAA: Dividend PL\"+\"RiskPAA: CrossGammaPL\"+\"RiskPAA: VarSwap\"" },
            //{ "Non Model PL",   "\"Interest PL (DTD T-1) <USD>\"+if(AND(\"Security Type\" = \"EquitySwap\",\"HasTplusData\"=1),0,\"Dividend PL (DTD T-1) <USD>\")+IF(OR(\"Coupon PL (DTD T-1) <USD>\"=\"Intraday Trading P&L\",\"HasTplusData\"=1),0,\"Coupon PL (DTD T-1) <USD>\")+\"Net Accrued Interest (DTD T-1) <USD>\"" },
            //{ "Fair-Vs-Mkt Diff",   "if(and(\"Security Type\"=\"InterestRateFuture\",\"Security Currency\"=\"AUD\"),0, if(OR(\"Security Type\"=\"BondFuture\",\"Security Type\"=\"InterestRateFuture\"),\"Fair-Vs-Mkt Diff 1\",0))" },
            //{ "Fair-Vs-Mkt Diff 1", "\"Quantity for PAA\"*((\"Fair Price T-1\"-\"Fair Price T-2\")/\"Sec FX /USD [-1]\"-(\"Factor Stress: Fair T-1 <USD>\"-\"Factor Stress: Prior Fair T-1 <USD>\"))" },
            //{ "Credit PAA", "0" },
            //{ "Security Change PAA",    "\"Quantity for PAA\"*(\"Factor Stress: Prior Fair Recalc T-1 <USD>\"-\"Factor Stress: Prior Fair T-1 <USD>\")" },
            //{ "Carry| Theta",   "\"Quantity for PAA\"*if(\"HasTplusData\"=1,\"Risk PAA: Theta PL T-1 <USD>\",\"Factor Stress: Theta PL T-1 <USD>\")*if(and(\"SecTypeId\"=130,\"Quantity T-1\"<>0,\"Quantity T-2\"=0),0,1)" },
            //OLD{ "Security Change PAA*",   "IF(AND(OR(\"Factor Stress: Prior Fair T-1 <USD>\"=0,\"Factor Stress: Prior Fair Recalc T-1 <USD>\"=0),\"Security Type\"<>\"InterestRateSwap\"),0,\"Security Change PAA\")*\"KO Multiplier\"" },
            //{ "Security Change PAA*",   "IF(AND(OR(\"Factor Stress: Prior Fair T-1 <USD>\"=0,\"Factor Stress: Prior Fair Recalc T-1 <USD>\"=0),\"Security Type\"<>\"InterestRateSwap\"),0,\"Security Change PAA\")*\"KO Multiplier\"" },
            //{ "Theta",  "(\"Carry| Theta\"+\"Non Model PL\"-\"Interest PL (DTD T-1) <USD>\"+if(\"IsTodayPastModels\"=1,\"Coupon PL (DTD T-1) <USD>\"+\"Dividend PL (DTD T-1) <USD>\",0))*\"KO Multiplier\"" },
            //{ "FXAdjustment",   "\"FXDelta(DTDSAdj)\"+\"FXDelta(TradeCcyAdj)\"" },
            //{ "Intraday Trading PL USD",    "IF(\"IsTerminatedWithZeroFairValue\",\"Intraday Trading PL (DTD T-1) <USD> <PAA Style>\",\"Intraday Trading PL (DTD T-1) <USD> <Trader Style>\")+if(\"SecTypeId\"=130,\"PfsCfAdj\",0)" },
            //{ "KOModels1",  "IF(OR(\"Model Name T-1\"=\"Barrier\",\"Model Name T-1\"=\"BarrierDupireLVPDE\",\"Model Name T-1\"=\"DCBarrier\",\"Model Name T-1\"=\"RankedBasketBarrierNote\",\"Model Name T-1\"=\"StructNote\"),1,0)" },
            //{ "KOModels2",  "IF(\"Model Name T-1\"=\"RankedBasketBarrierNoteMCPathsDupireLocalVolMonteCarlo\",1,0)" },
            //{ "IsKOEvent",  "IF(AND(\"CheckKOFlag\"=1,\"Model Name T-1\"=\"StopLossOpenEnd\"),\"yes\",IF(AND(\"CheckKOFlag\"=1,\"Generic Data inOrOut\"=\"out\",OR(\"KOModels1\"=1,\"KOModels2\"=1)),\"yes\",\"no\"))" },
            //{ "KO Multiplier",  "If(\"IsKOEvent\"=\"yes\",0,1)" },
            //{ "CheckKOFlag",    "IF(OR(\"Generic Data KnockedThrough\"=\"yes\",\"Generic Data KnockedThrough\"=\"TRUE\",\"Generic Data KnockedThrough\"=1),1,0)" },
            //{ "KO PL",  "IF(\"IsKOEvent\"=\"yes\",\"Fair Economic (DTD T-1) <USD>\"-\"Interest PL (DTD T-1) <USD>\"-\"Intraday Trading PL (DTD T-1) <USD> <PAA Style>\"-\"Fair-Vs-Mkt Diff\"-\"Dividend PL (DTD T-1) <USD>\",0)" },
            //{ "Total PAA",  "\"Total PAA1\"+\"Exchange Fees PL (DTD T-1) <USD>\"+\"Other Fees PL (DTD T-1) <USD>\"" },
            //{ "Total PAA1", "\"Total Risk PAA\"+\"Security Change PAA*\"+\"Intraday Trading PL USD\"+\"Theta\"+\"Fair-Vs-Mkt Diff\"+\"Risk PAA: VolThetaAdj\"+\"Interest PL (DTD T-1) <USD>\"+\"KO PL\"+\"FXAdjustment\"+\"Extraordinary PL (DTD T-1) <USD>\"+\"Commission PL (DTD T-1) <USD>\"+ \"Credit PAA\"" },
            //{ "Residual",   "\"Fair Economic (DTDS T-1) <USD>\"-\"Total PAA\"" },
            //{ "Sec FX /USD [-1]",   "if(\"Security FX /USD T-1\"<>0,\"Security FX /USD T-1\",1)" },
            //{ "%Residual",  "IF(AND(\"Fair Economic (DTDS T-1) <USD>\"<0.5,\"Fair Economic (DTDS T-1) <USD>\">-0.5),0,(\"Residual\"/\"Fair Economic (DTDS T-1) <USD>\"))" },
            ////{ "stressError",    "eqlookup(\"Position Id\",1,20004511,1)" },
            //{ "Stressing Errors",   "IF(\"stressError\"=\"Not Found\", \"N\", \"Y\")" },
            //{ "IsVIXModel", "if (OR(\"IsVIXModels1\"=1,\"IsVIXModels2\"=1), 1,0)" },
            //{ "IsVIXModels1",   "if (OR(\"Model Name T-2\"=\"VolFutureEuropeanVIFFVAnalytic\",\"Model Name T-2\"=\"VolFutureContractVIFFAnalytic\",\"Model Name T-2\"=\"VolFutureEuropeanCalibratedVIFFVAnalytic\",\"Model Name T-2\"=\"VolFutureContractCalibratedVIFFAnalytic\"), 1,0)" },
            //{ "IsVIXModels2",   "if (OR(\"Model Name T-2\"=\"RollingBasketVolFutureSpotAnalytic\",\"Model Name T-2\"=\"RollingBasketVolFutureAmericanFVA\",\"Model Name T-2\"=\"RollingBasketVolFutureEuropeanFVA\"), 1,0)" },
            ////{ "IsVanillaModel", "if (eqlookup(\"Position Id\",0,94633,2) = \"Not Found\", 0,1)" },
            //{ "Active Trade",   "IF(\"Fair Economic (DTDS T-1) <USD>\"=0,\"No\",\"Yes\")" },
            //{ "IsTodayPastModels",  "if(AND(\"HasTplusData\"=1,OR(\"Model Name T-2\"=\"MarginLoan\",\"Model Name T-2\"=\"CBModel\",\"Model Name T-2\"=\"Mandatory\")),1,0)" },
            //{ "WarrantMultiplier",  "if(AND(\"Security Class\"=\"Covered\",\"HasTplusData\"=1),\"Multiplier T-1\",1)" },
            //{ "HasTplusData",   "if (\"Risk PAA: TPlus Stress Missing T-1\" != 0,0,1)" },
            //{ "IsPfsCBFut", "and(\"SecTypeId\"=130,or(\"Underlying Type\"=\"ConvertibleBond\",\"Underlying Type\"=\"Future\"))" },
            //{ "DeltaAdj",   "if(and(\"SecTypeId\"=130,isnumber(\"Underlying Price T-1 <Position>\"),isnumber(\"Underlying Price T-2 <Position>\")),(\"Underlying Price T-1 <Position>\"-\"Underlying Price T-2 <Position>\")*\"Quantity T-2\"/if(\"Underlying FX /USD T-1\"=0,1,\"Underlying FX /USD T-1\"),0)" },
            //{ "EqFV USD[-1]",   "if(\"NoUndPriceOnT-1\",0,(\"Underlying Price T-1 <Position>\"-\"Average Cost T-1\")*\"Quantity T-1\"/if(\"Underlying FX /USD T-1\"=0,1,\"Underlying FX /USD T-1\"))" },
            //{ "EqFV USD[-2]",   "if(\"NoUndPriceOnT-2\",0,(\"Underlying Price T-2 <Position>\"-\"Average Cost T-2\")*\"Quantity T-2\"/if(\"Underlying FX /USD T-2\"=0,1,\"Underlying FX /USD T-2\"))" },
            //{ "NoUndPriceOnT-1",    "or(eqisnan(\"Underlying Price T-1 <Position>\"),not(isnumber(\"Underlying Price T-1 <Position>\")),\"Underlying Price T-1 <Position>\"=0)" },
            //{ "NoUndPriceOnT-2",    "or(eqisnan(\"Underlying Price T-2 <Position>\"),not(isnumber(\"Underlying Price T-2 <Position>\")),\"Underlying Price T-2 <Position>\"=0)" },
            //{ "PfsCfAdj1",  "\"PFS Unrealised CF DTD Amount T-1 <USD> <Distribution>\"+\"PFS Unrealised CF DTD Amount T-1 <USD> <Reset>\"-\"PFS Realised CF DTD Amount T-1 <USD> <Distribution>\"-if(\"Coupon PL (DTD T-1) <USD>\"=0.0,\"PFS Realised CF DTD Amount T-1 <USD> <Reset>\",0.0)" },
            //{ "PfsCfAdj2",  "if(and(\"SecTypeId\"=130,\"Quantity T-1\"=0,\"Quantity T-2\"=0),\"PFS RCF DTD Total T-1 <USD>\"-\"PFS Realised CF DTD Amount T-1 <USD> <Distribution>\"-\"PFS Realised CF DTD Amount T-1 <USD> <Reset>\",0)" },
            //{ "PfsCfAdj3",  "if(and(\"SecTypeId\"=130,\"Quantity T-1\"=0,\"Quantity T-2\"=0,\"PfsCfAdj2\"!=0,abs((\"Carry| Theta\"+\"PFS RCF DTD Total T-1 <USD>\")/if(\"PFS RCF DTD Total T-1 <USD>\"=0,1,\"PFS RCF DTD Total T-1 <USD>\"))<0.01),\"PFS RCF DTD Total T-1 <USD>\",0)" },
            //{ "PfsCfAdj4",  "if(\"SecTypeId\"=130,if(and(\"Quantity T-2\"!=0,\"Delta T-2 <DFX>\"=0,\"NoUndPriceOnT-2\"=0),\"EqFV USD[-2]\",if(and(\"Quantity T-1\"!=0,\"Delta T-1 <DFX>\"=0,\"NoUndPriceOnT-1\"=0),-\"EqFV USD[-1]\",0)),0)" },
            //{ "PfsSecChngAdj",  "\"PFS Realised CF Sudden DTD Total T-1 <USD>\"-\"PFS Unrealised CF Sudden Total T-1 <USD>\"" },
            //{ "PfsCfAdj",   "\"PfsCfAdj1\"+\"PfsSecChngAdj\"+if(and(\"RiskPAA: Delta PL\"=0,\"NoUndPriceOnT-1\"=0,\"NoUndPriceOnT-2\"=0),\"DeltaAdj\",0)+\"PfsCfAdj3\"+\"PfsCfAdj4\"" },
            //{ "DeltaDiff",  "\"RiskPAA: Delta PL\"-\"DeltaAdj\"" },
            //{ "IsLargeResidual",    "and(abs(\"Residual\")>=10000,abs(\"%Residual\")>=0.1)" },
            //{ "MissingDeltaPL", "and(\"Quantity T-2\"<>0,int(\"RiskPAA: Delta PL\")=0)" },
            //{ "WrongDeltaPL",   "and(\"Quantity T-2\"<>0,abs(\"DeltaDiff\"/if(\"RiskPAA: Delta PL\"=0,1,\"RiskPAA: Delta PL\"))>0.05)" },
            //{ "IsTerminated",   "AND(\"Quantity T-2\"!=0,\"Quantity T-1\"=0)" },
            //{ "Outstanding Payments",   "\"Outstanding Payments T-1 <Equity Leg>\"+\"Outstanding Payments T-1 <Libor Leg>\"+\"Outstanding Payments T-1 <Dividend Leg>\""},
            //{ "RiskPAA: VG PutSlopeTW", "\"Risk PAA: VolGeo Put Slope TW PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG PutConvexityTW", "\"Risk PAA: VolGeo Put Convexity TW PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG CallSlopeTW",    "\"Risk PAA: VolGeo Call Slope TW PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG CallConvexityTW",    "\"Risk PAA: VolGeo Call Convexity TW PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "IsTerminatedWithZeroFairValue",  "if(AND(OR(\"IsVIXModel\"=1,AND(\"COB Price T-1\"=0,NOT(OR(\"Security Type\" = \"Option\", \"Security Type\" = \"ExoticOption\"))),AND(\"Security Type\"=\"EquitySwap\",\"Outstanding Payments\"<>0)),\"IsTerminated\"),1, 0)" },
            //{ "volGeoError",    "eqlookup(\"Position Id\",1, 20004533,1)" },
            //{ "Vol Geo Stress Errors",  "IF(\"volGeoError\"=\"Not Found\", \"N\", \"Y\")" }
            #endregion
        };
        private readonly  Dictionary<string, string>  Layer11 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Residual",   "\"Fair Economic (DTDS T-1) <USD>\"-\"Total PAA\"" },
            //{ "%Residual",  "IF(AND(\"Fair Economic (DTDS T-1) <USD>\"<0.5,\"Fair Economic (DTDS T-1) <USD>\">-0.5),0,(\"Residual\"/\"Fair Economic (DTDS T-1) <USD>\"))" },
        };

        private readonly Dictionary<string, string> Layer10 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Total PAA",  "\"Total PAA1\"+\"Exchange Fees PL (DTD T-1) <USD>\"+\"Other Fees PL (DTD T-1) <USD>\"" }
        };
        private readonly Dictionary<string, string> Layer9 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Total PAA1", "\"Total Risk PAA\"+\"Security Change PAA*\"+\"Intraday Trading PL USD\"+\"Theta\"+\"Fair-Vs-Mkt Diff\"+\"Risk PAA: VolThetaAdj\"+\"Interest PL (DTD T-1) <USD>\"+\"KO PL\"+\"FXAdjustment\"+\"Extraordinary PL (DTD T-1) <USD>\"+\"Commission PL (DTD T-1) <USD>\"+\"Credit PAA\"" },
            //{ "New Trades", "if(and(\"Quantity T-2\"=0,\"Quantity T-1\"!=0),\"Intraday Trading PL USD\",0)" },
            //{ "Day Trading",    "if(and(\"Quantity T-2\"=\"Quantity T-1\"),\"Intraday Trading PL USD\",0)" },
            //{ "Upsize / Downsize",  "if(and(\"Quantity T-2\"!=0,\"Quantity T-1\"!=0,\"Quantity T-2\"!=\"Quantity T-1\"),\"Intraday Trading PL USD\",0)" },
            
        };
        private readonly Dictionary<string, string> Layer8 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Total Risk PAA", "\"Total Risk PAA1\"+\"RiskPAA: VolGeo Unds PL\"" }, //APAC = Risk PAA: VolGeo Unds PL || EMEA/NAM = RiskPAA: VolGeo Unds PL
            //{ "Security Change PAA*", "IF(AND(OR(\"Factor Stress: Prior Fair T-1 <USD>\"=0,\"Factor Stress: Prior Fair Recalc T-1 <USD>\"=0),\"Security Type\"<>\"InterestRateSwap\"),0,\"Security Change PAA\")*\"KO Multiplier\"" },            
            { "Theta",  "(\"Carry| Theta\"+\"Non Model PL\"-\"Interest PL (DTD T-1) <USD>\"+if(\"IsTodayPastModels\"=1,\"Coupon PL (DTD T-1) <USD>\"+\"Dividend PL (DTD T-1) <USD>\",0))*\"KO Multiplier\"+\"PfsThetaAdj\"" }, //EMEA ONLY
            //{ "Theta",  "(\"Carry| Theta\"+\"Non Model PL\"-\"Interest PL (DTD T-1) <USD>\"+if(\"IsTodayPastModels\"=1,\"Coupon PL (DTD T-1) <USD>\"+\"Dividend PL (DTD T-1) <USD>\",0)+\"DividendToday\")*\"KO Multiplier\"+\"PfsThetaAdj\"" }, //NAM & APAC ONLY
        };
        private readonly Dictionary<string, string> Layer7 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Non Model PL",   "\"Interest PL (DTD T-1) <USD>\"+if(AND(\"Security Type\"=\"EquitySwap\",\"HasTplusData\"=1),0,\"Dividend PL (DTD T-1) <USD>\")+IF(OR(\"Coupon PL (DTD T-1) <USD>\"=\"Intraday Trading P&L\",\"HasTplusData\"=1),0,\"Coupon PL (DTD T-1) <USD>\")+\"Net Accrued Interest (DTD T-1) <USD>\"+\"PfsNModelPlAdj\"" }, //
        };
        private readonly Dictionary<string, string> Layer6 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "Total Risk PAA1", "\"RiskPAA: Delta PL\"+\"RiskPAA: Gamma PL\"+\"RiskPAA: FX Delta PL\"+\"RiskPAA: Rate PL\"+\"RiskPAA: ASAS PL\"+\"RiskPAA: ASFX PL\"+\"RiskPAA: IR Vol PL\"+\"RiskPAA: Volatility PL\"+\"RiskPAA: BorrowCostPL\"+\"RiskPAA: Dividend PL\"+\"RiskPAA: CrossGammaPL\"+\"RiskPAA: VarSwap\"" },
            //{ "Carry| Theta",   "\"Quantity for PAA\"*if(\"HasTplusData\"=1,\"Risk PAA: Theta PL T-1 <USD>\",\"Factor Stress: Theta PL T-1 <USD>\")*if(and(\"SecTypeId\"=130,\"Quantity T-1\"<>0,\"Quantity T-2\"=0),0,1)" },
            //{ "DeltaDiff",  "\"RiskPAA: Delta PL\"-\"DeltaAdj\"" },
          //{ "FXAdjustment",   "\"FXDelta(DTDSAdj)\"+\"FXDelta(TradeCcyAdj)\"" },
        };
        private readonly Dictionary<string, string> Layer5 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            //{ "HasTplusData",   "if (\"Risk PAA: TPlus Stress Missing T-1\" != 0,0,1)" },
            //{ "RiskPAA: Delta PL",  "\"Risk PAA: Delta PL T-1 <USD>\"*\"Quantity for Spot\"*\"KO Multiplier\"+\"DeltaAdj\"" },
            { "RiskPAA: Delta PL",  "if(and(\"SecTypeId\"=130,\"Risk PAA: Delta PL T-1 <USD>\"*\"Quantity for Spot\"*\"KO Multiplier\"=0.0),\"DeltaAdj\",\"Risk PAA: Delta PL T-1 <USD>\"*\"Quantity for Spot\"*\"KO Multiplier\")" },
            //{ "RiskPAA: Gamma PL",  "\"Risk PAA: Gamma PL T-1 <USD>\"*\"Quantity for Spot\"*\"KO Multiplier\"" },
            //{ "RiskPAA: FX Delta PL",   "\"Risk PAA: FX Delta PL T-1 <USD>\"*\"Quantity for Spot\"*\"KO Multiplier\"" },
            //{ "FXDelta(TradeCcyAdj)",   "IF(\"Security Type\"=\"Currency\",0,IF(OR(\"P&L FX /USD T-1\"=1,\"Fair Economic (DTD T-1) <USD>\"=0, \"Quantity T-2\"=0),0,(\"Fair Value T-2 <USD>\"/\"P&L FX /USD T-2\")*(\"P&L FX /USD T-1\"-\"P&L FX /USD T-2\")))*\"KO Multiplier\"" },
            //{ "RiskPAA: ASAS PL",   "\"Risk PAA: Correlation PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: ASFX PL",   "\"Risk PAA: FX Correlation PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: Rate PL",   "\"Risk PAA: Rate PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: IR Vol PL", "\"Risk PAA: IR Vol PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: Volatility PL", "(\"Risk PAA: Equity Vega PL T-1 <USD>\"+\"Risk PAA: Skew Vega PL T-1 <USD>\")*\"WarrantMultiplier\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VolGeo Unds PL",    "\"RiskPAA: VG VolAtm\"+\"RiskPAA: VG Skew\"+\"RiskPAA: VG Smile\"+\"RiskPAA: VG PutWingA\"+\"RiskPAA: VG PutWingB\"+\"RiskPAA: VG CallWingA\"+\"RiskPAA: VG CallWingB\"+\"RiskPAA: VG RefForward\"+\"VolGeoSWParams\"" },
            //{ "Risk PAA: VolThetaAdj",  "\"Risk PAA: Theta Vol Adjustment T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: BorrowCostPL",  "\"Risk PAA: Borrow Cost PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: Dividend PL",   "\"Risk PAA: Dividend PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: CrossGammaPL",  "\"Risk PAA: Cross Gamma PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VarSwap",   "\"Risk PAA: VaR Swap Basis PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG VolAtm", "\"Risk PAA: VolGeo Vol Atm PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG Skew",   "\"Risk PAA: VolGeo Skew PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG Smile",  "\"Risk PAA: VolGeo Smile PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG CallWingA",  "\"Risk PAA: VolGeo Call Wing A PL T-1 <USD>\"*\"Quantity for PAA\"*\"KSO Multiplier\"" },
            //{ "RiskPAA: VG CallWingB",  "\"Risk PAA: VolGeo Call Wing B PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG PutWingA",   "\"Risk PAA: VolGeo Put Wing A PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG PutWingB",   "\"Risk PAA: VolGeo Put Wing B PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG RefForward", "\"Risk PAA: VolGeo Ref Forward PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG PutSlopeTW", "\"Risk PAA: VolGeo Put Slope TW PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG PutConvexityTW", "\"Risk PAA: VolGeo Put Convexity TW PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG CallSlopeTW",    "\"Risk PAA: VolGeo Call Slope TW PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
            //{ "RiskPAA: VG CallConvexityTW",    "\"Risk PAA: VolGeo Call Convexity TW PL T-1 <USD>\"*\"Quantity for PAA\"*\"KO Multiplier\"" },
        };
        private readonly Dictionary<string, string> Layer4 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            
        };
        private readonly Dictionary<string, string> Layer3 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            //{ "Quantity for PAA",   "IF(\"IsTerminatedWithZeroFairValue\",0,IF(\"External Source\"=\"PFS\",1,\"MMult\" * \"Quantity   T-2\"))" },
            //{ "Quantity for Spot",  "IF(\"IsTerminatedWithZeroFairValue\",0,IF(\"External Source\"=\"PFS\",1,\"MMultSpot\" * \"Quantity T-2\"))" },
            //{ "KO Multiplier",  "If(\"IsKOEvent\"=\"yes\",0,1)" },
            //{ "KO Trades",  "IF(\"IsKOEvent\"=\"yes\",\"Fair Economic (DTD T-1) <USD>\"-\"Interest PL (DTD T-1) <USD>\"-\"Intraday Trading PL USD\"-\"Fair-Vs-Mkt Diff\"-\"Dividend PL (DTD T-1) <USD>\",0)" },
            { "Intraday Trading P&L",   "\"Intraday Trading PL USD\"" },
        };
        private readonly Dictionary<string, string> Layer2 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            //{ "MMult",  "IF(ISERROR(\"Calculating MMult\"),\"Multiplier T-1\",\"Calculating MMult\")" },
            //{ "MMultSpot",  "IF(ISERROR(\"Calculating MMult Spot\"),\"Multiplier T-1\",\"Calculating MMult Spot\")" },
            //{ "IsKOEvent",  "IF(AND(\"CheckKOFlag\"=1,\"Model Name T-1\"=\"StopLossOpenEnd\"),\"yes\",IF(AND(\"CheckKOFlag\"=1,\"Generic Data inOrOut\"=\"out\",OR(\"KOModels1\"=1,\"KOModels2\"=1)),\"yes\",\"no\"))" },
            //{ "KOModels2",  "IF(\"Model Name T-1\"=\"RankedBasketBarrierNoteMCPathsDupireLocalVolMonteCarlo\",1,0)" },    
            { "Intraday Trading PL USD",    "IF(\"IsTerminatedWithZeroFairValue\",\"Intraday Trading PL (DTD T-1) <USD> <PAA Style>\",\"Intraday Trading PL (DTD T-1) <USD> <Trader Style>\")+\"PfsIntraAdj\"" }, //
            //{ "PfsCfAdj3",  "if(and(\"SecTypeId\"=130,\"Quantity T-1\"=0,\"Quantity T-2\"=0,\"PfsCfAdj2\"!=0,abs((\"Carry| Theta\"+\"PFS RCF DTD Total T-1 <USD>\")/if(\"PFS RCF DTD Total T-1 <USD>\"=0,1,\"PFS RCF DTD Total T-1 <USD>\"))<0.01),\"PFS RCF DTD Total T-1 <USD>\",0)" },
            //{ "PfsCfAdj5",  "if(and(\"SecTypeId\"=130,\"Quantity T-1\"=0,\"Quantity T-2\"=0,\"PfsClosedPositionCheck\"!=0),\"PFS Unrealised CF Total T-1 <USD>\",0)" },
        };

        private readonly Dictionary<string, string> Layer1 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "PfsThetaAdj",   "if(\"SecTypeId\"=130,\"PfsCfAdj3\"+\"PfsUnrlsdReset\"+\"PfsUnrlsdDiv\"-\"PFS Unrealised CF Sudden Total T-1 <USD>\"+\"PfsRlsdSuddenClean2\",0.0)" }, //
            { "PfsIntraAdj",    "if(\"SecTypeId\"=130,\"PfsCfAdj4\"+\"PfsRlsdSuddenDirty\"+\"PfsUnrlsdComm\"-\"PfsRlsdComm\",0.0)" },
            { "PfsNModelPlAdj",    "if(\"SecTypeId\"=130,\"PfsRlsdSuddenClean\"-\"PfsRlsdReset\"-\"PfsRlsdDiv\",0.0)" }, //
        };
        private readonly Dictionary<string, string> Layer0 = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            //{ "Coupon PL* (DTD T-1) <USD>", "\"Coupon PL (DTD T-1) <USD>\"+\"PFS Unrealised CF DTD Amount T-1 <USD> <Reset>\"-if(\"Coupon PL (DTD T-1) <USD>\"=0.0,\"PFS Realised CF DTD Amount T-1 <USD> <Reset>\",0.0)" },
            //{ "Dividend PL* (DTD T-1) <USD>", "\"Dividend PL (DTD T-1) <USD>\"+\"PFS Unrealised CF DTD Amount T-1 <USD> <Distribution>\"-\"PFS Realised CF DTD Amount T-1 <USD> <Distribution>\"" },
            { "DeltaAdj",   "if(and(\"SecTypeId\"=130,\"NoUndPriceOnT-1\"=0,\"NoUndPriceOnT-2\"=0),(\"Underlying Price T-1 <Position>\"-\"Underlying Price T-2 <Position>\")*\"Quantity T-2\"/if(\"Underlying FX /USD T-1\"=0,1,\"Underlying FX /USD T-1\"),0)" },
             //{ "DeltaAdj",   "if(and(\"SecTypeId\"=130,isnumber(\"Underlying Price T-1 <Position>\"),isnumber(\"Underlying Price T-2 <Position>\")),(\"Underlying Price T-1 <Position>\"-\"Underlying Price T-2 <Position>\")*\"Quantity T-2\"/if(\"Underlying FX /USD T-1\"=0,1,\"Underlying FX /USD T-1\"),0)" },//{ "PfsSecChngAdj",  "\"PFS Realised CF Sudden DTD Total T-1 <USD>\"-\"PFS Unrealised CF Sudden Total T-1 <USD>\"" },
            //{ "PfsCfAdj1",  "\"PFS Unrealised CF DTD Amount T-1 <USD> <Distribution>\"+\"PFS Unrealised CF DTD Amount T-1 <USD> <Reset>\"-\"PFS Realised CF DTD Amount T-1 <USD> <Distribution>\"-if(\"Coupon PL (DTD T-1) <USD>\"=0.0,\"PFS Realised CF DTD Amount T-1 <USD> <Reset>\",0.0)" },
            //{ "PfsCfAdj4",  "if(and(\"SecTypeId\"=130,\"Quantity T-2\"!=0,\"Delta T-2 <DFX>\"=0,\"NoUndPriceOnT-2\"=0),\"EqFV USD[-2]\",if(and(\"Quantity T-1\"!=0,\"Delta T-1 <DFX>\"=0,\"NoUndPriceOnT-1\"=0),-\"EqFV USD[-1]\",0))" },
            //{ "PfsCfAdj3",  "if(and(\"SecTypeId\"=130,\"Quantity T-1\"=0,\"Quantity T-2\"=0,\"PfsCfAdj2\"!=0,abs((\"Carry| Theta\"+\"PFS RCF DTD Total T-1 <USD>\")/if(\"PFS RCF DTD Total T-1 <USD>\"=0,1,\"PFS RCF DTD Total T-1 <USD>\"))<0.01),\"PFS RCF DTD Total T-1 <USD>\",0)" },
            //{ "PfsCfAdj2",  "if(and(\"SecTypeId\"=130,\"Quantity T-1\"=0,\"Quantity T-2\"=0),\"PFS RCF DTD Total T-1 <USD>\"-\"PFS Realised CF DTD Amount T-1 <USD> <Distribution>\"-\"PFS Realised CF DTD Amount T-1 <USD> <Reset>\",0)" },
            { "PfsRlsdDiv", "if(and(\"NoUndPriceOnT-1\"=1,\"Quantity T-2\"=0,\"Quantity T-1\"=0),0,\"PFS Realised CF DTD Amount T-1 <USD> <Distribution>\")" },
            { "PfsUnrlsdDiv",   "\"PFS Unrealised CF DTD Amount T-1 <USD> <Distribution>\"" },
            { "PfsRlsdReset", "if(and(\"NoUndPriceOnT-1\"=1,\"Quantity T-2\"=0,\"Quantity T-1\"=0),0,if(\"Coupon PL (DTD T-1) <USD>\"=0.0,\"PFS Realised CF DTD Amount T-1 <USD> <Reset>\",0.0))" },
            { "PfsUnrlsdReset", "\"PFS Unrealised CF DTD Amount T-1 <USD> <Reset>\"" }, //-\"PFS Unrealised CF DTD Amount T-1 <USD> <Reset>\"
            { "PfsRlsdComm", "if(and(\"NoUndPriceOnT-1\"=1,\"Quantity T-2\"=0,\"Quantity T-1\"=0),0,\"PFS Realised CF DTD Amount T-1 <USD> <TransactionFee>\")" }, //if(\"Commission PL (DTD T-1) <USD>\"=0.0,
            { "PfsUnrlsdComm", "\"PFS Unrealised CF DTD Amount T-1 <USD> <TransactionFee>\"" },
            { "PfsRlsdSuddenClean", "\"PFS Realised CF Sudden DTD Amount T-1 <USD> <Reset>\"+\"PFS Realised CF Sudden DTD Amount T-1 <USD> <Distribution>\"" },
            { "PfsRlsdSuddenClean2", "\"PFS Realised CF Sudden DTD Amount T-1 <USD> <Interest>\"+\"PFS Realised CF Sudden DTD Amount T-1 <USD> <BorrowCost>\"+\"PFS Realised CF Sudden DTD Amount T-1 <USD> <CompoundInterest>\"" }, //
            { "PfsRlsdSuddenDirty", "\"PFS Realised CF Sudden DTD Amount T-1 <USD> <Reserves>\"+\"PFS Realised CF Sudden DTD Amount T-1 <USD> <TransactionFee>\"" },
            //{ "PfsUnrlsdBorrowInt", "\"PFS Unrealised CF DTD Amount T-1 <USD> <BorrowCost>\"+\"PFS Unrealised CF DTD Amount T-1 <USD> <Interest>\"" },
            //{ "RiskPAA: Rate PL*", "if(OR(\"Underlying Currency\"=\"INL\",\"Underlying Currency\"=\"INR\",\"Underlying Currency\"=\"INF\",\"Underlying Currency\"=\"IND\",\"Underlying Currency\"=\"IDR\",\"Underlying Currency\"=\"IDF\",\"Underlying Currency\"=\"PHP\",\"Underlying Currency\"=\"PHF\",\"Underlying Currency\"=\"VND\"),\"Factor Stress: Rate PL T-1 <USD>\"*\"MMult\"*\"Quantity T-2\",\"RiskPAA: Rate PL\")" },
            //{ "PfsZeroQuantity", "if(and(\"Quantity T-1\"=\"Quantity T-2\",\"HasTplusData\"=0),\"PFS Realised CF DTD Amount T-1 <USD> <Resdid you kerves>\"-\"PFS Unrealised CF DTD Amount T-1 <USD> <Reserves>\",0)" }
            //{ "PfsClosedPositionCheck", "if(and(\"SecTypeId\"=130,\"Quantity T-1\"=0,\"Quantity T-2\"=0,\"NoUndPriceOnT-2\"=1,\"NoUndPriceOnT-1\"=0,\"PFS Unrealised CF DTD Amount T-1 <USD> <Reserves>\"=0),\"PFS Unrealised CF Total T-1 <USD>\"-\"PFS Unrealised CF DTD Amount T-1 <USD> <Reset>\"-\"PFS Unrealised CF DTD Amount T-1 <USD> <Distribution>\",0)" }
            //{ "IsTerminatedWithZeroFairValue",  "if(AND(OR(\"IsVIXModel\"=1,AND(\"COB Price T-1\"=0,NOT(OR(\"Security Type\" = \"Option\", \"Security Type\" = \"ExoticOption\"))),AND(\"Security Type\"=\"EquitySwap\",\"Outstanding Payments\"<>0)),\"IsTerminated\"),1, 0)" },
            //{ "Calculating MMult",  "IF(OR(\"Quantity T-1\"=0,\"COB Price T-1\"=0),\"Fair Value T-2 <DFX>\"/\"Quantity T-2\"/\"Fair Price T-2\",\"Fair Value T-1 <DFX>\"/\"Quantity T-1\"/\"COB Price T-1\")" },
            //{ "Calculating MMult Spot", "IF(\"Quantity T-1\"=0,IF(\"Cash Delta T-2\"=0,\"PV01 /bp T-2 <DFX>\"/\"Quantity T-2\"/\"Unit PV01 /bp T-2\",\"Delta T-2 <DFX>\"/\"Quantity T-2\"/\"Cash Delta T-2\"),IF(\"Cash Delta T-1\"=0,\"PV01ScalingFactorT1\",\"Delta T-1 <DFX>\"/\"Quantity T-1\"/\"Cash Delta T-1\"))" },
            //{ "CheckKOFlag",  "IF(OR(\"Generic Data KnockedThrough\"=\"yes\",\"Generic Data KnockedThrough\"=\"TRUE\",\"Generic Data KnockedThrough\"=1),1,0)" },
            //{ "NoUndPriceOnT-1",    "or(eqisnan(\"Underlying Price T-1 <Position>\"),not(isnumber(\"Underlying Price T-1 <Position>\")),\"Underlying Price T-1 <Position>\"=0)" },
            //{ "NoUndPriceOnT-2",    "or(eqisnan(\"Underlying Price T-2 <Position>\"),not(isnumber(\"Underlying Price T-2 <Position>\")),\"Underlying Price T-2 <Position>\"=0)" },
            //{ "volGeoError",    "eqlookup(\"Position Id\",1, 20004533,1)" },
            //{ "Vol Geo Stress Errors",  "IF(\"volGeoError\"=\"Not Found\", \"N\", \"Y\")" },
            //{ "PV01ScalingFactorT1",    "\"PV01 /bp T-1 <DFX>\"/\"Quantity T-1\"/\"Unit PV01 /bp T-1\"" },
            //{ "Sec FX /USD [-1]",   "if(\"Security FX /USD T-1\"<>0,\"Security FX /USD T-1\",1)" },
            //{ "IsTerminated",   "AND(\"Quantity T-2\"!=0,\"Quantity T-1\"=0)" },
            //{ "Outstanding Payments",   "\"Outstanding Payments T-1 <Equity Leg>\"+\"Outstanding Payments T-1 <Libor Leg>\"+\"Outstanding Payments T-1 <Dividend Leg>\""},
            //{ "Trade Quantity", "\"Quantity T-1\"-\"Quantity T-2\"" },
            //{ "FXDelta(DTDSAdj)",   "\"Fair Economic (DTDS T-1) <USD>\"-\"Fair Economic (DTD T-1) <USD>\"" },
            //{ "KOModels1",  "IF(OR(\"Model Name T-1\"=\"Barrier\",\"Model Name T-1\"=\"BarrierDupireLVPDE\",\"Model Name T-1\"=\"DCBarrier\",\"Model Name T-1\"=\"RankedBasketBarrierNote\",\"Model Name T-1\"=\"StructNote\"),1,0)" },
        };
        private void BuildDictionary()
        {
            FormulasLayered.Add(Layer0);
            FormulasLayered.Add(Layer1);
            FormulasLayered.Add(Layer2);
            FormulasLayered.Add(Layer3);
            FormulasLayered.Add(Layer4);
            FormulasLayered.Add(Layer5);
            FormulasLayered.Add(Layer6);
            FormulasLayered.Add(Layer7);
            FormulasLayered.Add(Layer8);
            FormulasLayered.Add(Layer9);
            FormulasLayered.Add(Layer10);
            FormulasLayered.Add(Layer11);
        }
        public List<Dictionary<string, string>> FormulasLayered = new List<Dictionary<string, string>>();

        public EQRMSFormulaLayers()
        {
            BuildDictionary();
        }

    }
}

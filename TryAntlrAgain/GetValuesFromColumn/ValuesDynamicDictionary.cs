using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GetValuesFromColumn
{
    public class ValuesDynamicDictionary    
        {
            #region Initialise List

        public Dictionary<int, dynamic> ValuesUnbound = new Dictionary<int, dynamic>
        {
            [0] = new List<int>(), //	 "Position Id"
            [1] = new List<string>(), //	 "Expiry"
            [2] = new List<int?>(), //hidden);	 //	 "Compound Position Id"
            [3] = new List<string>(), //hidden);	 //	 "Cusip <v2.0>"
            [4] = new List<string>(), //	 "Component Mnem <RIC>"
            [5] = new List<double?>(), //	 "Strike"
            [6] = new List<string>(), //	 "Package Number <COM2>"
            [7] = new List<string>(), //	 "Security Type"
            [8] = new List<int?>(), //	 "SecTypeId"
            [9] = new List<string>(), //hidden);	 //	 "P/C"
            [10] = new List<string>(), //	 "Security Currency"
            [11] = new List<string>(), //	 "Model Name T-2"
            [12] = new List<string>(), //	 "Account"
            [13] = new List<string>(), //	 "Account Entity Code"
            [14] = new List<double?>(), //	 "Calculating MMult"
            [15] = new List<double?>(), //	 "Underlying Price T-2 <Position>"
            [16] = new List<double?>(), //	 "Underlying Price T-1 <Position>"
            [17] = new List<double?>(), //	 "Calculating MMult Spot"
            [18] = new List<string>(), //	 "PV01ScalingFactorT1"
            [19] = new List<double?>(), //	 "Cash Delta T-1"
            [20] = new List<double?>(), //	 "Gamma /1% T-2 <USD>"
            [21] = new List<double?>(), //	 "Vega /1% T-2 <USD>"
            [22] = new List<double?>(), //	 "PV01 /bp T-2 <USD>"
            [23] = new List<double?>(), //	 "CR01 T-2 <USD>"
            [24] = new List<double?>(), //	 "Cash Delta T-2"
            [25] = new List<double?>(), //	 "Unit PV01 /bp T-1"
            [26] = new List<double?>(), //	 "Unit PV01 /bp T-2"
            [27] = new List<double?>(), //	 "PV01 /bp T-1 <DFX>"
            [28] = new List<double?>(), //	 "PV01 /bp T-2 <DFX>"
            [29] = new List<double?>(), //	 "Delta T-1 <DFX>"
            [30] = new List<double?>(), //hidden);	 //	 "Delta T-2 <USD>"
            [31] = new List<double?>(), //	 "Delta T-2 <DFX>"
            [32] = new List<double?>(), //	 "MMult"
            [33] = new List<double?>(), //	 "MMultSpot"
            [34] = new List<double?>(), //hidden);	 //	 "Fair Value T-2 <USD>"
            [35] = new List<double?>(), //	 "COB Price T-1"
            [36] = new List<double?>(), //	 "Fair Price T-1"
            [37] = new List<double?>(), //	 "Fair Price T-2"
            [38] = new List<double?>(), //	 "Quantity T-1"
            [39] = new List<double?>(), //	 "Quantity T-2"
            [40] = new List<double?>(), //	 "Fair Value T-1 <DFX>"
            [41] = new List<double?>(), //	 "Fair Value T-2 <DFX>"
            [42] = new List<double?>(), //	 "Quantity for PAA"
            [43] = new List<double?>(), //	 "Quantity for Spot"
            [44] = new List<string>(), //hidden);	 //	 "External Source"
            [45] = new List<double?>(), //	 "Trade Quantity"
            [46] = new List<double?>(), //	 "KO Trades"
            [47] = new List<double?>(), //	 "RiskPAA: Delta PL"
            [48] = new List<double?>(), //	 "RiskPAA: Gamma PL"
            [49] = new List<double?>(), //	 "RiskPAA: FX Delta PL"
            [50] = new List<double?>(), //	 "FXDelta(TradeCcyAdj)"
            [51] = new List<double?>(), //	 "FXDelta(DTDSAdj)"
            [52] = new List<double?>(), //	 "RiskPAA: ASAS PL"
            [53] = new List<double?>(), //	 "RiskPAA: ASFX PL"
            [54] = new List<double?>(), //	 "RiskPAA: Rate PL"
            [55] = new List<double?>(), //	 "RiskPAA: IR Vol PL"
            [56] = new List<double?>(), //	 "RiskPAA: Volatility PL"
            [57] = new List<double?>(), //	 "RiskPAA: VolGeo Unds PL"
            [58] = new List<double?>(), //	 "VolGeoSWParams"
            [59] = new List<double?>(), //	 "Risk PAA: VolThetaAdj"
            [60] = new List<double?>(), //	 "RiskPAA: BorrowCostPL"
            [61] = new List<double?>(), //	 "RiskPAA: Dividend PL"
            [62] = new List<double?>(), //	 "RiskPAA: CrossGammaPL"
            [63] = new List<double?>(), //	 "RiskPAA: VarSwap"
            [64] = new List<double?>(), //	 "RiskPAA: VG VolAtm"
            [65] = new List<double?>(), //	 "RiskPAA: VG Skew"
            [66] = new List<double?>(), //	 "RiskPAA: VG Smile"
            [67] = new List<double?>(), //	 "RiskPAA: VG CallWingA"
            [68] = new List<double?>(), //	 "RiskPAA: VG CallWingB"
            [69] = new List<double?>(), //	 "RiskPAA: VG PutWingA"
            [70] = new List<double?>(), //	 "RiskPAA: VG PutWingB"
            [71] = new List<double?>(), //	 "RiskPAA: VG RefForward"
            [72] = new List<double?>(), //	 "New Trades"
            [73] = new List<double?>(), //	 "Day Trading"
            [74] = new List<double?>(), //	 "Upsize / Downsize"
            [75] = new List<double?>(), //	 "Intraday Trading P&L"
            [76] = new List<double?>(), //	 "P&L FX /USD T-2"
            [77] = new List<double?>(), //	 "P&L FX /USD T-1"
            [78] = new List<double?>(), //	 "Terminated Trades"
            [79] = new List<double?>(), //	 "Total Risk PAA"
            [80] = new List<double?>(), //	 "Total Risk PAA1"
            [81] = new List<double?>(), //	 "Dividend PL (DTD T-1) <USD>"
            [82] = new List<double?>(), //	 "Commission PL (DTD T-1) <USD>"
            [83] = new List<double?>(), //	 "Interest PL (DTD T-1) <USD>"
            [84] = new List<double?>(), //	 "Dividend PL (DTD T-1) <USD> Duped"
            [85] = new List<double?>(), //	 "Coupon PL (DTD T-1) <USD>"
            [86] = new List<double?>(), //	 "Extraordinary PL (DTD T-1) <USD>"
            [87] = new List<double?>(), //	 "Net Accrued Interest (DTD T-1) <USD>"
            [88] = new List<double?>(), //	 "Non Model PL"
            [89] = new List<double?>(), //	 "Fair-Vs-Mkt Diff"
            [90] = new List<double?>(), //	 "Fair-Vs-Mkt Diff 1"
            [91] = new List<double?>(), //	 "Credit PAA"
            [92] = new List<double?>(), //	 "Security Change PAA"
            [93] = new List<double?>(), //	 "Carry| Theta"
            [94] = new List<double?>(), //	 "Security Change PAA*"
            [95] = new List<double?>(), //	 "Theta"
            [96] = new List<double?>(), //	 "FXAdjustment"
            [97] = new List<double?>(), //	 "Intraday Trading PL (DTD T-1) <USD> <PAA Style>"
            [98] = new List<double?>(), //	 "Intraday Trading PL USD"
            [99] = new List<double?>(), //	 "Intraday Trading PL (DTD T-1) <USD> <Trader Style>"
            [100] = new List<int?>(), //hidden);	 //	 "KOModels1"
            [101] = new List<int?>(), //hidden);	 //	 "KOModels2"
            [102] = new List<string>(), //hidden);	 //	 "IsKOEvent"
            [103] = new List<double?>(), //	 "KO Multiplier"
            [104] = new List<int?>(), //hidden);	 //	 "CheckKOFlag"
            [105] = new List<string>(), //hidden);	 //	 "Generic Data <KnockedThrough>"
            [106] = new List<string>(), //hidden);	 //	 "Generic Data <inOrOut>"
            [107] = new List<double?>(), //	 "KO PL"
            [108] = new List<double?>(), //	 "Total PAA1"
            [109] = new List<double?>(), //	 "Total PAA"
            [110] = new List<double?>(), //hidden);	 //	 "Fair Economic (DTD T-1) <USD>"
            [111] = new List<double?>(), //hidden);	 //	 "Fair Economic (MTD T-2) <PFX>"
            [112] = new List<double?>(), //	 "Fair Economic (DTDS T-1) <USD>"
            [113] = new List<double?>(), //	 "Residual"
            [114] = new List<double?>(), //	 "Security FX /USD T-1"
            [115] = new List<double?>(), //	 "Sec FX /USD [-1]"
            [116] = new List<string>(), //hidden);	 //	 "Model Name T-1"
            [117] = new List<double?>(), //	 {
            [118] = new List<double?>(), //	 "Risk PAA: Sub Id T-1"
            [119] = new List<double?>(), //	 "Factor Stress: Theta PL T-1 <USD>"
            [120] = new List<double?>(), //	 "Risk PAA: Correlation PL T-1 <USD>"
            [121] = new List<double?>(), //	 "Risk PAA: FX Correlation PL T-1 <USD>"
            [122] = new List<double?>(), //	 "Risk PAA: Delta PL T-1 <USD>"
            [123] = new List<double?>(), //	 "Risk PAA: Gamma PL T-1 <USD>"
            [124] = new List<double?>(), //	 "Risk PAA: FX Delta PL T-1 <USD>"
            [125] = new List<double?>(), //	 "Risk PAA: Rate PL T-1 <USD>"
            [126] = new List<double?>(), //	 "Risk PAA: IR Vol PL T-1 <USD>"
            [127] = new List<double?>(), //	 "Risk PAA: Borrow Cost PL T-1 <USD>"
            [128] = new List<double?>(), //	 "Risk PAA: Dividend PL T-1 <USD>"
            [129] = new List<double?>(), //	 "Risk PAA: Equity Vega PL T-1 <USD>"
            [130] = new List<double?>(), //	 "Risk PAA: Skew Vega PL T-1 <USD>"
            [131] = new List<double?>(), //	 "Risk PAA: Cross Gamma PL T-1 <USD>"
            [132] = new List<double?>(), //	 "Risk PAA: VaR Swap Basis PL T-1 <USD>"
            [133] = new List<double?>(), //	 "Risk PAA: Theta Vol Adjustment T-1 <USD>"
            [134] = new List<double?>(), //	 "Risk PAA: Theta PL T-1 <USD>"
            [135] = new List<double?>(), //	 "Risk PAA: VolGeo Vol Atm PL T-1 <USD>"
            [136] = new List<double?>(), //	 "Risk PAA: VolGeo Skew PL T-1 <USD>"
            [137] = new List<double?>(), //	 "Risk PAA: VolGeo Smile PL T-1 <USD>"
            [138] = new List<double?>(), //	 "Risk PAA: VolGeo Put Wing A PL T-1 <USD>"
            [139] = new List<double?>(), //	 "Risk PAA: VolGeo Call Wing A PL T-1 <USD>"
            [140] = new List<double?>(), //	 "Risk PAA: VolGeo Put Wing B PL T-1 <USD>"
            [141] = new List<double?>(), //	 "Risk PAA: VolGeo Call Wing B PL T-1 <USD>"
            [142] = new List<double?>(), //	 "Risk PAA: VolGeo Ref Forward PL T-1 <USD>"
            [143] = new List<double?>(), //	 "Risk PAA: VolGeo Put Slope TW PL T-1 <USD>"
            [144] = new List<double?>(), //	 "Risk PAA: VolGeo Call Slope TW PL T-1 <USD>"
            [145] = new List<double?>(), //	 "Risk PAA: VolGeo Put Convexity TW PL T-1 <USD>"
            [146] = new List<double?>(), //	 "Risk PAA: VolGeo Call Convexity TW PL T-1 <USD>"
            [147] = new List<double?>(), //	 "Risk PAA: TPlus Stress Missing T-1"
            [148] = new List<double?>(), //	 "Factor Stress: Sub Id T-1"
            [149] = new List<double?>(), //	 "Factor Stress: Prior Fair T-1 <USD>"
            [150] = new List<double?>(), //	 "Factor Stress: Prior Fair Recalc T-1 <USD>"
            [151] = new List<double?>(), //	 "Factor Stress: Fair T-1 <USD>"
            [152] = new List<string>(), //hidden);	 //	 "stressError"
            [153] = new List<string>(), //	 "Stressing Errors"
            [154] = new List<int?>(), //hidden);	 //	 "IsVIXModel"
            [155] = new List<int?>(), //hidden);	 //	 "IsVIXModels1"
            [156] = new List<int?>(), //hidden);	 //	 "IsVIXModels2"
            [157] = new List<int?>(), //hidden);	 //	 "IsVanillaModel"
            [158] = new List<double?>(), //	 "Fair Value T-1 <USD>"
            [159] = new List<string>(), //hidden);	 //	 "Active Trade"
            [160] = new List<double?>(), //	 "Fair Value T-2 <USD> Duped"
            [161] = new List<string>(), //hidden);	 //	 "Final Counterparty"
            [162] = new List<int?>(), //	 "IsTodayPastModels"
            [163] = new List<double?>(), //	 "Multiplier T-1"
            [164] = new List<string>(), //	 "Security Class"
            [165] = new List<double?>(), //	 "WarrantMultiplier"
            [166] = new List<int?>(), //	 "HasTplusData"
            [167] = new List<double?>(), //	 "PFS Realised CF DTD Amount T-1 <USD> <Distribution>"
            [168] = new List<double?>(), //	 "PFS Realised CF DTD Amount T-1 <USD> <Reset>"
            [169] = new List<double?>(), //	 "PFS Realised CF DTD Amount T-1 <USD> <TransactionFee>"
            [170] = new List<double?>(), //	 "PFS Realised CF DTD Amount T-1 <USD> <BorrowCost>"
            [171] = new List<double?>(), //	 "PFS Unrealised CF DTD Amount T-1 <USD> <Distribution>"
            [172] = new List<double?>(), //	 "PFS Unrealised CF DTD Amount T-1 <USD> <Reset>"
            [173] = new List<double?>(), //	 "PFS Unrealised CF DTD Amount T-1 <USD> <TransactionFee>"
            [174] = new List<double?>(), //	 "PFS Unrealised CF DTD Amount T-1 <USD> <BorrowCost>"
            [175] = new List<double?>(), //	 "PFS Unrealised CF DTD Amount T-1 <USD> <Interest>"
            [176] = new List<double?>(), //	 "PFS Realised CF Sudden DTD Total T-1 <USD>"
            [177] = new List<double?>(), //	 "PFS Unrealised CF Sudden Total T-1 <USD>"
            [178] = new List<double?>(), //	 "PFS RCF DTD Total T-1 <USD>"
            [179] = new List<double?>(), //	 "Underlying FX /USD T-2"
            [180] = new List<double?>(), //	 "Underlying FX /USD T-1"
            [181] = new List<double?>(), //	 "Average Cost T-2"
            [182] = new List<double?>(), //	 "Average Cost T-1"
            [183] = new List<string>(), //	 "Underlying Type"
            [184] = new List<double?>(), //	 "IsPfsCBFut"
            [185] = new List<double?>(), //	 "DeltaAdj"
            [186] = new List<double?>(), //	 "EqFV USD[-1]"
            [187] = new List<double?>(), //	 "EqFV USD[-2]"
            [188] = new List<int?>(), //	 "NoUndPriceOnT-1"
            [189] = new List<int?>(), //	 "NoUndPriceOnT-2"
            [190] = new List<double?>(), //	 "PfsCfAdj1"
            [191] = new List<double?>(), //	 "PfsCfAdj2"
            [192] = new List<double?>(), //	 "PfsCfAdj3"
            [193] = new List<double?>(), //	 "PfsCfAdj4"
            [194] = new List<double?>(), //	 "PfsSecChngAdj"
            [195] = new List<double?>(), //	 "PfsCfAdj"
            [196] = new List<double?>(), //	 "DeltaDiff"
            [197] = new List<int?>(), //	 "IsLargeResidual"
            [198] = new List<int?>(), //	 "MissingDeltaPL"
            [199] = new List<int?>(), //	 "WrongDeltaPL"
            [200] = new List<int?>(), //	 "IsTerminated"
            [201] = new List<double?>(), //	 "Outstanding Payments"
            [202] = new List<double?>(), //	 "Outstanding Payments T-1 <Equity Leg>"
            [203] = new List<double?>(), //	 "Outstanding Payments T-1 <Dividend Leg>"
            [204] = new List<double?>(), //	 "Outstanding Payments T-1 <Libor Leg>"
            [205] = new List<int?>(), //	 "Security Id"
            [206] = new List<double?>(), //	 "RiskPAA: VG PutSlopeTW"
            [207] = new List<double?>(), //	 "RiskPAA: VG PutConvexityTW"
            [208] = new List<double?>(), //	 "RiskPAA: VG CallSlopeTW"
            [209] = new List<double?>(), //	 "RiskPAA: VG CallConvexityTW"
            [210] = new List<int?>(), //	 "IsTerminatedWithZeroFairValue"
            [211] = new List<string>(), //	 "volGeoError"
            [212] = new List<string>(), //hidden);	 //	 "Vol Geo Stress Errors"
            [213] = new List<double?>(), //	 "Exchange Fees PL (DTD T-1) <USD>"
            [214] = new List<double?>(), //	 "Other Fees PL (DTD T-1) <USD>"
            [215] = new List<double?>(), //	 "PFS Unrealised CF Total T-1 <USD>"
            [216] = new List<double?>(), //	 "PFS Unrealised CF Total T-2 <USD>"
            [217] = new List<int?>(), //"PFS Inconsistency Code T-1"
            [218] = new List<int?>(), //"PFS Inconsistency Code T-2"
            [219] = new List<string>(), //"PFS Inconsistency Description T-1"
            [220] = new List<string>(), //"PFS Inconsistency Description T-2"
            [221] = new List<string>(), //DUPLICATE COLUMN DUMP
            [222] = new List<double?>(), // PFS Unrealised CF DTD Amount T-1 <USD> <Reserves>
            [223] = new List<double?>(), //PFS Realised CF DTD Amount T-1 <USD> <Interest>
            [224] = new List<double?>(), //PFS Realised CF DTD Amount T-1 <USD> <Reserves>
            [225] = new List<double?>(), //"PFS Realised CF Sudden DTD Amounnt T-1 <USD> <Interest>" },
            [226] = new List<double?>(), //"PFS Realised CF Sudden DTD Amounnt T-1 <USD> <BorrowCost>"
            [227] = new List<double?>(), //"PFS Realised CF Sudden DTD Amounnt T-1 <USD> <Reset>"
            [228] = new List<double?>(), //"PFS Realised CF Sudden DTD Amounnt T-1 <USD> <TransactionFee>"
            [229] = new List<double?>(), //"PFS Realised CF Sudden DTD Amounnt T-1 <USD> <Distribution>"
            [230] = new List<double?>(), //PFS Realised CF Sudden DTD Amount T-1 <USD> <Reserves>
            [231] = new List<double?>(), //"PFS Realised CF Sudden DTD Amount T-1 <USD> <CompoundInterest>"
            [232] = new List<double?>(), //"PFS Unrealised CF DTD Amount T-1 <USD> <CompoundInterest>"
            [233] = new List<double?>(), //"PFS Realised CF DTD Amount T-1 <USD> <CompoundInterest>"
            [234] = new List<double?>(), //"RiskPAA: Rate PL*"   //APAC ONLY COLUMN
            [235] = new List<string>(), //"Underlying Currency"
            [236] = new List<double?>(), //"Risk PAA: VolGeo Unds PL" //APAC ONLY COLUMN
            [237] = new List<string>(), //"Account Entity"
            [238] = new List<double?>(), //"Factor Stress: Rate PL T-1 <USD>"
            [239] = new List<string>(), //Has Dividends
            [240] = new List<string>(), //Underlying ID
            [241] = new List<string>(), //DivLookup
            [242] = new List<string>(), //DividendToday
            [243] = new List<double?>(), //"RiskPAA:  VG PutWingA" //NAM only misstyped column name
            [244] = new List<double?>(), //"Total Risk PAA 1" //NAM only space after PAA 
            [245] = new List<double?>(), //"Derivative Series" //NAM ONLY OCLUMN
        };

        #endregion

        //1) compare the type of the source to the destination type, 
        //2) if they are the same, cast and return casted value
        private dynamic CheckDictionaryTypeAndCast(int key, object obj) 
        {
            Type[] dictType = ValuesUnbound[key].GetType().GetGenericArguments();
            Type one = dictType[0];

            if (one == typeof(int) || one == typeof(int?)) //EQNaN or "could not divide by zero" or ""
            {
                int num = 0;
                if (!int.TryParse(obj.ToString(), out num))
                {
                    if (obj == null || obj == "" || Regex.IsMatch(obj.ToString(), "\\D"))
                        return null;

                }
                return num;
            }
            else if (one == typeof(double) || one == typeof(double?))
            {
                double num = 0.0;
                if (!double.TryParse(obj.ToString(), out num))
                {
                    if (obj == null || obj == "" || Regex.IsMatch(obj.ToString(), "\\D"))
                        return null;
                    
                }                
                return num;
            }
            else if (one == typeof(string)) //default to string
            {
                return obj; //only string is returned from read line
            }
            return null;
        }

        public void Add(int key, string value)
        {
           if (ValuesUnbound.ContainsKey(key)) //do we have a key?
            {
                dynamic boggart = CheckDictionaryTypeAndCast(key, value); //int or double or string
                ValuesUnbound[key].Add(boggart);
            }
            else
            {
                throw new Exception("Problem in Add(), the key does not exist in the dictionary");
            }
        }
        public object GetValue(int column, int rownumber)
        {
            var ret = ValuesUnbound[column][rownumber];
            if (ret == null) { ret = 0; } //Can't subtract 1 from EQNaN; thus set this to zero
            return ret;
        }

        public int Count()
        {
            int ret = ValuesUnbound[0].Count; //posId         
            return ret;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace RiskPAA_EQRMS_Net
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> PositionId = new List<int>();
            List<string> Expiry = new List<string>();
            List<string> CompoundPositionId = new List<string>();
            List<string> Cusipv2 = new List<string>();
            List<string> ComponentMnem = new List<string>();
            List<double> Strike = new List<double>();
            List<string> PackageNumber = new List<string>();
            List<string> SecurityType = new List<string>();
            List<string> PC = new List<string>();
            List<string> SecurityCurrency = new List<string>();
            List<string> ModelName = new List<string>();
            List<string> Account = new List<string>();
            List<string> AccountEntityCode = new List<string>();
            List<double> UnderlyingPriceT_2 = new List<double>();
            List<double> UnderlyingPriceT_1 = new List<double>();
            List<double> Gamma_1_T_2 = new List<double>();
            List<double> Vega_1_T_2 = new List<double>();
            List<double> PV01_bp_T_2 = new List<double>();
            List<double> CR01_T_2 = new List<double>();
            List<double> Delta_T_2 = new List<double>();
            List<double> COB_Price_T_1 = new List<double>();
            List<double> Quantity_T_1 = new List<double>();
            List<double> Quantity_T_2 = new List<double>();
            List<double> TradeQuantity = new List<double>();
            List<double> KOTrades = new List<double>();
            List<double> RiskPAA_DeltaPL = new List<double>();
            List<double> RiskPAA_GammaPL = new List<double>();
            List<double> RiskPAA_FXDeltaPL = new List<double>();
            List<double> RiskPAA_FXDelta_TradeCcyAdj = new List<double>();
            List<double> RiskPAA_FXDelta_DTDSAdj = new List<double>();
            List<double> RiskPAA_ASASPL = new List<double>();
            List<double> RiskPAA_ASFXPL = new List<double>();
            List<double> RiskPAA_RatePL = new List<double>();
            List<double> RiskPAA_IRVolPL = new List<double>();
            List<double> RiskPAA_VolatilityPL = new List<double>();
            List<double> RiskPAA_VolGeoUndsPL = new List<double>();
            List<double> RiskPAA_VolThetaAdj = new List<double>();
            List<double> RiskPAA_BorrowCostPL = new List<double>();
            List<double> RiskPAA_DividendPL = new List<double>();
            List<double> RiskPAA_CrossGammaPL = new List<double>();
            List<double> RiskPAA_VarSwap = new List<double>();
            List<double> RiskPAA_VGVolAtm = new List<double>();
            List<double> RiskPAA_VGSkew = new List<double>();
            List<double> RiskPAA_VGSmile = new List<double>();
            List<double> RiskPAA_VGCallWingA = new List<double>();
            List<double> RiskPAA_VGCallWingB = new List<double>();
            List<double> RiskPAA_VGPutWingA = new List<double>();
            List<double> RiskPAA_VGPutWingB = new List<double>();
            List<double> RiskPAA_VGRefForward = new List<double>();
            List<double> NewTrades = new List<double>();
            List<double> DayTrading = new List<double>();
            List<double> Upsize_Downsize = new List<double>();
            List<double> IntradayTradingPL = new List<double>();
            List<double> TerminatedTrades = new List<double>();
            List<double> CommissionPL_DTD_T_1 = new List<double>();
            List<double> FairVsMktDiff = new List<double>();
            List<double> InterestPL_DTD_T_1 = new List<double>();
            List<double> DividendPL_DTD_T_1 = new List<double>();
            List<double> CouponPL_DTD_T_1 = new List<double>();
            List<double> ExtraordinaryPL_DTD_T_1 = new List<double>();
            List<double> NetAccruedInterest_DTD_T_1 = new List<double>();
            List<double> CreditPAA = new List<double>();
            List<double> SecurityChangePAA = new List<double>();
            List<double> Carry_Theta = new List<double>();
            List<double> SecurityChangePAA2 = new List<double>();
            List<double> Theta = new List<double>();
            List<double> IntradayTradingPLUSD = new List<double>();
            List<double> KOPL = new List<double>();
            List<double> TotalPAA = new List<double>();
            List<double> FairEconomicDTDS_T_1 = new List<double>();
            List<double> Residual = new List<double>();
            List<double> PercentageResidual = new List<double>();
            List<string> StressingErrors = new List<string>();
            List<int> IsVIXModel = new List<int>();
            List<int> IsVanillaModel = new List<int>();
            List<double> FairValue_T_1 = new List<double>();
            List<double> FairValue_T_2 = new List<double>();
            List<string> FinalCounterparty = new List<string>();
            List<int> SecurityId = new List<int>();
            List<double> RiskPAA_VGPutSlopeTW = new List<double>();
            List<double> RiskPAA_VGPutConvexityTW = new List<double>();
            List<double> RiskPAA_VGCallSlopeTW = new List<double>();
            List<double> RiskPAA_VGCallConvexityTW = new List<double>();
            List<int> IsTerminatedWithZeroFairValue = new List<int>();
            List<string> VolGeoStressErrors = new List<string>();
            List<double> ExchangeFeesPLDTD_T_1 = new List<double>();
            List<double> OtherFeesPLDTD_T_1 = new List<double>();

            List<double> FairEconomicDTD_T_1 = new List<double>();
            List<double> AverageCost_T_2 = new List<double>();
            List<string> AccountEntity = new List<string>();

            List<string> Region = new List<string>();
            List<string> PositionNode = new List<string>();
            List<string> EodDate = new List<string>();

            var directoryName = @"\\eqtrmseuapdv53.eur.nsroot.net\RiskPAA\ReportOutput";
            //var directoryName = @"C:\Users\sc93445\Documents\RiskPAA\High Residual\20161122";

            var folders = Directory.GetDirectories(directoryName);

            Console.WriteLine("Enter from date");
            var fromDate = DateTime.ParseExact(Console.ReadLine(), "yyyyMMdd", CultureInfo.InvariantCulture,
                                    DateTimeStyles.None);

            Console.WriteLine("Enter to date");
            var toDate = DateTime.ParseExact(Console.ReadLine(), "yyyyMMdd", CultureInfo.InvariantCulture,
                                    DateTimeStyles.None);

            Application oXL = new Application();
            _Workbook oWB;
            _Worksheet oSheet;
            Range oRng;

            foreach (var folder in folders)
            {
                if (!folder.Contains("NAM") && !folder.Contains("EMEA"))
                    continue;

                var date = fromDate;

                while (date <= toDate)
                {
                    string fileSubstring = date.ToString("yyyyMMdd") + ".txt";

                    var files = Directory.GetFiles(folder);

                    foreach (string fileName in files)
                    {
                        if (!fileName.Contains(fileSubstring) || !fileName.Contains("RiskPAASummary"))
                            continue;

                       

                        Console.WriteLine(fileName);

                        //using (FileStream fStream = File.OpenRead(fileName))
                        using (FileStream fStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {

                            var fileMetaData = fileName.Split('.');
                            string positionNode = fileMetaData[fileMetaData.Length - 3];
                            string eodDate = fileMetaData[fileMetaData.Length - 2];

                            using (var reader = new StreamReader(fStream))
                            {

                                try
                                {
                                    int i = 0;

                                    while (!reader.EndOfStream)
                                    {
                                        var line = reader.ReadLine();

                                        if (i == 0 || i == 1)
                                        {
                                            //i++;
                                            continue;
                                        }
                                        var values = line.Split('\t');

                                        if (string.Equals(values[7], "Portfolio") || string.Equals(values[7], "ExternalSecurity"))
                                            continue;

                                        PositionId.Add(Int32.Parse(values[0]));

                                        Expiry.Add(values[1]);

                                        CompoundPositionId.Add(values[2]);

                                        Cusipv2.Add(values[3]);

                                        ComponentMnem.Add(values[4]);

                                        if (values[5] != "")
                                            Strike.Add(Double.Parse(values[5]));
                                        else
                                            Strike.Add(0);

                                        PackageNumber.Add(values[6]);

                                        SecurityType.Add(values[7]);

                                        PC.Add(values[8]);

                                        SecurityCurrency.Add(values[9]);

                                        ModelName.Add(values[10]);

                                        Account.Add(values[11]);

                                        AccountEntityCode.Add(values[12]);

                                        double UnderlyingPriceT_2_Value;
                                        if (Double.TryParse(values[13], out UnderlyingPriceT_2_Value))
                                            UnderlyingPriceT_2.Add(UnderlyingPriceT_2_Value);
                                        else
                                            UnderlyingPriceT_2.Add(0);

                                        double UnderlyingPriceT_1_Value;
                                        if (Double.TryParse(values[14], out UnderlyingPriceT_1_Value))
                                            UnderlyingPriceT_1.Add(UnderlyingPriceT_1_Value);
                                        else
                                            UnderlyingPriceT_1.Add(0);

                                        if (values[15] != "")
                                            Gamma_1_T_2.Add(Double.Parse(values[15]));
                                        else
                                            Gamma_1_T_2.Add(0);

                                        if (values[16] != "")
                                            Vega_1_T_2.Add(Double.Parse(values[16]));
                                        else
                                            Vega_1_T_2.Add(0);

                                        if (values[17] != "")
                                            PV01_bp_T_2.Add(Double.Parse(values[17]));
                                        else
                                            PV01_bp_T_2.Add(0);

                                        if (values[18] != "")
                                            CR01_T_2.Add(Double.Parse(values[18]));
                                        else
                                            CR01_T_2.Add(0);

                                        if (values[19] != "")
                                            Delta_T_2.Add(Double.Parse(values[19]));
                                        else
                                            Delta_T_2.Add(0);

                                        if (values[20] != "")
                                            COB_Price_T_1.Add(Double.Parse(values[20]));
                                        else
                                            COB_Price_T_1.Add(0);

                                        Quantity_T_1.Add(Double.Parse(values[21]));

                                        Quantity_T_2.Add(Double.Parse(values[22]));

                                        TradeQuantity.Add(Double.Parse(values[23]));

                                        KOTrades.Add(Double.Parse(values[24]));

                                        RiskPAA_DeltaPL.Add(Double.Parse(values[25]));

                                        RiskPAA_GammaPL.Add(Double.Parse(values[26]));

                                        RiskPAA_FXDeltaPL.Add(Double.Parse(values[27]));

                                        RiskPAA_FXDelta_TradeCcyAdj.Add(Double.Parse(values[28]));

                                        RiskPAA_FXDelta_DTDSAdj.Add(Double.Parse(values[29]));

                                        RiskPAA_ASASPL.Add(Double.Parse(values[30]));

                                        RiskPAA_ASFXPL.Add(Double.Parse(values[31]));

                                        if (values[32] != "")
                                            RiskPAA_RatePL.Add(Double.Parse(values[32]));
                                        else
                                            RiskPAA_RatePL.Add(0);

                                        RiskPAA_IRVolPL.Add(Double.Parse(values[33]));

                                        RiskPAA_VolatilityPL.Add(Double.Parse(values[34]));

                                        RiskPAA_VolGeoUndsPL.Add(Double.Parse(values[35]));

                                        RiskPAA_VolThetaAdj.Add(Double.Parse(values[36]));

                                        if (values[37] != "")
                                            RiskPAA_BorrowCostPL.Add(Double.Parse(values[37]));
                                        else
                                            RiskPAA_BorrowCostPL.Add(0);

                                        if (values[38] != "")
                                            RiskPAA_DividendPL.Add(Double.Parse(values[38]));
                                        else
                                            RiskPAA_DividendPL.Add(0);

                                        if (values[39] != "")
                                            RiskPAA_CrossGammaPL.Add(Double.Parse(values[39]));
                                        else
                                            RiskPAA_CrossGammaPL.Add(0);

                                        RiskPAA_VarSwap.Add(Double.Parse(values[40]));

                                        RiskPAA_VGVolAtm.Add(Double.Parse(values[41]));

                                        RiskPAA_VGSkew.Add(Double.Parse(values[42]));

                                        RiskPAA_VGSmile.Add(Double.Parse(values[43]));

                                        RiskPAA_VGCallWingA.Add(Double.Parse(values[44]));

                                        RiskPAA_VGCallWingB.Add(Double.Parse(values[45]));

                                        RiskPAA_VGPutWingA.Add(Double.Parse(values[46]));

                                        RiskPAA_VGPutWingB.Add(Double.Parse(values[47]));

                                        RiskPAA_VGRefForward.Add(Double.Parse(values[48]));

                                        NewTrades.Add(Double.Parse(values[49]));

                                        DayTrading.Add(Double.Parse(values[50]));

                                        Upsize_Downsize.Add(Double.Parse(values[51]));

                                        IntradayTradingPL.Add(Double.Parse(values[52]));

                                        TerminatedTrades.Add(Double.Parse(values[53]));

                                        CommissionPL_DTD_T_1.Add(Double.Parse(values[54]));

                                        FairVsMktDiff.Add(Double.Parse(values[55]));

                                        InterestPL_DTD_T_1.Add(Double.Parse(values[56]));

                                        DividendPL_DTD_T_1.Add(Double.Parse(values[57]));

                                        CouponPL_DTD_T_1.Add(Double.Parse(values[58]));

                                        ExtraordinaryPL_DTD_T_1.Add(Double.Parse(values[59]));

                                        NetAccruedInterest_DTD_T_1.Add(Double.Parse(values[60]));

                                        CreditPAA.Add(Double.Parse(values[61]));

                                        SecurityChangePAA.Add(Double.Parse(values[62]));

                                        if (values[63] != "")
                                            Carry_Theta.Add(Double.Parse(values[63]));
                                        else
                                            Carry_Theta.Add(0);

                                        SecurityChangePAA2.Add(Double.Parse(values[64]));

                                        if (values[65] != "")
                                            Theta.Add(Double.Parse(values[65]));
                                        else
                                            Theta.Add(0);

                                        IntradayTradingPLUSD.Add(Double.Parse(values[66]));

                                        KOPL.Add(Double.Parse(values[67]));

                                        if (values[68] != "")

                                            TotalPAA.Add(Double.Parse(values[68]));
                                        else
                                            TotalPAA.Add(0);

                                        FairEconomicDTDS_T_1.Add(Double.Parse(values[69]));

                                        if (values[70] != "")
                                            Residual.Add(Double.Parse(values[70]));
                                        else
                                            Residual.Add(0);

                                        if (values[71] != "")
                                            PercentageResidual.Add(Double.Parse(values[71]));
                                        else
                                            PercentageResidual.Add(0);

                                        StressingErrors.Add(values[72]);

                                        IsVIXModel.Add(Int32.Parse(values[73]));

                                        IsVanillaModel.Add(Int32.Parse(values[74]));

                                        if (values[75] != "")
                                            FairValue_T_1.Add(Double.Parse(values[75]));
                                        else
                                            FairValue_T_1.Add(0);

                                        if (values[76] != "")
                                            FairValue_T_2.Add(Double.Parse(values[76]));
                                        else
                                            FairValue_T_2.Add(0);

                                        FinalCounterparty.Add(values[77]);

                                        SecurityId.Add(Int32.Parse(values[78]));

                                        RiskPAA_VGPutSlopeTW.Add(Double.Parse(values[79]));

                                        RiskPAA_VGPutConvexityTW.Add(Double.Parse(values[80]));

                                        RiskPAA_VGCallSlopeTW.Add(Double.Parse(values[81]));

                                        RiskPAA_VGCallConvexityTW.Add(Double.Parse(values[82]));

                                        IsTerminatedWithZeroFairValue.Add(Int32.Parse(values[83]));

                                        VolGeoStressErrors.Add(values[84]);

                                        ExchangeFeesPLDTD_T_1.Add(Double.Parse(values[85]));

                                        OtherFeesPLDTD_T_1.Add(Double.Parse(values[86]));

                                        //these columns dont exist in NAM
                                        FairEconomicDTD_T_1.Add(0);
                                        AverageCost_T_2.Add(0);
                                        AccountEntity.Add("");

                                        if (folder.Contains("NAM"))
                                            Region.Add("NAM");

                                        if (folder.Contains("EMEA"))
                                            Region.Add("EMEA");

                                        PositionNode.Add(positionNode);

                                        EodDate.Add(eodDate);
                                    }
                                }

                                finally
                                {
                                    fStream.Close();
                                }
                            }
                        }
                    }

                    date = date.AddDays(1);
                }

            }

            
            foreach (var folder in folders)
            {
                if (!folder.Contains("APAC"))
                    continue;

                var date = fromDate;

                while (date <= toDate)
                {
                    string fileSubstring = date.ToString("yyyyMMdd") + ".txt";

                    var files = Directory.GetFiles(folder);

                    foreach (string fileName in files)
                    {
                        if (!fileName.Contains(fileSubstring) || !fileName.Contains("RiskPAASummary"))
                            continue;

                        Console.WriteLine(fileName);

                        //using (FileStream fStream = File.OpenRead(fileName))
                        using (FileStream fStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            var fileMetaData = fileName.Split('.');
                            string positionNode = fileMetaData[fileMetaData.Length - 3];
                            string eodDate = fileMetaData[fileMetaData.Length - 2];

                            using (var reader = new StreamReader(fStream))
                            {

                                try
                                {
                                    int j = 0;

                                    while (!reader.EndOfStream)
                                    {
                                        var line = reader.ReadLine();

                                        var values = line.Split('\t');

                                        if (string.Equals(values[7], "Portfolio") || string.Equals(values[7], "ExternalSecurity"))
                                            continue;

                                        if (values[0] == "Position Id" || values[0] == "")
                                        {
                                            continue;
                                        }

                                        PositionId.Add(Int32.Parse(values[0]));

                                        Expiry.Add(values[1]);

                                        CompoundPositionId.Add(values[2]);

                                        Cusipv2.Add(values[3]);

                                        ComponentMnem.Add(values[4]);

                                        if (values[5] != "")
                                            Strike.Add(Double.Parse(values[5]));
                                        else
                                            Strike.Add(0);

                                        PackageNumber.Add(values[6]);

                                        SecurityType.Add(values[7]);

                                        PC.Add(values[8]);

                                        SecurityCurrency.Add(values[9]);

                                        ModelName.Add(values[10]);

                                        Account.Add(values[11]);


                                        double UnderlyingPriceT_2_Value;
                                        if (Double.TryParse(values[12], out UnderlyingPriceT_2_Value))
                                            UnderlyingPriceT_2.Add(UnderlyingPriceT_2_Value);
                                        else
                                            UnderlyingPriceT_2.Add(0);

                                        double UnderlyingPriceT_1_Value;
                                        if (Double.TryParse(values[13], out UnderlyingPriceT_1_Value))
                                            UnderlyingPriceT_1.Add(UnderlyingPriceT_1_Value);
                                        else
                                            UnderlyingPriceT_1.Add(0);

                                        if (values[14] != "")
                                            Gamma_1_T_2.Add(Double.Parse(values[14]));
                                        else
                                            Gamma_1_T_2.Add(0);

                                        if (values[15] != "")
                                            Vega_1_T_2.Add(Double.Parse(values[15]));
                                        else
                                            Vega_1_T_2.Add(0);

                                        if (values[16] != "")
                                            PV01_bp_T_2.Add(Double.Parse(values[16]));
                                        else
                                            PV01_bp_T_2.Add(0);

                                        if (values[17] != "")
                                            CR01_T_2.Add(Double.Parse(values[17]));
                                        else
                                            CR01_T_2.Add(0);

                                        if (values[18] != "")
                                            Delta_T_2.Add(Double.Parse(values[18]));
                                        else
                                            Delta_T_2.Add(0);

                                        if (values[19] != "")
                                            COB_Price_T_1.Add(Double.Parse(values[19]));
                                        else
                                            COB_Price_T_1.Add(0);

                                        Quantity_T_1.Add(Double.Parse(values[20]));

                                        Quantity_T_2.Add(Double.Parse(values[21]));

                                        TradeQuantity.Add(Double.Parse(values[22]));

                                        KOTrades.Add(Double.Parse(values[23]));

                                        RiskPAA_DeltaPL.Add(Double.Parse(values[24]));

                                        RiskPAA_GammaPL.Add(Double.Parse(values[25]));

                                        RiskPAA_FXDeltaPL.Add(Double.Parse(values[26]));

                                        RiskPAA_FXDelta_TradeCcyAdj.Add(Double.Parse(values[27]));

                                        RiskPAA_FXDelta_DTDSAdj.Add(Double.Parse(values[28]));

                                        RiskPAA_ASASPL.Add(Double.Parse(values[29]));

                                        RiskPAA_ASFXPL.Add(Double.Parse(values[30]));

                                        RiskPAA_RatePL.Add(Double.Parse(values[31]));

                                        RiskPAA_IRVolPL.Add(Double.Parse(values[32]));

                                        RiskPAA_VolatilityPL.Add(Double.Parse(values[33]));

                                        RiskPAA_VolGeoUndsPL.Add(Double.Parse(values[34]));

                                        RiskPAA_VGVolAtm.Add(Double.Parse(values[35]));

                                        RiskPAA_VGSkew.Add(Double.Parse(values[36]));

                                        RiskPAA_VGSmile.Add(Double.Parse(values[37]));

                                        RiskPAA_VGPutWingA.Add(Double.Parse(values[38]));

                                        RiskPAA_VGPutWingB.Add(Double.Parse(values[39]));

                                        RiskPAA_VGCallWingA.Add(Double.Parse(values[40]));

                                        RiskPAA_VGCallWingB.Add(Double.Parse(values[41]));

                                        RiskPAA_VGRefForward.Add(Double.Parse(values[42]));

                                        RiskPAA_VolThetaAdj.Add(Double.Parse(values[43]));

                                        RiskPAA_BorrowCostPL.Add(Double.Parse(values[44]));

                                        RiskPAA_DividendPL.Add(Double.Parse(values[45]));

                                        RiskPAA_CrossGammaPL.Add(Double.Parse(values[46]));

                                        RiskPAA_VarSwap.Add(Double.Parse(values[47]));

                                        CreditPAA.Add(Double.Parse(values[48]));

                                        NewTrades.Add(Double.Parse(values[49]));

                                        DayTrading.Add(Double.Parse(values[50]));

                                        Upsize_Downsize.Add(Double.Parse(values[51]));

                                        TerminatedTrades.Add(Double.Parse(values[52]));

                                        CommissionPL_DTD_T_1.Add(Double.Parse(values[53]));

                                        FairVsMktDiff.Add(Double.Parse(values[54]));

                                        InterestPL_DTD_T_1.Add(Double.Parse(values[55]));

                                        DividendPL_DTD_T_1.Add(Double.Parse(values[56]));

                                        ExtraordinaryPL_DTD_T_1.Add(Double.Parse(values[57]));

                                        SecurityChangePAA2.Add(Double.Parse(values[58]));

                                        Theta.Add(Double.Parse(values[59]));

                                        IntradayTradingPLUSD.Add(Double.Parse(values[60]));

                                        KOPL.Add(Double.Parse(values[61]));

                                        TotalPAA.Add(Double.Parse(values[62]));

                                        FairEconomicDTD_T_1.Add(Double.Parse(values[63]));

                                        FairEconomicDTDS_T_1.Add(Double.Parse(values[64]));

                                        Residual.Add(Double.Parse(values[65]));

                                        if (values[66] != "")
                                            AverageCost_T_2.Add(Double.Parse(values[66]));
                                        else
                                            AverageCost_T_2.Add(0);

                                        PercentageResidual.Add(Double.Parse(values[67]));

                                        StressingErrors.Add(values[68]);

                                        IsVIXModel.Add(Int32.Parse(values[69]));

                                        IsVanillaModel.Add(Int32.Parse(values[70]));

                                        if (values[71] != "")
                                            FairValue_T_1.Add(Double.Parse(values[71]));
                                        else
                                            FairValue_T_1.Add(0);

                                        AccountEntity.Add(values[72]);

                                        AccountEntityCode.Add(values[73]);

                                        SecurityId.Add(Int32.Parse(values[74]));

                                        RiskPAA_VGPutSlopeTW.Add(Double.Parse(values[75]));

                                        RiskPAA_VGPutConvexityTW.Add(Double.Parse(values[76]));

                                        RiskPAA_VGCallSlopeTW.Add(Double.Parse(values[77]));

                                        RiskPAA_VGCallConvexityTW.Add(Double.Parse(values[78]));

                                        IsTerminatedWithZeroFairValue.Add(Int32.Parse(values[79]));

                                        VolGeoStressErrors.Add(values[80]);

                                        ExchangeFeesPLDTD_T_1.Add(Double.Parse(values[81]));

                                        OtherFeesPLDTD_T_1.Add(Double.Parse(values[82]));

                                        //the below columns dont exist in apac
                                        IntradayTradingPL.Add(0);

                                        CouponPL_DTD_T_1.Add(0);

                                        NetAccruedInterest_DTD_T_1.Add(0);

                                        SecurityChangePAA.Add(0);

                                        Carry_Theta.Add(0);

                                        FairValue_T_2.Add(0);

                                        FinalCounterparty.Add("");

                                        Region.Add("APAC");

                                        PositionNode.Add(positionNode);

                                        EodDate.Add(eodDate);
                                    }
                                }

                                finally
                                {
                                    fStream.Close();
                                }
                            }
                        }
                    }

                    date = date.AddDays(1);
                }

            }

            
            Console.WriteLine("Position Id: " + PositionId.Count);
            Console.WriteLine("Expiry: " + Expiry.Count);
            Console.WriteLine("Compound Position Id: " + CompoundPositionId.Count);
            Console.WriteLine("Cusip: " + Cusipv2.Count);
            Console.WriteLine("Component Mnem: " + ComponentMnem.Count);
            Console.WriteLine("Strike: " + Strike.Count);
            Console.WriteLine("Package Number: " + PackageNumber.Count);
            Console.WriteLine("Security Type: " + SecurityType.Count);
            Console.WriteLine("PC: " + PC.Count);
            Console.WriteLine("Security Currency: " + SecurityCurrency.Count);
            Console.WriteLine("Model Name: " + ModelName.Count);
            Console.WriteLine("Account: " + Account.Count);
            Console.WriteLine("Account Entity Code: " + AccountEntityCode.Count);
            Console.WriteLine("Underlying Price T-2: " + UnderlyingPriceT_2.Count);
            Console.WriteLine("Underlying Price T-1: " + UnderlyingPriceT_1.Count);
            Console.WriteLine("Gamma 1%: " + Gamma_1_T_2.Count);
            Console.WriteLine("Vega 1%: " + Vega_1_T_2.Count);
            Console.WriteLine("PV01_bp: " + PV01_bp_T_2.Count);
            Console.WriteLine("CR01: " + CR01_T_2.Count);
            Console.WriteLine("Delta: " + Delta_T_2.Count);
            Console.WriteLine("COB Price: " + COB_Price_T_1.Count);
            Console.WriteLine("Quantity T-1: " + Quantity_T_1.Count);
            Console.WriteLine("Quantity T-2: " + Quantity_T_2.Count);
            Console.WriteLine("Trade Quantity: " + TradeQuantity.Count);
            Console.WriteLine("KO Trades: " + KOTrades.Count);
            Console.WriteLine("Delta PL: " + RiskPAA_DeltaPL.Count);
            Console.WriteLine("Gamma PL: " + RiskPAA_GammaPL.Count);
            Console.WriteLine("FX Delta PL: " + RiskPAA_FXDeltaPL.Count);
            Console.WriteLine("FX Delta TradeCcyAdj: " + RiskPAA_FXDelta_TradeCcyAdj.Count);
            Console.WriteLine("FX Delta DTDAdj: " + RiskPAA_FXDelta_DTDSAdj.Count);
            Console.WriteLine("ASAS PL: " + RiskPAA_ASASPL.Count);
            Console.WriteLine("ASFX PL: " + RiskPAA_ASFXPL.Count);
            Console.WriteLine("Rate PL: " + RiskPAA_RatePL.Count);
            Console.WriteLine("IR Vol PL: " + RiskPAA_IRVolPL.Count);
            Console.WriteLine("Volatility PL: " + RiskPAA_VolatilityPL.Count);
            Console.WriteLine("VolGeo Und PL: " + RiskPAA_VolGeoUndsPL.Count);
            Console.WriteLine("VolThetaAdj: " + RiskPAA_VolThetaAdj.Count);
            Console.WriteLine("Borrow Cost PL: " + RiskPAA_BorrowCostPL.Count);
            Console.WriteLine("Dividend PL: " + RiskPAA_DividendPL.Count);
            Console.WriteLine("Cross Gamma PL: " + RiskPAA_CrossGammaPL.Count);
            Console.WriteLine("VarSwap: " + RiskPAA_VarSwap.Count);
            Console.WriteLine("VG VOl Atm: " + RiskPAA_VGVolAtm.Count);
            Console.WriteLine("VG Skew: " + RiskPAA_VGSkew.Count);
            Console.WriteLine("VG Smile: " + RiskPAA_VGSmile.Count);
            Console.WriteLine("VG Call WingA: " + RiskPAA_VGCallWingA.Count);
            Console.WriteLine("VG Call Wing B: " + RiskPAA_VGCallWingB.Count);
            Console.WriteLine("VG Put WingA: " + RiskPAA_VGPutWingA.Count);
            Console.WriteLine("VG Put Wing B: " + RiskPAA_VGPutWingB.Count);
            Console.WriteLine("VG Ref Forwards: " + RiskPAA_VGRefForward.Count);
            Console.WriteLine("New trades: " + NewTrades.Count);
            Console.WriteLine("Day Trading: " + DayTrading.Count);
            Console.WriteLine("Upsize_Downsize: " + Upsize_Downsize.Count);
            Console.WriteLine("INtraday trading PL: " + IntradayTradingPL.Count);
            Console.WriteLine("Terminated Trades: " + TerminatedTrades.Count);
            Console.WriteLine("Commission PL " + CommissionPL_DTD_T_1.Count);
            Console.WriteLine("Fair vs Mkt Diff: " + FairVsMktDiff.Count);
            Console.WriteLine("InterestPL " + InterestPL_DTD_T_1.Count);
            Console.WriteLine("DividendPL " + DividendPL_DTD_T_1.Count);
            Console.WriteLine("CouponPL: " + CouponPL_DTD_T_1.Count);
            Console.WriteLine("Extraordinary PL: " + ExtraordinaryPL_DTD_T_1.Count);
            Console.WriteLine("Net Accrued Interest: " + NetAccruedInterest_DTD_T_1.Count);
            Console.WriteLine("Credit PAA: " + CreditPAA.Count);
            Console.WriteLine("Security ChangePAA: " + SecurityChangePAA.Count);
            Console.WriteLine("Carry_Theta: " + Carry_Theta.Count);
            Console.WriteLine("Security Change PAA 2: " + SecurityChangePAA2.Count);
            Console.WriteLine("Theta: " + Theta.Count);
            Console.WriteLine("Intraday Trading PL USD: " + IntradayTradingPLUSD.Count);
            Console.WriteLine("KO PL: " + KOPL.Count);
            Console.WriteLine("Total PAA: " + TotalPAA.Count);
            Console.WriteLine("Fair Economic DTDS: " + FairEconomicDTDS_T_1.Count);
            Console.WriteLine("Residual: " + Residual.Count);
            Console.WriteLine("Percentage Residual: " + PercentageResidual.Count);
            Console.WriteLine("Stressing Errors: " + StressingErrors.Count);
            Console.WriteLine("Is VIX Model: " + IsVIXModel.Count);
            Console.WriteLine("Is Vanilla MOdel: " + IsVanillaModel.Count);
            Console.WriteLine("Fair Value T-1: " + FairValue_T_1.Count);
            Console.WriteLine("Fair Value T-2: " + FairValue_T_2.Count);
            Console.WriteLine("Final Counterparty: " + FinalCounterparty.Count);
            Console.WriteLine("Security ID: " + SecurityId.Count);
            Console.WriteLine("VG PutSlope TW: " + RiskPAA_VGPutSlopeTW.Count);
            Console.WriteLine("VG PutConvexity TW: " + RiskPAA_VGPutConvexityTW.Count);
            Console.WriteLine("VG Call SlopeTW: " + RiskPAA_VGCallSlopeTW.Count);
            Console.WriteLine("VG Call Convexity TW: " + RiskPAA_VGCallConvexityTW.Count);
            Console.WriteLine("Is terminated with zero fair value: " + IsTerminatedWithZeroFairValue.Count);
            Console.WriteLine("Vol Geo Stress errors: " + VolGeoStressErrors.Count);
            Console.WriteLine("Exchange Fees PL: " + ExchangeFeesPLDTD_T_1.Count);
            Console.WriteLine("Other fees PL: " + OtherFeesPLDTD_T_1.Count);

            Console.WriteLine("Fair Economic DTD: " + FairEconomicDTD_T_1.Count);
            Console.WriteLine("Average Cost " + AverageCost_T_2.Count);
            Console.WriteLine("Account Entity: " + AccountEntity.Count);

            Console.WriteLine("Region: " + Region.Count);
            Console.WriteLine("Position Node: " + PositionNode.Count);
            Console.WriteLine("EodDate: " + EodDate.Count);

            List<string[]> HighResidualSummaryOutput = new List<string[]>();
            //List<string[]> HighPLSummaryOutput = new List<string[]>();
            IEnumerable<string> distinctEod = EodDate.Distinct();


            Dictionary<string, Dictionary<string, double[]>> HighLevelSummaryOutput = new Dictionary<string, Dictionary<string, double[]>>();



            string[] regions = { "EMEA", "NAM", "APAC" };





            foreach (var date in distinctEod)
            {
                foreach (var region in regions)
                {
                    double numberOfDefault = 0;
                    double absoluteResidual = 0;
                    double absolutePL = 0;

                    for (int i = 0; i < PositionId.Count; i++)
                    {
                        if (EodDate[i] != date)
                            continue;

                        if (Region[i] != region)
                            continue;

                        if (Math.Abs(Residual[i]) > 10000)
                        {
                            if (Math.Abs(Residual[i] / FairEconomicDTDS_T_1[i]) > 0.1)
                            {

                                //at the moment running one date at a time. so this logic works in that case only
                                if (!HighLevelSummaryOutput.ContainsKey(date))
                                    HighLevelSummaryOutput[date] = new Dictionary<string, double[]>();

                                if (!HighLevelSummaryOutput[date].ContainsKey(region))
                                    HighLevelSummaryOutput[date][region] = new double[3];


                                string[] rows = new string[7];
                                rows[0] = EodDate[i];
                                rows[1] = Region[i];
                                rows[2] = PositionNode[i];
                                rows[3] = PositionId[i].ToString();
                                rows[4] = Account[i];
                                rows[5] = FairEconomicDTDS_T_1[i].ToString();
                                rows[6] = Residual[i].ToString();


                                HighResidualSummaryOutput.Add(rows);

                                numberOfDefault++;
                                absoluteResidual += Math.Abs(Residual[i]);
                                absolutePL += Math.Abs(FairEconomicDTDS_T_1[i]);

                            }

                        }

                    }

                    if (HighLevelSummaryOutput[date].ContainsKey(region))
                    {
                        HighLevelSummaryOutput[date][region][0] = numberOfDefault;
                        HighLevelSummaryOutput[date][region][1] = absoluteResidual;
                        HighLevelSummaryOutput[date][region][2] = absolutePL;
                    }
                }
            }
            
            

            var csv = new StringBuilder();
            var headers = "EodDate,Region,Position Node,PosId,Account,Fair Economic DTDS,Residual";
            csv.AppendLine(headers);

            foreach (var row in HighResidualSummaryOutput)
            {
                var newLine = string.Format("{0},{1},{2},{3},{4},{5},{6}", row[0], row[1], row[2], row[3],row[4],row[5],row[6]);
                csv.AppendLine(newLine);
            }

            File.WriteAllText(@"N:\Issues\High Residual\HighResidualSummaryOutput_" + fromDate.ToString("yyyyMMdd") + "_" + toDate.ToString("yyyyMMdd") + ".csv", csv.ToString());

            var csv2 = new StringBuilder();
            var header = "Date,Region,Number of Defaults,Absolute Residual Sum,Absolute PL move";
            csv2.AppendLine(header);

            foreach (var date in HighLevelSummaryOutput)
            {
                foreach (var region in HighLevelSummaryOutput[date.Key])
                {
                    var newLine = string.Format("{0},{1},{2},{3},{4}", date.Key, region.Key, region.Value[0], region.Value[1], region.Value[2]);
                    csv2.AppendLine(newLine);
                }
            }

            File.WriteAllText(@"N:\Issues\High Residual\HighLevelSummaryOutput_" + fromDate.ToString("yyyyMMdd") + "_" + toDate.ToString("yyyyMMdd") + ".csv", csv2.ToString());
            
        }
    }
}

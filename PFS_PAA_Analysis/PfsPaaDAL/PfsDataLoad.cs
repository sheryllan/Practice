using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EQTG.Database;
using PFSDataLayer.Util;
using PFSFeed;
using PFSFeed.Model;
using System.Collections;

namespace PfsPaaDAL
{
    public enum Region
    {
        EMEA,
        NAM,
        APAC
    }
    public class PfsDataLoad
    {
        public List<PfsData> PfsHist { get; private set; }
        public List<PaaData> PaaHist { get; private set; }

        public Dictionary<int, PfsData> PfsDataSet { get; private set ; }
        public Dictionary<int, PaaData> PaaDataSet { get; private set; }

        public Dictionary<int, PfsDbConsistencyData> ConsistencyDataSet { get; private set; }
        public Dictionary<int, PaaData> PaaDtdDataSet { get; private set; }

        #region config

        public readonly PFSGateway PFSGateway;
        //public const string EQPasswordDir = @"\\LDNEQTSAcs650DV\eqtg\AsapRiskGrid\RegressionTest\job\Security";
        public const string EQPasswordDir = @"\\ldneqtsacs654dv\EQTGSecurity\UA";
        public static readonly Dictionary<Region, DBConnectionDetails> DbConnections = new Dictionary<Region, DBConnectionDetails>
        {
            //{ Region.EMEA, new DBConnectionDetails("EQTGDBDEV1_DS", "eqjobs", "jobs99", "DRMS", "_PositionFeed_test", DBProvider.Odbc) },
            { Region.EMEA,   new DBConnectionDetails("DRMSPROD", "cl31006", "Jobs33king", "DRMS", "_test_", DBProvider.Odbc) },

            //{ Region.APAC, new DBConnectionDetails("HKDRMSUAT_DS", "eqjobssa", "citi05", "DRMS", "_test_", DBProvider.Odbc) },
            { Region.APAC, new DBConnectionDetails("HKDRMSPROD", "cl31006", "Jobs33king", "DRMS", "_test_", DBProvider.Odbc) },

            //{ Region.NAM, new DBConnectionDetails("NYDRMS_DM2", "proddbo", "proddbo", "DRMS", "_test_", DBProvider.Odbc) },
            { Region.NAM, new DBConnectionDetails("NYDRMS_PROD", "cl31006", "Jobs33king", "DRMS", "_test_", DBProvider.Odbc) },
            //{ Region.NAM, new DBConnectionDetails("NYDRMS_PROD", "eqrmsjob", GetCred("eqrmsjob", "NYDRMS_PROD"), "DRMS", "_test_", DBProvider.Odbc) },
        };
        public static readonly Dictionary<Region, string> EqrmsPfsRegionMap = new Dictionary<Region, string> { { Region.EMEA, "EUR" }, { Region.NAM, "US" }, { Region.APAC, "ASIA" } };

        public static readonly Dictionary<Region, string> RootPath = new Dictionary<Region, string>
        {
            { Region.NAM, @"\\eqtextny12\jobs\log\running\PA6" },
        };
        public static readonly Dictionary<Region, Tuple<string, string>> VolckerBox = new Dictionary<Region, Tuple<string, string>>
        {
            { Region.NAM, Tuple.Create(@"150744_VolckerPAAFeed_Box\150744_VolckerRiskBasedPAAFeed_*_*", "EQRMSRISKBASED.PAA.XProduct.NAM.*.data") },
        };
        public static readonly Dictionary<Region, Tuple<string, string>> ChkVolckerBox = new Dictionary<Region, Tuple<string, string>>
        {
            { Region.NAM, Tuple.Create(@"150744_CheckVolckerPAAFeed_Box\150744_CheckRiskBasedPAAFeed_*_*", "EQRMSRB.PAA.XProduct.NAM.POS.*.txt") },
        };

        public const string URL = "http://pfseqrmsprod.eur.nsroot.net:4569/PfsExternalFeeds/RiskFeed/SwapData/Service.svc"; 
        // see NB 1: PFS environments
        //public const string URL="http://pfseqrmsuat.eur.nsroot.net:4569/PfsExternalFeeds/RiskFeed/SwapData/Service.svc"; // UAT
        //public const string URL="http://vm-06c1-7fb6.nam.nsroot.net:4569/PfsExternalFeeds/RiskFeed/SwapData/Service.svc"; // CI
        public const string LiveURLFormat = URL + "/web/GetCurrentSwap?password=password&pfsid={0}";
        public const string EodURLFormat = URL + "/web/GetEodSwap?password=password&eodTag={0}&date={1}&pfsid={2}";
        #endregion config

        public PfsDataLoad()
        {
            PFSGateway = new PFSGateway();
            PFSGateway.Initialise("pfsProd", URL, "BasicHttpBinding", "basicHttp1", "password");
        }

        public Dictionary<int, Dictionary<string, double>> InitialiseFxHist(Region region, int startingDate)
        {
            return ReadFXHist(DbConnections[region], startingDate);
        }


        public IEnumerable<IGrouping<string, int>> GroupByExtId(Region region, IEnumerable<int> posIds)
        {
            posIds = posIds.Distinct().ToList();

            var pfsIds = GetPfsIds(DbConnections[region], posIds).ToDictionary(p => (int)p.posId, p => (string)p.pfsId);

            var extIdGroup = pfsIds.GroupBy(p => p.Value.Substring(0, p.Value.LastIndexOf('-')), p => p.Key);

            return extIdGroup;
        }


        public void GetOnePositionData(Region region, int posId, List<int> dates, Dictionary<int, Dictionary<string, double>> fxHist, string pfsId = null, int goBack = 2)
        {
            if (pfsId == null) pfsId = GetPfsId(DbConnections[region], posId);
            if(fxHist == null) throw new ArgumentNullException(nameof(fxHist));

            dates.Sort((a, b) => a.CompareTo(b));
            var fromDate = Utility.DateToRover8(Utility.AddBusinessDays(Utility.Rover8ToDate(dates[0]), -goBack - 1, null));
            var tillDate = dates.Last();

            PaaHist = ReadPaaData(DbConnections[region], posId, fromDate, tillDate);
            var paaHistDict = PaaHist.ToDictionary(h => h.EodDate, h => h);

            var pfsHistDict = FetchPfsSwapHistory(region, pfsId, fromDate, tillDate).OrderBy(s => s.Key).ToList();

            PfsHist = new List<PfsData>();
            var i = -1;
            foreach (var d in dates)
            {
                do
                {
                    i++;                    
                } while (i < pfsHistDict.Count - 1 && pfsHistDict[i].Key < d);


                if (pfsHistDict[i].Key != d)
                    continue;

                var swap_T_1 = pfsHistDict[i].Value;
                var swap_T_2 = pfsHistDict[i == 0 ? 0 : i - 1].Value;

                var fxRates = fxHist.ContainsKey(d) ? fxHist[d] : null;
                var fxRate = Utility.GetFxRate(fxRates, swap_T_1.SwapCurrency);

                PfsHist.Add(new PfsData(d, swap_T_1, swap_T_2, fxRate));
                                
                Console.WriteLine(EodURLFormat, EqrmsPfsRegionMap[region], d, pfsId);
                Console.WriteLine(LiveURLFormat, pfsId);
            }
        }
        
        //public void ShowHist(Region region, int date, int posId = -1, string pfsId = null, int goBack = 2, bool showFixes = false)
        //{
        //    if (pfsId == null) pfsId = GetPfsId(DbConnections[region], posId);
        //    if (posId < 0) posId = GetPfsPosId(DbConnections[region], pfsId);
        //    var secId = GetPfsSecId(DbConnections[region], pfsId);
        //    var underlyer = GetUnderlyer(DbConnections[region], posId);
        //    var fromDate = Utility.DateToRover8(Utility.AddBusinessDays(Utility.Rover8ToDate(date), -goBack - 1, null));
        //    var fxHist = ReadFXHist(DbConnections[region], fromDate);
        //    //    fxHist.Select(kvp => new { Dt = kvp.Key, FX_USD_GBP = kvp.Value["GBP"], FX_USD_AUD = kvp.Value["AUD"], }).Dump();
        //    PaaHist = ReadPaaData(DbConnections[region], posId, fromDate);
        //    var paaHistDict = PaaHist.ToDictionary(h => h.EodDate, h => h);

        //    //string.Format("date= {0}, posId= {1}, secId= {2}, extId= {3},\t\t\t\t\t\t{4}", date, posId, secId, pfsId, underlyer).Dump();
        //    //string.Format(LiveURLFormat, pfsId).Dump();
        //    //string.Format(EodURLFormat, EqrmsPfsRegionMap[region], date, pfsId).Dump();
        //    Console.WriteLine(string.Format("date= {0}, posId= {1}, secId= {2}, extId= {3},\t\t\t\t\t\t{4}", date, posId, secId, pfsId, underlyer));
        //    Console.WriteLine(string.Format(LiveURLFormat, pfsId));
        //    Console.WriteLine(string.Format(EodURLFormat, EqrmsPfsRegionMap[region], date, pfsId));
        //    var pfsHist = FetchPfsSwapHistory(region, pfsId, fromDate).Select(sw => new { Date = sw.Key, Swap = sw.Value }).OrderBy(s => s.Date).ToList();
      
        //}

        #region Methods called by ShowHist
        public void PopulateDateSets(int date)
        {
            //"".Dump("PFS Data"); pfsData.Dump();           
            PfsDataSet = PfsHist.Skip(1).TakeWhile(p => p.Date <= date).ToDictionary(h => h.Date, h => h);

            //"".Dump("PL Consistency Data");
            var plData = (from p in PfsHist
                          join d in PaaHist on p.Date equals d.EodDate
                          select PfsDbConsistencyData.CreatePfsDbConsistencyData(p.Swap_T_1, d)
                          ).Skip(1).TakeWhile(p => p.EodDate <= date);
            ConsistencyDataSet = plData.ToDictionary(h => h.EodDate, h => h);

            //"".Dump("PAA Data");
            PaaDataSet = PaaHist.Skip(1).TakeWhile(p => p.EodDate <= date).ToDictionary(h => h.EodDate, h => h);//.Dump();

            //"".Dump("PAA DtD Data");
            PaaDtdDataSet = PaaDtDData(PaaHist).Skip(1).TakeWhile(p => p.EodDate <= date).ToDictionary(h => h.EodDate, h => h);//.Dump();

            //var paaUsdfied = PaaUsdFiedData(paaHist.TakeWhile(p => p.EodDate <= date).ToList(), fxHist);
            //"".Dump("PAA Data USDfied");
            //paaUsdfied.Skip(1)
            //.Dump();
            //"".Dump("PAA DtD Data USDfied");
            //PaaDtDData(paaUsdfied).Skip(1)
            //.Dump();
        }

        public static List<PaaData> ReadPaaData(DBConnectionDetails conn, int posId, int fromDate, int tillDate = 0)
        {
            if (tillDate < fromDate)
                tillDate = Utility.DateToRover8(DateTime.Today);

            var query = string.Format(@"select pq.eodDate, pq.posId, pq.quantity, r.spot, r.delta, r.theta, r.markOK
                , pl.fairValue, pl.averageCost, pl.interest, pl.coupon, pl.dividend, pl.realised, pl.commission, pl.extraordinary EOPL, pl.thetaPL, pl.plOK
                , pla.averageCost avgCostA, pla.realised rlsdA, pla.commission commA
                , ple.extraordinary EOPLE, plrd.accruedInterest AccIntPLRD, plrd.coupon couponPLRD, plrd.dividend DivPLRD
                , pl.currency CCY
                , dc.result DayCount, lr.result LiborRate, lp.result LiborPrem, ep.result EquityPrem, dp.result DivPrem
                from ARCH..pfsTradedQuantity pq
                join ARCH..risk r on r.eodDate = pq.eodDate and r.posId=pq.posId
                join ARCH..profitLoss pl on pl.eodDate = pq.eodDate and pl.posId=pq.posId
                left outer join ARCH..plArchive pla on pla.eodDate = pq.eodDate and pla.posId=pq.posId
                left outer join ARCH..profitLossExtraordinary ple on ple.eodDate = pq.eodDate and ple.posId=pq.posId
                left outer join ARCH..profitLossRawData plrd on plrd.eodDate = pq.eodDate and plrd.posId=pq.posId
                left outer join ARCH..flexibleModelResults dc on dc.eodDate = pq.eodDate and dc.posId=pq.posId and dc.resultId = 170
                left outer join ARCH..flexibleModelResults lr on lr.eodDate = pq.eodDate and lr.posId=pq.posId and lr.resultId = 13
                left outer join ARCH..flexibleModelResults lp on lp.eodDate = pq.eodDate and lp.posId=pq.posId and lp.resultId = 8
                left outer join ARCH..flexibleModelResults ep on ep.eodDate = pq.eodDate and ep.posId=pq.posId and ep.resultId = 9
                left outer join ARCH..flexibleModelResults dp on dp.eodDate = pq.eodDate and dp.posId=pq.posId and dp.resultId = 5
                where pq.eodDate between {1} and {2} 
                and pq.posId={0}
                order by pq.eodDate
                ", posId, fromDate, tillDate);
            
            //query.Dump();
            return DbUtils.ExecuteReader(conn, query,
                ri => new
                {
                    EodDate = ri.GetOrdinal("eodDate"),
                    PosId = ri.GetOrdinal("posId"),
                    Quantity = ri.GetOrdinal("quantity"),
                    Spot = ri.GetOrdinal("spot"),
                    Delta = ri.GetOrdinal("delta"),
                    Theta = ri.GetOrdinal("theta"),
                    MOK = ri.GetOrdinal("markOK"),
                    FairValue = ri.GetOrdinal("fairValue"),
                    AverageCost = ri.GetOrdinal("averageCost"),
                    Interest = ri.GetOrdinal("interest"),
                    Coupon = ri.GetOrdinal("coupon"),
                    Dividend = ri.GetOrdinal("dividend"),
                    Realised = ri.GetOrdinal("realised"),
                    Commission = ri.GetOrdinal("commission"),
                    EOPL = ri.GetOrdinal("EOPL"),
                    ThetaPL = ri.GetOrdinal("thetaPL"),
                    PLOK = ri.GetOrdinal("plOK"),
                    AvgCostA = ri.GetOrdinal("avgCostA"),
                    RlsdA = ri.GetOrdinal("rlsdA"),
                    CommA = ri.GetOrdinal("commA"),
                    EOPLE = ri.GetOrdinal("EOPLE"),
                    AccIntPLRD = ri.GetOrdinal("AccIntPLRD"),
                    CouponPLRD = ri.GetOrdinal("couponPLRD"),
                    DivPLRD = ri.GetOrdinal("DivPLRD"),
                    CCY = ri.GetOrdinal("CCY"),
                    DayCount = ri.GetOrdinal("DayCount"),
                    LiborRate = ri.GetOrdinal("LiborRate"),
                    LiborPrem = ri.GetOrdinal("LiborPrem"),
                    EquityPrem = ri.GetOrdinal("EquityPrem"),
                    DivPrem = ri.GetOrdinal("DivPrem"),
                },
                (r, ri) =>
                {
                    return new PaaData
                    {
                        EodDate = r.GetInt32(ri.EodDate),
                        PosId = r.GetInt32(ri.PosId),
                        Quantity = r.GetDouble(ri.Quantity),
                        Spot = Math.Round(r.GetDouble(ri.Spot), 4),
                        Delta = r.GetDouble(ri.Delta),
                        Theta = Utility.Round(r.GetDouble(ri.Theta)),
                        MOK = r.GetString(ri.MOK),
                        FairValue = Utility.Round(r.GetDouble(ri.FairValue)),
                        AverageCost = Math.Round(r.GetDouble(ri.AverageCost), 6),
                        Interest = Utility.Round(r.GetDouble(ri.Interest)),
                        Coupon = Utility.Round(r.GetDouble(ri.Coupon)),
                        Dividend = Utility.Round(r.GetDouble(ri.Dividend)),
                        Realised = Utility.Round(r.GetDouble(ri.Realised)),
                        Commission = Utility.Round(r.GetDouble(ri.Commission)),
                        EOPL = Utility.Round(r.GetDouble(ri.EOPL)),
                        EOPLE = Utility.Round(r.IsDBNull(ri.EOPLE) ? 0.0 : r.GetDouble(ri.EOPLE)),
                        ThetaPL = Utility.Round(r.GetFloat(ri.ThetaPL)),
                        PLOK = r.GetString(ri.PLOK),
                        AvgCostA = (r.IsDBNull(ri.AvgCostA) ? 0.0 : Math.Round(r.GetDouble(ri.AvgCostA), 6)),
                        RlsdA = Utility.Round(r.IsDBNull(ri.RlsdA) ? 0.0 : r.GetFloat(ri.RlsdA)),
                        CommA = Utility.Round(r.IsDBNull(ri.CommA) ? 0.0 : r.GetFloat(ri.CommA)),
                        AccIntPLRD = Utility.Round(r.IsDBNull(ri.AccIntPLRD) ? 0.0 : r.GetFloat(ri.AccIntPLRD)),
                //CouponPLRD = Utility.Round(r.IsDBNull(ri.CouponPLRD) ? 0.0 : r.GetFloat(ri.CouponPLRD)),
                DivPLRD = Utility.Round(r.IsDBNull(ri.DivPLRD) ? 0.0 : r.GetFloat(ri.DivPLRD)),
                        CCY = r.GetString(ri.CCY),
                        DayCount = Utility.Round(r.IsDBNull(ri.DayCount) ? 0.0 : r.GetDouble(ri.DayCount)),
                        LiborRate = (r.IsDBNull(ri.LiborRate) ? 0.0 : r.GetDouble(ri.LiborRate)),
                        LiborPrem = Utility.Round(r.IsDBNull(ri.LiborPrem) ? 0.0 : r.GetDouble(ri.LiborPrem)),
                        EquityPrem = Utility.Round(r.IsDBNull(ri.EquityPrem) ? 0.0 : r.GetDouble(ri.EquityPrem)),
                        DivPrem = Utility.Round(r.IsDBNull(ri.DivPrem) ? 0.0 : r.GetDouble(ri.DivPrem)),
                    };
                },
                30).ToList();
        }

        public static Dictionary<int, Dictionary<string, double>> ReadFXHist(DBConnectionDetails conn, int fromDate)
        {
            var query = string.Format(@"select eod_date, frgn_curr_code CCY, calc_bid fxrate from ARCH..CDM_currency_rates_arch where eod_date>={0}", fromDate);
            var res = DbUtils.ExecuteReader(conn, query, 
                ri => new
                {
                    EodDate = ri.GetOrdinal("eod_date"),
                    CCY = ri.GetOrdinal("CCY"),
                    Fx = ri.GetOrdinal("fxrate")
                },
                (r, ri) => new
                {
                    EodDate = r.GetInt32(ri.EodDate),
                    CCY = r.GetString(ri.CCY),
                    Fx = r.GetDouble(ri.Fx)
                }, 
                30).ToList().GroupBy(du => du.EodDate).ToDictionary(du => du.Key, du => du.ToDictionary(d => d.CCY, d => d.Fx));

            var lastDate = res.Keys.OrderByDescending(d => d).First();
            var today = Utility.DateToRover8(DateTime.Today);
            if (!res.ContainsKey(today)) res.Add(today, res[lastDate]);
            return res;
        }

        public static List<PaaData> PaaDtDData(IList<PaaData> input)
        {
            return input.Select((p, i) => i > 0 ? PaaData.DtdDiffed(input[i - 1], p) : p).ToList();
        }
        public static List<PaaData> PaaUsdFiedData(IList<PaaData> input, IDictionary<int, Dictionary<string, double>> fxHist)
        {
            return input.Select(p => PaaData.UsdFied(p, fxHist)).ToList();
        }
        public static string GetPfsId(DBConnectionDetails conn, int posId)
        {
            return DbUtils.ObtainCmdAndEval(conn.ConnectionString(), cmd => (string)DbUtils.ExecuteScalar(false, cmd, "select externalId from externalPositionMap where posId = " + posId, null));
        }

        public static IEnumerable<dynamic> GetPfsIds(DBConnectionDetails conn, IEnumerable<int> posIds)
        {
            string posStr = string.Join(",", posIds);
            var query = string.Format("select posId, externalId from externalPositionMap where posId in ({0})", posStr);
            return DbUtils.ExecuteReader(conn, query, p => p, (r, i) => new { posId = r.GetInt32(0), pfsId = r.GetString(1) }, 30);            
        }

        public static int GetPfsPosId(DBConnectionDetails conn, string pfsId)
        {
            if (pfsId == null) return -1;
            return DbUtils.ObtainCmdAndEval(conn.ConnectionString(), cmd => (int?)DbUtils.ExecuteScalar(false, cmd, "select posId from externalPositionMap where externalId = '" + pfsId + "'", null)) ?? -1;
        }
        public static int GetPfsSecId(DBConnectionDetails conn, string pfsId)
        {
            if (pfsId == null) return -1;
            return DbUtils.ObtainCmdAndEval(conn.ConnectionString(), cmd => (int?)DbUtils.ExecuteScalar(false, cmd, "select secId from externalPositionMap where externalId = '" + pfsId + "'", null)) ?? -1;
        }
        public static string GetUnderlyer(DBConnectionDetails conn, int posId)
        {
            return DbUtils.ObtainCmdAndEval(conn.ConnectionString(), cmd => (string)DbUtils.ExecuteScalar(false, cmd, @"
                --select 'A/C='+pd.firmAccount + ', RIC='+ric.altId + ', Uccy='+undfi.currency + ', RIC2='+ric2.altId + ', FutMult='+cast(fut.multiplier as varchar(20)) + ', CB {type='+ct.mnem + ', initConvPrc='+cast(c.initialConversionPrice as varchar(20)) + ', FaceVal='+cast(c.faceValue as varchar(20)) + ', tradesGross='+c.tradesGross + '}'
                select 'A/C='+pd.firmAccount + ', RIC='+ric.altId + ', RIC2='+ric2.altId + ', FutMult='+cast(fut.multiplier as varchar(20)) + ', CB {type='+ct.mnem + ', initConvPrc='+cast(c.initialConversionPrice as varchar(20)) + ', FaceVal='+cast(c.faceValue as varchar(20)) + ', tradesGross='+c.tradesGross + '}'
                  from externalPositionMap epm
                  join positionDescription pd on pd.posId=epm.posId
                  join ETSderivative der on der.derId = epm.secId
                --  join ETSfinancialInstrument undfi on undfi.id = der.undId and undfi.validUntil=99999999
                  left outer join ETSforward fut on fut.id=der.undId and fut.validUntil=99999999
                  left outer join ETSalternativeIdentifier ric on ric.id=der.undId and ric.type='RIC'
                  --left outer join ETSalternativeIdentifier cus on cus.id=der.undId and cus.type='CUS'
                  left outer join ETSderivative der2 on der2.derId = der.undId
                  left outer join ETSalternativeIdentifier ric2 on ric2.id=der2.undId and ric2.type='RIC'
                  left outer join CDM_basket_detail bd on bd.secId=der.undId
                  left outer join CDM_basket_list bl on bl.bskt_name=bd.bskt_name
                  left outer join ETSconvertible c on c.id=bl.undId and c.validUntil=99999999
                  left outer join ETSconvertibleType ct on ct.code=c.type
                 where epm.posId = " + posId,
          null));
        }

        public Dictionary<int, ISwapDescription> FetchPfsSwapHistory(Region region, string pfsId, int fromDate, int tillDate = 0)
        {
            if (tillDate < fromDate)
                tillDate = Utility.DateToRover8(DateTime.Today);

            var retVal = new Dictionary<int, ISwapDescription>();
            DateTime dt;
            for (dt = Utility.Rover8ToDate(fromDate); dt < Utility.Rover8ToDate(tillDate); dt = Utility.AddBusinessDays(dt, 1, null))
            {
                ISwapDescription val = null;
                try { val = PFSGateway.GetEoDSwap(pfsId, region.ToString(), dt); } catch (ParsingException) { }
                retVal.Add(Utility.DateToRover8(dt), val);
            }

            ISwapDescription valLive = null;             
            try { valLive = dt >= DateTime.Today ? PFSGateway.GetSwap(pfsId) : PFSGateway.GetEoDSwap(pfsId, region.ToString(), dt); } catch (ParsingException) { }   
            retVal.Add(Utility.DateToRover8(dt >= DateTime.Today ? DateTime.Today : dt), valLive);
            return retVal;
        }

        #endregion


        #region PfsData reference

        //    var pfsData = pfsHist.Select((s, i) =>
        //    {
        //        //var plFrom=paaHist[pfsHist[i==0?0:i-1].Date];
        //        //var plTo=paaHist[pfsHist[i].Date];
        //        //var LSSLTradePriceComponent1
        //        var fxRates = fxHist.ContainsKey(s.Date) ? fxHist[s.Date] : null;
        //        var yy = pfsHist[i == 0 ? 0 : i - 1];
        //        //var yesterdayUcf = yy != null ? yy.Swap.Position.UnrealisedCashFlows : null;
        //        var yesterdayUcf = yy?.Swap?.Position?.UnrealisedCashFlows ?? null;
        //        return new
        //        {
        //            Date = s?.Date,
        //            SCCY = s.Swap?.SwapCurrency,
        //            TQ = s.Swap?.Position.TradedQuantity,
        //            IdayTQ = s.Swap?.Position.TradedQuantity - (i == 0 ? 0 : pfsHist[i - 1]?.Swap?.Position.TradedQuantity),
        //            AvgCost = s.Swap?.Position.ProfitLoss.AverageCost,
        //            TrdFX = s.Swap?.Position.TradedFX,
        //            SettQty = s.Swap?.Position.SettledQuantity,
        //            SettPrice = s.Swap?.Position.SettledPrice,
        //            SettFX = s.Swap?.Position.SettledFX, //SettQ = s.Swap?.Position.SettledQuantity, SettP = Utility.Round(s.Swap?.Position.SettledPrice), FFix=s.Swap?.FloatingLeg.Schedule.First()?.Amount,
        //            BC = s.Swap?.Position.BorrowCost,
        //            //                AvgTrdCost=s.Swap?.Position.ProfitLoss.AverageTradedCost, 
        //            //                SumUCF = (int?)s.Swap?.Position.UnrealisedCashFlows.Sum(cf => cf.Amount * cf.FxFix),
        //            //                UCFDiv = (int?)s.Swap?.Position.UnrealisedCashFlows.Where(cf => cf.CashType == "Dividend").Sum(cf => cf.Amount * cf.FxFix),
        //            //SumUCFIntrt = (int?)s.Swap?.Position.UnrealisedCashFlows.Where(cf => cf.CashType == "Interest").Sum(cf => cf.Amount * cf.FxFix),
        //            //                SumUCFOth = (int?)s.Swap?.Position.UnrealisedCashFlows.Where(cf => cf.CashType != "Interest" && cf.CashType != "Dividend").Sum(cf => cf.Amount * cf.FxFix),
        //            UnrealisedCF = s.Swap?.Position.UnrealisedCashFlows.Select(cf => new
        //            {
        //                cf.PayDate,
        //                CfType = cf.ShortCashFlowType,
        //                CT = cf.CashType,
        //                CCY = cf.Currency,
        //                Amount = Utility.Round(cf.Amount),
        //                cf.FxFix,
        //                FinAmt = Utility.Round(cf.Amount * cf.FxFix),
        //                USDAmt = Utility.Round(cf.Amount * cf.FxFix / Utility.GetFxRate(fxRates, s.Swap.SwapCurrency)),
        //                cf.PostingDate
        //            }),
        //            RealisedCF = s.Swap?.Position.RealisedCashFlows.Select(cf => new
        //            {
        //                CfType = cf.ShortCashFlowType,
        //                CT = cf.CashType,
        //                CCY = cf.Currency,
        //                Ltd = Utility.Round(cf.LtdAmount),
        //                Dtd = Utility.Round(cf.DtdAmount),
        //                cf.FxFix,
        //                FinAmt = Utility.Round(cf.DtdAmount * cf.FxFix),
        //                //CfType=cf.ShortCashFlowType, CT=cf.CashType, CCY=cf.Currency, DtdAmount=(int)cf.DtdAmount, cf.FxFix, FinAmt=(int)(cf.DtdAmount*cf.FxFix),
        //                USDAmt = Utility.Round(cf.DtdAmount * cf.FxFix / Utility.GetFxRate(fxRates, s.Swap.SwapCurrency))
        //            }),
        //            UcfDtd = i > 0 ? s.Swap?.GetUcfDtd(yesterdayUcf)?.Select(cf => new
        //            {
        //                cf.PayDate,
        //                CfType = cf.ShortCashFlowType,
        //                CT = cf.CashType,
        //                CCY = cf.Currency,
        //                Amount = Utility.Round(cf.Amount),
        //                //cf.FxFix,
        //                USDAmt = Utility.Round(cf.Amount / Utility.GetFxRate(fxRates, s.Swap.SwapCurrency)),
        //            }) : null,
        //            UcfSudden = i > 0 ? s.Swap?.GetUcfSudden(yesterdayUcf)?.Select(cf => new
        //            {
        //                cf.PayDate,
        //                CfType = cf.ShortCashFlowType,
        //                CT = cf.CashType,
        //                CCY = cf.Currency,
        //                Amount = Utility.Round(cf.Amount),
        //                //cf.FxFix,
        //                USDAmt = Utility.Round(cf.Amount / Utility.GetFxRate(fxRates, s.Swap.SwapCurrency)),
        //            }) : null,
        //            RcfSudden = i > 0 ? s.Swap?.GetRcfSudden(yesterdayUcf)?.Select(cf => new
        //            {
        //                CT = cf.CashType,
        //                CCY = cf.Currency,
        //                Amount = Utility.Round(cf.DtdAmount),
        //                //cf.FxFix,
        //                USDAmt = Utility.Round(cf.DtdAmount / Utility.GetFxRate(fxRates, s.Swap.SwapCurrency)),
        //            }) : null,
        //            EqFix = showFixes ? s.Swap?.EquityLeg.Schedule.Select(f => new { f.FixDate, f.PayDate, f.Amount, f.FX }) : null,
        //            FlFix = showFixes ? s.Swap?.FloatingLeg.Schedule : null,
        //            //DivFix = showFixes ? s.Swap?.DividendLeg.Schedule : null,
        //        };
        //    }).Skip(1).TakeWhile(p => p.Date <= date);
        #endregion

    }
}

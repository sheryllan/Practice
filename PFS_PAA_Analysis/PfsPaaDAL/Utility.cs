using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PfsPaaDAL
{
    public class Utility
    {
        public static double GetFxRate(IDictionary<string, double> rates, string ccy)
        {
            return rates == null ? double.NaN : rates.ContainsKey(ccy) ? rates[ccy] : double.NaN;
        }

        public static bool DblEquals(double d1, double d2, double d3 = double.NaN, double epsilon = 0.00005) => Math.Abs(d1 - d2) < epsilon && (double.IsNaN(d3) || Math.Abs(d2 - d3) < epsilon);
        public static object DBNullToNull(object obj) { return obj == DBNull.Value ? null : obj; }

        public static string AttachString(object obj, string value, string seperator = ",") { return string.IsNullOrEmpty(DBNullToNull(obj)?.ToString()) ? value : obj.ToString() + seperator + value; }

        public static int Round(double fm)
        {
            return (int)Math.Round(fm);
        }

        #region Date Funcs
        public static int DateToRover8(DateTime dt) { return dt.Year * 10000 + dt.Month * 100 + dt.Day; }
        public static DateTime Rover8ToDate(int rover8)
        {
            try
            {
                return new DateTime(rover8 / 10000, rover8 / 100 % 100, rover8 % 100);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //(ex.Message + ":" + rover8).Dump();
                Console.WriteLine(ex.Message + ":" + rover8);
                return new DateTime(9999, 12, 31);
            }
        }

        public static bool IsWeekend(DateTime date) { return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday; }
        //public static bool IsHoliday(DateTime date, IEnumerable<string> sets) { return IsWeekend(date) ? true : sets.Any(s => Holidays.ContainsKey(s) && Holidays[s].Contains(date)); }
        //public static bool IsWeekendOrHoliday(DateTime date, IEnumerable<string> sets) { return IsWeekend(date) || IsHoliday(date, sets); }
        public static int AddBusinessDays(int dt, int days, IEnumerable<string> sets = null)
        {
            if (days == 0) return dt;
            return DateToRover8(AddBusinessDays(Rover8ToDate(dt), days, sets));
        }
        public static DateTime AddBusinessDays(DateTime date, int days, IEnumerable<string> sets = null)
        {
            if (days == 0) return date;
            var incr = Math.Sign(days);
            for (int i = 0; i < Math.Abs(days); i++)
            {
                do
                {
                    date = date.AddDays(incr);
                } while (IsWeekend/*OrHoliday*/(date /*, sets*/));
            }
            return date;
        }
        public static int BusinessDateDiff(DateTime fromDate, DateTime toDate, IEnumerable<string> sets = null)
        {
            if (fromDate == toDate) return 0;
            var sign = 1;
            if (toDate < fromDate) { var tmp = fromDate; fromDate = toDate; toDate = tmp; sign = -1; }
            var diff = (toDate - fromDate).Days;
            while (fromDate <= toDate)
            {
                //(string.Format("{0:yyyyMMdd} to {1:yyyyMMdd} = {2}", fromDate, toDate, diff)).Dump();
                if (IsWeekend/*OrHoliday*/(fromDate/*, sets*/)) diff--;
                fromDate = fromDate.AddDays(1);
            }
            return diff * sign;
        }
        public static int PreviuosMonthEndForDate(int eod)
        {
            var dt = Rover8ToDate(eod);
            dt = dt.AddDays(-dt.Day + 1);
            return DateToRover8(AddBusinessDays(dt, -1));
        }
        public static int PreviuosYearEndForDate(int eod)
        {
            var dt = Rover8ToDate(eod);
            dt = dt.AddDays(-dt.DayOfYear + 1);
            return DateToRover8(AddBusinessDays(dt, -1));
        }
        #endregion
    }
}

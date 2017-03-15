using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFSFeed.Model;

namespace PfsPaaDAL
{
    public class FixSchedule : IScheduleRow
    {
        private IScheduleRow _schedule;

        public FixSchedule(IScheduleRow schedule)
        {
            _schedule = schedule;

        }
        public double Amount
        {
            get
            {
                return _schedule.Amount;
            }
        }  

        public int FixDate
        {
            get
            {
                return _schedule.FixDate;
            }
        }

        public double FX
        {
            get
            {
                return _schedule.FX;
            }
        }

        public int PayDate
        {
            get
            {
                return _schedule.PayDate;
            }
        }

        public int EndDate
        {
            get
            {
                return _schedule.EndDate;
            }
        }
    }
}

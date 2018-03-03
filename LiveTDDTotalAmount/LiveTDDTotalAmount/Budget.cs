using System;

namespace LiveTDDTotalAmount
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }

        public DateTime FirstDay
        {
            get { return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null); }
        }

        public DateTime LastDay
        {
            get
            {
                return new DateTime(FirstDay.Year,FirstDay.Month, DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month));
              
            }
        }
    }
}
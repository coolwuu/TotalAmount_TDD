using System;

namespace LiveTDDTotalAmount
{
    public class Budget
    {
        public string YearMonth { get; set; }
        public int Amount { get; set; }

        private DateTime FirstDay
        {
            get { return DateTime.ParseExact(YearMonth + "01", "yyyyMMdd", null); }
        }

        private DateTime LastDay
        {
            get
            {
                return new DateTime(FirstDay.Year,FirstDay.Month, TotalDays);
              
            }
        }

        private int TotalDays
        {
            get { return DateTime.DaysInMonth(FirstDay.Year, FirstDay.Month); }
        }

        private int DailyAmount()
        {
            return Amount / TotalDays;
        }

        public int TotalAmount(Period period)
        {
            return DailyAmount() * period.EffectiveDays(new Period(FirstDay, LastDay));
        }
    }
}
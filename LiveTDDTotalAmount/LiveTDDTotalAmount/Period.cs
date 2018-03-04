using System;

namespace LiveTDDTotalAmount
{
    public class Period
    {
        public DateTime StartDate;
        public DateTime EndDate;

        public Period(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException();
            }
            this.StartDate = startDate;
            EndDate = endDate;
        }

        public int EffectiveDays(Period period)
        {
            if (StartDate > period.EndDate)
            {
                return 0;
            }
            if (EndDate < period.StartDate)
            {
                return 0;
            }

            var effectiveEndDate = EffectiveEndDate(period);
            var effectiveStartDate = EffectiveStartDate(period);

            return (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
        }

        private DateTime EffectiveStartDate(Period period)
        {
            return period.StartDate > StartDate
                ? period.StartDate
                : StartDate;
        }

        private DateTime EffectiveEndDate(Period period)
        {
            return EndDate > period.EndDate
                ? period.EndDate
                : EndDate;
        }
    }
}
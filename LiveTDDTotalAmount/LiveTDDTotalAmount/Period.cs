using System;

namespace LiveTDDTotalAmount
{
    internal class Period
    {
        public DateTime StartDate;
        public DateTime EndDate;

        public Period(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public int EffectiveDays(Budget budget)
        {
            if (StartDate > budget.LastDay)
            {
                return 0;
            }
            if (EndDate < budget.FirstDay)
            {
                return 0;
            }
            var effectiveEndDate = EndDate > budget.LastDay
                ? budget.LastDay
                : EndDate;

            var effectiveStartDate = budget.FirstDay > StartDate
                ? budget.FirstDay
                : StartDate;

            return (effectiveEndDate.AddDays(1) - effectiveStartDate).Days;
        }
    }
}
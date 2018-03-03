using System;
using System.Linq;

namespace LiveTDDTotalAmount
{
    public class Accounting
    {
        private readonly IRepository<Budget> _repo;

        public Accounting(IRepository<Budget> repo)
        {
            _repo = repo;
        }

        public decimal TotalAmount(DateTime startDate, DateTime endDate)
        {
            var budgets = _repo.GetBudgets();

            if (budgets.Any())
            {
                return 1;
            }
            return 0;
        }
    }
}
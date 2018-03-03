using System.Collections.Generic;

namespace LiveTDDTotalAmount
{
    public interface IRepository<T>
    {
        List<Budget> GetBudgets();

    }
}
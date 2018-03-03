﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace LiveTDDTotalAmount
{
    [TestClass]
    public class TotalAmountTests
    {
        private readonly IRepository<Budget> _repository = Substitute.For<IRepository<Budget>>();

        private Accounting _accounting;

        [TestInitialize]
        public void TestInit()
        {
            _accounting = new Accounting(_repository);
        }

        [Ignore]
        [TestMethod]
        public void daily_amount()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 300 });
            TotalAmountShouldBe(20, new DateTime(2018, 4, 1), new DateTime(2018, 4, 2));
        }

        [Ignore]
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void invalid_period()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2018, 6, 30), new DateTime(2018, 5, 1));
        }

        [Ignore]
        [TestMethod]
        public void multiple_budgets()
        {
            GivenBudgets(
                new Budget { YearMonth = "201804", Amount = 300 },
                new Budget { YearMonth = "201806", Amount = 30 }
                );
            TotalAmountShouldBe(103, new DateTime(2018, 4, 21), new DateTime(2018, 6, 3));
        }

        [Ignore]
        [TestMethod]
        public void no_effective_day_period_after_budget_month()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(0, new DateTime(2018, 5, 1), new DateTime(2018, 5, 1));
        }

        [Ignore]
        [TestMethod]
        public void no_effective_day_period_before_budget_month()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(0, new DateTime(2018, 3, 31), new DateTime(2018, 3, 31));
        }

        [TestMethod]
        public void NoBudget()
        {
            GivenBudgets();
            TotalAmountShouldBe(0, new DateTime(2018, 4, 1), new DateTime(2018, 5, 1));
        }

        [TestMethod]
        public void one_effective_day_period_inside_budget_month()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2018, 4, 1), new DateTime(2018, 4, 1));
        }

        [Ignore]
        [TestMethod]
        public void one_effective_day_period_overlap_budget_month_FirstDay()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2018, 3, 31), new DateTime(2018, 4, 1));
        }

        [Ignore]
        [TestMethod]
        public void one_effective_day_period_overlap_budget_month_LastDay()
        {
            GivenBudgets(new Budget { YearMonth = "201804", Amount = 30 });
            TotalAmountShouldBe(1, new DateTime(2018, 4, 30), new DateTime(2018, 5, 1));
        }

        private void GivenBudgets(params Budget[] budgets)
        {
            _repository.GetBudgets().Returns(budgets.ToList());
        }

        private void TotalAmountShouldBe(int expected, DateTime startDate, DateTime endDate)
        {
            var actual = _accounting.TotalAmount(startDate, endDate);
            Assert.AreEqual(expected, actual);
        }
    }
}

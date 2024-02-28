using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyChart.Helpers
{
    public class StaticMethods
    {
        public static string GetFullName(string Title,
            string FirstName, string LastName, string OtherName)
        {
            string FullName = Title + " " + FirstName + " "
                + OtherName + " " + LastName;
            return FullName;
        }

        public static decimal GetEquity(decimal Revenue,decimal Expenses,
                                decimal Assets, decimal Liability)
        {
            decimal TotalEquity =Revenue-Expenses-Assets-Liability;
            return TotalEquity;
        }

        public static decimal GetProfit(decimal Equity, decimal Percentageprofit)
        {
            decimal Profit = Equity* Percentageprofit;
            return Profit;
        }
    }
}

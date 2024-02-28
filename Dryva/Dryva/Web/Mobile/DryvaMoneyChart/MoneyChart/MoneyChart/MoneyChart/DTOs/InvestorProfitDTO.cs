using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyChart.DTOs
{
    public class InvestorProfitDTO
    {
        public decimal Capex { get; set; }
        public decimal Opex { get; set; }

        public decimal PercentageRetainedProfit { get; set; }
        public decimal Dividend { get; set; }

        public decimal Percentage { get; set; }
        public decimal CumulativeROI { get; set; }
        public decimal CurrentROI { get; set; }
    }
}

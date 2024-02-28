using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyChart.DTOs
{
    public class SubscriberReportDTO 
    {

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string LGA { get; set; }
        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>The surname.</value>
        public string State { get; set; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public long CustomerCount { get; set; }

        public decimal Amount { get; set; }


    }
}

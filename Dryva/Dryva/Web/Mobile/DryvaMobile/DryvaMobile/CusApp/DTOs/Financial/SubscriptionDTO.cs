using System;
using System.Collections.Generic;
using System.Text;

namespace CusApp.DTOs.Financial
{
    public class SubscriptionDTO
    {
        public Guid CustomerId { get; set; }
        public DateTime DateofPayment { get; set; }

        public int Units { get; set; }

        public decimal Amount { get; set; }

        public string SelectedCountry { get; set; }

        public DateTime ExpiredDate { get; set; }

        public string CVC { get; set; }

        public string SelectedBank { get; set; }

        public string AccountNumber { get; set; }

        public bool ByCard { get; set; }

        public string CardNumber { get; set; }
    }
}

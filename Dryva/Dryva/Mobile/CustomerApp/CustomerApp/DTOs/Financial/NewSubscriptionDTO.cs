using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.DTOs.Financial
{
    public class NewSubscriptionDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime DateofPayment { get; set; }

        public int Units { get; set; }

        public double Amount { get; set; }

        public string SelectedCountry { get; set; }

        public DateTime ExpiredDate { get; set; }

        public string CVC { get; set; }

        public string SelectedBank { get; set; }

        public string AccountNumber { get; set; }

        public bool ByCard { get; set; }

        public string MasterCardNumber { get; set; }

        public long CardSerialNumber { get; set; }
    }
}

using SQLite;
using System;

namespace CusApp.Models
{
    public class WalletItem
    {
        public WalletItem()
        {
            Id = new Guid();
        }    
        [PrimaryKey]
        public Guid Id { get; set; }
        public bool IsMonthlyChecked { get; set; }
        public bool IsWeeklyChecked { get; set; }
        public decimal Units { get; set; }
        public DateTime PaidDate { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string Country { get; set; }
        public DateTime CardExpiredDate { get; set; }
        public string CardNumber { get; set; }
        public string CVC { get; set; }

    }
}

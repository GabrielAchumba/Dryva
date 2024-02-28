using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Services
{
    public class PaymentDetail
    {
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Plan { get; set; }
    }
}

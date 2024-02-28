using CustomerApp.Enum;
using System;

namespace CustomerApp.DTOs.Financial
{
    public class PaymentSubscriptionDTO
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string TransactionCode { get; set; }
        public double Amount { get; set; }
        public PaymentPlanEnum PaymentPlan { get; set; }
        public long CardSerialNumber { get; set; }


    }
}

using System;

namespace Dryva.PaymentGateways.PayStack
{
    public interface ISettlementsApi
    {
        SettlementsFetchResponse Fetch(DateTime? from = null, DateTime? to = null, string subaccount = "none");
    }
}
using Newtonsoft.Json;

namespace Dryva.PaymentGateways.PayStack
{    
    public class TransferOtpResponse : HasRawResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
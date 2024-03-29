using Newtonsoft.Json;

namespace Dryva.PaymentGateways.PayStack
{
    public class FetchTransferResponse : HasRawResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public Transfer Data { get; set; }
    }
}
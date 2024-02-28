using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dryva.PaymentGateways
{
    public abstract class GatewayValidator
    {
        protected string responseJSON, signature, secretKey;

        private static string GetJSON(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));

            stream.Seek(0, SeekOrigin.Begin);

            var json = new StreamReader(stream).ReadToEnd();
            return json;
        }

        public GatewayValidator(Stream responseBody, string signature, string secretKey)
            : this(GetJSON(responseBody), signature, secretKey)
        {

        }

        public GatewayValidator(string responseJSON, string signature, string secretKey)
        {
            this.responseJSON = responseJSON;
            this.signature = signature;
            this.secretKey = secretKey;
        }

        public TPayload GetPayload<TPayload>() where TPayload : class, new()
        {
            if (IsValid())
                return JsonConvert.DeserializeObject<TPayload>(responseJSON);
            else
                return default;
        }

        public abstract string SignatureRequestKey { get; }
        public abstract bool IsValid();
    }
}

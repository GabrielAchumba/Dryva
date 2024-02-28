using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dryva.PaymentGateways.Rave
{
    public class RaveGatewayValidator : GatewayValidator
    {
        private string hookSig = "DEV_STORE_PASS";

        public RaveGatewayValidator(Stream responseBody, string signature, string secretKey)
            : base(responseBody, signature, secretKey)
        {
        }

        public RaveGatewayValidator(string responseJSON, string signature, string secretKey)
            : base(responseJSON, signature, secretKey)
        {
        }

        public override string SignatureRequestKey => "Verif-Hash";

        public override bool IsValid()
        {
            return hookSig.Equals(signature);
        }
    }
}

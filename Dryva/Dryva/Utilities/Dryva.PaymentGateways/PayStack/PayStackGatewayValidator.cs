using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Dryva.PaymentGateways.PayStack
{
    public class PayStackGatewayValidator : GatewayValidator
    {
        public PayStackGatewayValidator(Stream responseBody, string signature, string secretKey)
            : base(responseBody, signature, secretKey)
        {
        }

        public PayStackGatewayValidator(string responseJSON, string signature, string secretKey)
            : base(responseJSON, signature, secretKey)
        {
        }

        public override string SignatureRequestKey => "x-paystack-signature";

        public override bool IsValid()
        {
            var jsonBytes = Encoding.UTF8.GetBytes(responseJSON);
            var secretBytes = Encoding.UTF8.GetBytes(secretKey);
            string result = "";

            using (var hmac = new HMACSHA512(secretBytes))
            {
                var hash = hmac.ComputeHash(jsonBytes);
                result = BitConverter.ToString(hash).Replace("-", string.Empty);
            }

            return result.ToLower().Equals(signature);
        }
    }
}

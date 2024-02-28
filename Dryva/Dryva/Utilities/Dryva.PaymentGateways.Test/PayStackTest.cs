using NUnit.Framework;
using System;

namespace Dryva.PaymentGateways.Test
{
    public class PayStackTest
    {
        private PGConfiguration configuration;
        private string accessCode, email;
        private decimal amount;
        private int amountInKobo;

        private string cardNo, cardCVC;
        private int expiryMonth, expiryYear;

        PayStack.PayStackApi api;

        [SetUp]
        public void Setup()
        {
            configuration = TestHelper.GetConfiguration(TestContext.CurrentContext.TestDirectory);
            api = new PayStack.PayStackApi(configuration.SecretKey);

            email = "wizzyno@gmail.com";
            amount = 750;

            decimal charge = ChargeCalculator.Get(PaymentGatewayTypes.PayStack).Compute(amount);
            amountInKobo = Convert.ToInt32((amount + charge) * 100);

            cardNo = "4084084084084081";
            cardCVC = "408";
            expiryMonth = 2;
            expiryYear = 2020;
        }

        [Test]
        public void TransactionTest()
        {
            Guid refNo = Guid.NewGuid();

            var result = api.Transactions.Initialize(new PayStack.TransactionInitializeRequest
            {
                Reference = refNo.ToString(),
                AmountInKobo = amountInKobo,
                Email = email,
                //CallbackUrl = Url.Action(nameof(<action>), "<controller>", null, Request.Url.Scheme),
                //MetadataObject =
                //{
                //    { "<e.g customerId>", <value> }
                //}
            });

            /* CallbackUrl applies to web application so it can be redirected on successful transaction
             * MetadataObject can be used to pass additional data (especially if webhook is implemented).
             */
            if (result.Status)
            {
                //return Redirect(result.Data.AuthorizationUrl);
            }
            Assert.Pass();
        }

        /// <summary>
        /// Sample verification method.
        /// </summary>
        /// <returns>ActionResult.</returns>
        //public ActionResult VerifyTransaction(string reference)
        //{
        //    PaymentGateways.PayStack.PayStackApi api = new PayStack.PayStackApi(configuration.SecretKey);
        //    var result = api.Transactions.Verify(reference);

        //    if (result.Status)
        //    {
        //        switch (result.Data.Status)
        //        {
        //            case "success":
        //                var customerId = Guid.Parse(result.Data.Metadata["<e.g customerId>"] as string);
        //                break;

        //            default:
        //                break;
        //        }
        //    }

        //    return RedirectToAction(nameof(PaymentComplete), new { id = cartId });
        //}

        ///// <summary>
        ///// Sample webhook method.
        ///// </summary>
        ///// <returns>ActionResult.</returns>
        //[HttpPost]
        //public ActionResult Rave()
        //{
        //    var validator = new PaymentGateways.PayStack.PayStackGatewayValidator(Request.InputStream,
        //        Request.Headers[validator.SignatureRequestKey], configuration.SecretKey);

        //    var payload = validator.GetPayload<PayStack.TransactionVerifyResponse>();

        //    if (payload != null)
        //    {
        //        // Transaction verification successful. Perform task.
        //    }

        //    return Json(new { message = "success" });
        //}

    }
}

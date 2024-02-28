using NUnit.Framework;

namespace Dryva.Utilities.Test
{
    public class SMSTest
    {
        private string email;
        private string subAccount;
        private string password;

        [SetUp]
        public void Setup()
        {
            email = "enewizard@yahoo.com";
            subAccount = "DRYVA";
            password = "Dryva@Smart0";
        }

        [Test]
        public void Test()
        {
            var smsService = new SMS.SMSLive247Service();

            if (smsService.Login(email, subAccount, password))
            {
                //var result = smsService.SendMessage("Hello World!", subAccount, "08069328151");
                var result = smsService.SendMessage("Hello World!", subAccount, "07030229161");
                //var result = smsService.SendMessage("Hello World!", subAccount, "08037502316");
                //var result = smsService.SendMessage("Hello World!", subAccount, "08167080180");
                Assert.IsNotNull(result);
                return;
            }
            
            Assert.Fail();
        }
    }
}
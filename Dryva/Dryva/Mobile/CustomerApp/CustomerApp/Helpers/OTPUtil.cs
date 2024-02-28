using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerApp.Helpers
{
    public class OTPUtil
    {
        public static int GeneratePassword(int digits)
        {
            int MultiplyNTimes(int n)
            {
                if (n == 1)
                    return 1;
                else
                    return 10 * MultiplyNTimes(n - 1);
            }

            if (digits < 3)
                return new Random().Next(10, 99);
            else
                return new Random().Next(MultiplyNTimes(digits), MultiplyNTimes(digits + 1) - 1);
        }

        public static OTPMOdel GenerateOTP(int digits)
        {
            var nowStart = DateTime.Now;
            var date = nowStart.AddMinutes(10);

            int MultiplyNTimes(int n)
            {
                if (n == 1)
                    return 1;
                else
                    return 10 * MultiplyNTimes(n - 1);
            }

            if (digits < 3)
                return new OTPMOdel(new Random().Next(10, 99), date);
            else
            {
                var result = new Random().Next(MultiplyNTimes(digits), MultiplyNTimes(digits + 1) - 1);
                return new OTPMOdel(result, date);
            }
        }
    }

    public class OTPMOdel
    {
        public int OTP { get; }
        public DateTime ExpiryDate { get; }
        public string ExpiryDateText { get; }

        public OTPMOdel(int otp, DateTime expiryDate)
        {
            this.OTP = otp;
            this.ExpiryDate = expiryDate;
            this.ExpiryDateText = expiryDate.ToString();
        }
    }
}

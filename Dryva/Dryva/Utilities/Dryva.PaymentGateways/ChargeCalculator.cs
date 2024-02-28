using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Dryva.PaymentGateways
{
    /// <summary>
    /// Represents the different supported payment gateways.
    /// </summary>
    public enum PaymentGatewayTypes
    {
        /// <summary>
        /// The PayStack gateway.
        /// </summary>
        PayStack
    }

    /// <summary>
    /// Represents the ChargeCalculatorOptions class.
    /// </summary>
    public class ChargeCalculatorOptions
    {
        /// <summary>
        /// Gets or sets the additional charge.
        /// </summary>
        /// <value>The additional charge.</value>
        public decimal Additional { get; set; }
        /// <summary>
        /// Gets or sets the maximum charge cap irrespective of transaction amount.
        /// </summary>
        /// <value>The maximum charge cap irrespective of transaction amount.</value>
        public decimal Cap { get; set; }
        /// <summary>
        /// Gets or sets the cross over limit (where additional charge may imply).
        /// </summary>
        /// <value>The crossover limit (where additional charge may imply).</value>
        public decimal CrossOver { get; set; }
        /// <summary>
        /// Gets or sets the percentage charge.
        /// </summary>
        /// <value>The percentage charge.</value>
        public decimal Percentage { get; set; }
    }
    /// <summary>
    /// Represents the ChargeCalculator class.
    /// </summary>
    public class ChargeCalculator
    {
        /// <summary>
        /// Represents an IPLocation class.
        /// </summary>
        private class IPLocation
        {
            /// <summary>
            /// Gets or sets the ip address.
            /// </summary>
            /// <value>The ip address.</value>
            [JsonProperty("ip")]
            public string IP { get; set; }
            /// <summary>
            /// Gets or sets the country code.
            /// </summary>
            /// <value>The country code.</value>
            [JsonProperty("country_code")]
            public string CountryCode { get; set; }
            /// <summary>
            /// Gets or sets the name of the country.
            /// </summary>
            /// <value>The name of the country.</value>
            [JsonProperty("country_name")]
            public string CountryName { get; set; }
            /// <summary>
            /// Gets or sets the region code.
            /// </summary>
            /// <value>The region code.</value>
            [JsonProperty("region_code")]
            public string RegionCode { get; set; }
            /// <summary>
            /// Gets or sets the name of the region.
            /// </summary>
            /// <value>The name of the region.</value>
            [JsonProperty("region_name")]
            public string RegionName { get; set; }
            /// <summary>
            /// Gets or sets the city.
            /// </summary>
            /// <value>The city.</value>
            [JsonProperty("city")]
            public string City { get; set; }
            /// <summary>
            /// Gets or sets the zip code.
            /// </summary>
            /// <value>The zip code.</value>
            [JsonProperty("zip_code")]
            public string ZipCode { get; set; }
            /// <summary>
            /// Gets or sets the time zone.
            /// </summary>
            /// <value>The time zone.</value>
            [JsonProperty("time_zone")]
            public string TimeZone { get; set; }
            /// <summary>
            /// Gets or sets the latitude.
            /// </summary>
            /// <value>The latitude.</value>
            [JsonProperty("latitude")]
            public float? Latitude { get; set; }
            /// <summary>
            /// Gets or sets the longitude.
            /// </summary>
            /// <value>The longitude.</value>
            [JsonProperty("longitude")]
            public float? Longitude { get; set; }
            /// <summary>
            /// Gets or sets the metro code.
            /// </summary>
            /// <value>The metro code.</value>
            [JsonProperty("metro_code")]
            public int? MetroCode { get; set; }

            /// <summary>
            /// Determines whether this caller IP address is local (Nigeria).
            /// </summary>
            /// <returns><c>true</c> if this instance is local; otherwise, <c>false</c>.</returns>
            public static bool IsLocal()
            {
                var client = new HttpClient { BaseAddress = new Uri("https://freegeoip.app/") };
                //var client = new HttpClient { BaseAddress = new Uri("http://freegeoip.net/") };
                var result = client.GetAsync("json").Result.Content.ReadAsStringAsync().Result;
                var location = JsonConvert.DeserializeObject<IPLocation>(result);

                return location.CountryName.Equals("Nigeria", StringComparison.OrdinalIgnoreCase);
            }

            /// <summary>
            /// Gets the IP address.
            /// </summary>
            /// <returns>System.String.</returns>
            public static string GetIP()
            {
                //this line is to check the client ip address from the server itself
                string hostName = Dns.GetHostName();
                IPHostEntry ipEntry = Dns.GetHostEntry(hostName);
                IPAddress[] addr = ipEntry.AddressList;
                string ip = addr[2].ToString();

                return ip;
            }
        }

        /// <summary>
        /// The percentage
        /// </summary>
        private readonly decimal percentage, additional, crossover, cap;
        /// <summary>
        /// The minimum crossover
        /// </summary>
        private readonly decimal minCrossover, flatLine;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChargeCalculator" /> class.
        /// </summary>
        /// <param name="percentage">The percentage charge.</param>
        /// <param name="additional">The additional charge.</param>
        /// <param name="crossover">The crossover limit (where additional charge may imply).</param>
        /// <param name="cap">The maximum charge cap irrespective of transaction amount.</param>
        /// <exception cref="ArgumentOutOfRangeException">Percentage values must be between 0 to 1 inclusive.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Percentage values must be between 0 to 1 inclusive.</exception>
        private ChargeCalculator(decimal percentage, decimal additional, decimal crossover, decimal cap)
        {
            if (percentage <= 0 || percentage > 1)
                throw new ArgumentOutOfRangeException($"Percentage values must be between 0 to 1 inclusive.");

            this.percentage = percentage;
            this.additional = additional;
            this.crossover = crossover;
            this.cap = cap;

            minCrossover = Math.Ceiling((crossover - 0.01m) / (1 + percentage));
            flatLine = ((cap - additional) / percentage);
            //minCrossover = Math.Ceiling((crossover - additional) / (1 + percentage));
            //flatLine = ((cap - additional) / percentage) - cap;

            if (flatLine < 0)
                flatLine = decimal.MaxValue;
        }

        /// <summary>
        /// Computes the charge amount applied by the payment gateway to transaction amount.
        /// </summary>
        /// <param name="amount">The amount.</param>
        /// <returns>System.Decimal.</returns>
        public decimal Compute(decimal amount)
        {
            if (amount > flatLine)
                return cap;
            else if (amount > minCrossover)
                return Math.Ceiling(amount * percentage) + additional;
            else
                return Math.Ceiling(amount * percentage);
        }

        /// <summary>
        /// Gets the specified payment gateway charge calculator.
        /// </summary>
        /// <param name="paymentGateway">The payment gateway.</param>
        /// <returns>ChargeCalculator.</returns>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        /// <exception cref="System.NotSupportedException"></exception>
        public static ChargeCalculator Get(PaymentGatewayTypes paymentGateway)
        {
            string notSupportedError = $"The payment gateway '{paymentGateway}' is not supported.";

            if (IPLocation.IsLocal())
            {
                switch (paymentGateway)
                {
                    case PaymentGatewayTypes.PayStack:
                        return new ChargeCalculator(0.015m, 100, 2500, 2000);
                    default:
                        throw new NotSupportedException(notSupportedError);
                }
            }
            else
            {
                switch (paymentGateway)
                {
                    case PaymentGatewayTypes.PayStack:
                        return new ChargeCalculator(0.039m, 100, 2500, 0);
                    default:
                        throw new NotSupportedException(notSupportedError);
                }
            }
        }

        /// <summary>
        /// Gets the charge calculator.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <returns>ChargeCalculator.</returns>
        public static ChargeCalculator Get(ChargeCalculatorOptions options)
        {
            return new ChargeCalculator(options.Percentage, options.Additional, options.CrossOver, options.Cap);
        }
    }
}

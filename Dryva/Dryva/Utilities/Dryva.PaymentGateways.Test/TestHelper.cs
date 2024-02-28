using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dryva.PaymentGateways.Test
{
    public class TestHelper
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appSettings.json", optional: true)
                //.AddUserSecrets("e3dfcccf-0cb3-423a-b302-e3e92e95c128")
                .AddEnvironmentVariables()
                .Build();
        }

        public static PGConfiguration GetConfiguration(string outputPath)
        {
            var configuration = new PGConfiguration();
            var section = GetIConfigurationRoot(outputPath).GetSection("PayStack");

            section.Bind(configuration);
            return configuration;
        }
    }

    public class PGConfiguration
    {
        public string SecretKey { get; set; }
    }
}

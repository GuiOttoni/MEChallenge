using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEChallenge.Core
{
    public static class TestHelper
    {
        public static IConfigurationRoot BuildConfiguration(string testDirectory)
        {
            return new ConfigurationBuilder()
                .SetBasePath(testDirectory)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();
        }
    }
}

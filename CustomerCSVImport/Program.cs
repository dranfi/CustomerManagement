using System;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Utilities.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace CustomerCSVImport
{
    class Program
    {
        static readonly HttpClient httpClient = new HttpClient();
        static void Main(string[] args)
        {
            // Read config from appSettings.json
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            // Wait 5 seconds to make sure the server is loaded if using multiple startup projects
            Thread.Sleep(5000);
            string csvFile = config["CSVFile"];
            string url = config["ServerUrl"];
            // Using a CSV Library to parse the CSV File. Object fields are matched by the Column index and Column header defined in Customer classs
            using (var reader = new StreamReader(csvFile))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Customer>().ToList();
                foreach(var customer in records)
                {
                    POSTData(customer, url);
                }
            }
        }

        public static bool POSTData(object json, string url)
        {
            // Convert the Customer object to JSON using Newtonsoft.json library
            using (var content = new StringContent(JsonConvert.SerializeObject(json), System.Text.Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage result = httpClient.PostAsync(url, content).Result;
                if (result.StatusCode == System.Net.HttpStatusCode.Created)
                    return true;
                string returnValue = result.Content.ReadAsStringAsync().Result;
                throw new Exception($"Failed to POST data: ({result.StatusCode}): {returnValue}");
            }
        }
    }
}

using System;
using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Utilities.Model
{
    public class Customer
    {
        // Index and Name allow CSV Library to match the CSV column with the Customer object fields

        // Customer Ref is the primary key. This makes sure Entity Framework knows which field is the key
        [Key]
        [Index(0)]
        [Name("Customer Ref")]
        public string CustomerRef { get; set; }
        [Index(1)]
        [Name("Customer Name")]
        public string CustomerName { get; set; }
        [Index(2)]
        [Name("Address Line 1")]
        public string AddressLine1 { get; set; }
        [Index(3)]
        [Name("Address Line 2")]
        public string AddressLine2 { get; set; }
        [Index(4)]
        [Name("Town")]
        public string Town { get; set; }
        [Index(5)]
        [Name("County")]
        public string County { get; set; }
        [Index(6)]
        [Name("Country")]
        public string Country { get; set; }
        [Index(7)]
        [Name("Post Code")]
        public string PostCode { get; set; }
    }
}

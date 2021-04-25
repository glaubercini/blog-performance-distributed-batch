using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models.Purchasing
{
    public class Vendor
    {
        [Key]
        public int BusinessEntityId { get; set; }

        public string AccountNumber { get; set; }

        public string Name { get; set; }

        public int CreditRating { get; set; }

        public bool PreferredVendorStatus { get; set; }

        public bool ActiveFlag { get; set; }

        public string PurchasingWebServiceUrl { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}

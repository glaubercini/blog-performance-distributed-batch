using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models.Purchasing
{
    public class PurchaseOrderDetail
    {
        public int PurchaseOrderId { get; set; }

        public int PurchaseOrderDetailsId { get; set; }

        public DateTime DueDate { get; set; }

        public int OrderQty { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal ReceivedQty { get; set; }

        public decimal RejectedQty { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}

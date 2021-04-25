using DataLayer.Context;
using SimpleBatch.Interfaces;
using System;
using System.Linq;

namespace Batches.Example
{
    public sealed class SummedSalesBatch : ITaskfy
    {
        public void Execute(IContract _contract)
        {
            var contract = _contract as SummedSalesContract;

            var vendorId = contract.VendorId;

            using var ctx = new PurchasingContext();

            decimal total = ctx.PurchaseOrderHeader
                                .Where(poh => poh.VendorId == vendorId)
                                .Sum(poh => poh.SubTotal);

            decimal qty = (from details in ctx.PurchaseOrderDetail
                           join header in ctx.PurchaseOrderHeader
                               on details.PurchaseOrderId equals header.PurchaseOrderId
                           where header.VendorId == vendorId
                           select details.PurchaseOrderDetailsId)
                           .Count();

            Console.WriteLine($"VendorId: {vendorId}, Total: {total}, Items {qty}.");
        }
    }
}

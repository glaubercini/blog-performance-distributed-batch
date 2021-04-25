using DataLayer.Models.Purchasing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Context
{
    public class PurchasingContext : DefaultDbContext
    {
        public DbSet<Vendor> Vendor { get; set; }

        public DbSet<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }

        public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("purchasing");

            modelBuilder
                .Entity<PurchaseOrderDetail>()
                .HasKey(k => new { k.PurchaseOrderId, k.PurchaseOrderDetailsId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
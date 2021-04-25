using DataLayer.Models;
using DataLayer.Models.Blog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace DataLayer.Context
{
    public sealed class BlogContext : DefaultDbContext
    {
        public DbSet<BatchJob> BatchJob { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("blog");
        }

        public static TransactionScope RepeatableReadScope()
        {
            TransactionOptions transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.RepeatableRead
            };

            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
    }
}
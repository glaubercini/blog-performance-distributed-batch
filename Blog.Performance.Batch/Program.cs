using DataLayer.Context;
using DataLayer.Models.Purchasing;
using Batches.Example;
using System.Linq;
using DataLayer.Models.Blog;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace Blog.Performance.Batch
{
    class Program
    {
        static void Main(string[] args)
        {
            Migration();

            CreateTaskList();
        }

        static void Migration()
        {
            using var blogCtx = new BlogContext();
            blogCtx.Database.Migrate();
        }

        static void CreateTaskList()
        {
            using var ctx = new PurchasingContext();
            using var blogCtx = new BlogContext();

            var entityType = blogCtx.Model.FindEntityType(typeof(BatchJob));
            var schema = entityType.GetSchema();
            var tableName = entityType.GetTableName();

            var vendors = ctx.Vendor
                            .Select(v => new Vendor()
                            {
                                BusinessEntityId = v.BusinessEntityId
                            }).ToList();

            blogCtx.Database.ExecuteSqlRaw($"TRUNCATE TABLE {schema}.{tableName}");
            
            foreach (var item in vendors)
            {
                var contract = new SummedSalesContract
                {
                    VendorId = item.BusinessEntityId
                };

                blogCtx.BatchJob.Add(new BatchJob
                {
                    ClassName = typeof(SummedSalesBatch).AssemblyQualifiedName,
                    ContractName = typeof(SummedSalesContract).AssemblyQualifiedName,
                    ContractJson = JsonSerializer.Serialize(contract),
                    Status = 0 //Pending
                });;
            }

            blogCtx.SaveChanges();
        }
    }
}

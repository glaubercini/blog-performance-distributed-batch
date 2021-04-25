using DataLayer.Context;
using DataLayer.Models.Blog;
using Microsoft.EntityFrameworkCore;
using SimpleBatch.Interfaces;
using System;
using System.Data;
using System.Linq;
using System.Text.Json;

namespace SimpleBatchRunner
{
    class Program
    {
        private static readonly int _limit = 1;

        static void Main(string[] args)
        {
            bool keepPeeking;
            do
            {
                keepPeeking = RunBatch();
            } while (keepPeeking);
        }

        static bool RunBatch()
        {
            bool hadRows = false;

            using var ctx = new BlogContext();

            using var ts = ctx.Database.BeginTransaction(IsolationLevel.RepeatableRead);

            var batchJobs = ctx.BatchJob
                    .FromSqlInterpolated($"SELECT * FROM blog.batchjob WHERE Status = 0 FOR UPDATE SKIP LOCKED LIMIT {_limit}");


            foreach (var batchJob in batchJobs)
            {
                batchJob.StartedAt = DateTime.Now;

                Type batchType = Type.GetType(batchJob.ClassName);
                var batch = Activator.CreateInstance(batchType) as ITaskfy;

                Type contractType = Type.GetType(batchJob.ContractName);
                var contract = JsonSerializer.Deserialize(batchJob.ContractJson, contractType) as IContract;

                //Run
                batch.Execute(contract);

                batchJob.StoppedAt = DateTime.Now;
                batchJob.Status = 1; //Done

                hadRows = true;
            }

            ctx.SaveChanges();

            System.Threading.Thread.Sleep(500);

            ts.Commit();

            return hadRows;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Context
{
    public abstract class DefaultDbContext : DbContext
    {
        private static readonly string Host = DbAddress();
        private static readonly string User = "postgres";
        private static readonly string DBname = "Adventureworks";
        private static readonly string Password = "blog";
        private static readonly string Port = "5432";

        private static string DbAddress()
        {
            string dbAddress = Environment.GetEnvironmentVariable("DB_ADDRESS");
            if(string.IsNullOrWhiteSpace(dbAddress))
            {
                dbAddress = "localhost";
            }

            return dbAddress;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql(string.Format(
                    "Server={0};Username={1};Database={2};Port={3};Password={4};SSLMode=Prefer",
                    Host,
                    User,
                    DBname,
                    Port,
                    Password),
                    x => x.MigrationsHistoryTable("_ef_migration_history", "blog")
                )
                .UseLowerCaseNamingConvention();
    }
}

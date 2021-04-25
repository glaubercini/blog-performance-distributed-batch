using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models.Blog
{
    [Index(nameof(Status))]
    public class BatchJob
    {
        public long Id { get; set; }

        public string ClassName { get; set; }

        public string ContractName { get; set; }

        public string ContractJson { get; set; }

        public int Status { get; set; } = 0;

        public DateTime StartedAt { get; set; }

        public DateTime StoppedAt { get; set; }
    }
}

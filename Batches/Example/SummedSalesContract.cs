using System;
using System.Collections.Generic;
using System.Text;
using SimpleBatch.Interfaces;

namespace Batches.Example
{
    [Serializable]
    public class SummedSalesContract : IContract
    {
        public int VendorId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBatch.Interfaces
{
    public interface ITaskfy
    {
        public void Execute(IContract contract);
    }
}

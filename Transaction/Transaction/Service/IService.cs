using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transaction.Service
{
    public interface IService
    {
        List<Transaction> Transactions { get; set; }
        void Add();
        void Get();
    }
}

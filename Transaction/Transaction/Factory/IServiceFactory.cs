using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transaction.Service;

namespace Transaction.Factory
{
    public interface IServiceFactory<T> where T : IService
    {
        T CreateTransaction();
    }
}

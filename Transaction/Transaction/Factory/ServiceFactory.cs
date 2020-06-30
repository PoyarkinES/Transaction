using System;
using Transaction.Service;

namespace Transaction.Factory
{
    public class ServiceFactory<T> : IServiceFactory<T> where T : IService
    {
        public T CreateTransaction()
        {
            return Activator.CreateInstance<T>();
        }
    }
}

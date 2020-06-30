using Transaction.Service;

namespace Transaction.Factory
{
    public interface IServiceFactory<out T> where T : IService
    {
        T CreateTransaction();
    }
}

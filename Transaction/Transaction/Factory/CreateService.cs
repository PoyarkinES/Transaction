using Transaction.Service;

namespace Transaction.Factory
{
    public class CreateService : ICreateService
    {
        public IService CreateTransaction()
        {
            return new TransactionService();
        }
    }
}

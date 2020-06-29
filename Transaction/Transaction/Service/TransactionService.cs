using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Transaction.Factory;
using static Transaction.Helper.HelperStaticClass;

namespace Transaction.Service
{
    public class TransactionService : IService
    {
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        public void Add()
        {
            var id = InputUniqueValue<Int32>("Id", "Введите Id", Transactions);
            var transactionDate = InputValue<DateTime>("TransactionDate", "Введите дату");
            var amount = InputValue<Decimal>("Amount", "Введите сумму");

            if (Transactions.Any(a => a.Id == id))
            {
                Console.WriteLine($"Запись с Id {id} уже существует. Диблирование данных запрещено. Пожалуйста укажите правильные данные");
            }
            Transactions.Add(new Transaction() {Id = id, TransactionDate = transactionDate, Amount = amount});
            Console.WriteLine("[OK]");
        }

        public void Get()
        {
            var id = InputValue<Int32>("Id", "Введите Id");
            var item = JsonConvert.SerializeObject(Transactions.FirstOrDefault(f => f.Id == id));
            Console.WriteLine($"{item}");
            Console.WriteLine("[OK]");
        }

    }
}

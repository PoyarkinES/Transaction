using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static Transaction.Helper;

namespace Transaction
{
    public class TransactionService
    {
        public List<Transaction> Transactions { get; set; }

        public void Add()
        {
            var id = InputValue<Int32>("Id", "Введите Id");
            var transactionDate = InputValue<DateTime>("TransactionDate", "Введите дату");
            var amount = InputValue<Decimal>("Amount", "Введите сумму");

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

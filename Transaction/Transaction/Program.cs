using System;
using System.Collections.Generic;

namespace Transaction
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new TransactionService {Transactions = new List<Transaction>()};

            var cmd = ShowCommand();
            do
            {
                switch (cmd)
                {
                    case "add":
                        service.Add();
                        Console.WriteLine("Веедите команду");
                        cmd = Console.ReadLine();
                        break;
                    case "get":
                        service.Get();
                        Console.WriteLine("Веедите команду");
                        cmd = Console.ReadLine();
                        break;
                    case "exit":
                        Exit();
                        break;
                }
            } while (!string.Equals(cmd, null, StringComparison.Ordinal) && cmd != "exit");
        }

        private static void Exit()
        {
            System.Environment.Exit(0);
        }

        private static string ShowCommand()
        {
            Console.WriteLine("Ввод данных - add");
            Console.WriteLine("Выбор данных - get");
            Console.WriteLine("Выход из программы - exit");
            return Console.ReadLine();
        }
    }
}

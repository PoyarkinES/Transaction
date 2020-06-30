using System;
using System.Linq;
using Transaction.Enum;
using Transaction.Factory;
using Transaction.Helper;
using Transaction.Service;

namespace Transaction
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ServiceFactory<TransactionService>().CreateTransaction();

            var cmd = ShowCommand();
            do
            {
                switch (cmd.ToLower())
                {
                    case "add":
                        service.Add();
                        cmd = ShowCommand();
                        break;
                    case "get":
                        service.Get();
                        cmd = ShowCommand();
                        break;
                    case "exit":
                        Exit();
                        break;
                }
            } while (!string.Equals(cmd, null, StringComparison.Ordinal) && cmd != "exit");
        }

        private static void Exit()
        {
            Environment.Exit(0);
        }

        private static string ShowCommand()
        {
            foreach (System.Enum cmd in System.Enum.GetValues(typeof(CommandEnum)))
            {
                Console.WriteLine($"{cmd.GetDescription()} - {cmd}");
            }

            var result = Console.ReadLine()?.ToLower();

            if (System.Enum.GetNames(typeof(CommandEnum)).Any(a => a.ToLower() == result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Указанной команды не существует. Повторите ввод.");
                return ShowCommand();
            }
        }
    }
}

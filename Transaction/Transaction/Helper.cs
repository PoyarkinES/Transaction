using System;

namespace Transaction
{
    public static class Helper
    {
        public static T InputValue<T>(string nameValue, string name) where T : struct
        {
            Console.Write($"{name} = ");
            var value = Console.ReadLine();
            if (Is<T>(value, out var result)) return result;
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Значение {nameValue} невозможно преобразовать в {typeof(T).Name}. Повторите ввод.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write($"{name} = ");
                value = Console.ReadLine();
            } while (!Is(value, out result));
            return result;
        }

        private static T GetValue<T>(string str) where T : struct
        {
            return (T)Convert.ChangeType(str, typeof(T));
        }

        private static bool Is<T>(string input, out T result) where T : struct
        {
            try
            {
                result = GetValue<T>(input);
                return true;
            }
            catch
            {
                result = new T();
                return false;
            }
        }
    }
}

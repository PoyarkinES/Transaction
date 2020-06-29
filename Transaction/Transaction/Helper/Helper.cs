using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Transaction.Helper
{
    public static class HelperStaticClass
    {
        public static T InputValue<T>(string nameValue, string name) where T : struct
        {
            Console.Write($"{name} = ");
            var value = Console.ReadLine();
            return Correct<T>(nameValue, name, value,
                $"Значение {nameValue} невозможно преобразовать в {typeof(T).Name}. Повторите ввод.");
        }

        public static T InputUniqueValue<T>(string nameValue, string name, List<Transaction> list) where T : struct
        {
            Console.Write($"{name} = ");
            var value = Console.ReadLine();
            return CorrectUnique<T>(nameValue, name, value,
                $"Значение {nameValue} уже содержится в коллекции. Дублирование записей запрещено. Повторите ввод.",
                list);
        }

        private static T Correct<T>(string nameValue, string name, string value, string error) where T : struct
        {
            if (Is<T>(value, out var result)) return result;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{name} = ");
            return Correct<T>(nameValue, name, Console.ReadLine(), error);
        }

        private static T CorrectUnique<T>(string nameValue, string name, string value, string error,
            List<Transaction> list) where T : struct
        {
            var result = Correct<T>(nameValue, name, value,
                $"Значение {nameValue} невозможно преобразовать в {typeof(T).Name}. Повторите ввод.");
            if (list.All(a =>
                a.GetType().GetProperty(nameValue)?.GetValue(a, new object[] { }).ToString() != result.ToString()))
                return result;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write($"{name} = ");
            return CorrectUnique<T>(nameValue, name, Console.ReadLine(), error, list);
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

        private static T GetValue<T>(string str) where T : struct
        {
            return (T)Convert.ChangeType(str, typeof(T));
        }

        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is System.Enum)
            {
                Type type = e.GetType();
                Array values = System.Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val) ?? throw new InvalidOperationException());
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(DescriptionAttribute), false)
                            .FirstOrDefault() as DescriptionAttribute;

                        if (descriptionAttribute != null)
                        {
                            return descriptionAttribute.Description;
                        }
                    }
                }

                return null;
            }
            return String.Empty;
        }
    }
}

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Transaction.Enum
{
    public enum CommandEnum
    {
        [Description("Ввод данных")]
        Add = 1,
        [Description("Выбор данных")]
        Get = 2,
        [Description("Выход из программы")]
        Exit = 3
    }
}

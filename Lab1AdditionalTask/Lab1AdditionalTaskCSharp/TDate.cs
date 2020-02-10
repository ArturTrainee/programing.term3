using System;
using System.Globalization;

namespace Lab1AdditionalTaskCSharp
{
    public class TDate
    {
        public TDate(string date)
        {
            FullDate = date;
        }

        public string FullDate
        {
            get => FullDate;
            set => FullDate = IsCorrectDate(value)
                ? value
                : throw new ArgumentException($"Invalid date entered {value}");
        }

        public static bool IsCorrectDate(string date) => DateTime.TryParseExact(date,
                                                                                "dd.mm.yyyy",
                                                                                CultureInfo.InvariantCulture,
                                                                                style: DateTimeStyles.None,
                                                                                result: out _);
    }
}

using System;
using System.Globalization;

namespace Lab1AdditionalTaskCSharp
{
    public class TDate
    {
        private string fullDate;
        public TDate(string date)
        {
            FullDate = date;
        }

        public string FullDate
        {
            get => fullDate;
            set
            {
                try
                {
                    if (IsCorrectDate(value))
                    {
                        fullDate = value;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid date entered " + value.ToString());
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static bool IsCorrectDate(string date) => DateTime.TryParseExact(date,
                                                                                "dd.mm.yyyy",
                                                                                CultureInfo.InvariantCulture,
                                                                                style: DateTimeStyles.None,
                                                                                result: out _);
    }
}

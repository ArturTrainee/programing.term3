using System;
using static System.Console;

namespace Lab1AdditionalTaskCSharp
{
    internal static class Program
    {
        public static void Main(string[] _)
        {
            WriteLine("Enter your name in format: [first name] [last name] [patronymic name]");
            string fullName = ReadLine();
            BankAccount bankAccount = new BankAccount(fullName);

            AskToChangeBalance(bankAccount);
            AskToChangeCreationDate(bankAccount);
            PrintOptions();
            ExecuteOptions(bankAccount);
        }

        private static void AskToChangeBalance(BankAccount bankAccount)
        {
            WriteLine("Do you want to change default balance? y/n");
            switch (ReadLine())
            {
                case "y":
                    WriteLine("Enter the amount of money:");
                    bankAccount.Balance = new TMoney(ReadLine());
                    break;

                case "n": break;
            }
        }

        private static void AskToChangeCreationDate(BankAccount bankAccount)
        {
            WriteLine("Do you want to change the date of creation? y/n");
            switch (ReadLine())
            {
                case "y":
                    WriteLine("Enter the date in format: [dd.mm.yyyy]");
                    bankAccount.CreationTime = new TDate(ReadLine());
                    break;

                case "n": break;
            }
        }

        private static void ExecuteOptions(BankAccount bankAccount)
        {
            while (true)
            {
                WriteLine("\nChoose option: ");
                switch (ReadLine())
                {
                    case "1":
                        WriteLine("Enter new name:");
                        bankAccount.ChangeName(ReadLine());
                        break;

                    case "2":
                        WriteLine("Enter the withdraw amount:");
                        bankAccount.WithdrawMoney(new TMoney(ReadLine()));
                        break;

                    case "3":
                        WriteLine("Enter the refill amount:");
                        bankAccount.RefillMoney(new TMoney(ReadLine()));
                        break;

                    case "4":
                        WriteLine("Enter the UAH amount you want to convert:");
                        if (decimal.TryParse(ReadLine(), out decimal uahAmount))
                        {
                            if (uahAmount >= 0) bankAccount.ConvertUAHToEuro(uahAmount);
                            else WriteLine($"UAH amount can not be negative: {uahAmount}");
                        }
                        else
                        {
                            WriteLine("Invalid UAH amount");
                        }

                        WriteLine($"Your euro balance: {decimal.Round(bankAccount.EuroBalance, 2).ToString()}");
                        break;

                    case "5":
                        WriteLine(bankAccount.GetFullInfo());
                        break;

                    case "6":
                        Environment.Exit(1);
                        break;
                }
            }
        }

        private static void PrintOptions()
        {
            WriteLine("1. Change first name");
            WriteLine("2. Withdraw money");
            WriteLine("3. Refill money");
            WriteLine("4. Convert money to euro");
            WriteLine("5. Show account information");
            WriteLine("6. Exit\n");
        }
    }
}
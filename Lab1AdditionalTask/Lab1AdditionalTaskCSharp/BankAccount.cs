using System;
using System.Text.RegularExpressions;

namespace Lab1AdditionalTaskCSharp
{
    class BankAccount : TAccount, ITransactionable
    {
        private string fullName;
        private TMoney balance;
        private readonly decimal euroBalance;
        private TDate creationTime = new TDate(DateTime.Today.ToShortDateString());

        public BankAccount(string fullName) : this(fullName, 5000M, DateTime.Today.ToShortDateString()) { }
        public BankAccount(string fullName, decimal accountBalance) : this(fullName, accountBalance, DateTime.Today.ToShortDateString()) { }
        public BankAccount(string fullName, decimal accountBalance, string customTime)
        {
            FullName = fullName;
            Balance = new TMoney(accountBalance.ToString());
            CreationTime = new TDate(customTime);
            ++AccountNumber;
        }

        public override string FullName
        {
            get => fullName;
            set
            {
                try
                {
                    if (value != null)
                    {
                        string[] _fullName = value.Split(' ');

                        foreach (string name in _fullName)
                        {
                            if (IsCorrectName(name) == false)
                            {
                                throw new ArgumentException("Invalid name entered: " + name);
                            }
                        }
                        HasCorrectFullName = true;
                        fullName = value;
                    }
                    else
                    {
                        throw new ArgumentException("Full name should contain: first name, last name and patronymic name");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public override TDate CreationTime
        {
            get => creationTime;
            set
            {
                if (TDate.IsCorrectDate(value.FullDate))
                {
                    creationTime = value;
                }
                else
                {
                    Console.WriteLine("Invalid date entered: " + value.FullDate);
                    Console.WriteLine("Date of creation in setted as: " + creationTime);
                }
            }
        }
        public TMoney Balance
        {
            get => balance;
            set
            {
                try
                {
                    if (value.CompareTo(0) > 0)
                    {
                        balance = value;
                    }
                    else
                    {
                        throw new ArgumentException("Account balance can not be negative: " + value);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Your balance setted to 5000 UAH");
                }
            }
        }
        public decimal EuroBalance { get; private set; }
        public bool HasCorrectFullName { get; private set; }

        public void ChangeName(string name)
        {
            if (IsCorrectName(name))
            {
                ;
                FullName = fullName.Replace(fullName.Split(' ')[0], name);
            }
            else
            {
                Console.WriteLine("Invalid name entered");
            }
        }

        public static bool IsCorrectName(string name) => Regex.IsMatch(name, "[A-Z][a-z]*");

        public void WithdrawMoney(TMoney withdrawalAmount)
        {
            try
            {
                if (withdrawalAmount.CompareTo(0) >= 0)
                {
                    if (balance.CompareTo(withdrawalAmount) >= 0)
                    {
                        balance = balance.Subtract(withdrawalAmount);
                    }
                    else
                    {
                        throw new ArgumentException("Withdrawal amount: " + withdrawalAmount +
                            " is bigger then account balance");
                    }
                }
                else
                {
                    throw new ArgumentException("Withdrawal amount: " + withdrawalAmount + " is less then 0");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RefillMoney(TMoney replenishmentAmount)
        {
            try
            {
                if (replenishmentAmount.CompareTo(0) >= 0)
                {
                    Balance = balance.Add(replenishmentAmount);
                }
                else
                {
                    throw new ArgumentException("Replenishment amount:" + replenishmentAmount + " is less then 0");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AccrueInterest(int daysPassed)
        {
            Balance = balance.Multiply(1 + TMoney.INTEREST_RATE * daysPassed / (365 * 100));
        }

        public void ConvertUAHToEuro(decimal conversionAmount)
        {
            try
            {
                if (conversionAmount > 0)
                {
                    if (balance.ToDecimal() >= conversionAmount)
                    {
                        decimal convertedAmount = conversionAmount / TMoney.EURO_RATE;
                        EuroBalance += convertedAmount;
                        balance = balance.Subtract(new TMoney(conversionAmount.ToString()));
                    }
                    else
                    {
                        throw new ArgumentException("Conversion amount: " + conversionAmount +
                            " is bigger then UAH balance: " + balance);
                    }
                }
                else
                {
                    throw new ArgumentException("Conversion amount: " + conversionAmount + " is less then 0");
                }
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string GetFullInfo() => fullName + "\n" + Balance.ToDecimal() + " UAH\ncreation time: " + CreationTime.FullDate;
    }
}
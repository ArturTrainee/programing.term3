using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace Lab1AdditionalTaskCSharp
{
    internal class BankAccount : TAccount, ITransactionable
    {
        private static int nextID = 1;

        public BankAccount(string fullName) : this(fullName, 5000M, DateTime.Today.ToShortDateString())
        {
        }

        public BankAccount(string fullName, decimal accountBalance) : this(fullName, accountBalance, DateTime.Today.ToShortDateString())
        {
        }

        public BankAccount(string fullName, decimal accountBalance, string customTime)
        {
            FullName = fullName;
            Balance = new TMoney(accountBalance.ToString());
            CreationTime = new TDate(customTime);
            AccountNumber = nextID;
            ++nextID;
        }

        public TMoney Balance
        {
            get => Balance;
            set => Balance = value.CompareTo(0) > 0
                ? value
                : throw new ArgumentException("Account balance can not be negative: " + value);
        }

        public override TDate CreationTime
        {
            get => CreationTime;
            set
            {
                if (TDate.IsCorrectDate(value.FullDate))
                {
                    CreationTime = value;
                }
                else
                {
                    WriteLine($"Invalid date entered: {value.FullDate}");
                    CreationTime = new TDate(DateTime.Today.ToShortDateString());
                    WriteLine($"Date of creation in setted as: {CreationTime}");
                }
            }
        }

        public decimal EuroBalance { get; private set; }

        public override string FullName
        {
            get => FullName;
            set
            {
                if (value != null)
                {
                    FullName = IsCorrectInitials(value)
                        ? value
                        : throw new ArgumentException($"Invalid initials {value} entered");
                }
                else
                {
                    throw new ArgumentException("Full name is null");
                }
            }
        }

        public void AccrueInterest(int daysPassed) => Balance = Balance.Multiply(1 + (TMoney.INTEREST_RATE * daysPassed / (365 * 100)));

        public void ChangeName(string name)
        {
            FullName = IsCorrectInitials(name)
                ? FullName.Replace(FullName.Split(' ')[0], name)
                : throw new ArgumentException($"Invalid name: {name} entered");
        }

        public void ConvertUAHToEuro(decimal conversionAmount)
        {
            if (conversionAmount > 0)
            {
                if (Balance.ToDecimal() >= conversionAmount)
                {
                    decimal convertedAmount = conversionAmount / TMoney.EURO_RATE;
                    EuroBalance += convertedAmount;
                    Balance = Balance.Subtract(new TMoney(conversionAmount.ToString()));
                }
                else
                {
                    throw new ArgumentException($"Conversion amount: {conversionAmount} is bigger then UAH balance: {Balance}");
                }
            }
            else
            {
                throw new ArgumentException($"Conversion amount: {conversionAmount} is less then 0");
            }
        }

        public string GetFullInfo() => $"{FullName}\n{Balance.ToDecimal()} UAH\ncreation time: {CreationTime.FullDate}";

        public void RefillMoney(TMoney replenishmentAmount)
        {
            Balance = (replenishmentAmount.CompareTo(0) >= 0)
                ? Balance.Add(replenishmentAmount)
                : throw new ArgumentException($"Replenishment amount:{replenishmentAmount} is less then 0");
        }

        public void WithdrawMoney(TMoney withdrawalAmount)
        {
            if (withdrawalAmount.CompareTo(0) >= 0)
            {
                if (Balance.CompareTo(withdrawalAmount) >= 0) Balance = Balance.Subtract(withdrawalAmount);
                else throw new ArgumentException($"Withdrawal amount: {withdrawalAmount} is bigger then balance");
            }
            else
            {
                throw new ArgumentException($"Withdrawal amount: {withdrawalAmount} is less then 0");
            }
        }

        private static bool IsCorrectInitials(string value)
        {
            foreach (string name in value.Split(' '))
            {
                if (!Regex.IsMatch(name, "^[A-Z][a-z]*&"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
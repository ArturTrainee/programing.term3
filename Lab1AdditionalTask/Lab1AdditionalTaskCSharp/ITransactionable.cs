namespace Lab1AdditionalTaskCSharp
{
    internal interface ITransactionable
    {
        void WithdrawMoney(TMoney withdrawalAmount);
        void RefillMoney(TMoney replenishmentAmount);
        void AccrueInterest(int daysPassed);
        void ConvertUAHToEuro(decimal conversionAmount);
    }
}
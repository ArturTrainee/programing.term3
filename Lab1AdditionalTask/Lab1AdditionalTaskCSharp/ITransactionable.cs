namespace Lab1AdditionalTaskCSharp
{
    internal interface ITransactionable
    {
        void AccrueInterest(int daysPassed);

        void ConvertUAHToEuro(decimal conversionAmount);

        void RefillMoney(TMoney replenishmentAmount);

        void WithdrawMoney(TMoney withdrawalAmount);
    }
}
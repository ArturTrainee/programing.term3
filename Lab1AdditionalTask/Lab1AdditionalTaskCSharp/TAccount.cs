namespace Lab1AdditionalTaskCSharp
{
    internal abstract class TAccount
    {
        public static int AccountNumber { get; set; }
        public virtual string FullName { get; set; }
        public virtual TDate CreationTime { get; set; }
    }
}
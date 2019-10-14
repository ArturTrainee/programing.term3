namespace Lab1AdditionalTaskCSharp
{
    abstract class TAccount
    {
        public static int AccountNumber { get; set; }
        public virtual string FullName { get; set; }
        public virtual TDate CreationTime { get; set; }
    }
}
using System;
using System.Threading;

namespace CallCenterModel
{
    internal class Call
    {
        private static int nextId;

        public int ID { get; private set; }
        public int DurationSeconds { get; }

        public Call(int durationInSeconds)
        {
            if (durationInSeconds < 1)
            {
                throw new ArgumentException("Call duration is less than 0");
            }
            DurationSeconds = durationInSeconds;
            ID = Interlocked.Increment(ref nextId);
        }

        public override string ToString() => $"Call id = {ID}, Duration = {DurationSeconds} sec.";
    }
}
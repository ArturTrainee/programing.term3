using System;
using System.Threading;

namespace CallCenterModel
{
    internal class Call
    {
        private static int nextId;

        public Call(int durationInSeconds)
        {
            if (durationInSeconds < 1)
            {
                throw new ArgumentException("Call duration is less than 0");
            }
            DurationSec = durationInSeconds;
            ID = Interlocked.Increment(ref nextId);
        }

        public int DurationSec { get; }
        public int ID { get; }

        public override string ToString() => $"Call id = {ID}, Duration = {DurationSec} sec.";
    }
}
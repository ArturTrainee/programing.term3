using System.Collections.Concurrent;
using System.Threading;
using static System.Console;

namespace CallCenterModel
{
    internal delegate void ResponseCallDelegate(ConcurrentQueue<Call> calls);

    public enum EmployeeState { AVAILABLE, BUSY }

    public enum EmployeeType { OPERATOR, SUPERVISOR, DIRECTOR }

    internal class Employee
    {
        private static int nextId;

        public Employee(EmployeeType type) : this(type, EmployeeState.AVAILABLE)
        {
        }

        public Employee(EmployeeState state) : this(EmployeeType.OPERATOR, state)
        {
        }

        public Employee(EmployeeType type, EmployeeState state)
        {
            Type = type;
            State = state;
            ID = Interlocked.Increment(ref nextId);
        }

        private event ResponseCallDelegate ReadyForNextCall;

        public ConcurrentQueue<Call> AttendedCalls { get; } = new ConcurrentQueue<Call>();
        public int ID { get; }
        public EmployeeState State { get; set; }
        public EmployeeType Type { get; }

        public override string ToString() => $"Employee id = {ID}, type = {Type}, state = {State}";

        internal void ResponseCall(ConcurrentQueue<Call> calls)
        {
            calls.TryDequeue(out Call call);
            if (call != null)
            {
                WriteLine($"Employee id = {ID}, recived {call}\n");
                Thread.Sleep(call.DurationSec * 1000);
                WriteLine($"{call} has been ended.\n");
                AttendedCalls.Enqueue(call);
                State = EmployeeState.AVAILABLE;
            }
            else
            {
                Thread.Sleep(3000);
            }
            ReadyForNextCall?.Invoke(calls);
        }
    }
}
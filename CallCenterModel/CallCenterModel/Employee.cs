using System.Collections.Concurrent;
using System.Threading;
using static System.Console;

namespace CallCenterModel
{
    public enum EmployeeType { OPERATOR, SUPERVISOR, DIRECTOR }
    public enum EmployeeState { AVAILABLE, BUSY }

    delegate void ResponseCallDelegate(ConcurrentQueue<Call> calls);

    class Employee
    {
        event ResponseCallDelegate ReadyForNextCall;

        private static int nextId;

        public int ID { get; private set; }
        public EmployeeType Type { get; }
        public EmployeeState State { get; set; }

        public ConcurrentQueue<Call> AttendedCalls { get; private set; } = new ConcurrentQueue<Call>();

        public Employee(EmployeeType type) : this(type, EmployeeState.AVAILABLE) { }

        public Employee(EmployeeState state) : this(EmployeeType.OPERATOR, state) { }

        public Employee(EmployeeType type, EmployeeState state)
        {
            Type = type;
            State = state;
            ID = Interlocked.Increment(ref nextId);
        }

        internal void ResponseCall(ConcurrentQueue<Call> calls)
        {
            calls.TryDequeue(out Call call);
            if (call != null)
            {
                WriteLine($"\nEmployee id = {ID}, recived {call.ToString()}\n");
                Thread.Sleep(call.DurationSeconds * 1000);
                WriteLine(call.ToString() +" has been ended.\n");
                AttendedCalls.Enqueue(call);
                State = EmployeeState.AVAILABLE;
            }
            else Thread.Sleep(3000);
            ReadyForNextCall?.Invoke(calls);
        }
    }
}

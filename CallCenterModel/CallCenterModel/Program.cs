using System.Collections.Concurrent;
using System.Collections.Generic;
using static System.Console;

namespace CallCenterModel
{
    internal static class Program
    {
        private static void Main(string[] _)
        {
            var employees = new List<Employee>
            {
                new Employee(EmployeeType.OPERATOR, EmployeeState.AVAILABLE),
                new Employee(EmployeeType.OPERATOR, EmployeeState.AVAILABLE),
                new Employee(EmployeeType.SUPERVISOR, EmployeeState.AVAILABLE),
                new Employee(EmployeeType.DIRECTOR, EmployeeState.AVAILABLE)
            };

            var incomingCalls = new ConcurrentQueue<Call>();

            CallGenerator.GenerateCalls(ref incomingCalls, 13, 5, 20);
            var callHandler = new CallHandler();
            callHandler.RunCallsHandling(incomingCalls, employees);
            ReadKey();
        }
    }
}
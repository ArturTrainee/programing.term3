using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CallCenterModel
{
    class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>();
            employees.Add(new Employee(EmployeeType.OPERATOR,   EmployeeState.AVAILABLE));
            employees.Add(new Employee(EmployeeType.OPERATOR,   EmployeeState.AVAILABLE));
            employees.Add(new Employee(EmployeeType.SUPERVISOR, EmployeeState.AVAILABLE));
            employees.Add(new Employee(EmployeeType.DIRECTOR,   EmployeeState.AVAILABLE));

            var incomingCalls = new ConcurrentQueue<Call>();

            CallGenerator.GenerateCalls(ref incomingCalls, 10, 5, 10);
            var callHandler = new CallHandler();
            callHandler.RunCallsHandling(incomingCalls, employees);
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace CallCenterModel
{
    internal class CallHandler
    {
        public Employee FindEmployee(IEnumerable<Employee> employees)
        {
            if (employees is null)
            {
                throw new ArgumentNullException("Employees are null");
            }

            var availableEmployees = employees.Where(e => e.State == EmployeeState.AVAILABLE);
            WriteLine($"Available operators: {availableEmployees.Count()}\n");
            if (!availableEmployees.Any())
            {
                return null;
            }

            var employee = availableEmployees.FirstOrDefault(e => e.Type == EmployeeType.OPERATOR);
            if (employee is null)
            {
                WriteLine("No available operators were founded\n");
                employee = availableEmployees.FirstOrDefault(e => e.Type == EmployeeType.SUPERVISOR);
                if (employee is null)
                {
                    WriteLine("No available supervisors were founded\n");
                    employee = availableEmployees.FirstOrDefault(e => e.Type == EmployeeType.DIRECTOR);
                    if (employee is null)
                    {
                        WriteLine("No available employees were founded\n");
                        return null;
                    }
                }
            }
            WriteLine($"{employee} were founded\n");
            return employee;
        }

        public void RunCallsHandling(ConcurrentQueue<Call> calls, List<Employee> employees)
        {
            while (!calls.IsEmpty)
            {
                var employee = FindEmployee(employees);
                if (employee is null && !calls.IsEmpty)
                {
                    int minCallSeconds = calls.OrderBy(call => call.DurationSec).FirstOrDefault()?.DurationSec ?? 0;
                    Thread.Sleep(minCallSeconds * 1000);
                }
                else
                {
                    employee.State = EmployeeState.BUSY;
                    var callResponse = Task.Run(() => employee.ResponseCall(calls));
                }
            }
        }
    }
}
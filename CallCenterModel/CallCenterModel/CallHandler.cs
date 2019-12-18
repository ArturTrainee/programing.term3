using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallCenterModel
{
    class CallHandler
    {
        public void RunCallsHandling(ConcurrentQueue<Call> calls, List<Employee> employees)
        {
            while (!calls.IsEmpty)
            {
                var employee = findEmployee(employees);
                if (employee is null)
                {
                    Thread.Sleep(5000);
                }
                else
                {
                    employee.State = EmployeeState.BUSY;
                    Task callResponse = Task.Run(delegate ()
                    {
                        employee.ResponseCall(calls);
                    });
                }
            }
        }

        public Employee findEmployee(IEnumerable<Employee> employees)
        {
            if (employees is null)
            {
                throw new ArgumentNullException("Employees are null");
            }

            var availableEmployees = employees.Where(e => e.State == EmployeeState.AVAILABLE);
            Console.WriteLine("Available operators: " + availableEmployees.Count());
            if (availableEmployees.Count() == 0) return null;

            var employee = availableEmployees.FirstOrDefault(e => e.Type == EmployeeType.OPERATOR);
            if (employee is null)
            {
                Console.WriteLine("No available operators founded");
                employee = availableEmployees.FirstOrDefault(e => e.Type == EmployeeType.SUPERVISOR);
                if (employee is null)
                {
                    Console.WriteLine("No available supervisors founded");
                    employee = availableEmployees.FirstOrDefault(e => e.Type == EmployeeType.DIRECTOR);
                    if (employee is null)
                    {
                        Console.WriteLine("No available directors founded");
                        return null;
                    }
                }
            }
            Console.WriteLine("Employee of type " + employee.Type + " founded");
            return employee;
        }
    }
}

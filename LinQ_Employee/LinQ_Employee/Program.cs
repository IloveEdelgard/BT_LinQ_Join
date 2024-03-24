using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Employee
{
    class Program
    {
        static void Main(string[] args)
        {

            var employee = Employee.getEmployees();
            var department = Department.getDepartments();

            var maxSalary = employee.Max(x => x.Salary);
            Console.WriteLine("Max Salary: " + maxSalary);

            var minSalary = employee.Min(x => x.Salary);
            Console.WriteLine("Min Salary: " + minSalary);

            var averageSalary = employee.Average(x => x.Salary);
            Console.WriteLine("Average Salary: " + averageSalary);
            Console.WriteLine();

            Console.WriteLine("GroupBy DepartmentID:");
            var employeeGroup = employee.GroupBy(e => e.DepartmentID);
            foreach (var group in employeeGroup)
            {
                Console.WriteLine("DepartmentID: {0}- #{1}", group.Key, group.Count());
                foreach (var em in group)
                {
                    Console.WriteLine(em.Name);
                }
            }
            Console.WriteLine();

            Console.WriteLine("GroupJoin Department:");
            var employeesByDepartment = Department.getDepartments().GroupJoin(employee,
                                        d => d.ID,
                                        e => e.DepartmentID,
                                        (departments, employees) => new
                                        {
                                            Department = departments,
                                            Employee = employees
                                        });
            foreach (var departments in employeesByDepartment)
            {
                Console.WriteLine(departments.Department.Name);
                foreach (var em in departments.Employee)
                {
                    Console.WriteLine("" + em.Name);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Left Outer Join: ");
            var resultLeft = from e in employee
                             join d in department
                             on e.DepartmentID equals d.ID into eGroup
                             from d in eGroup.DefaultIfEmpty()
                             select new
                             {
                                 EmployeeName = e.Name,
                                 DepartmentName = d == null ? "No Department" : d.Name
                             };
            foreach (var em in resultLeft)
            {
                Console.WriteLine("{0}-{1}", em.EmployeeName, em.DepartmentName);
            }
            Console.WriteLine();

            Console.WriteLine("Right Outer Join: ");
            var resultRight = from d in department
                              join e in employee
                              on d.ID equals e.DepartmentID into dGroup
                              from e in dGroup.DefaultIfEmpty()
                              select new
                              {
                                  EmployeeName = e == null ? "No Employee" : e.Name,
                                  DepartmentName = d.Name
                              };
            foreach (var dp in resultRight)
            {
                Console.WriteLine("{0}-{1}", dp.EmployeeName, dp.DepartmentName);
            }
            Console.WriteLine();

            var maxAge = employee.Max(x => x.Age);
            Console.WriteLine("Max Age: " + maxAge);

            var minAge = employee.Min(x => x.Age);
            Console.WriteLine("Min Age: " + minAge);

            Console.ReadKey();
        }

    }

}

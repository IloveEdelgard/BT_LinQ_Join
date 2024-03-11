using System;
using System.Collections.Generic;

namespace LinQ_Employee
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int DepartmentID { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public DateTime Birthday { get; set; }

        public static List<Employee> getEmployees()
        {
            return new List<Employee>()
            {
                new Employee { ID = 1, Name = "A", DepartmentID = 1, Age = 23, Salary = 12000000, Birthday = new DateTime(2001, 5, 20) },
                new Employee { ID = 2, Name = "B", DepartmentID = 2, Age = 24, Salary = 10000000, Birthday = new DateTime(2000, 4, 23) },
                new Employee { ID = 3, Name = "C", DepartmentID = 3, Age = 23, Salary = 22000000, Birthday = new DateTime(2001, 10, 30) },
                new Employee { ID = 4, Name = "D", DepartmentID = 1, Age = 26, Salary = 15000000, Birthday = new DateTime(1998, 4, 6) },
                new Employee { ID = 5, Name = "E", DepartmentID = 5, Age = 22, Salary = 8000000, Birthday = new DateTime(2002, 5, 31) }
            };
        }
    }
}
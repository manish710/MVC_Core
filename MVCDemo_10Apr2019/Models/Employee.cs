using System;
using System.Collections.Generic;

namespace MVCDemo_10Apr2019.Models
{
    public class Employee
    {
        public int EmpId { get; set; }

        public String EmployeeName { get; set; }

        public decimal Salary { get; set; }

        public List<Employee> EmployeeCollection()
        {
            List<Employee> empList = new List<Employee>
            {
                new Employee{ EmpId=1,EmployeeName="Tom", Salary=10000},
                new Employee{ EmpId=2,EmployeeName="Dick", Salary=12000},
                new Employee{ EmpId=3,EmployeeName="Harry", Salary=9000},
                new Employee{ EmpId=4,EmployeeName="Tim", Salary=7000},
                new Employee{ EmpId=5,EmployeeName="Jack", Salary=11000},
                new Employee{ EmpId=6,EmployeeName="Jill", Salary=10500},
                new Employee{ EmpId=7,EmployeeName="Mallya", Salary=9500},
            };

            return empList;
        }
    }
}

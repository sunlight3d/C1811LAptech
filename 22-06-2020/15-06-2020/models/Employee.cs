using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_06_2020.models
{
    public class Employee
    {
        public int Id { get; set; }
        //thu validate bang models
        [StringLength(500, MinimumLength = 6, ErrorMessage = "EmployeeName must >= 5 characters")]
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }

        [Range(typeof(DateTime), "1/1/1999", "1/1/3000",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DateOfBirth { get; set; }
        [RegularExpression(@"^0[\d]{5,}$", ErrorMessage = "Telephone must start with 0, at least 5 characters")]
        public string Telephone { get; set; }

        //bia du lieu, sau khi ok thi xoa di
        public static List<Employee> employees = new List<Employee>()
        {
            new Employee() { EmployeeName = "Hoang", Department = "IT", Gender = "Male"},
            new Employee() { EmployeeName = "TRung", Department = "Administration", Gender = "Female"},
            new Employee() { EmployeeName = "Kien", Department = "IT", Gender = "Male"},
        };
        public int DeptId { get; set; }
        public Department department;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinSelfHost
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime DateOfJoin { get; set; }
        public int Gender { get; set; }
        public int YearOfBirth { get; set; }

    }
}

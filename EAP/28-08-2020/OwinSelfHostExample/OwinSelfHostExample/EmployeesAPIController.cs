using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace OwinSelfHostExample
{
    public class EmployeesAPIController:ApiController
    {
        MyDBEntities myDBEntities;
        public IEnumerable<Object> Get() {            
            using (myDBEntities = new MyDBEntities()) {
                var query = from dbEmployees in myDBEntities.Employees
                            select new { dbEmployees.EmpName, dbEmployees.Email };

                var listOfEmployees = query.ToList();
                return listOfEmployees;
            }
        }
        public Object Get(int id)
        {
            using (myDBEntities = new MyDBEntities())
            {
                var employeeObj = myDBEntities
                    .Employees.Where(employee => employee.EmpID == id)
                    .FirstOrDefault();
                return new
                {
                    EmpName = employeeObj.EmpName,
                    Email = employeeObj.Email,
                    EmpId = employeeObj.EmpID
                };
            }
        }
        public void Post([FromBody]Employee newEmployee)
        {
            using (myDBEntities = new MyDBEntities())
            {
                myDBEntities.Employees.Add(newEmployee);
            }
        }



    }
}

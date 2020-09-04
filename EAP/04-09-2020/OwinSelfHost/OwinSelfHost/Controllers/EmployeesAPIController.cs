using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinSelfHost.Controllers
{

    public class EmployeesAPIController: ApiController
    {
        public IHttpActionResult Get() {
            using (HumanResourceManagementEntities dbContext = new HumanResourceManagementEntities()) {
                var query = from employee in dbContext.Employees
                            select new EmployeeModel { 
                                EmployeeId = employee.EmpID,
                                EmployeeName = employee.EmpName
                            };
                var listOfEmployees = query.ToList();
                return Ok(listOfEmployees);
            }                  
        }
        public IHttpActionResult Get(int id)
        {
            using (HumanResourceManagementEntities dbContext = new HumanResourceManagementEntities())
            {
                var query = from employee in dbContext.Employees
                            where employee.EmpID == id
                            select new EmployeeModel
                            {
                                EmployeeId = employee.EmpID,
                                EmployeeName = employee.EmpName
                            };
                var foundEmployee = query.FirstOrDefault();
                return Ok(foundEmployee);
            }
        }
        public IHttpActionResult Post([FromBody] EmployeeModel newEmployee)
        {
            using (HumanResourceManagementEntities dbContext = new HumanResourceManagementEntities())
            {
                var insertedEmployee = dbContext.Employees.Add(new Employee() { 
                    EmpName = newEmployee.EmployeeName,
                    DeptID = newEmployee.DepartmentId,
                    Email = newEmployee.Email,
                    Address = newEmployee.Address,
                    DOJ = newEmployee.DateOfJoin,
                    Gender = newEmployee.Gender > 0,
                    YearOfBirth = newEmployee.YearOfBirth,
                    
                });
                
                dbContext.SaveChanges();
                return Ok(insertedEmployee);
            }
        }
    }
}

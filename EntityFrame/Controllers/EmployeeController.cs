using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrame.Models;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace EntityFrame.Controllers
{
    [Produces("application/json")]
    [Route("api/employee")]
    public class EmployeeController : Controller
         {
    [HttpGet]
    public ActionResult Get()
         {
         using (var EmployeeContext = new EmployeeDbContext())
             {
             var EmployeeList = new List<EmployeeModel>();
             EmployeeList = EmployeeContext.TableEmployee.ToList();
             return Ok(EmployeeList);
             }
         }
    [HttpPost]
    public ActionResult Insert([FromBody]EmployeeModel EmployeeObject)
         {
         using (var EmployeeContext = new EmployeeDbContext())
            {
            var employeeModel = new EmployeeModel
                {
                Name = EmployeeObject.Name,
                Salary = EmployeeObject.Salary,
                Age = EmployeeObject.Age
                };
            EmployeeContext.TableEmployee.Add(employeeModel);
            EmployeeContext.SaveChanges();
            }
         return Ok("Employee Added");
         }
    [HttpPut]
    public ActionResult Put([FromBody]EmployeeModel EmployeeObject)
         {
         using (var EmployeeContext = new EmployeeDbContext())
            {
            EmployeeContext.TableEmployee.Update(EmployeeObject);
            EmployeeContext.SaveChanges();
            }
         return Ok("Employee Updated");
         }
    [HttpDelete]
    public ActionResult Delete([FromBody]EmployeeModel EmployeeObject)
         {
         using (var EmployeeContext = new EmployeeDbContext())
            {
            EmployeeContext.TableEmployee.Remove(EmployeeObject);
            EmployeeContext.SaveChanges();
            }
         return Ok("Employee Deleted");
         }
    }
}


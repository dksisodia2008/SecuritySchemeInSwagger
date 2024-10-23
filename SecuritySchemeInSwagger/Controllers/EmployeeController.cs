using Microsoft.AspNetCore.Mvc;
using SecuritySchemeInSwagger.Models;
using System.Net.Http;

namespace SecuritySchemeInSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpGet]
        [Route("getemployees")]
        public ActionResult<List<Employee>> Get()
        {
            if (!Request.Headers.ContainsKey("Authorization")) return Unauthorized();

            Console.WriteLine(Request.Headers["Authorization"]);

            var employees = GetEmployees();

            return employees;

        }

        private static List<Employee> GetEmployees()
        {
            var employees = new List<Employee>()
          {
              new Employee {Id= Guid.NewGuid(), FirstName= "Dheeraj", LastName="Kumar", MobileNumer ="9911414416"},
              new Employee {Id= Guid.NewGuid(), FirstName= "Raj", LastName="Singh", MobileNumer ="1234567890"},
              new Employee {Id= Guid.NewGuid(), FirstName= "Amit", LastName="Raj", MobileNumer ="1234567800"},
              new Employee {Id= Guid.NewGuid(), FirstName= "Raj", LastName="Kumar", MobileNumer ="1234567811"}
          };

            return employees;

        }

    }
}

using ContentNegotiationDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentNegotiationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //Get: api/employee
        [HttpGet]
        public ActionResult<List<Employee>> GetEmployees()
        {
            var listEmployee = new List<Employee>
            {
                new Employee(){ Id = 1001, Name = "Anurag", Age = 28, Gender = "Male", Department = "IT" },
                new Employee(){ Id = 1002, Name = "Pranaya", Age = 28, Gender = "Male", Department = "IT" },
            };

            return Ok(listEmployee);
        }
    }
}

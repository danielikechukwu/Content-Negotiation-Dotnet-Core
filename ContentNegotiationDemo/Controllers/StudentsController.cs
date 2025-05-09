using ContentNegotiationDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentNegotiationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        public static readonly List<Student> listStudents = new List<Student>
        {
            new Student(){ Id = 1, Name = "Anurag", Age = 28, Salary = 1000, Gender = "Male", Department = "IT" },
            new Student(){ Id = 2, Name = "Pranaya", Age = 28, Salary = 2000, Gender = "Male", Department = "IT" },
        };

        // Returns the list of all employees.
        // GET api/Employee
        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            return Ok(listStudents);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent(Student student)
        {

            if (student != null)
            {
                //Manually setting the sensative properties to avoid clients manipulations.
                student.Id = listStudents.Count + 1;
                student.Salary = 3000;
                listStudents.Add(student);
                return Ok(student);
            }

            return BadRequest();
        }


    }
}

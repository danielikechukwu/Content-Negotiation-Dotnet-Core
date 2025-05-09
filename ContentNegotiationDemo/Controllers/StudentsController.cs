using ContentNegotiationDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContentNegotiationDemo.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        public ActionResult<List<StudentDTO>> GetStudentDTOs()
        {
            var studentDTOs = listStudents.Select(x => new StudentDTO { 
                Name = x.Name,
                Age = x.Age,
                Gender = x.Gender,
                Department = x.Department
            }).ToList();

            return Ok(studentDTOs);
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

        [HttpPost]
        public ActionResult<StudentDTO> CreateStudent(StudentDTO studentDto)
        {
            if(studentDto != null)
            {
                var newStudent = new Student
                {
                    Id = listStudents.Count + 1,    // Set server-side
                    Salary = 3000,                   // Set server-side
                    Name = studentDto.Name,
                    Age = studentDto.Age,
                    Gender = studentDto.Gender,
                    Department = studentDto.Department
                };

                listStudents.Add(newStudent);

                return Ok(studentDto);
            }

            return BadRequest();
        }


    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_API_Controllers.Models;

namespace Student_API_Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // rajout de la liste d'étudiants
        // api contient une liste d'étudiants
        private static List<Student> _students = new List<Student>()
        {
            new Student { Id = 1, FirstName = "Paul", LastName = "Ochon", Birthdate = new DateTime(1950, 12, 1) },
            new Student { Id = 2, FirstName = "Daisy", LastName = "Drathey", Birthdate = new DateTime(1970, 12, 1) },
            new Student { Id = 3, FirstName = "Elie", LastName = "Coptaire", Birthdate = new DateTime(1980, 12, 1) }
        };

        // afficher liste des étudiants : getall
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetAll()
        {
            return _students;
        }

        // ajouter un étudiant : add
        [HttpPost]
        public ActionResult<Student> Add(Student student)
        {
            if(_students.Any(s => s.Id == student.Id))
            {
                return StatusCode(StatusCodes.Status409Conflict, "Student already exists");
            }

            _students.Add(student);
            return student;
        }

        // afficher un étudiant : getbyid
        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }
    }
}

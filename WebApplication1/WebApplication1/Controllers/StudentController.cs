using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(StudentStorage studentStorage) : Controller
    {
        [HttpGet]
        public List<StudentResponse> GetAll()
        {
            List<Student> students = studentStorage.GetAll();
            return students.Select(Mapiraj).ToList();
        }

        private static StudentResponse Mapiraj(Student s)
        {
            return new StudentResponse()
            {
                Id = s.Id,
                ImePrezime = $"{s.Ime} {s.Prezime}",
                BrojIndeksa = s.BrojIndeksa,
                DatumRodjenja = s.DatumRodjenja,
            };
        }
    }
}
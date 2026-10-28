using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController(AppDbContext db) : Controller
    {
        [HttpGet]
        public async Task<List<StudentResponse>> GetAll(CancellationToken ct)
        {
            List<Student> students = await db.Studenti.ToListAsync(ct);
            return students.Select(Mapiraj).ToList();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<StudentResponse>> GetById(int id, CancellationToken ct)
        {
            Student? student = await db.Studenti.FirstOrDefaultAsync(c => c.Id == id, ct);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(Mapiraj(student));
        }

        [HttpPost]
        public async Task<ActionResult<StudentResponse>> Dodaj(StudentDodajRequest request, CancellationToken ct)
        {
            Student student = new Student()
            {
                Ime = request.Ime,
                Prezime = request.Prezime,
                BrojIndeksa = request.BrojIndeksa,
                DatumRodjenja = request.DatumRodjenja,
                DatumKreiranja = DateTime.Now,
            };
            db.Studenti.Add(student);
            await db.SaveChangesAsync(ct);
            return Ok(Mapiraj(student));
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
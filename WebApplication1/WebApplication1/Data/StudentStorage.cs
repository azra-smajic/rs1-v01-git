using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class StudentStorage
    {
        private readonly List<Student> _students = [];

        private int _sljedeciId = 1;

        public StudentStorage()
        {
            Dodaj(new Student()
            {
                Ime = "Azra",
                Prezime = "Smajić",
                BrojIndeksa = "IB260001",
                DatumRodjenja = new DateOnly(2006, 3, 14)
            });

            Dodaj(new Student()
            {
                Ime = "Adil",
                Prezime = "Joldić",
                BrojIndeksa = "IB260002",
                DatumRodjenja = new DateOnly(2006, 3, 14)
            });
        }

        public Student Dodaj(Student student)
        {
            student.Id = _sljedeciId++;
            student.DatumKreiranja = DateTime.UtcNow;
            _students.Add(student);

            return student;
        }

        public List<Student> GetAll()
        {
            return _students;
        }
    }
}
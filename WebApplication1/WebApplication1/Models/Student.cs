namespace WebApplication1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public string BrojIndeksa { get; set; }
        public DateOnly? DatumRodjenja { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public int? SmjerId { get; set; }
        public Smjer? Smjer { get; set; }
    }
}
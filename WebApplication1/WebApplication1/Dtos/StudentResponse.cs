namespace WebApplication1.Dtos
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string ImePrezime { get; set; }
        public string BrojIndeksa { get; set; }
        public DateOnly? DatumRodjenja { get; set; }
        public string? Smjer { get; set; }
    }
}
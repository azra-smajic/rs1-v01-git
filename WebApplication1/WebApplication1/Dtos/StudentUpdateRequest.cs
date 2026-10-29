namespace WebApplication1.Dtos
{
    public class StudentUpdateRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojIndeksa { get; set; }
        public DateOnly? DatumRodjenja { get; set; }
        public int? SmjerId { get; set; }
    }
}
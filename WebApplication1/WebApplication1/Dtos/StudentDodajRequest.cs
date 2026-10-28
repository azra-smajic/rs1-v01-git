using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Dtos
{
    public class StudentDodajRequest
    {
        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public string BrojIndeksa { get; set; }

        public DateOnly? DatumRodjenja { get; set; }
    }
}
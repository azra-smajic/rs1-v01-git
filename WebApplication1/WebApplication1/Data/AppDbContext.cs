using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Studenti => Set<Student>();
        public DbSet<Smjer> Smjerovi => Set<Smjer>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasData(
                new Student()
                {
                    Id = 1,
                    Ime = "Ana",
                    Prezime = "Anić",
                    BrojIndeksa = "IB250001",
                    DatumRodjenja = new DateOnly(2005, 3, 14),
                    DatumKreiranja = new DateTime(2026, 10, 28)
                },
                new Student()
                {
                    Id = 2,
                    Ime = "Edin",
                    Prezime = "Edić",
                    BrojIndeksa = "IB250002",
                    DatumRodjenja = null,
                    DatumKreiranja = new DateTime(2026, 10, 28)
                }
                );
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Smjer)
                .WithMany(sm => sm.Studenti)
                .HasForeignKey(s => s.SmjerId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Smjer>().HasData(
                new Smjer
                {
                    Id = 1,
                    Naziv = "Softverski inzenjering"
                },
                new Smjer
                {
                    Id = 2,
                    Naziv = "Razvoj softvera"
                }
                );
        }
    }
}
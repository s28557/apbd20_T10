using T10.Models;
using Microsoft.EntityFrameworkCore;

namespace T10.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    {
    }

    // konstruktor
    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>
        {
            new Doctor() {
                IdDoctor = 1,
                FirstName = "Ania",
                LastName = "Woźniak",
                Email = "ania@mail.com"
            },
            new Doctor() {
                IdDoctor = 2,
                FirstName = "Meekhun",
                LastName = "Woźniak",
                Email = "meekhun@mail.com"
            },
            new Doctor() {
                IdDoctor = 3,
                FirstName = "Sofia",
                LastName = "Van Kannel",
                Email = "sofia@mail.com"
            }
        });
        
        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>
        {
            new Medicament()
            {
                IdMedicament = 1,
                Name = "Medicament 1",
                Description = "...",
                Type = "Pill"
            },
            new Medicament()
            {
                IdMedicament = 2,
                Name = "Medicament 2",
                Description = "...",
                Type = "Syrop"
            },
            new Medicament()
            {
                IdMedicament = 3,
                Name = "Medicament 3",
                Description = "...",
                Type = "Pill"
            }
        });
        
        modelBuilder.Entity<Patient>().HasData(new List<Patient>
        {
            new Patient()
            {
                IdPatient = 1,
                FirstName = "Zendaya",
                LastName = "Coleman",
                BirthDate = new DateTime(1995-06-10)
            },
            new Patient()
            {
                IdPatient = 2,
                FirstName = "Eleanor",
                LastName = "Shellstrop",
                BirthDate = new DateTime(1971-01-01)
            },
            new Patient()
            {
                IdPatient = 3,
                FirstName = "Maggie",
                LastName = "Smith",
                BirthDate = new DateTime(1960-03-02)
            }
        });
        
        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>
        {
            new Prescription()
            {
                IdPrescription = 1,
                Date = new DateTime(2023-04-02),
                DueDate = new DateTime(2023-04-05),
                IdPatient = 1,
                IdDoctor = 1
            },
            new Prescription()
            {
                IdPrescription = 2,
                Date = new DateTime(2020-03-12),
                DueDate = new DateTime(2020-04-12),
                IdPatient = 2,
                IdDoctor = 2
            },
            new Prescription()
            {
                IdPrescription = 3,
                Date = new DateTime(2024-10-10),
                DueDate = new DateTime(2024-11-11),
                IdPatient = 3,
                IdDoctor = 3
            }
        });
        
        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>
        {
            new PrescriptionMedicament()
            {
                IdMedicament = 1,
                IdPrescription = 1,
                Dose = 2,
                Details = "..."
            },
            new PrescriptionMedicament()
            {
                IdMedicament = 2,
                IdPrescription = 2,
                Dose = 1,
                Details = ".."
            },
            new PrescriptionMedicament()
            {
                IdMedicament = 3,
                IdPrescription = 3,
                Dose = 10,
                Details = "..."
            }
        });
    }
}
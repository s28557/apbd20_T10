using System.ComponentModel.DataAnnotations;
using T10.Models;

namespace T10.DTOs;

public class NewPrescriptionDTO
{
    [Required]
    public NewPatientDTO Patient { get; set; } = null!;
    
    [Required]
    public int IdDoctor { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }
    
    [Required]
    public ICollection<NewPrescriptionMedicamentDTO> Medicaments { get; set; } = null!;
}

public class NewPatientDTO
{
    [Required]
    public int IdPatient { get; set; }
    
    [Required]
    public string FirstName { get; set; } = null!;
    
    [Required]
    public string LastName { get; set; } = null!;
    
    [Required]
    public DateTime BirthDate { get; set; }
}

public class NewPrescriptionMedicamentDTO
{
    [Required]
    public int IdMedicament { get; set; }
    
    public int? Dose { get; set; }
    
    [Required]
    public string Description { get; set; }
}
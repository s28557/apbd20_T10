using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace T10.Models;

[Table("prescription")]
[PrimaryKey(nameof(IdPrescription))]
public class Prescription
{
    public int IdPrescription { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }

    public int IdPatient { get; set; }
    [ForeignKey(nameof(IdPatient))] 
    public Patient Patient { get; set; } = null!;

    public int IdDoctor { get; set; }
    [ForeignKey(nameof(IdDoctor))] 
    public Doctor Doctor { get; set; } = null!;

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}
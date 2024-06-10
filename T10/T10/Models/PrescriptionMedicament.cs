using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace T10.Models;

[Table("prescription_medicament")]
[PrimaryKey(nameof(IdMedicament),nameof(IdPrescription))]
public class PrescriptionMedicament
{
    public int IdMedicament { get; set; }
    [ForeignKey(nameof(IdMedicament))] 
    public Medicament Medicament { get; set; } = null!;

    public int IdPrescription { get; set; }
    [ForeignKey(nameof(IdPrescription))] 
    public Prescription Prescription { get; set; } = null!;

    public int? Dose { get; set; }
    public string Details { get; set; } = string.Empty;
}
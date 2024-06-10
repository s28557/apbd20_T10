using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace T10.Models;

[Table("medicament")]
[PrimaryKey(nameof(IdMedicament))]
public class Medicament
{
    public int IdMedicament { get; set; }
    [MaxLength(100)] 
    public string Name { get; set; } = string.Empty;
    [MaxLength(100)] 
    public string Description { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Type { get; set; }

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; } =
        new HashSet<PrescriptionMedicament>();
}
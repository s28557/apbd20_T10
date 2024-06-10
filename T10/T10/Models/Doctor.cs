using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace T10.Models;

[Table("doctor")]
[PrimaryKey(nameof(IdDoctor))]
public class Doctor
{
    public int IdDoctor { get; set; }
    [MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;

    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}
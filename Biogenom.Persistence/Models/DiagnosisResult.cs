using System.ComponentModel.DataAnnotations;

namespace Biogenom.Persistence.Models;

public class DiagnosisResult
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    public ICollection<DiagnosisValue> Values { get; set; } = new List<DiagnosisValue>();
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biogenom.Persistence.Models;

public class DiagnosisValue
{
    [Key]
    public int Id { get; set; }

    [Required]
    public double Value { get; set; }

    [Required]
    public int NutritionItemId { get; set; }

    [ForeignKey(nameof(NutritionItemId))]
    public NutritionItem NutritionItem { get; set; } = null!;

    [Required]
    public Guid DiagnosisResultId { get; set; }

    [ForeignKey(nameof(DiagnosisResultId))]
    public DiagnosisResult DiagnosisResult { get; set; } = null!;
}
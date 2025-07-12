using System.ComponentModel.DataAnnotations;

namespace Biogenom.Persistence.Models;

public class NutritionItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Unit { get; set; } = null!;
}
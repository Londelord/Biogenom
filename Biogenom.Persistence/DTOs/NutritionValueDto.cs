namespace Biogenom.Persistence.DTOs;

public class NutritionValueDto
{
    public string Name { get; set; } = null!;
    public double Value { get; set; }
    public string Unit { get; set; } = null!;
}
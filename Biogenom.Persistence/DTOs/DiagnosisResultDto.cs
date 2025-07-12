namespace Biogenom.Persistence.DTOs;

public class DiagnosisResultDto
{
    public DateTime CreatedAt { get; set; }
    public List<NutritionValueDto> Values { get; set; } = new();
}
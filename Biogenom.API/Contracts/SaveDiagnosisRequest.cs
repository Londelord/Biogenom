using Biogenom.Persistence.DTOs;

namespace Biogenom.API.Contracts;

public record SaveDiagnosisRequest(List<NutritionNameValue> Values);
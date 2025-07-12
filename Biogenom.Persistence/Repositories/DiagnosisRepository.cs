using Biogenom.Persistence.DataAccess;
using Biogenom.Persistence.DTOs;
using Biogenom.Persistence.Models;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace Biogenom.Persistence.Repositories;

public class DiagnosisRepository
{
    private readonly BiogenomDbContext _context;

    public DiagnosisRepository(BiogenomDbContext context)
    {
        _context = context;
    }

    public async Task<Result<DiagnosisResultDto>> GetLatestDiagnosisResult()
    {
        var result = await _context.DiagnosisResults
            .Include(r => r.Values)
            .ThenInclude(v => v.NutritionItem)
            .OrderByDescending(r => r.CreatedAt)
            .FirstOrDefaultAsync();
        
        if (result == null) return Result.Failure<DiagnosisResultDto>("Diagnosis not found");
         
        var output = new DiagnosisResultDto
        {
            CreatedAt = result.CreatedAt,
            Values = result.Values
                .Select(v => new NutritionValueDto
                {
                    Name = v.NutritionItem.Name,
                    Value = v.Value,
                    Unit = v.NutritionItem.Unit
                }).ToList()
        };
        
        return Result.Success(output);
    }

    public async Task<Result<string>> SaveDiagnosisResults(List<NutritionNameValue> values)
    {
        var last = await _context.DiagnosisResults
            .OrderByDescending(r => r.CreatedAt)
            .FirstOrDefaultAsync();

        if (last != null)
        {
            _context.DiagnosisResults.Remove(last);
            await _context.SaveChangesAsync();
        }

        var result = new DiagnosisResult
        {
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.UtcNow
        };

        foreach (var entry in values)
        {
            var item = await _context.NutritionItems
                .FirstOrDefaultAsync(n => n.Name == entry.Name.ToLower());

            if (item == null) return Result.Failure<string>($"Unknown nutrient: {entry.Name}");

            result.Values.Add(new DiagnosisValue
            {
                NutritionItemId = item.Id,
                Value = entry.Value
            });
        }

        _context.DiagnosisResults.Add(result);
        await _context.SaveChangesAsync();

        return Result.Success("Successfully saved");
    }
}
using Biogenom.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Biogenom.Persistence.DataAccess;

public class BiogenomDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public BiogenomDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<NutritionItem> NutritionItems => Set<NutritionItem>();
    public DbSet<DiagnosisResult> DiagnosisResults => Set<DiagnosisResult>();
    public DbSet<DiagnosisValue> DiagnosisValues => Set<DiagnosisValue>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Postgres"));
    }
}
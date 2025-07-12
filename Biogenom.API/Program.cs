using Biogenom.Persistence.DataAccess;
using Biogenom.Persistence.Initializers;
using Biogenom.Persistence.Repositories;

namespace Biogenom.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<BiogenomDbContext>();
        builder.Services.AddScoped<DiagnosisRepository>();
        
        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        { 
            var dbContext = scope.ServiceProvider.GetRequiredService<BiogenomDbContext>(); 
            dbContext.Database.EnsureCreated();
            BiogenomDbInitializer.SeedNutritionItems(dbContext);
        }
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        app.MapControllers();

        app.Run();
    }
}
using Biogenom.Persistence.DataAccess;
using Biogenom.Persistence.Models;

namespace Biogenom.Persistence.Initializers;

public static class BiogenomDbInitializer
{
    public static void SeedNutritionItems(BiogenomDbContext context)
    {
        if (context.NutritionItems.Any()) return;

        var nutrients = new[]
        {
            new NutritionItem { Name = "vitamin c", Unit = "mg" },
            new NutritionItem { Name = "vitamin d", Unit = "mcg" },
            new NutritionItem { Name = "zink", Unit = "mg" },
            new NutritionItem { Name = "iodine", Unit = "mcg" },
            new NutritionItem { Name = "water", Unit = "g" },
            new NutritionItem { Name = "vitamin b6", Unit = "mg" }
        };

        context.NutritionItems.AddRange(nutrients);
        context.SaveChanges();
    }
}
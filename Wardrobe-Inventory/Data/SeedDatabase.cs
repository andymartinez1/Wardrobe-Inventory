using Microsoft.EntityFrameworkCore;
using Wardrobe_Inventory.Models;

namespace Wardrobe_Inventory.Data;

public static class SeedDatabase
{
    public static async Task InitializeDataAsync(IServiceProvider serviceProvider)
    {
        using var context = new WardrobeDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<WardrobeDbContext>>()
        );

        // Ensure database exists
        await context.Database.EnsureCreatedAsync();

        // If table already contains data, skip seeding
        if (await context.Items.AnyAsync())
            return;

        var clothingItems = new List<ClothingItem>
        {
            new()
            {
                Name = "T-Shirt",
                Brand = "Adidas",
                Category = ClothingCategory.Shirts,
                Color = "Blue",
                ShirtSize = ShirtSize.M,
            },
            new()
            {
                Name = "Jeans",
                Brand = "Nike",
                Category = ClothingCategory.Jeans,
                Color = "Black",
                JeansInseam = 30,
                JeansWaist = 32,
            },
            new()
            {
                Name = "Jacket",
                Brand = "Under Armour",
                Category = ClothingCategory.Jackets,
                Color = "Green",
                ShirtSize = ShirtSize.L,
            },
            new()
            {
                Name = "Hoodie",
                Brand = "Champion",
                Category = ClothingCategory.Jackets,
                Color = "Gray",
                ShirtSize = ShirtSize.L,
            },
            new()
            {
                Name = "Polo",
                Brand = "Ralph Lauren",
                Category = ClothingCategory.Shirts,
                Color = "Navy",
                ShirtSize = ShirtSize.L,
            },
            new()
            {
                Name = "Dress Shirt",
                Brand = "Calvin Klein",
                Category = ClothingCategory.Shirts,
                Color = "White",
                ShirtSize = ShirtSize.M,
            },
            new()
            {
                Name = "Slim Jeans",
                Brand = "Levi's",
                Category = ClothingCategory.Jeans,
                Color = "Dark Blue",
                JeansInseam = 32,
                JeansWaist = 31,
            },
            new()
            {
                Name = "Air Force",
                Brand = "Nike",
                Category = ClothingCategory.Sneakers,
                Color = "White",
                ShoeSize = 11.5m,
            },
        };

        context.AddRange(clothingItems);

        await context.SaveChangesAsync();
    }
}

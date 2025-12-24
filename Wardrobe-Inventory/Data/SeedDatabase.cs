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
                Name = "Cotton Crewneck T-Shirt - Ocean Stripe",
                Brand = "Everlane",
                Category = ClothingCategory.Shirts,
                Color = "Ocean Stripe",
                ShirtSize = ShirtSize.M,
            },
            new()
            {
                Name = "Dark Wash Straight-Leg Jeans - Selvedge",
                Brand = "Nudie",
                Category = ClothingCategory.Jeans,
                Color = "Dark Indigo",
                JeansInseam = 32,
                JeansWaist = 33,
            },
            new()
            {
                Name = "Insulated Parka Jacket - Alpine Green",
                Brand = "Arc'teryx",
                Category = ClothingCategory.Jackets,
                Color = "Alpine Green",
                ShirtSize = ShirtSize.L,
            },
            new()
            {
                Name = "Fleece Lined Hoodie - Heather Gray",
                Brand = "Patagonia",
                Category = ClothingCategory.Jackets,
                Color = "Heather Gray",
                ShirtSize = ShirtSize.L,
            },
            new()
            {
                Name = "Pima Polo Shirt - Deep Navy",
                Brand = "Ralph Lauren",
                Category = ClothingCategory.Shirts,
                Color = "Deep Navy",
                ShirtSize = ShirtSize.M,
            },
            new()
            {
                Name = "Slim Fit Dress Shirt - White Pinstripe",
                Brand = "Calvin Klein",
                Category = ClothingCategory.Shirts,
                Color = "White Pinstripe",
                ShirtSize = ShirtSize.M,
            },
            new()
            {
                Name = "Rinse Slim Jeans - Dark Rinse",
                Brand = "Levi's",
                Category = ClothingCategory.Jeans,
                Color = "Dark Rinse",
                JeansInseam = 30,
                JeansWaist = 31,
            },
            new()
            {
                Name = "Retro White Air Force - Leather",
                Brand = "Nike",
                Category = ClothingCategory.Sneakers,
                Color = "White",
                ShoeSize = 11.5m,
            },
            new()
            {
                Name = "Performance Road Runners - Black Reflective",
                Brand = "Asics",
                Category = ClothingCategory.Sneakers,
                Color = "Black/Reflective",
                ShoeSize = 10.0m,
            },
            new()
            {
                Name = "Court Classic Tennis Sneakers - White Gum",
                Brand = "Adidas",
                Category = ClothingCategory.Sneakers,
                Color = "White/Gum",
                ShoeSize = 9.0m,
            },
            new()
            {
                Name = "Oxford Lightweight Shirt - Powder Blue",
                Brand = "Banana Republic",
                Category = ClothingCategory.Shirts,
                Color = "Powder Blue",
                ShirtSize = ShirtSize.S,
            },
            new()
            {
                Name = "Vintage Band Tee - Distressed Red",
                Brand = "H&M",
                Category = ClothingCategory.Shirts,
                Color = "Distressed Red",
                ShirtSize = ShirtSize.M,
            },
            new()
            {
                Name = "Classic Chino Pants - Khaki",
                Brand = "Dockers",
                Category = ClothingCategory.Jeans,
                Color = "Khaki",
                JeansInseam = 32,
                JeansWaist = 34,
            },
            new()
            {
                Name = "Cargo Utility Jeans - Olive Drab",
                Brand = "Carhartt",
                Category = ClothingCategory.Jeans,
                Color = "Olive Drab",
                JeansInseam = 32,
                JeansWaist = 33,
            },
            new()
            {
                Name = "Packable Windbreaker - Electric Blue",
                Brand = "The North Face",
                Category = ClothingCategory.Jackets,
                Color = "Electric Blue",
                ShirtSize = ShirtSize.M,
            },
            new()
            {
                Name = "Wool Blend Peacoat - Charcoal",
                Brand = "Zara",
                Category = ClothingCategory.Jackets,
                Color = "Charcoal",
                ShirtSize = ShirtSize.L,
            },
            new()
            {
                Name = "Breton Striped Henley - Navy/White",
                Brand = "Uniqlo",
                Category = ClothingCategory.Shirts,
                Color = "Navy/White",
                ShirtSize = ShirtSize.S,
            },
            new()
            {
                Name = "Stretch Slim Jeans - Light Stone",
                Brand = "Gap",
                Category = ClothingCategory.Jeans,
                Color = "Light Stone",
                JeansInseam = 30,
                JeansWaist = 30,
            },
            new()
            {
                Name = "Slip-On Canvas Sneakers - Black",
                Brand = "Vans",
                Category = ClothingCategory.Sneakers,
                Color = "Black",
                ShoeSize = 9.5m,
            },
            new()
            {
                Name = "Trail Runner Pro GTX - Orange/Black",
                Brand = "Salomon",
                Category = ClothingCategory.Sneakers,
                Color = "Orange/Black",
                ShoeSize = 11.0m,
            },
            new()
            {
                Name = "Lightweight Linen Shirt - Sand",
                Brand = "J.Crew",
                Category = ClothingCategory.Shirts,
                Color = "Sand",
                ShirtSize = ShirtSize.L,
            },
            new()
            {
                Name = "Relaxed Vintage Jeans - Indigo Fade",
                Brand = "Levi's",
                Category = ClothingCategory.Jeans,
                Color = "Indigo Fade",
                JeansInseam = 34,
                JeansWaist = 34,
            },
            new()
            {
                Name = "High-Top Skate Sneakers - Black/White",
                Brand = "Converse",
                Category = ClothingCategory.Sneakers,
                Color = "Black/White",
                ShoeSize = 10.5m,
            },
            new()
            {
                Name = "Softshell Technical Jacket - Stone",
                Brand = "Columbia",
                Category = ClothingCategory.Jackets,
                Color = "Stone",
                ShirtSize = ShirtSize.M,
            },
            new()
            {
                Name = "Everyday Trainer Sneakers - Grey Mesh",
                Brand = "New Balance",
                Category = ClothingCategory.Sneakers,
                Color = "Grey",
                ShoeSize = 10.0m,
            },
        };

        context.AddRange(clothingItems);

        await context.SaveChangesAsync();
    }
}

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

        // Ensure database exists (optional)
        await context.Database.EnsureCreatedAsync();

        // If any of these tables already contain data, skip seeding
        if (
            await context.Items.AnyAsync()
            || await context.Brands.AnyAsync()
            || await context.Categories.AnyAsync()
        )
            return;

        {
            var brands = new List<Brand>
            {
                new() { Name = "Nike" },
                new() { Name = "Adidas" },
                new() { Name = "Under Armour" },
            };

            var clothes = new List<ClothingItem>
            {
                new()
                {
                    Brand = brands[0],
                    Category = new ClothingCategory { ClothingType = ClothingType.Shirt },
                    Name = "Classic Polo T-shirt",
                    IsFavorite = true,
                    Color = "Red",
                    PurchasedDate = DateTime.Now,
                },
                new()
                {
                    Brand = brands[1],
                    Category = new ClothingCategory { ClothingType = ClothingType.Shoes },
                    Name = "Tennis Shoes",
                    IsFavorite = false,
                    Color = "Black",
                    PurchasedDate = DateTime.Now.AddHours(-1),
                },
                new()
                {
                    Brand = brands[2],
                    Category = new ClothingCategory { ClothingType = ClothingType.Jacket },
                    Name = "Performance Jacket",
                    IsFavorite = false,
                    Color = "Blue",
                    PurchasedDate = DateTime.Now.AddDays(-10),
                },
                new()
                {
                    Brand = brands[0],
                    Category = new ClothingCategory { ClothingType = ClothingType.Pants },
                    Name = "Slim Jeans",
                    IsFavorite = true,
                    Color = "Dark Blue",
                    PurchasedDate = DateTime.Now.AddMonths(-2),
                },
                new()
                {
                    Brand = brands[1],
                    Category = new ClothingCategory { ClothingType = ClothingType.Pants },
                    Name = "Casual Chinos",
                    IsFavorite = false,
                    Color = "Khaki",
                    PurchasedDate = DateTime.Now.AddMonths(-1),
                },
                new()
                {
                    Brand = brands[2],
                    Category = new ClothingCategory { ClothingType = ClothingType.Shirt },
                    Name = "Graphic Tee",
                    IsFavorite = false,
                    Color = "White",
                    PurchasedDate = DateTime.Now.AddDays(-30),
                },
                new()
                {
                    Brand = brands[0],
                    Category = new ClothingCategory { ClothingType = ClothingType.Shoes },
                    Name = "Running Sneakers",
                    IsFavorite = true,
                    Color = "White",
                    PurchasedDate = DateTime.Now.AddDays(-100),
                },
                new()
                {
                    Brand = brands[1],
                    Category = new ClothingCategory { ClothingType = ClothingType.Jacket },
                    Name = "Windbreaker",
                    IsFavorite = false,
                    Color = "Green",
                    PurchasedDate = DateTime.Now.AddMonths(-6),
                },
                new()
                {
                    Brand = brands[2],
                    Category = new ClothingCategory { ClothingType = ClothingType.Jacket },
                    Name = "Cozy Hoodie",
                    IsFavorite = true,
                    Color = "Grey",
                    PurchasedDate = DateTime.Now.AddYears(-1),
                },
                new()
                {
                    Brand = brands[1],
                    Category = new ClothingCategory { ClothingType = ClothingType.Pants },
                    Name = "Dress Pants",
                    IsFavorite = false,
                    Color = "Black",
                    PurchasedDate = DateTime.Now.AddDays(-12),
                },
            };

            context.Brands.AddRange(brands);
            context.Items.AddRange(clothes);

            await context.SaveChangesAsync();
        }
    }
}

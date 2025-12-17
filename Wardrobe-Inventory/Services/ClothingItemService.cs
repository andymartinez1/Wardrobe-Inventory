using Microsoft.EntityFrameworkCore;
using Wardrobe_Inventory.Data;
using Wardrobe_Inventory.Models;

namespace Wardrobe_Inventory.Services;

public class ClothingItemService : IClothingItemService
{
    private readonly WardrobeDbContext _wardrobeDbContext;

    public ClothingItemService(WardrobeDbContext wardrobeDbContext)
    {
        _wardrobeDbContext = wardrobeDbContext;
    }

    public async Task AddClothingItemAsync(ClothingItem item)
    {
        await _wardrobeDbContext.Items.AddAsync(item);

        await _wardrobeDbContext.SaveChangesAsync();
    }

    public async Task<List<ClothingItem>> GetAllClothingItemsAsync()
    {
        var items = _wardrobeDbContext
            .Items.Include(i => i.Category)
            .Include(i => i.Brand)
            .ToListAsync();

        return await items;
    }

    public async Task<ClothingItem> GetClothingItemAsync(int id)
    {
        return await _wardrobeDbContext.Items.FindAsync(id);
    }

    public async Task UpdateClothingItemAsync(ClothingItem item)
    {
        _wardrobeDbContext.Items.Update(item);

        await _wardrobeDbContext.SaveChangesAsync();
    }

    public async Task DeleteClothingItemAsync(int id)
    {
        var item = await GetClothingItemAsync(id);

        _wardrobeDbContext.Items.Remove(item);

        await _wardrobeDbContext.SaveChangesAsync();
    }

    public async Task<List<ClothingItem>> SearchClothes(string searchFilter)
    {
        var clothingItems = await GetAllClothingItemsAsync();

        return clothingItems
            .Where(i => i.Name.Contains(searchFilter, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}

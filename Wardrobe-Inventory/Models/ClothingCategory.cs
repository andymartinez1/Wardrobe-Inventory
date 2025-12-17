using System.ComponentModel.DataAnnotations;

namespace Wardrobe_Inventory.Models;

public class ClothingCategory
{
    [Key]
    public int Id { get; set; }

    public ClothingType ClothingType { get; set; }

    public List<ClothingItem>? Items { get; set; }
}

public enum ClothingType
{
    Hat,
    Shirt,
    Jacket,
    Shorts,
    Pants,
    Shoes,
    Boots,
}

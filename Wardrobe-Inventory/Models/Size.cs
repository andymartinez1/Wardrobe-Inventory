using System.ComponentModel.DataAnnotations;

namespace Wardrobe_Inventory.Models;

public class Size
{
    [Key]
    public int Id { get; set; }

    public ClothingCategory Category { get; private set; } = null!;

    // Only one of these will be populated based on Category
    public double? ShoeSize { get; set; }

    public string? ShirtSize { get; set; }

    public string? Pants { get; set; }
}

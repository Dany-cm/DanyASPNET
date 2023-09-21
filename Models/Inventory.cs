using System.ComponentModel.DataAnnotations;

namespace DanyTGC.Models;

public class Inventory
{
    public int Id { get; set; }

    [Required] 
    public string? Edition { get; set; }
    public string? Name { get; set; }
    public string? Rarity { get; set; }

    [Range(0.01, 9999.99)] public decimal Stock { get; set; }
}
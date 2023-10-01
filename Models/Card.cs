using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanyTCG.Models;

public class Card : ICanValidate
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(Edition))]
    public int EditionId { get; set; }
    public virtual Edition Edition { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    [ForeignKey(nameof(Rarity))]
    public int RarityId { get; set; }

    public virtual Rarity Rarity { get; set; }

    public Dictionary<string, string> ModelErrors { get; } = new();
    public bool Validate()
    {
        if (string.IsNullOrEmpty(Name))
        {
            ModelErrors.Add(nameof(Name), "Name is required");
        }

        if (RarityId == default)
        {
            ModelErrors.Add(nameof(RarityId), "Rarity is required");
        }
        
        if (EditionId == default)
        {
            ModelErrors.Add(nameof(EditionId), "Edition is required");
        }

        return !ModelErrors.Any();
    }
}
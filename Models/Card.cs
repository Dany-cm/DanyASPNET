using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanyTCG.Models;

public class Card
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
}
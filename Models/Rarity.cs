using System.ComponentModel.DataAnnotations;

namespace DanyTCG.Models
{
    public class Rarity
    {
        [Key]
        public int RarityId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

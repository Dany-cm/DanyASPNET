using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanyTCG.Models
{
    public class Rarity : ICanValidate
    {
        [Key]
        public int RarityId { get; set; }

        [Required]
        public string Name { get; set; }

        [NotMapped] public Dictionary<string, string> ModelErrors { get; } = new();

        public bool Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                ModelErrors.Add(nameof(Name), "Name is required");
            }

            return !ModelErrors.Any();
        }
    }
}

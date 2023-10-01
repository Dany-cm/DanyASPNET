using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanyTCG.Models
{
    public class Edition : ICanValidate
    {
        [Key]
        public int EditionId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Card> Cards { get; set; }

        [NotMapped] public Dictionary<string, string> ModelErrors { get; } = new();
        public bool Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                ModelErrors.Add(nameof(Name), "Must have a valid name.");
            }

            return !ModelErrors.Any();
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DanyTCG.Models
{
    public class Edition
    {
        [Key]
        public int EditionId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}

using DanyTCG.Models;
using DanyTCG.Schemas;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DanyTCG.Pages.Cards
{
    public class CreateModel : PageModel
    {
        private readonly EditionSchema _editionSchema;

        public SelectList EditionsDropdown => new(Editions, nameof(Edition.EditionId), nameof(Edition.Name));

        public IList<Edition> Editions { get; }

        [Required]
        public string CardName { get; set; }

        [Required]
        public int EditionId { get; set; }

        public CreateModel(EditionSchema editionSchema)
        {
            _editionSchema = editionSchema;
            Editions = _editionSchema.ListEditions();
        }

        public void OnGet()
        {
        }
    }
}

using DanyTCG.Models;
using DanyTCG.Schemas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanyTCG.Pages.Cards
{
    public class IndexModel : PageModel
    {
        private readonly CardSchema _cardSchema;

        public IndexModel(CardSchema cardSchema)
        {
            _cardSchema = cardSchema;
        }

        public IList<Card> Cards { get; private set; }

        public IActionResult OnGet()
        {
            Cards = _cardSchema.List();
            return Page();
        }
    }
}

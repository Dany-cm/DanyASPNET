using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DanyTCG.Schemas;
using DanyTCG.Models;

namespace DanyTCG.Pages
{
    public class InventoryListModel : PageModel
    {
        private readonly CardSchema _service;
        [BindProperty]
        public Card NewInventory { get; set; } = default!;
        public IList<Card> InventoryList { get; set; } = default!;

        public InventoryListModel(CardSchema service)
        {
            _service = service;
        }

        public void OnGet()
        {
            InventoryList = _service.List();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Create(NewInventory);

            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            _service.Delete(id);

            return RedirectToAction("Get");
        }
    }
}

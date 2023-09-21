using DanyTGC.Services;
using DanyTGC.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanyTGC.Pages
{
    public class InventoryListModel : PageModel
    {
        private readonly InventoryService _service;
        [BindProperty]
        public Inventory NewInventory { get; set; } = default!;
        public IList<Inventory> InventoryList { get;set; } = default!;

        public InventoryListModel(InventoryService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            InventoryList = _service.GetInventories();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.AddInventory(NewInventory);

            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id)
        {
            _service.DeleteInventory(id);

            return RedirectToAction("Get");
        }
    }
}

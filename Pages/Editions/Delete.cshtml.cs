using DanyTCG.Models;
using DanyTCG.Schemas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanyTCG.Pages.Editions;

public class Delete : PageModel
{
    private readonly EditionSchema _editionSchema;

    public Delete(EditionSchema editionSchema)
    {
        _editionSchema = editionSchema;
    }
    
    public IActionResult OnGet(int editionId)
    {
        var edition = _editionSchema.Find(editionId);
        if (edition == null)
        {
            return NotFound();
        }

        Edition = edition;
        return Page();
    }
    
    public IActionResult OnPost(int editionId)
    {
        var edition = _editionSchema.Find(editionId);
        if (edition == null)
        {
            return NotFound();
        }

        _editionSchema.Delete(edition);
        return RedirectToPage("Index");
    }

    public Edition Edition { get; set; } = new();
}
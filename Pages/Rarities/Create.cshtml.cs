using DanyTCG.Exceptions;
using DanyTCG.Models;
using DanyTCG.Pages.Rarities.Forms;
using DanyTCG.Schemas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanyTCG.Pages.Rarities;

public class Create : PageModel
{
    private readonly RaritySchema _raritySchema;
    [BindProperty] public CreateForm Form { get; set; }

    public Create(RaritySchema raritySchema)
    {
        _raritySchema = raritySchema;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var rarity = new Rarity
        {
            Name = Form.RarityName,
        };

        try
        {
            _raritySchema.Create(rarity);
        }
        catch (InvalidSchemaException ex)
        {
            foreach (var (key, error) in rarity.ModelErrors)
            {
                ModelState.AddModelError(key, error);
            }

            if (ex.DisplayToUser)
            {
                ModelState.AddModelError(ex.FieldName, ex.Message);
            }

            return Page();
        }

        return RedirectToPage("Index");
    }
}
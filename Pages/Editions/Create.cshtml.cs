using System.ComponentModel.DataAnnotations;
using DanyTCG.Exceptions;
using DanyTCG.Models;
using DanyTCG.Pages.Editions.Forms;
using DanyTCG.Schemas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanyTCG.Pages.Editions;

public class Create : PageModel
{
    private readonly EditionSchema _editionSchema;

    [BindProperty] public CreateForm Form { get; set; }

    public Create(EditionSchema editionSchema)
    {
        _editionSchema = editionSchema;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var edition = new Edition
        {
            Name = Form.Edition,
        };

        try
        {
            _editionSchema.Create(edition);
        }
        catch (InvalidSchemaException ex)
        {
            foreach (var (key, error) in edition.ModelErrors)
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
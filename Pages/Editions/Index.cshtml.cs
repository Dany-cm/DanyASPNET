using DanyTCG.Models;
using DanyTCG.Schemas;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanyTCG.Pages.Editions;

public class Index : PageModel
{
    private readonly EditionSchema _editionSchema;

    public Index(EditionSchema editionSchema)
    {
        _editionSchema = editionSchema;
        Editions = _editionSchema.ListAll();
    }

    public IList<Edition> Editions { get; set; }
}
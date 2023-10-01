using DanyTCG.Models;
using DanyTCG.Schemas;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DanyTCG.Pages.Rarities;

public class Index : PageModel
{
    private readonly RaritySchema _raritySchema;

    public Index(RaritySchema raritySchema)
    {
        _raritySchema = raritySchema;
        Rarities = _raritySchema.ListAll();
    }

    public IList<Rarity> Rarities { get; set; }
}
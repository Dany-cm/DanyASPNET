using DanyTCG.Exceptions;
using DanyTCG.Models;
using DanyTCG.Pages.Cards.Forms;
using DanyTCG.Schemas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DanyTCG.Pages.Cards;

public class CreateModel : PageModel
{
    private readonly CardSchema _cardSchema;
    private readonly EditionSchema _editionSchema;
    private readonly RaritySchema _raritySchema;

    public CreateModel(
        CardSchema cardSchema,
        EditionSchema editionSchema,
        RaritySchema raritySchema)
    {
        _cardSchema = cardSchema;
        _editionSchema = editionSchema;
        _raritySchema = raritySchema;
        Editions = _editionSchema.ListAll();
        Rarities = _raritySchema.ListAll();
    }

    [BindProperty] public CreateForm Form { get; set; }

    public SelectList EditionsDropdown => new(Editions, nameof(Edition.EditionId), nameof(Edition.Name));
    public SelectList RaritiesDropdown => new(Rarities, nameof(Rarity.RarityId), nameof(Rarity.Name));

    public IList<Edition> Editions { get; }

    public IList<Rarity> Rarities { get; set; }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }
        
        var edition = _editionSchema.Find(Form.EditionId);
        if (edition == null)
        {
            ModelState.AddModelError(nameof(Form.EditionId), "Edition is invalid.");
            return Page();
        }
        
        var rarity = _raritySchema.Find(Form.RarityId);
        if (rarity == null)
        {
            ModelState.AddModelError(nameof(Form.RarityId), "Rarity is invalid.");
            return Page();
        }

        var card = new Card
        {
            Name = Form.CardName,
            Edition = edition,
            Rarity = rarity,
            CardNumber = Form.CardNumber,
        };

        try
        {
            _cardSchema.Update(card);
        }
        catch (InvalidSchemaException ex)
        {
            foreach (var (key, error) in card.ModelErrors)
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
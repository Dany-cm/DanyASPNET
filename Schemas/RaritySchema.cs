using DanyTCG.Data;
using DanyTCG.Exceptions;
using DanyTCG.Models;

namespace DanyTCG.Schemas;

public class RaritySchema
{
    private readonly TcgContext _context;

    public RaritySchema(TcgContext context)
    {
        _context = context;
    }

    public IList<Rarity> ListAll()
    {
        return _context
            .Rarities
            .ToList();
    }

    public void Create(Rarity rarity)
    {
        if (!rarity.Validate())
        {
            throw new InvalidSchemaException("Model validation failed.");
        }

        if (_context.Rarities.Any(row => row.Name == rarity.Name))
        {
            throw new InvalidSchemaException("Rarity already exists.", nameof(Rarity.Name), true);
        }

        _context.Rarities.Add(rarity);
        _context.SaveChanges();
    }

    public Rarity? Find(int rarityId)
    {
        return _context.Rarities.Find(rarityId);
    }
}
using DanyTCG.Data;
using DanyTCG.Exceptions;
using DanyTCG.Models;

namespace DanyTCG.Schemas;

public class CardSchema
{
    private readonly TcgContext _context;

    public CardSchema(TcgContext context)
    {
        _context = context;
    }

    public IList<Card> List(int start = 0, int take = 25)
    {
        return _context
            .Cards
            .Where(card => card.Id > start)
            .OrderBy(card => card.Id)
            .Take(take)
            .ToList();
    }

    public void Create(Card card)
    {
        if (!card.Validate())
        {
            throw new InvalidSchemaException("Model validation failed.");
        }
        
        _context.Cards.Add(card);
        _context.SaveChanges();
    }

    public void Delete(int cardId)
    {
        var card = _context.Cards.Find(cardId);
        if (card == null)
        {
            return;
        }

        _context.Cards.Remove(card);
        _context.SaveChanges();
    }

    public void Update(Card card)
    {
        _context.Cards.Update(card);
        _context.SaveChanges();
    }
}
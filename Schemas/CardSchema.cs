using DanyTCG.Data;
using DanyTCG.Models;

namespace DanyTCG.Schemas;

public class CardSchema
{
    private readonly TcgContext _context;

    public CardSchema(TcgContext context)
    {
        _context = context;
    }

    public IList<Card> GetCards(int start = 0, int take = 25)
    {
        return _context
            .Cards
            .Where(card => card.Id > start)
            .OrderBy(card => card.Id)
            .Take(take)
            .ToList();
    }

    public void StoreCard(Card card)
    {
        _context.Cards.Add(card);
        _context.SaveChanges();
    }

    public void DeleteCard(int cardId)
    {
        var card = _context.Cards.Find(cardId);
        if (card == null)
        {
            return;
        }

        _context.Cards.Remove(card);
        _context.SaveChanges();
    }

    public void SaveCard(Card card)
    {
        _context.Cards.Update(card);
        _context.SaveChanges();
    }
}
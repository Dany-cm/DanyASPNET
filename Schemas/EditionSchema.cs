using DanyTCG.Data;
using DanyTCG.Exceptions;
using DanyTCG.Models;
using DanyTCG.Pages.Editions.Forms;

namespace DanyTCG.Schemas
{
    public class EditionSchema
    {
        private readonly TcgContext _context;

        public EditionSchema(TcgContext context)
        {
            _context = context;
        }

        public IList<Edition> ListAll()
        {
            return _context
                .Editions
                .ToList();
        }

        public void Create(Edition edition)
        {
            if (!edition.Validate())
            {
                throw new InvalidSchemaException("Data validation failed.");
            }

            if (_context.Editions.Any(row => row.Name == edition.Name))
            {
                throw new InvalidSchemaException("Edition already exists.", nameof(CreateForm.Edition), true);
            }
            _context.Editions.Add(edition);
            _context.SaveChanges();
        }

        public Edition? Find(int editionId)
        {
            return _context.Editions.Find(editionId);
        }

        public void Delete(Edition edition)
        {
            _context.Cards.RemoveRange(edition.Cards);
            _context.Remove(edition);
            _context.SaveChanges();
        }
    }
}

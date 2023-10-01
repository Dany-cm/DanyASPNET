using DanyTCG.Data;
using DanyTCG.Models;

namespace DanyTCG.Schemas
{
    public class EditionSchema
    {
        private readonly TcgContext _context;

        public EditionSchema(TcgContext context)
        {
            _context = context;
        }

        public IList<Edition> ListEditions()
        {
            return _context
                .Editions
                .ToList();
        }
    }
}

using DanyTGC.Data;
using DanyTGC.Models;

namespace DanyTGC.Services
{
    public class InventoryService
    {
        private readonly InventoryContext _context;

        public InventoryService(InventoryContext context) 
        {
            _context = context;
        }
        
        public IList<Inventory> GetInventories()
        {
            return _context.Inventories != null ? _context.Inventories.ToList() : new List<Inventory>();
        }

        public void AddInventory(Inventory inventory)
        {
            if (_context.Inventories != null)
            {
                _context.Inventories.Add(inventory);
                _context.SaveChanges();
            }
        }

        public void DeleteInventory(int id)
        {
            var inventory = _context.Inventories?.Find(id);
            if (inventory != null)
            {
                _context.Inventories?.Remove(inventory);
                _context.SaveChanges();
            }
        } 
    }
}

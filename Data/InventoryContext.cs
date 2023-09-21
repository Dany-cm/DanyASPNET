using Microsoft.EntityFrameworkCore;

namespace DanyTGC.Data;

public class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options)
    {
    }
    public DbSet<DanyTGC.Models.Inventory>? Inventories { get; set; }
}
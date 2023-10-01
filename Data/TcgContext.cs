using DanyTCG.Models;
using Microsoft.EntityFrameworkCore;

namespace DanyTCG.Data;

public class TcgContext : DbContext
{
    public TcgContext(DbContextOptions<TcgContext> options)
        : base(options)
    {
    }

    public DbSet<Edition> Editions { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Rarity> Rarities { get; set; }
}
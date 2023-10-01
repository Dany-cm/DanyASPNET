using DanyTCG.Models;
using Microsoft.EntityFrameworkCore;

namespace DanyTCG.Data;

public class TcgContext : DbContext
{
    public TcgContext(DbContextOptions<TcgContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }

    public DbSet<Edition> Editions { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Rarity> Rarities { get; set; }
}
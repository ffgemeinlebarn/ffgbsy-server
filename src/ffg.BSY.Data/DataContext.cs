using Microsoft.EntityFrameworkCore;

namespace ffg.BSY.Data;

public class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Aufnehmer> Aufnehmer { get; set; } = null!;
    public DbSet<Bestellposition> Bestellpositionen { get; set; } = null!;
    public DbSet<BestellpositionEigenschaft> BestellpositionEigenschaften { get; set; } = null!;
    public DbSet<BestellpositionStorno> BestellpositionStornos { get; set; } = null!;
    public DbSet<Bestellung> Bestellungen { get; set; } = null!;
    public DbSet<BonAusdruck> BonAusdrucke { get; set; } = null!;
    public DbSet<Drucker> Drucker { get; set; } = null!;
    public DbSet<Eigenschaft> Eigenschaften { get; set; } = null!;
    public DbSet<Grundprodukt> Grundprodukte { get; set; } = null!;
    public DbSet<Produktbereich> Produktbereiche { get; set; } = null!;
    public DbSet<Produkt> Produkte { get; set; } = null!;
    public DbSet<Produkteigenschaft> Produkteigenschaften { get; set; } = null!;
    public DbSet<Produkteinteilung> Produkteinteilungen { get; set; } = null!;
    public DbSet<Produktkategorie> Produktkategorien { get; set; } = null!;
    public DbSet<ProduktkategorieEigenschaft> ProduktkategorieEigenschaften { get; set; } = null!;
    public DbSet<Tisch> Tische { get; set; } = null!;
    public DbSet<Tischkategorie> Tischkategorien { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");
    }
}

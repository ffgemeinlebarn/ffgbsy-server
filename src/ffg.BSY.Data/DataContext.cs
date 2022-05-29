using Microsoft.EntityFrameworkCore;

namespace ffg.BSY.Data;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aufnehmer> Aufnehmers { get; set; } = null!;
    public virtual DbSet<Bestellposition> Bestellpositionen { get; set; } = null!;
    public virtual DbSet<BestellpositionEigenschaft> BestellpositionenEigenschaften { get; set; } = null!;
    public virtual DbSet<BestellpositionStorno> BestellpositionStornos { get; set; } = null!;
    public virtual DbSet<Bestellung> Bestellungens { get; set; } = null!;
    public virtual DbSet<BonAusdruck> BonAusdrucke { get; set; } = null!;
    public virtual DbSet<Drucker> Drucker { get; set; } = null!;
    public virtual DbSet<Eigenschaft> Eigenschaften { get; set; } = null!;
    public virtual DbSet<Grundprodukt> Grundprodukte { get; set; } = null!;
    public virtual DbSet<Produktbereich> Produktbereiche { get; set; } = null!;
    public virtual DbSet<Produkt> Produkte { get; set; } = null!;
    public virtual DbSet<ProduktEigenschaft> ProduktEigenschaften { get; set; } = null!;
    public virtual DbSet<Produkteinteilung> Produkteinteilungen { get; set; } = null!;
    public virtual DbSet<Produktkategorie> Produktkategorien { get; set; } = null!;
    public virtual DbSet<ProduktkategorieEigenschaft> ProduktkategorieEigenschaften { get; set; } = null!;
    public virtual DbSet<Tisch> Tische { get; set; } = null!;
    public virtual DbSet<Tischkategorie> Tischkategorien { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Aufnehmer>(entity =>
        {
            entity.ToTable("aufnehmer");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Aktiv).HasColumnName("aktiv");

            entity.Property(e => e.Nachname)
                .HasMaxLength(50)
                .HasColumnName("nachname");

            entity.Property(e => e.Vorname)
                .HasMaxLength(50)
                .HasColumnName("vorname");

            entity.Property(e => e.ZoomLevel)
                .HasColumnType("int(11)")
                .HasColumnName("zoom_level")
                .HasDefaultValueSql("'1'");
        });

        modelBuilder.Entity<Bestellposition>(entity =>
        {
            entity.ToTable("bestellpositionen");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.BestellungenId, "fk_bestellungen_id");

            entity.HasIndex(e => e.ProdukteId, "fk_produkte_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Anzahl)
                .HasColumnType("int(11)")
                .HasColumnName("anzahl");

            entity.Property(e => e.BestellungenId)
                .HasColumnType("int(11)")
                .HasColumnName("bestellungen_id");

            entity.Property(e => e.Notiz)
                .HasColumnType("text")
                .HasColumnName("notiz");

            entity.Property(e => e.ProdukteId)
                .HasColumnType("int(11)")
                .HasColumnName("produkte_id");
        });

        modelBuilder.Entity<BestellpositionEigenschaft>(entity =>
        {
            entity.HasKey(e => new { e.BestellpositionenId, e.EigenschaftenId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("bestellpositionen_eigenschaften");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.BestellpositionenId)
                .HasColumnType("int(11)")
                .HasColumnName("bestellpositionen_id");

            entity.Property(e => e.EigenschaftenId)
                .HasColumnType("int(11)")
                .HasColumnName("eigenschaften_id");

            entity.Property(e => e.Aktiv).HasColumnName("aktiv");

            entity.Property(e => e.InProduktEnthalten).HasColumnName("in_produkt_enthalten");
        });

        modelBuilder.Entity<BestellpositionStorno>(entity =>
        {
            entity.ToTable("bestellpositionen_storno");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Anzahl)
                .HasColumnType("int(11)")
                .HasColumnName("anzahl")
                .HasDefaultValueSql("'1'");

            entity.Property(e => e.BestellpositionenId)
                .HasColumnType("int(11)")
                .HasColumnName("bestellpositionen_id");

            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime")
                .HasColumnName("timestamp")
                .HasDefaultValueSql("current_timestamp()");
        });

        modelBuilder.Entity<Bestellung>(entity =>
        {
            entity.ToTable("bestellungen");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.AufnehmerId, "fk_aufnehmer_id");

            entity.HasIndex(e => e.TischeId, "fk_tische_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.AufnehmerId)
                .HasColumnType("int(11)")
                .HasColumnName("aufnehmer_id");

            entity.Property(e => e.TimestampBeendet)
                .HasColumnType("datetime")
                .HasColumnName("timestamp_beendet")
                .HasDefaultValueSql("current_timestamp()");

            entity.Property(e => e.TimestampBegonnen)
                .HasColumnType("datetime")
                .HasColumnName("timestamp_begonnen");

            entity.Property(e => e.TimestampGedruckt)
                .HasColumnType("datetime")
                .HasColumnName("timestamp_gedruckt");

            entity.Property(e => e.TischeId)
                .HasColumnType("int(11)")
                .HasColumnName("tische_id");

            entity.HasOne(d => d.Aufnehmer)
                .WithMany(p => p.Bestellungens)
                .HasForeignKey(d => d.AufnehmerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_aufnehmer_id");

            entity.HasOne(d => d.Tische)
                .WithMany(p => p.Bestellungens)
                .HasForeignKey(d => d.TischeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tische_id");
        });

        modelBuilder.Entity<BonAusdruck>(entity =>
        {
            entity.ToTable("bons_druck");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.BestellungenId)
                .HasColumnType("int(11)")
                .HasColumnName("bestellungen_id");

            entity.Property(e => e.Datum).HasColumnName("datum");

            entity.Property(e => e.DruckerId)
                .HasColumnType("int(11)")
                .HasColumnName("drucker_id");

            entity.Property(e => e.Laufnummer)
                .HasColumnType("int(11)")
                .HasColumnName("laufnummer");

            entity.Property(e => e.Result).HasColumnName("result");

            entity.Property(e => e.ResultMessage)
                .HasMaxLength(300)
                .HasColumnName("result_message");

            entity.Property(e => e.StornoId)
                .HasColumnType("int(11)")
                .HasColumnName("storno_id");

            entity.Property(e => e.TimestampGedruckt)
                .HasColumnType("datetime")
                .HasColumnName("timestamp_gedruckt")
                .HasDefaultValueSql("current_timestamp()");
        });

        modelBuilder.Entity<Drucker>(entity =>
        {
            entity.ToTable("drucker");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Ip)
                .HasMaxLength(30)
                .HasColumnName("ip");

            entity.Property(e => e.Mac)
                .HasMaxLength(50)
                .HasColumnName("mac");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");

            entity.Property(e => e.Port)
                .HasColumnType("int(11)")
                .HasColumnName("port");
        });

        modelBuilder.Entity<Eigenschaft>(entity =>
        {
            entity.ToTable("eigenschaften");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");

            entity.Property(e => e.Preis)
                .HasPrecision(19, 2)
                .HasColumnName("preis");

            entity.Property(e => e.Sortierindex)
                .HasColumnType("int(11)")
                .HasColumnName("sortierindex");
        });

        modelBuilder.Entity<Grundprodukt>(entity =>
        {
            entity.ToTable("grundprodukte");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Bestand)
                .HasColumnType("int(11)")
                .HasColumnName("bestand");

            entity.Property(e => e.Einheit)
                .HasMaxLength(30)
                .HasColumnName("einheit");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Produktbereich>(entity =>
        {
            entity.ToTable("produktbereiche");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.DruckerIdLevel0, "fk_drucker_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.DruckerIdLevel0)
                .HasColumnType("int(11)")
                .HasColumnName("drucker_id_level_0");

            entity.Property(e => e.Farbe)
                .HasMaxLength(30)
                .HasColumnName("farbe");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Produkt>(entity =>
        {
            entity.ToTable("produkte");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.DruckerIdLevel2, "fk_drucker_id_level_2");

            entity.HasIndex(e => e.GrundprodukteId, "fk_grundprodukte_id");

            entity.HasIndex(e => e.ProduktkategorienId, "fk_kategorien_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Aktiv)
                .IsRequired()
                .HasColumnName("aktiv")
                .HasDefaultValueSql("'1'");

            entity.Property(e => e.DruckerIdLevel2)
                .HasColumnType("int(11)")
                .HasColumnName("drucker_id_level_2");

            entity.Property(e => e.Einheit)
                .HasMaxLength(50)
                .HasColumnName("einheit");

            entity.Property(e => e.Einzahl).HasColumnName("einzahl");

            entity.Property(e => e.FormalName)
                .HasMaxLength(50)
                .HasColumnName("formal_name");

            entity.Property(e => e.GrundprodukteId)
                .HasColumnType("int(11)")
                .HasColumnName("grundprodukte_id");

            entity.Property(e => e.GrundprodukteMultiplikator)
                .HasColumnType("int(11)")
                .HasColumnName("grundprodukte_multiplikator");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");

            entity.Property(e => e.Preis)
                .HasPrecision(19, 2)
                .HasColumnName("preis");

            entity.Property(e => e.ProdukteinteilungenId)
                .HasColumnType("int(11)")
                .HasColumnName("produkteinteilungen_id");

            entity.Property(e => e.ProduktkategorienId)
                .HasColumnType("int(11)")
                .HasColumnName("produktkategorien_id");

            entity.Property(e => e.Sortierindex)
                .HasColumnType("int(11)")
                .HasColumnName("sortierindex");
        });

        modelBuilder.Entity<ProduktEigenschaft>(entity =>
        {
            entity.HasKey(e => new { e.ProdukteId, e.EigenschaftenId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("produkte_eigenschaften");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.ProdukteId)
                .HasColumnType("int(11)")
                .HasColumnName("produkte_id");

            entity.Property(e => e.EigenschaftenId)
                .HasColumnType("int(11)")
                .HasColumnName("eigenschaften_id");

            entity.Property(e => e.InProduktEnthalten).HasColumnName("in_produkt_enthalten");
        });

        modelBuilder.Entity<Produkteinteilung>(entity =>
        {
            entity.ToTable("produkteinteilungen");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.Property(e => e.Sortierindex)
                .HasColumnType("int(11)")
                .HasColumnName("sortierindex");
        });

        modelBuilder.Entity<Produktkategorie>(entity =>
        {
            entity.ToTable("produktkategorien");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.ProduktbereicheId, "fk_bereiche_id");

            entity.HasIndex(e => e.DruckerIdLevel1, "fk_drucker_id_level_1");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Color)
                .HasMaxLength(30)
                .HasColumnName("color");

            entity.Property(e => e.DruckerIdLevel1)
                .HasColumnType("int(11)")
                .HasColumnName("drucker_id_level_1");

            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .HasColumnName("name");

            entity.Property(e => e.ProduktbereicheId)
                .HasColumnType("int(11)")
                .HasColumnName("produktbereiche_id");

            entity.Property(e => e.Sortierindex)
                .HasColumnType("int(11)")
                .HasColumnName("sortierindex");
        });

        modelBuilder.Entity<ProduktkategorieEigenschaft>(entity =>
        {
            entity.HasKey(e => new { e.ProduktkategorienId, e.EigenschaftenId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("produktkategorien_eigenschaften");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.ProduktkategorienId)
                .HasColumnType("int(11)")
                .ValueGeneratedOnAdd()
                .HasColumnName("produktkategorien_id");

            entity.Property(e => e.EigenschaftenId)
                .HasColumnType("int(11)")
                .HasColumnName("eigenschaften_id");

            entity.Property(e => e.InProduktEnthalten).HasColumnName("in_produkt_enthalten");
        });

        modelBuilder.Entity<Tisch>(entity =>
        {
            entity.ToTable("tische");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Nummer)
                .HasColumnType("int(11)")
                .HasColumnName("nummer");

            entity.Property(e => e.Reihe)
                .HasMaxLength(30)
                .HasColumnName("reihe");

            entity.Property(e => e.Sortierindex)
                .HasColumnType("int(11)")
                .HasColumnName("sortierindex");

            entity.Property(e => e.TischkategorienId)
                .HasColumnType("int(11)")
                .HasColumnName("tischkategorien_id");
        });

        modelBuilder.Entity<Tischkategorie>(entity =>
        {
            entity.ToTable("tischkategorien");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.Property(e => e.Sortierindex)
                .HasColumnType("int(11)")
                .HasColumnName("sortierindex");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

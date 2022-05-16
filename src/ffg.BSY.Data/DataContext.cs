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
    public virtual DbSet<AufnehmerSession> AufnehmerSessions { get; set; } = null!;
    public virtual DbSet<Bestellpositionen> Bestellpositionens { get; set; } = null!;
    public virtual DbSet<BestellpositionenEigenschaften> BestellpositionenEigenschaftens { get; set; } = null!;
    public virtual DbSet<BestellpositionenStorno> BestellpositionenStornos { get; set; } = null!;
    public virtual DbSet<Bestellungen> Bestellungens { get; set; } = null!;
    public virtual DbSet<BonsDruck> BonsDrucks { get; set; } = null!;
    public virtual DbSet<Drucker> Druckers { get; set; } = null!;
    public virtual DbSet<Eigenschaften> Eigenschaftens { get; set; } = null!;
    public virtual DbSet<Geraete> Geraetes { get; set; } = null!;
    public virtual DbSet<Grundprodukte> Grundproduktes { get; set; } = null!;
    public virtual DbSet<Produktbereiche> Produktbereiches { get; set; } = null!;
    public virtual DbSet<Produkte> Produktes { get; set; } = null!;
    public virtual DbSet<ProdukteEigenschaften> ProdukteEigenschaftens { get; set; } = null!;
    public virtual DbSet<Produkteinteilungen> Produkteinteilungens { get; set; } = null!;
    public virtual DbSet<Produktkategorien> Produktkategoriens { get; set; } = null!;
    public virtual DbSet<ProduktkategorienEigenschaften> ProduktkategorienEigenschaftens { get; set; } = null!;
    public virtual DbSet<Tische> Tisches { get; set; } = null!;
    public virtual DbSet<Tischkategorien> Tischkategoriens { get; set; } = null!;

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

        modelBuilder.Entity<AufnehmerSession>(entity =>
        {
            entity.ToTable("aufnehmer_sessions");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.AufnehmerId)
                .HasColumnType("int(11)")
                .HasColumnName("aufnehmer_id");

            entity.Property(e => e.Ende)
                .HasColumnType("datetime")
                .HasColumnName("ende");

            entity.Property(e => e.GeraeteId)
                .HasColumnType("int(11)")
                .HasColumnName("geraete_id");

            entity.Property(e => e.Hash)
                .HasMaxLength(400)
                .HasColumnName("hash");

            entity.Property(e => e.Start)
                .HasColumnType("datetime")
                .HasColumnName("start");
        });

        modelBuilder.Entity<Bestellpositionen>(entity =>
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

        modelBuilder.Entity<BestellpositionenEigenschaften>(entity =>
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

        modelBuilder.Entity<BestellpositionenStorno>(entity =>
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

        modelBuilder.Entity<Bestellungen>(entity =>
        {
            entity.ToTable("bestellungen");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.HasIndex(e => e.AufnehmerId, "fk_aufnehmer_id");

            entity.HasIndex(e => e.GeraeteId, "fk_geraete_id");

            entity.HasIndex(e => e.TischeId, "fk_tische_id");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.AufnehmerId)
                .HasColumnType("int(11)")
                .HasColumnName("aufnehmer_id");

            entity.Property(e => e.GeraeteId)
                .HasColumnType("int(11)")
                .HasColumnName("geraete_id");

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

            entity.HasOne(d => d.Geraete)
                .WithMany(p => p.Bestellungens)
                .HasForeignKey(d => d.GeraeteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_geraete_id");

            entity.HasOne(d => d.Tische)
                .WithMany(p => p.Bestellungens)
                .HasForeignKey(d => d.TischeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tische_id");
        });

        modelBuilder.Entity<BonsDruck>(entity =>
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

        modelBuilder.Entity<Eigenschaften>(entity =>
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

        modelBuilder.Entity<Geraete>(entity =>
        {
            entity.ToTable("geraete");

            entity.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");

            entity.Property(e => e.Hersteller)
                .HasMaxLength(50)
                .HasColumnName("hersteller");

            entity.Property(e => e.Ip)
                .HasMaxLength(50)
                .HasColumnName("ip");

            entity.Property(e => e.Mac)
                .HasMaxLength(100)
                .HasColumnName("mac");

            entity.Property(e => e.Type)
                .HasMaxLength(80)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Grundprodukte>(entity =>
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

        modelBuilder.Entity<Produktbereiche>(entity =>
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

        modelBuilder.Entity<Produkte>(entity =>
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

        modelBuilder.Entity<ProdukteEigenschaften>(entity =>
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

        modelBuilder.Entity<Produkteinteilungen>(entity =>
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

        modelBuilder.Entity<Produktkategorien>(entity =>
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

        modelBuilder.Entity<ProduktkategorienEigenschaften>(entity =>
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

        modelBuilder.Entity<Tische>(entity =>
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

        modelBuilder.Entity<Tischkategorien>(entity =>
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

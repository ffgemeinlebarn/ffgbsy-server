using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffg.BSY.Data;

public class Produkt
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(50)]
    public string? FormalName { get; set; }

    public float? Einzahl { get; set; }

    public string? Einheit { get; set; }

    [Range(0, 100)]
    public decimal Preis { get; set; }

    public bool Aktiv { get; set; } = false;

    public int Sortierindex { get; set; } = 100;

    public int GrundprodukteMultiplikator { get; set; } = 1;

    [ForeignKey(nameof(Produkteinteilung))]
    public int? ProdukteinteilungId { get; set; }

    [ForeignKey(nameof(Produkteinteilung))]
    public int? GrundproduktId { get; set; }

    [ForeignKey(nameof(Produkteinteilung))]
    public int ProduktkategorieId { get; set; }

    [ForeignKey(nameof(Drucker))]
    public int? DruckerIdLevel2 { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffg.BSY.Data;

public class Produktkategorie : AuditBase
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(9)]
    public string Color { get; set; } = "#aaaaaa";

    [ForeignKey(nameof(Produktbereich))]
    public int ProduktbereichId { get; set; }

    public int Sortierindex { get; set; } = 100;

    [ForeignKey(nameof(Drucker))]
    public int? DruckerIdLevel1 { get; set; }
}

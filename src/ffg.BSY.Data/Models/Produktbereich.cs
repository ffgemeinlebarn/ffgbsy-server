using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffg.BSY.Data;

public class Produktbereich : AuditBase
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(9)]
    public string? Farbe { get; set; }

    [ForeignKey(nameof(Drucker))]
    public int? DruckerIdLevel0 { get; set; }
    public Drucker? Drucker { get; set; }
}

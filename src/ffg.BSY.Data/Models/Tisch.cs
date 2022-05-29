using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffg.BSY.Data;

public class Tisch
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Reihe { get; set; } = null!;

    public int? Nummer { get; set; }

    public int Sortierindex { get; set; } = 100;

    [ForeignKey(nameof(Drucker))]
    public int TischkategorienId { get; set; }
}

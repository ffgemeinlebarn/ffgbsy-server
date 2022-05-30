using System.ComponentModel.DataAnnotations;

namespace ffg.BSY.Data;

public class Eigenschaft : AuditBase
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [Range(0, 50)]
    public decimal Preis { get; set; }

    public int Sortierindex { get; set; } = 100;
}

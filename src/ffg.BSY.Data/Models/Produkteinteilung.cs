using System.ComponentModel.DataAnnotations;

namespace ffg.BSY.Data;

public class Produkteinteilung : AuditBase
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public int? Sortierindex { get; set; } = 100;
}

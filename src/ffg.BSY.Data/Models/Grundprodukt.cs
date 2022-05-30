using System.ComponentModel.DataAnnotations;

namespace ffg.BSY.Data;

public class Grundprodukt : AuditBase
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    public int? Bestand { get; set; }

    public string? Einheit { get; set; }
}

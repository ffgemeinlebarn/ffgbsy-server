using System.ComponentModel.DataAnnotations;

namespace ffg.BSY.Data;

public class Aufnehmer : AuditBase
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Vorname { get; set; }

    [StringLength(50)]
    public string? Nachname { get; set; }

    public bool Aktiv { get; set; } = true;

    [Range(1, 3)]
    public int ZoomLevel { get; set; } = 1;

    public ICollection<Bestellung> Bestellungen { get; set; } = new HashSet<Bestellung>();
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffg.BSY.Data;

public class BonAusdruck : AuditBase
{
    [Key]
    public int Id { get; set; }

    public DateOnly Datum { get; set; }

    public int Laufnummer { get; set; }

    public DateTime? TimestampGedruckt { get; set; } = null;

    public bool? Result { get; set; }
    public string? ResultMessage { get; set; }

    // [ForeignKey(nameof(Storno))]
    // public int? StornoId { get; set; }

    [ForeignKey(nameof(Bestellung))]
    public int BestellungenId { get; set; }
    public Bestellung? Bestellung { get; set; }

    [ForeignKey(nameof(Drucker))]
    public int DruckerId { get; set; }
    public Drucker? Drucker { get; set; }
}

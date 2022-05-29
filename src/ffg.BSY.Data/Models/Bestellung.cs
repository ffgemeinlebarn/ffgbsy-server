using System.ComponentModel.DataAnnotations;

namespace ffg.BSY.Data;

public partial class Bestellung
{
    public int Id { get; set; }
    public int TischeId { get; set; }
    public DateTime TimestampBegonnen { get; set; }
    public DateTime TimestampBeendet { get; set; }
    public DateTime? TimestampGedruckt { get; set; }
    public int AufnehmerId { get; set; }

    [MaxLength(15)]
    public string? GeraetIpAddress { get; set; }

    [MaxLength(100)]
    public string? GeraetName { get; set; }

    public virtual Aufnehmer Aufnehmer { get; set; } = null!;
    public virtual Tisch Tische { get; set; } = null!;
}

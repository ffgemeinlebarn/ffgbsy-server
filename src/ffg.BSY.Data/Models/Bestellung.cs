using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffg.BSY.Data;

public class Bestellung : AuditBase
{
    [Key]
    public int Id { get; set; }

    public DateTime TimestampBegonnen { get; set; }
    public DateTime TimestampBeendet { get; set; }
    public DateTime? TimestampGedruckt { get; set; }

    [MaxLength(15)]
    public string? GeraetIpAddress { get; set; }

    [MaxLength(100)]
    public string? GeraetName { get; set; }

    #region Relations

    [ForeignKey(nameof(Aufnehmer))]
    public int AufnehmerId { get; set; }
    public Aufnehmer Aufnehmer { get; set; } = null!;

    [ForeignKey(nameof(Tisch))]
    public int TischId { get; set; }
    public Tisch Tisch { get; set; } = null!;

    #endregion
}

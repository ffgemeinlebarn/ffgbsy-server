using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffg.BSY.Data;

public class Bestellposition : AuditBase
{
    [Key]
    public int Id { get; set; }

    [Range(0, 1000)]
    public int Anzahl { get; set; }

    public string? Notiz { get; set; }

    [ForeignKey(nameof(Produkt))]
    public int ProduktId { get; set; }
    public Produkt? Produkt { get; set; }

    [ForeignKey(nameof(Bestellung))]
    public int BestellungId { get; set; }
    public Bestellung? Bestellung { get; set; }
}

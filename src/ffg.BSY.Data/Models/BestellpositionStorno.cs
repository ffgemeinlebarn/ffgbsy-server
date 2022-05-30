using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ffg.BSY.Data;

public class BestellpositionStorno : AuditBase
{
    [Key]
    public int Id { get; set; }

    public int Anzahl { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime Timestamp { get; set; }

    [ForeignKey(nameof(Bestellposition))]
    public int Bestellposition { get; set; }
}

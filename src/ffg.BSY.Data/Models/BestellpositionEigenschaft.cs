using System.ComponentModel.DataAnnotations.Schema;

namespace ffg.BSY.Data;

public class BestellpositionEigenschaft : AuditBase
{
    public bool InProduktEnthalten { get; set; } = true;
    public bool Aktiv { get; set; } = true;

    [ForeignKey(nameof(Bestellposition))]
    public int BestellpositionId { get; set; }

    [ForeignKey(nameof(Eigenschaft))]
    public int EigenschaftId { get; set; }
}

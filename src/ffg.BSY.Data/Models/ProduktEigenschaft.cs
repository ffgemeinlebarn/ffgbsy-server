using System.ComponentModel.DataAnnotations.Schema;

namespace ffg.BSY.Data;

public class ProduktEigenschaft : AuditBase
{
    [ForeignKey(nameof(Produkt))]
    public int ProduktId { get; set; }

    [ForeignKey(nameof(Eigenschaft))]
    public int EigenschaftId { get; set; }

    public bool InProduktEnthalten { get; set; } = false;
}

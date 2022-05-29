using System.ComponentModel.DataAnnotations.Schema;

namespace ffg.BSY.Data;

public class ProduktkategorieEigenschaft
{
    [ForeignKey(nameof(Produktkategorie))]
    public int ProduktkategorieId { get; set; }

    [ForeignKey(nameof(Eigenschaft))]
    public int EigenschaftId { get; set; }

    public bool InProduktEnthalten { get; set; } = false;
}

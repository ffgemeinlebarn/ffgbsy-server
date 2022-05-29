using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class ProduktkategorieEigenschaft
    {
        public int ProduktkategorienId { get; set; }
        public int EigenschaftenId { get; set; }
        public bool InProduktEnthalten { get; set; }
    }
}

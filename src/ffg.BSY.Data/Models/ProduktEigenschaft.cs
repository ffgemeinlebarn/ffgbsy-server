using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class ProduktEigenschaft
    {
        public int ProdukteId { get; set; }
        public int EigenschaftenId { get; set; }
        public bool InProduktEnthalten { get; set; }
    }
}

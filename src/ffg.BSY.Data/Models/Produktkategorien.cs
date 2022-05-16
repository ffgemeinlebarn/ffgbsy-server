using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Produktkategorien
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Color { get; set; } = null!;
        public int ProduktbereicheId { get; set; }
        public int? DruckerIdLevel1 { get; set; }
        public int? Sortierindex { get; set; }
    }
}

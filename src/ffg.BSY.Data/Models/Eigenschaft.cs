using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Eigenschaft
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Preis { get; set; }
        public int Sortierindex { get; set; }
    }
}

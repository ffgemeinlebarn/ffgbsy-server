using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Produkteinteilung
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Sortierindex { get; set; }
    }
}

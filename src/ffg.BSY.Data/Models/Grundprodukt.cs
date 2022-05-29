using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Grundprodukt
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Bestand { get; set; }
        public string? Einheit { get; set; }
    }
}

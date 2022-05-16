using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Produktbereiche
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Farbe { get; set; }
        public int? DruckerIdLevel0 { get; set; }
    }
}

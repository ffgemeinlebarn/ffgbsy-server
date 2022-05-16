using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class Produkte
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? FormalName { get; set; }
        public float? Einzahl { get; set; }
        public string? Einheit { get; set; }
        public decimal Preis { get; set; }
        public int ProduktkategorienId { get; set; }
        public int? DruckerIdLevel2 { get; set; }
        public bool? Aktiv { get; set; }
        public int? Sortierindex { get; set; }
        public int? ProdukteinteilungenId { get; set; }
        public int? GrundprodukteId { get; set; }
        public int? GrundprodukteMultiplikator { get; set; }
    }
}

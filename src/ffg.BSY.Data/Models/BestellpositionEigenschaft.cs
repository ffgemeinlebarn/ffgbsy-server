﻿using System;
using System.Collections.Generic;

namespace ffg.BSY.Data
{
    public partial class BestellpositionEigenschaft
    {
        public int BestellpositionenId { get; set; }
        public int EigenschaftenId { get; set; }
        public bool? InProduktEnthalten { get; set; }
        public bool? Aktiv { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;

namespace PEPRN231_SU24TrialTest_StudentFullname_FE.Models
{
    public partial class Style
    {
        public Style()
        {
            WatercolorsPaintings = new HashSet<WatercolorsPainting>();
        }

        public string StyleId { get; set; } = null!;
        public string StyleName { get; set; } = null!;
        public string StyleDescription { get; set; } = null!;
        public string? OriginalCountry { get; set; }

        public virtual ICollection<WatercolorsPainting> WatercolorsPaintings { get; set; }
    }
}

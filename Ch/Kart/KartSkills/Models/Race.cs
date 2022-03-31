using System;
using System.Collections.Generic;

#nullable disable

namespace KartSkills.Models
{
    public partial class Race
    {
        public int IdRace { get; set; }
        public string RaceName { get; set; }
        public string Sity { get; set; }
        public string IdCountry { get; set; }
        public short YearHeld { get; set; }
    }
}

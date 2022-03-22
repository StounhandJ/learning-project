using System;
using System.Collections.Generic;

#nullable disable

namespace KartSkills.Models
{
    public partial class Sponsorship
    {
        public int IdSponsorship { get; set; }
        public string SponsorName { get; set; }
        public decimal? Amount { get; set; }
    }
}

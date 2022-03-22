using System;
using System.Collections.Generic;

#nullable disable

namespace KartSkills.Models
{
    public partial class Position
    {
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public string PositionDescription { get; set; }
        public string PayPeriod { get; set; }
        public decimal PayRate { get; set; }

    }
}

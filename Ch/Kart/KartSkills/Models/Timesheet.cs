using System;
using System.Collections.Generic;

#nullable disable

namespace KartSkills.Models
{
    public partial class Timesheet
    {
        public int Timesheetid { get; set; }
        public int StaffId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public decimal? PayAmount { get; set; }

    }
}

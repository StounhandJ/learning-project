using System;
using System.Collections.Generic;

#nullable disable

namespace KartSkills.Models
{
    public partial class staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int PositionId { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
    }
}

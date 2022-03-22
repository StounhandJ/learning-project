using System;
using System.Collections.Generic;

#nullable disable

namespace KartSkills.Models
{
    public partial class Event
    {
        public int IdEvent { get; set; }
        public string EventName { get; set; }
        public string IdEventType { get; set; }
        public int IdRace { get; set; }
        public DateTime StartDateTime { get; set; }
        public decimal Cost { get; set; }
        public short MaxParticipants { get; set; }
    }
}

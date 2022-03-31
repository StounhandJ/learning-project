using System;
using System.Collections.Generic;
using System.Data;

#nullable disable

namespace KartSkills.Models
{
    public class Racer
    {
        public int IdRacer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FIO { get=>string.Format("{0} {1}", this.LastName, this.FirstName); }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IdCountry { get; set; }
        public string Photo { get; set; }
        
        public Racer(DataRow data)
        {
            IdRacer = (int)data["ID_Racer"];
            FirstName = data["First_Name"] as string;
            LastName = data["Last_Name"] as string;
            Gender = data["Gender"] as string;
            DateOfBirth = (DateTime)data["DateOfBirth"];
            IdCountry = data["ID_Country"] as string;
            Photo = data["Photo"] as string;
        }

        public Racer()
        {
        }
    }
}

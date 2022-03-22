using System.Data;

namespace KartSkills.Models
{
    public class Volunteer
    {
        public string IdVolunteer { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdCountry { get; set; }
        public string GenderId { get; set; }

        public Volunteer(DataRow data)
        {
            IdVolunteer = data["ID_Volunteer"] as string;
            FirstName = data["First_Name"] as string;
            LastName = data["Last_Name"] as string;
            IdCountry = data["ID_Country"] as string;
            GenderId = data["Gender_ID"] as string;
        }

        public Volunteer()
        {
        }
    }
}
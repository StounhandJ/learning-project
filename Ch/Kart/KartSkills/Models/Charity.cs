using System.Data;

#nullable disable

namespace KartSkills.Models
{
    public class Charity
    {
        public int IdСharity { get; set; }
        public string CharityName { get; set; }
        public string CharityDescription { get; set; }
        public string CharityLogo { get; set; }
        
        public Charity(DataRow data)
        {
            IdСharity = (int)data["ID_Сharity"];
            CharityName = data["Charity_Name"] as string;
            CharityDescription = data["Charity_Description"] as string;
            CharityLogo = data["Charity_Logo"] as string;
        }

        public Charity()
        {
        }
    }
}

using System.Data;

#nullable disable

namespace KartSkills.Models
{
    public class Country
    {
        public string IdCountry { get; set; }
        public string CountryName { get; set; }
        public string CountryFlag { get; set; }
        
        public Country(DataRow data)
        {
            IdCountry = data["Id_Country"] as string;
            CountryName = data["Country_Name"] as string;
            CountryFlag = data["Country_Flag"] as string;
        }

        public Country()
        {
        }
        
        public new static bool Equals(object objA, object objB)
        {
            if (objA.GetType() == objB.GetType() && objB.GetType() == typeof(Country))
                return ((Country)objA).IdCountry == ((Country)objB).IdCountry;
            return false;
        }

        public override bool Equals(object? objA)
        {
            if (objA == null)
                return false;
            return Country.Equals(this, objA);
        }
    }
}

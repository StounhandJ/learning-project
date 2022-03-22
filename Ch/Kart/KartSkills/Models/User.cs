using System.Data;

#nullable disable

namespace KartSkills.Models
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdRole { get; set; }

        public User(DataRow data)
        {
            Email = data["Email"] as string;
            Password = data["Password"] as string;
            FirstName = data["First_Name"] as string;
            LastName = data["Last_Name"] as string;
            IdRole = data["ID_Role"] as string;
        }

        public User()
        {
        }
    }
}
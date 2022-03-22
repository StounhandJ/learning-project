
using System.Data;

namespace KartSkills.Models
{
    public class Role
    {
        public string IdRole { get; set; }
        public string RoleName { get; set; }
        
        public Role(DataRow data)
        {
            IdRole = data["ID_Role"] as string;
            RoleName = data["Role_Name"] as string;
        }

        public Role()
        {
        }
    }
}

using System;
using System.Collections.Generic;

namespace InventoryOfEquipment.Models
{
    public class Role
    {
        public const int Accountant = 1;
        public const int AdministratorDB = 2;
        public const int Employee = 3;
        
        public Role()
        {
            
        }
        
        public Role(Dictionary<string, object> data)
        {
            this.name = data["name_dolj"].ToString();
            Int32.TryParse(data["id_dolj"].ToString(), out this._id);
            Int32.TryParse(data["id_otdel"].ToString(), out this._idDepartment);
        }
        
        public string name { get; set; }
        
        private int _idDepartment;
        public Department Department { get => Department.getById(_idDepartment); }
        
        private int _id;
        public int ID { get => _id; }

        public static List<Role> getAll()
        {
            List<Role> roles = new List<Role>();
            foreach (var data in App.db.execute("select * from doljnost where true;"))
            {
                roles.Add(new Role(data));
            }

            return roles;
        }

        public static Role getById(int id)
        {
            var data = App.db.execute("select * from doljnost where id_dolj=@id;",
                new Dictionary<string, object>()
                {
                    { "id", id }
                });
            if (data.Count==0)
            {
                return new Role();
            }

            return new Role(data[0]);
        }
    }
}
using System;
using System.Collections.Generic;

namespace InventoryOfEquipment.Models
{
    public class Department
    {
        public const int HRDepartment = 1;
        public const int TechnicalDepartment = 2;

        public Department()
        {
        }

        public Department(Dictionary<string, object> data)
        {
            this.name = data["name_otdel"].ToString();
            Int32.TryParse(data["id_otdel"].ToString(), out this._id);
        }

        public string name { get; set; }

        private int _id;

        public int ID
        {
            get => _id;
        }

        public static List<Department> getAll()
        {
            List<Department> departments = new List<Department>();
            foreach (var data in App.db.execute("select * from otdel where true;"))
            {
                departments.Add(new Department(data));
            }

            return departments;
        }

        public static Department getById(int id)
        {
            var data = App.db.execute("select * from otdel where id_otdel=@id;",
                new Dictionary<string, object>()
                {
                    { "id", id }
                });
            if (data.Count == 0)
            {
                return new Department();
            }

            return new Department(data[0]);
        }
    }
}
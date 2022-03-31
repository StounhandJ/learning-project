using System;
using System.Collections.Generic;

namespace InventoryOfEquipment.Models
{
    public class Equipment
    {
        public Equipment()
        {
        }

        public Equipment(string name, string manufacturer, DateTime expirationDate, DateTime datePurchase, double price,
            int nomer, User user)
        {
            this.name = name;
            this.manufacturer = manufacturer;
            this.expirationDate = expirationDate;
            this.datePurchase = datePurchase;
            this.price = price;
            this.nomer = nomer;
            this._idUser = user.ID;
        }

        public Equipment(Dictionary<string, object> data)
        {
            this.name = data["name_equip"].ToString();
            this.manufacturer = data["prod_equip"].ToString();
            this.expirationDate = (DateTime)data["time_godn"];
            this.datePurchase = (DateTime)data["date_pok"];
            double price;
            double.TryParse(data["price_equip"].ToString(), out price);
            int nomer;
            Int32.TryParse(data["nomer_equip"].ToString(), out nomer);
            this.price = price;
            this.nomer = nomer;
            Int32.TryParse(data["id_personal"].ToString(), out this._idUser);
            Int32.TryParse(data["id_equip"].ToString(), out this._id);
        }

        public string name { get; set; }

        public string manufacturer { get; set; }

        public double price { get; set; }

        public int nomer { get; set; }

        public DateTime expirationDate { get; set; }

        public DateTime datePurchase { get; set; }

        private int _id = -1;

        public int ID
        {
            get => _id;
        }

        private int _idUser;

        public User User
        {
            get => User.getById(_idUser);
            set => _idUser = value.ID;
        }

        public static Equipment getById(int id)
        {
            var data = App.db.execute("select * from equipment where id_equip=@id;",
                new Dictionary<string, object>()
                {
                    { "id", id }
                });
            if (data.Count == 0)
            {
                return new Equipment();
            }

            return new Equipment(data[0]);
        }

        public static List<Equipment> getAll()
        {
            List<Equipment> equipments = new List<Equipment>();
            foreach (var data in App.db.execute("select * from equipment where true;"))
            {
                equipments.Add(new Equipment(data));
            }

            return equipments;
        }
        
        public static List<Equipment> getAllForUser(User user)
        {
            List<Equipment> equipments = new List<Equipment>();
            foreach (var data in App.db.execute("select * from equipment where id_personal=@id_personal;",new Dictionary<string, object>()
                {
                    { "id_personal", user.ID }
                }))
            {
                equipments.Add(new Equipment(data));
            }

            return equipments;
        }

        public bool exists()
        {
            return _id != -1;
        }

        public void delete()
        {
            App.db.execute("delete from equipment where id_equip=@id;",
                new Dictionary<string, object>()
                {
                    { "id", ID }
                });
            _id = -1;
        }

        public void save()
        {
            if (this.exists())
            {
                App.db.execute(
                    "UPDATE equipment SET name_equip=@name, prod_equip=@manufacturer, price_equip=@price, time_godn=@expirationDate, date_pok=@datePurchase, nomer_equip=@nomer, id_personal=@idUser WHERE id_equip=@id;",
                    new Dictionary<string, object>()
                    {
                        { "name", name },
                        { "manufacturer", manufacturer },
                        { "expirationDate", expirationDate },
                        { "datePurchase", datePurchase },
                        { "price", price },
                        { "nomer", nomer },
                        { "idUser", _idUser },
                        { "id", _id },
                    });
                return;
            }

            var data = App.db.execute(
                "INSERT INTO equipment(name_equip, prod_equip, price_equip, time_godn, date_pok, nomer_equip, id_personal) VALUES (@name, @manufacturer, @price, @expirationDate, @datePurchase, @nomer, @idUser) RETURNING id_equip;",
                new Dictionary<string, object>()
                {
                    { "name", name },
                    { "manufacturer", manufacturer },
                    { "expirationDate", expirationDate },
                    { "datePurchase", datePurchase },
                    { "price", price },
                    { "nomer", nomer },
                    { "idUser", _idUser },
                    { "id", _id },
                });
            if (data.Count > 0)
            {
                Int32.TryParse(data[0]["id_equip"].ToString(), out this._id);
            }
        }
    }
}
using System;
using System.Collections.Generic;

namespace InventoryOfEquipment.Models
{
    public class User
    {
        public User()
        {
        }

        public User(string surname, string firstName, string patronymic, Role role)
        {
            this.surname = surname;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.mailPersonal = "-";
            this.login = "-";
            this.password = "-";
            this._idRole = role.ID;
        }

        public User(Dictionary<string, object> data)
        {
            this.surname = data["fam_personal"].ToString();
            this.firstName = data["name_personal"].ToString();
            this.patronymic = data["otch_personal"].ToString();
            this.login = data["login"].ToString();
            this.password = data["password"].ToString();
            this.mailPersonal = data["mail_personal"].ToString();
            Int32.TryParse(data["id_personal"].ToString(), out this._id);
            Int32.TryParse(data["id_dolj"].ToString(), out this._idRole);
        }

        public string surname { get; set; }

        public string firstName { get; set; }

        public string patronymic { get; set; }
        
        public string FIO
        {
            get => surname+" "+firstName+" "+patronymic;
        }

        public string login { get; set; }

        public string password { get; set; }

        public string mailPersonal { get; set; }

        private int _idRole;

        public Role Role
        {
            get => Role.getById(_idRole);
        }

        private int _id = -1;

        public int ID
        {
            get => _id;
        }

        public static User getById(int id)
        {
            var data = App.db.execute("select * from personal where id_personal=@id;",
                new Dictionary<string, object>()
                {
                    { "id", id }
                });
            if (data.Count == 0)
            {
                return new User();
            }

            return new User(data[0]);
        }

        public static User getByLoginPassword(string login, string password)
        {
            var data = App.db.execute("select * from personal where login=@login and password=@password;",
                new Dictionary<string, object>()
                {
                    { "login", login },
                    { "password", password },
                });
            if (data.Count == 0)
            {
                return new User();
            }

            return new User(data[0]);
        }
        
        public static List<User> getAll()
        {
            List<User> roles = new List<User>();
            foreach (var data in App.db.execute("select * from personal where true;"))
            {
                roles.Add(new User(data));
            }

            return roles;
        }

        public bool exists()
        {
            return _id != -1;
        }

        public void delete()
        {
            App.db.execute("delete from personal where id_personal=@id;",
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
                    "UPDATE personal SET fam_personal=@surname, name_personal=@firstName, otch_personal=@patronymic, login=@login, password=@password, mail_personal=@mailPersonal, id_dolj=@idRole WHERE id_personal=@id_personal;",
                    new Dictionary<string, object>()
                    {
                        { "surname", surname },
                        { "firstName", firstName },
                        { "patronymic", patronymic },
                        { "login", login },
                        { "password", password },
                        { "mailPersonal", mailPersonal },
                        { "idRole", _idRole },
                        { "id", _id },
                    });
                return;
            }

            var data = App.db.execute(
                "INSERT INTO personal(fam_personal, name_personal, otch_personal, login, password, mail_personal, id_dolj) VALUES (@surname, @firstName, @patronymic, @login, @password, @mailPersonal, @idRole) RETURNING id_personal;",
                new Dictionary<string, object>()
                {
                    { "surname", surname },
                    { "firstName", firstName },
                    { "patronymic", patronymic },
                    { "login", login },
                    { "password", password },
                    { "mailPersonal", mailPersonal },
                    { "idRole", _idRole },
                });
            if (data.Count > 0)
            {
                Int32.TryParse(data[0]["id_personal"].ToString(), out this._id);
            }
        }
    }
}
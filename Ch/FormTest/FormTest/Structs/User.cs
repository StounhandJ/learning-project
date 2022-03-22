using System;
using FormTest.Enums;

namespace FormTest.Structs
{
    public struct User
    {
        
        public long id { get; set; }
        
        public string login { get; set; }
        
        public string password { get; set; }
        
        public string fio { get; set; }
        
        public TypeOfUser TypeOfUser { get; set; }
        

        public User(string login, string password, string fio, TypeOfUser TypeOfUser, long id=default)
        {
            this.login = login;
            this.password = password;
            this.fio = fio;
            this.TypeOfUser = TypeOfUser;
            this.id = id!=default?id:DateTime.Now.Ticks;
        }
    }
}
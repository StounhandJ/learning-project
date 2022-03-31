using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Data;
using System.Windows.Documents;
using FormTest.Enums;
using FormTest.Structs;

namespace FormTest
{
    public class UsersController
    {
        public readonly List<User> users;

        public UsersController()
        {
            this.users = ManagementSave.loadUsersJSON();
            if (this.users.FindIndex(u => u.TypeOfUser == TypeOfUser.Admin)==-1) // if there is no admin add it
            {
                this.users.Add(new User(Properties.Resources.admin_login, Properties.Resources.admin_password, "Админ Админ Админ", TypeOfUser.Admin));
            }
        }

        public string getNameUser(long studentId)
        {
            User? user = getUser(studentId);
            if (user.HasValue)
            {
                return user?.fio;
            }
            else
            {
                return "";
            }
        }
        
        public User? getUser(string login, string password)
        {
            int userIndex =  this.users.FindIndex(u => u.login==login && u.password==password);
            
            if (userIndex!=-1)
            {
                return this.users[userIndex];
            }
            else
            {
                return null;
            }
        }
        
        public User? getUser(long id)
        {
            int userIndex =  this.users.FindIndex(u => u.id==id);
            
            if (userIndex!=-1)
            {
                return this.users[userIndex];
            }
            else
            {
                return null;
            }
        }
        
        private int getUserIndex(string login, string password)
        {
            return this.users.FindIndex(u => u.login==login && u.password==password);
        }
        
        private int getUserIndex(long id)
        {
            return this.users.FindIndex(u => u.id==id);
        }

        public List<User> getUsersTypeOf(TypeOfUser typeOfUser)
        {
            return this.users.FindAll(u => u.TypeOfUser == typeOfUser);
        }

        public bool createUser(string login, string password, string fio, TypeOfUser typeOfUser)
        {
            int userIndex = this.users.FindIndex(u => u.login==login);
            if (userIndex==-1)
            {
                this.users.Add(new User(login, password, fio, typeOfUser));
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool changeUser(long UserId, string login, string password, string fio, TypeOfUser typeOfUser)
        {
            int userIndex = getUserIndex(UserId);
            if (userIndex!=-1)
            {
                this.users[userIndex] = new User( login, password, fio, typeOfUser, UserId );
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool delUser(long UserId)
        {
            int userIndex = getUserIndex(UserId);
            if (userIndex!=-1)
            {
                this.users.RemoveAt(userIndex);
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void save()
        {
            new Thread(ManagementSave.saveUsersJSON).Start(this.users);
        }
    }
}
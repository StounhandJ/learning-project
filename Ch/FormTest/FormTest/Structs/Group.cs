using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace FormTest.Structs
{
    public class Group
    {
        public long id { get; set; }
        
        public string name { get; set; }
        
        public List<long> students { get; set; }
        public Group(string name, List<long> students=null, long id = default)
        {
            this.name = name;
            this.students = students??new List<long>();
            this.id = id!=default?id:DateTime.Now.Ticks;
        }

        public List<User> getStudents()
        {
            UsersController usersController = new UsersController();
            return students.ConvertAll(s => usersController.getUser(s)??new User());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace FormTest.Structs
{
    public class Lesson
    {
        public long id { get; set; }
        
        public string name { get; set; }
        
        public long teacherId { get; set; }
        
        public List<long> groups { get; set; }

        public Lesson(string name, long teacherId, List<long> groups=null, long id=default)
        {
            this.name = name;
            this.teacherId = teacherId;
            this.groups = groups??new List<long>();
            this.id = id!=default?id:DateTime.Now.Ticks;
        }

        public List<Group> getGroups()
        {
            GroupsController groupsController = new GroupsController();
            return groups.ConvertAll(s => groupsController.getGroup(s));
        }
        
        public User getTeacher()
        {
            UsersController usersController = new UsersController();
            return usersController.getUser(this.teacherId)??new User();
        }
    }
}
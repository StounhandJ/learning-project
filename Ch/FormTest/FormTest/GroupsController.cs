using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Documents;
using FormTest.Enums;
using FormTest.Structs;

namespace FormTest
{
    public class GroupsController
    {
        public readonly List<Group> groups;
            
        public GroupsController()
        {
            this.groups = ManagementSave.loadGroupsJSON();
        }

        public Group getGroup(long id)
        {
            int index =  this.groups.FindIndex(g => g.id==id);
            
            if (index!=-1)
            {
                return this.groups[index];
            }
            else
            {
                return null;
            }
        }
        
        public Group getGroup(string name)
        {
            int index =  this.groups.FindIndex(g => g.name==name);
            
            if (index!=-1)
            {
                return this.groups[index];
            }
            else
            {
                return null;
            }
        }
        
        public int getGroupIndex(string name)
        {
            return this.groups.FindIndex(g => g.name==name);
        }
        
        public int getGroupIndex(long id)
        {
            return this.groups.FindIndex(g => g.id==id);
        }

        public List<Group> getGroupsForStudent(User user)
        {
            return this.groups.FindAll(g => g.students.Exists(u => u.Equals(user.id)));
        }

        public bool createGroup(string name, List<User> students=null)
        {
            int groupIndex = getGroupIndex(name);
            if (groupIndex==-1)
            {
                this.groups.Add(new Group(name, students.ConvertAll(s=>s.id)));
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool changeGroup(long GroupId, string name, List<User> students=null)
        {
            int groupIndex = getGroupIndex(GroupId);
            if (groupIndex!=-1)
            {
                this.groups[groupIndex] = new Group(name, students.ConvertAll(s=>s.id), GroupId);
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool delGroup(long GroupId)
        {
            int groupIndex = getGroupIndex(GroupId);
            if (groupIndex!=-1)
            {
                this.groups.RemoveAt(groupIndex);
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool delStudentForGroup(string nameGroup, User user)
        {
            int groupIndex = getGroupIndex(nameGroup);
            bool result = groupIndex != -1 && this.groups[groupIndex].students.Remove(user.id);
            this.save();
            return result;
        }
        
        public bool addStudentForGroup(string nameGroup, User user)
        {
            int groupIndex = getGroupIndex(nameGroup);
            if (groupIndex != -1)
            {
                this.groups[groupIndex].students.Add(user.id);
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
            new Thread(ManagementSave.saveGroupsJSON).Start(this.groups);
        }
    }
}
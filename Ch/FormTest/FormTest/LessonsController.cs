using System.Collections.Generic;
using System.Threading;
using FormTest.Structs;

namespace FormTest
{
    public class LessonController
    {
        public readonly List<Lesson> lessons;
            
        public LessonController()
        {
            this.lessons = ManagementSave.loadLessonsJSON();
        }
        
        public Lesson getLesson(string name)
        {
            int index =  this.lessons.FindIndex(l => l.name==name);
            
            if (index!=-1)
            {
                return this.lessons[index];
            }
            else
            {
                return null;
            }
        }
        
        public int getLessonIndex(string name)
        {
            return this.lessons.FindIndex(l => l.name==name);
        }
        
        public int getLessonIndex(long id)
        {
            return this.lessons.FindIndex(l => l.id==id);
        }

        public List<Lesson> getLessonForGroup(Group group)
        {
            return this.lessons.FindAll(l => l.groups.Exists(g => g==group.id));
        }
        
        public List<Lesson> getLessonForTeacher(User teacher)
        {
            return this.lessons.FindAll(l => l.teacherId.Equals(teacher.id));
        }

        public bool createLesson(string name, User teacher, List<Group> groups=null)
        {
            int lessonIndex = getLessonIndex(name);
            if (lessonIndex==-1)
            {
                this.lessons.Add(new Lesson(name, teacher.id, groups.ConvertAll(g=>g.id)));
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool changeLesson(long LessonId, string name, User teacher, List<Group> groups=null)
        {
            int lessonIndex = getLessonIndex(LessonId);
            if (lessonIndex!=-1)
            {
                this.lessons[lessonIndex] = new Lesson(name, teacher.id, groups.ConvertAll(g=>g.id), LessonId);
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool delLesson(long LessonId)
        {
            int lessonIndex = getLessonIndex(LessonId);
            if (lessonIndex!=-1)
            {
                this.lessons.RemoveAt(lessonIndex);
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool delGroupForLesson(string nameLesson, Group group)
        {
            int lessonIndex = getLessonIndex(nameLesson);
            bool result = lessonIndex != -1 && this.lessons[lessonIndex].groups.Remove(group.id);
            this.save();
            return result;
        }
        
        public bool addGroupForLesson(string nameLesson, Group group)
        {
            int lessonIndex = getLessonIndex(nameLesson);
            if (lessonIndex != -1)
            {
                this.lessons[lessonIndex].groups.Remove(group.id);
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool delTeacherForLesson(string nameLesson)
        {
            int lessonIndex = getLessonIndex(nameLesson);
            if (lessonIndex != -1)
            {
                this.lessons[lessonIndex].teacherId = -1;
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool addTeacherForLesson(string nameLesson, User teacher)
        {
            int lessonIndex = getLessonIndex(nameLesson);
            if (lessonIndex != -1)
            {
                this.lessons[lessonIndex].teacherId = teacher.id;
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
            new Thread(ManagementSave.saveLessonsJSON).Start(this.lessons);
        }
    }
}
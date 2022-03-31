using System.Collections.Generic;
using System.Threading;
using FormTest.Structs;

namespace FormTest
{
    public class FormsController
    {
        public readonly List<Form> forms;
            
        public FormsController()
        {
            this.forms = ManagementSave.loadFormsJSON();
        }

        public List<Form> getFormsStudent(long studentId)
        {
            return this.forms.FindAll(f => f.studentsId.IndexOf(studentId) != -1);
        }
        public Form getForm(long id)
        {
            int index =  this.forms.FindIndex(f => f.id==id);
            
            if (index!=-1)
            {
                return this.forms[index];
            }
            else
            {
                return null;
            }
        }
        
        public Form getForm(string name)
        {
            int index =  this.forms.FindIndex(f => f.name==name);
            
            if (index!=-1)
            {
                return this.forms[index];
            }
            else
            {
                return null;
            }
        }
        
        public int getFormIndex(string name)
        {
            return this.forms.FindIndex(f => f.name==name);
        }
        
        public int getFormIndex(long id)
        {
            return this.forms.FindIndex(f => f.id==id);
        }
        

        public bool createForm(string name, long lessonId, List<long> studentsId, List<Question> questions)
        {
            int formIndex = getFormIndex(name);
            if (formIndex==-1)
            {
                this.forms.Add(new Form(name, lessonId, studentsId, questions));
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool changeForm(long FormId, string name, long lessonId, List<long> studentsId, List<Question> questions)
        {
            int formIndex = getFormIndex(FormId);
            if (formIndex!=-1)
            {
                this.forms[formIndex] = new Form(name, lessonId, studentsId, questions, FormId);
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool delForm(long FormId)
        {
            int formIndex = getFormIndex(FormId);
            if (formIndex!=-1)
            {
                this.forms.RemoveAt(formIndex);
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool studentComplited(long FormId, long studentId)
        {
            int formIndex = getFormIndex(FormId);
            if (formIndex!=-1)
            {
                this.forms[formIndex].studentsId.Remove(studentId);
                this.forms[formIndex].studentsComplitedId.Add(studentId);
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
            new Thread(ManagementSave.saveFormsJSON).Start(this.forms);
        }
    }
}
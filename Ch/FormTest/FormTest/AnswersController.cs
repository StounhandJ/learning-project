using System.Collections.Generic;
using System.Threading;
using FormTest.Structs;

namespace FormTest
{
    public class AnswersController
    {
        public readonly List<Answers> answersList;
        
        public AnswersController()
        {
            this.answersList = ManagementSave.loadAnswersJSON();
        }

        public List<Answers> getAnswersList(long formId)
        {
            return this.answersList.FindAll(a => a.formId == formId);
        }
        
        public List<Answers> getAnswersListStudent(long studentId)
        {
            return this.answersList.FindAll(a => a.studentId == studentId);
        }

        public Answers getAnswers(long formId, long userId)
        {
            return this.answersList.Find(a => a.formId == formId && a.studentId==userId);
        }
        
        public Answers getAnswers(long id)
        {
            int index =  this.answersList.FindIndex(a => a.id==id);
            
            if (index!=-1)
            {
                return this.answersList[index];
            }
            else
            {
                return null;
            }
        }
        
        public int getAnswerIndex(long id)
        {
            return this.answersList.FindIndex(a => a.id==id);
        }
        
        public bool createAnswers(long formId, long studentId, List<bool> result)
        {
            this.answersList.Add(new Answers(formId, studentId, result));
            this.save();
            return true;
        }
        
        public bool changeAnswers(long answersId, long formId, long studentId, List<bool> result)
        {
            int answersIndex = getAnswerIndex(answersId);
            if (answersIndex!=-1)
            {
                this.answersList[answersIndex] = new Answers(formId, studentId, result, answersId);
                this.save();
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool delAnswers(long answersId)
        {
            int answersIndex = getAnswerIndex(answersId);
            if (answersIndex!=-1)
            {
                this.answersList.RemoveAt(answersIndex);
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
            new Thread(ManagementSave.saveAnswersJSON).Start(this.answersList);
        }
    }
}
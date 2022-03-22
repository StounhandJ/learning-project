using System.Collections.Generic;
using FormTest.Enums;

namespace FormTest.Structs
{
    public struct Question
    {
        public string question { get; set; }
        
        public TypeOfQuestion TypeOfQuestion { get; set; }

        public List<string> answers { get; set; }
        public List<int> correctAnswerIDs { get; set; }

        public Question(TypeOfQuestion typeOfQuestion, string question, List<string> answers, List<int> correctAnswerIDs)
        {
            this.TypeOfQuestion = typeOfQuestion;
            this.question = question;
            this.answers = answers;
            this.correctAnswerIDs = correctAnswerIDs;
        }
    }
}
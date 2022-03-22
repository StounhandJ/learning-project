using System;
using System.Collections.Generic;

namespace FormTest.Structs
{
    public class Form
    {
        public long id { get; set; }
        public string name { get; set; }
        
        public long lessonId { get; set; }
        
        public List<long> studentsId { get; set; }
        
        public List<long> studentsComplitedId { get; set; }
        
        public List<Question> questions { get; set; }
        
        public long createDate { get; set; }

        public Form(string name, long lessonId, List<long> studentsId, List<Question> questions, long id = default, long createDate=default)
        {
            this.name = name;
            this.lessonId = lessonId;
            this.studentsId = studentsId;
            this.studentsComplitedId = new List<long>();
            this.questions = questions;
            this.id = id!=default?id:DateTime.Now.Ticks;
            this.createDate = createDate!=default?createDate:DateTime.Now.Ticks;
        }
    }
}
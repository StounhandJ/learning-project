using System;
using System.Collections.Generic;

namespace FormTest.Structs
{
    public class Answers
    {
        public long id { get; set; }

        public long formId { get; set; }
        
        public long studentId { get; set; }
        
        public List<bool> result { get; set; }

        public string studentName
        {
            get
            {
                UsersController _usersController = new UsersController();
                return _usersController.getNameUser(this.studentId);
            }
            set{}
        }

        public string points
        {
            get
            {
                int count = 0;
                result.ForEach(b => count += b ? 1 : 0);
                return $"{count}/{result.Count}";
            }
        }

        public Answers(long formId, long studentId, List<bool> result, long id = default)
        {
            this.id = id!=default?id:DateTime.Now.Ticks;
            this.formId = formId;
            this.studentId = studentId;
            this.result = result;
        }

        public string get()
        {
            return "FFF";
        }
    }
}
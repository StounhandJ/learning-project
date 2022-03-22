using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FormTest.Structs;
using Newtonsoft.Json;

namespace FormTest
{
    public static class ManagementSave
    {
        public static readonly string savePathUser = Directory.GetCurrentDirectory()+"\\profiles.bin";
        
        public static readonly string savePathGroup = Directory.GetCurrentDirectory()+"\\groups.bin";
        
        public static readonly string savePathLesson = Directory.GetCurrentDirectory()+"\\lessons.bin";

        public static readonly string savePathForms = Directory.GetCurrentDirectory()+"\\forms.bin";
        
        public static readonly string savePathAnswers = Directory.GetCurrentDirectory()+"\\answers.bin";
        
        public static async void saveUsersJSON(object users)
        {
            using (StreamWriter sw = new StreamWriter(savePathUser, false, System.Text.Encoding.UTF8))
            {
                await sw.WriteAsync(Encryption.encoding(JsonConvert.SerializeObject(users as List<User>),Properties.Resources.secret_code));
            }
        }

        public static List<User> loadUsersJSON()
        {
            if (File.Exists(savePathUser))
            {
                using (StreamReader fs = new StreamReader(savePathUser))
                {
                    string json = Encryption.dencoding(fs.ReadToEnd(), Properties.Resources.secret_code);
                    List<User> usersList = JsonConvert.DeserializeObject<List<User>>(json);
                    return usersList??new List<User>();
                }
            }
            return new List<User>();
        }
        
        public static async void saveGroupsJSON(object groups)
        {
            using (StreamWriter sw = new StreamWriter(savePathGroup, false, System.Text.Encoding.UTF8))
            {
                await sw.WriteAsync(Encryption.encoding(JsonConvert.SerializeObject(groups as List<Group>), Properties.Resources.secret_code));
            }
        }

        public static List<Group> loadGroupsJSON()
        {
            if (File.Exists(savePathGroup))
            {
                using (StreamReader fs = new StreamReader(savePathGroup))
                {
                    string json =  Encryption.dencoding(fs.ReadToEnd(), Properties.Resources.secret_code);
                    List<Group> groupsList = JsonConvert.DeserializeObject<List<Group>>(json);
                    return groupsList?? new List<Group>();
                }
            }
            return new List<Group>();
        }
        
        public static async void saveLessonsJSON(object lesson)
        {
            using (StreamWriter sw = new StreamWriter(savePathLesson, false, System.Text.Encoding.UTF8))
            {
                await sw.WriteAsync(Encryption.encoding(JsonConvert.SerializeObject(lesson as List<Lesson>), Properties.Resources.secret_code));
            }
        }

        public static List<Lesson> loadLessonsJSON()
        {
            if (File.Exists(savePathLesson))
            {
                using (StreamReader fs = new StreamReader(savePathLesson))
                {
                    string json =  Encryption.dencoding(fs.ReadToEnd(), Properties.Resources.secret_code);
                    List<Lesson> lessonsList = JsonConvert.DeserializeObject<List<Lesson>>(json);
                    return lessonsList?? new List<Lesson>();
                }
            }
            return new List<Lesson>();
        }
        
        public static async void saveFormsJSON(object forms)
        {
            using (StreamWriter sw = new StreamWriter(savePathForms, false, System.Text.Encoding.UTF8))
            {
                await sw.WriteAsync(Encryption.encoding(JsonConvert.SerializeObject(forms as List<Form>), Properties.Resources.secret_code));
            }
        }

        public static List<Form> loadFormsJSON()
        {
            if (File.Exists(savePathForms))
            {
                using (StreamReader fs = new StreamReader(savePathForms))
                {
                    string json =  Encryption.dencoding(fs.ReadToEnd(), Properties.Resources.secret_code);
                    List<Form> formsList = JsonConvert.DeserializeObject<List<Form>>(json);
                    return formsList?? new List<Form>();
                }
            }
            return new List<Form>();
        }
        
        public static async void saveAnswersJSON(object answers)
        {
            using (StreamWriter sw = new StreamWriter(savePathAnswers, false, System.Text.Encoding.UTF8))
            {
                await sw.WriteAsync(Encryption.encoding(JsonConvert.SerializeObject(answers as List<Answers>), Properties.Resources.secret_code));
            }
        }

        public static List<Answers> loadAnswersJSON()
        {
            if (File.Exists(savePathAnswers))
            {
                using (StreamReader fs = new StreamReader(savePathAnswers))
                {
                    string json =  Encryption.dencoding(fs.ReadToEnd(), Properties.Resources.secret_code);
                    List<Answers> answersList = JsonConvert.DeserializeObject<List<Answers>>(json);
                    return answersList?? new List<Answers>();
                }
            }
            return new List<Answers>();
        }
    }
}
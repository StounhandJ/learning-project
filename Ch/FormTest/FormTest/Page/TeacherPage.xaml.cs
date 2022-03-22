using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using FormTest.Structs;

namespace FormTest.Page
{
    public partial class TeacherPage : System.Windows.Controls.Page
    {
        public event Action Exit;

        private User _teacher;
        public User Teacher
        {
            get
            {
                return _teacher;
            }
            set
            {
                _teacher = value;
                this.FormChangeControl.Lessons = getLessons();
            }
        }

        private LessonController _lessonController;
        
        private FormsController _formsController;
        public TeacherPage()
        {
            InitializeComponent();

            this._lessonController = new LessonController();
            this._formsController = new FormsController();

            ResultFormControl.Forms = this._formsController.forms;

            MenuControl_OnCreateFormMenu();
        }

        public List<Lesson> getLessons()
        {
            return this._lessonController.getLessonForTeacher(Teacher);
        }

        private void FormChangeControl_OnCreateForm(Form form)
        {
            this._formsController.createForm(form.name, form.lessonId, form.studentsId, form.questions);
            
            ResultFormControl.Forms = this._formsController.forms;
        }
        
        private void FormChangeControl_OnError(string text)
        {
            MessageBox.Show(text);
        }

        public void HiddenAllChangeControl()
        {
            FormChangeControl.Visibility = Visibility.Hidden;
            FormChangeControl.IsEnabled = false;
            
            ResultFormControl.Visibility = Visibility.Hidden;
            ResultFormControl.IsEnabled = false;
        }
         
        private void MenuControl_OnCreateFormMenu()
        {
            HiddenAllChangeControl();
            
            FormChangeControl.Visibility = Visibility.Visible;
            FormChangeControl.IsEnabled = true;
        }
        
        private void MenuControl_OnShowResultMenu()
        {
            HiddenAllChangeControl();
            
            ResultFormControl.Visibility = Visibility.Visible;
            ResultFormControl.IsEnabled = true;
        }
        
        private void Close()
        {
            Exit?.Invoke();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using FormTest.Structs;

namespace FormTest.Page
{
    public partial class StudentPage : System.Windows.Controls.Page
    {
        public event Action Exit;

        private User _student;

        public User Student
        {
            get { return _student; }
            set
            {
                _student = value;
                
                ResultToStudentControl.Student = Student;
                update(value.id);
            }
        }

        private AnswersController _answersController;
        private FormsController _formsController;

        public StudentPage()
        {
            InitializeComponent();

            this._answersController = new AnswersController();
            this._formsController = new FormsController();

            MenuControl_OnPassageFormMenu();
        }

        private void FormPassageControl_OnPassageForm(long formId, List<bool> result)
        {
            this._answersController.createAnswers(formId, Student.id, result);
            this._formsController.studentComplited(formId, Student.id);

            update(Student.id);
        }

        private void FormPassageControl_OnError(string text)
        {
            MessageBox.Show(text);
        }

        private void update(long studentId)
        {
            FormPassageControl.Forms = this._formsController.getFormsStudent(studentId);

            ResultToStudentControl.Forms = this._answersController.getAnswersListStudent(studentId)
                .ConvertAll(a => this._formsController.getForm(a.formId));
        }

        public void HiddenAllChangeControl()
        {
            FormPassageControl.Visibility = Visibility.Hidden;
            FormPassageControl.IsEnabled = false;

            ResultToStudentControl.Visibility = Visibility.Hidden;
            ResultToStudentControl.IsEnabled = false;
        }

        private void MenuControl_OnPassageFormMenu()
        {
            HiddenAllChangeControl();

            FormPassageControl.Visibility = Visibility.Visible;
            FormPassageControl.IsEnabled = true;
        }

        private void MenuControl_OnShowResultStudentMenu()
        {
            HiddenAllChangeControl();

            ResultToStudentControl.Visibility = Visibility.Visible;
            ResultToStudentControl.IsEnabled = true;
        }

        private void Close()
        {
            Exit?.Invoke();
        }
    }
}
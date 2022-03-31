using System.Collections.Generic;
using System.Windows.Controls;
using FormTest.Structs;

namespace FormTest.Controls
{
    public partial class ResultToStudentControl : UserControl
    {
        private List<Form> _forms;
        public List<Form> Forms
        {
            get
            {
                return _forms;
            }
            set
            {
                FillFormsComboBox(value);
                _forms = value;
            }
        }
        
        private User _student;
        public User Student
        {
            get
            {
                return _student;
            }
            set
            {
                _student = value;
            }
        }

        private AnswersController _answersController;
        
        public ResultToStudentControl()
        {
            InitializeComponent();

            this._answersController = new AnswersController();
        }
        
        private void FillFormsComboBox(List<Form> forms)
        {
            FormsComboBox.ItemsSource = new List<Form>();
            FormsComboBox.ItemsSource = forms;
            FormsComboBox.DisplayMemberPath = "name";
        }

        private void FormsComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FormsComboBox.SelectedValue!=null)
            {
                Form form = (Form) FormsComboBox.SelectedValue;
                FormNameTextBlock.Text = form.name;
                FormResultTextBlock.Text = this._answersController.getAnswers(form.id, Student.id).points;
            }
        }
    }
}
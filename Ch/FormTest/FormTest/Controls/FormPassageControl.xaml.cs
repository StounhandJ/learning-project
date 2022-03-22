using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using FormTest.Structs;

namespace FormTest.Controls
{
    public partial class FormPassageControl : UserControl
    {
        public event Action<long, List<bool>> PassageForm;
        
        public event Action<string> Error;

        private List<Form> _forms;

        public List<Form> Forms
        {
            get { return _forms; }
            set
            {
                FillFormsComboBox(value);
                _forms = value;
            }
        }

        public FormPassageControl()
        {
            InitializeComponent();
        }

        private void FillFormsComboBox(List<Form> forms)
        {
            FormsComboBox.ItemsSource = new List<Form>();
            FormsComboBox.ItemsSource = forms;
            FormsComboBox.DisplayMemberPath = "name";
        }

        private void FormsComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FormsComboBox.SelectedValue != null)
            {
                QuestionsListView.Items.Clear();
                foreach (var questions in ((Form) FormsComboBox.SelectedValue).questions)
                {
                    QuestionsListView.Items.Add(new QuestionPassageControl {Question = questions});
                }
            }
        }

        private void SendButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                Form form = (Form) FormsComboBox.SelectedValue;
                List<bool> res = new List<bool>();
                foreach (QuestionPassageControl question in QuestionsListView.Items)
                {
                    res.Add(question.IsCorrected);
                }

                PassageForm?.Invoke(form.id, res);
                clear();
            }
            else
            {
                Error?.Invoke("Выбранны не все варианты ответа");
            }
        }

        private void clear()
        {
            FormsComboBox.SelectedIndex = -1;
            QuestionsListView.Items.Clear();
        }
        private bool check()
        {
            bool res = true;
            foreach (QuestionPassageControl question in QuestionsListView.Items)
            {
                if (!question.IsAnswered)
                {
                    res = false;
                }
            }

            return res;
        }
    }
}
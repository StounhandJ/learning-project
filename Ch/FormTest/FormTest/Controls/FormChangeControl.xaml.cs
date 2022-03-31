using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using FormTest.Structs;
using Xceed.Wpf.Toolkit.Primitives;

namespace FormTest.Controls
{
    public partial class FormChangeControl : UserControl
    {
        public event Action<Form> CreateForm;

        public event Action<string> Error; 


        private List<Lesson> _lessons;

        public List<Lesson> Lessons
        {
            get { return _lessons; }
            set
            {
                FillLessonsComboBox(value);
                _lessons = value;
            }
        }

        public FormChangeControl()
        {
            InitializeComponent();
        }

        private void FillLessonsComboBox(List<Lesson> lessons)
        {
            LessonComboBox.ItemsSource = new List<Lesson>();
            LessonComboBox.ItemsSource = lessons;
            LessonComboBox.DisplayMemberPath = "name";
        }

        private void FillGroupsComboBox(List<Group> groups)
        {
            GroupsCheckComboBox.ItemsSource = new List<Group>();
            GroupsCheckComboBox.ItemsSource = groups;
            GroupsCheckComboBox.DisplayMemberPath = "name";
            GroupsCheckComboBox.SelectedItemsOverride = new List<Group>();
        }

        private void LessonComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.LessonComboBox.SelectedItem != null)
            {
                FillGroupsComboBox(((Lesson) this.LessonComboBox.SelectedItem).getGroups());
            }

            checkAreas();
        }

        private void CreateQuestioButton_OnClick(object sender, RoutedEventArgs e)
        {
            QuestionChangeControl questionChangeControl = new QuestionChangeControl();
            questionChangeControl.QuestionDelete += this.QuestionsListView.Items.Remove;
            this.QuestionsListView.Items.Add(questionChangeControl);
            checkAreas();
        }

        private void SendFormButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (check())
            {
                List<Question> questions = new List<Question>();
                foreach (QuestionChangeControl item in this.QuestionsListView.Items)
                {
                    questions.Add(item.Question);
                }

                string nameForm = NameFormTextBox.Text;
                long lessonId = ((Lesson) LessonComboBox.SelectedItem).id;
                List<long> students = new List<long>();
                ((List<Group>) GroupsCheckComboBox.SelectedItems).ForEach(g => g.students.ForEach(students.Add));
                CreateForm?.Invoke(new Form(nameForm, lessonId, students, questions));
                clear();
            }
            else
            {
                Error?.Invoke("Выбранны не все варианты ответа");
            }
        }

        private void clear()
        {
            NameFormTextBox.Text = "";
            LessonComboBox.SelectedIndex = -1;
            GroupsCheckComboBox.SelectedItemsOverride = new List<Group>();
            this.QuestionsListView.Items.Clear();
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            checkAreas();
        }

        private void GroupsCheckComboBox_OnItemSelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            checkAreas();
        }

        private void checkAreas()
        {
            SendFormButton.IsEnabled = NameFormTextBox.Text != "" && LessonComboBox.SelectedIndex != -1 &&
                                       GroupsCheckComboBox.SelectedItems.Count > 0 && QuestionsListView.Items.Count > 0;
        }

        private bool check()
        {
            bool res = true;
            foreach (QuestionChangeControl question in QuestionsListView.Items)
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
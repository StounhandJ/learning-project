using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using FormTest.Structs;

namespace FormTest.Controls
{
    public partial class ChangeLessonControl : UserControl
    {
        public event Action<string, User, List<Group>> CreateLesson;

        public event Action<Lesson, string, User, List<Group>> ChangeLesson;
        
        public event Action<Lesson> DeleteLesson;
        
        private List<Lesson> _lessons;
        public List<Lesson> Lessons
        {
            get
            {
                return _lessons;
            }
            set
            {
                FillLessonsComboBox(value);
                _lessons = value;
            }
        }
        
        private List<User> _teachers;
        public List<User> Teachers
        {
            get
            {
                return _teachers;
            }
            set
            {
                FillTeacherComboBox(value);
                _teachers = value;
            }
        }
        
        private List<Group> _groups;
        public List<Group> Groups
        {
            get
            {
                return _groups;
            }
            set
            {
                FillGroupsComboBox(value);
                _groups = value;
            }
        }
        public ChangeLessonControl()
        {
            InitializeComponent();
                        
            selectItem(false);
        }
        
        private void ShowError(string text)
        {
            ErrorTextBlock.Text = text;
        }

        private void FillLessonsComboBox(List<Lesson> lessons)
        {
            LessonsComboBox.ItemsSource = new List<Lesson>();
            LessonsComboBox.ItemsSource = lessons;
            LessonsComboBox.DisplayMemberPath = "name";
        }
        
        private void FillTeacherComboBox(List<User> teachers)
        {
            TeacherComboBox.ItemsSource = new List<User>();
            TeacherComboBox.ItemsSource = teachers;
            TeacherComboBox.DisplayMemberPath = "login";
        }
        
        private void FillGroupsComboBox(List<Group> groups)
        {
            GroupsCheckComboBox.ItemsSource = new List<Group>();
            GroupsCheckComboBox.ItemsSource = groups;
            GroupsCheckComboBox.DisplayMemberPath = "name";
            GroupsCheckComboBox.SelectedItemsOverride = new List<Group>();
        }
        
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LessonsComboBox.SelectedIndex>-1)
            {
                Lesson lesson = (Lesson) LessonsComboBox.SelectedValue;
                NameTextBox.Text = lesson.name;
                TeacherComboBox.SelectedValue = lesson.getTeacher();
                GroupsCheckComboBox.SelectedItemsOverride = lesson.getGroups();
                selectItem(true);
            }
            else
            {
                selectItem(false);
                ClearAreas();
            }
        }

        private void CreateButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (GoodAreas())
            {
                CreateLesson?.Invoke(NameTextBox.Text, (User) TeacherComboBox.SelectedValue, (List<Group>) GroupsCheckComboBox.SelectedItems);

                selectItem(false);
                ClearAreas();
            }
            else
            {
                ShowError("Заполнены не все поля");
            }
        }

        private void ChangeButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (GoodAreas())
            {
                ChangeLesson?.Invoke((Lesson) LessonsComboBox.SelectedValue, NameTextBox.Text, (User) TeacherComboBox.SelectedValue, (List<Group>) GroupsCheckComboBox.SelectedItems);
                
                selectItem(false);
                ClearAreas();
            }
            else
            {
                ShowError("Заполнены не все поля");
            }
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            DeleteLesson?.Invoke((Lesson) LessonsComboBox.SelectedValue);
            selectItem(false);
            ClearAreas();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            selectItem(false);
            ClearAreas();
        }
        
        public void selectItem(bool IsSelectItem)
        {
            CreateButton.IsEnabled = !IsSelectItem;
            ChangeButton.IsEnabled = IsSelectItem;
            DeleteButton.IsEnabled = IsSelectItem;
            CancelButton.IsEnabled = IsSelectItem;
        }
        
        public void ClearAreas()
        {
            LessonsComboBox.SelectedIndex = -1;
            NameTextBox.Text = "";
            TeacherComboBox.SelectedIndex = -1;
            GroupsCheckComboBox.SelectedItemsOverride = new List<Group>();
            ShowError("");
        }
        
        private bool GoodAreas()
        {
            return NameTextBox.Text != "" && TeacherComboBox.SelectedValue!=null;
        }
    }
}
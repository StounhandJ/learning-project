using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FormTest.Enums;
using FormTest.Structs;

namespace FormTest.Controls
{
    public partial class ChangeGroupControl : UserControl
    {
        public event Action<string, List<User>> CreateGroup;

        public event Action<Group, string, List<User>> ChangeGroup;
        
        public event Action<Group> DeleteGroup;

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
        
        private List<User> _students;
        public List<User> Students
        {
            get
            {
                return _students;
            }
            set
            {
                FillStudentsComboBox(value);
                _students = value;
            }
        }
        
        public ChangeGroupControl()
        {
            InitializeComponent();

            selectItem(false);
        }
        
        private void ShowError(string text)
        {
            ErrorTextBlock.Text = text;
        }
        
        private void FillGroupsComboBox(List<Group> groups)
        {
            GroupsComboBox.ItemsSource = new List<Group>();
            GroupsComboBox.ItemsSource = groups;
            GroupsComboBox.DisplayMemberPath = "name";
        }
        
        private void FillStudentsComboBox(List<User> students)
        {
            StudentsCheckComboBox.ItemsSource = new List<User>();
            StudentsCheckComboBox.ItemsSource = students;
            StudentsCheckComboBox.DisplayMemberPath = "login";
            StudentsCheckComboBox.SelectedItemsOverride = new List<User>();
        }
        
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupsComboBox.SelectedIndex>-1)
            {
                Group group = (Group) GroupsComboBox.SelectedValue;
                NameTextBox.Text = group.name;
                StudentsCheckComboBox.SelectedItemsOverride = group.getStudents();
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
                CreateGroup?.Invoke(NameTextBox.Text, (List<User>) StudentsCheckComboBox.SelectedItems);
                
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
                ChangeGroup?.Invoke((Group) GroupsComboBox.SelectedValue, NameTextBox.Text, (List<User>) StudentsCheckComboBox.SelectedItems);
                
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
            DeleteGroup?.Invoke((Group) GroupsComboBox.SelectedValue);
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
            GroupsComboBox.SelectedIndex = -1;
            NameTextBox.Text = "";
            StudentsCheckComboBox.SelectedItemsOverride = new List<User>();
            ShowError("");
        }
        
        private bool GoodAreas()
        {
            return NameTextBox.Text != "";
        }
    }
}
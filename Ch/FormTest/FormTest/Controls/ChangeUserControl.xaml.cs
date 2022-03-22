using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using FormTest.Enums;
using FormTest.Structs;

namespace FormTest.Controls
{
    public partial class ChangeUserControl : UserControl
    {
        public event Action<string, string, string, TypeOfUser> CreateUser;

        public event Action<User, string, string, string, TypeOfUser> ChangeUser;
        
        public event Action<User> DeleteUser;

        private List<User> _users;
        public List<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                FillUsersComboBox(value);
                _users = value;
            }
        }

        public ChangeUserControl()
        {
            InitializeComponent();
            
            FillTypeOfUserComboBox();
            selectItem(false);
        }

        private void FillUsersComboBox(List<User> users)
        {
            UsersComboBox.ItemsSource = new List<User>();
            UsersComboBox.ItemsSource = users;
            UsersComboBox.DisplayMemberPath = "login";
        }
        
        private void FillTypeOfUserComboBox()
        {
            Dictionary<TypeOfUser, string> types = new Dictionary<TypeOfUser, string>
            {
                {TypeOfUser.Admin, "Админ"}, {TypeOfUser.Teachaer, "Преподаватель"}, {TypeOfUser.Studen, "Студент"}
            };
            TypeOfUserComboBox.ItemsSource = types;
            TypeOfUserComboBox.DisplayMemberPath = "Value";
            TypeOfUserComboBox.SelectedValuePath = "Key";
        }

        private void ShowError(string text)
        {
            ErrorTextBlock.Text = text;
        }
        
        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (UsersComboBox.SelectedIndex>-1)
            {
                User user = UsersComboBox.SelectedValue is User ? (User) UsersComboBox.SelectedValue : default;
                LoginTextBox.Text = user.login;
                PasswordTextBox.Text = user.password;
                FIOTextBox.Text = user.fio;
                TypeOfUserComboBox.SelectedValue = user.TypeOfUser;
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
                CreateUser?.Invoke(LoginTextBox.Text, PasswordTextBox.Text, FIOTextBox.Text, (TypeOfUser) TypeOfUserComboBox.SelectedValue);
                
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
                ChangeUser?.Invoke((User) UsersComboBox.SelectedValue, LoginTextBox.Text, PasswordTextBox.Text, FIOTextBox.Text, (TypeOfUser) TypeOfUserComboBox.SelectedValue);
                
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
            DeleteUser?.Invoke((User) UsersComboBox.SelectedValue);
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
            UsersComboBox.Text = "";
            LoginTextBox.Text = "";
            PasswordTextBox.Text = "";
            FIOTextBox.Text = "";
            TypeOfUserComboBox.SelectedIndex = -1;
            ShowError("");
        }
        
        private bool GoodAreas()
        {
            return LoginTextBox.Text != "" && PasswordTextBox.Text != "" && FIOTextBox.Text != "" && TypeOfUserComboBox.SelectedValue!=null;
        }
    }
}
using System;
using System.Data;
using System.Windows;
using System.Windows.Threading;
using KartSkills.Lib;
using KartSkills.Models;
using KartSkills.View.Admin;
using KartSkills.View.Coordinator;
using KartSkills.View.Racer;
using Microsoft.Data.SqlClient;

namespace KartSkills.View
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void StartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Timer.start((text => { TextTimer.Text = text; }));
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new MainWindow());
            Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            DataTable table = SqlHelper.GetTableFromSql(
                $"select * from [User] where [Email] = '{TextEmail.Text}' and [Password] = '{TextPassword.Password}'");

            if (table.Rows.Count != 0)
            {
                User user = new User(table.Rows[0]);

                switch (user.IdRole)
                {
                    case "R":
                        WindowHelper.OpenNewWindow(new RacerMenuWindow(user));
                        break;
                    case "C":
                        WindowHelper.OpenNewWindow(new CoordinatorMenuWindow());
                        break;
                    case "A":
                        WindowHelper.OpenNewWindow(new AdminMenuWindow());
                        break;
                }

                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
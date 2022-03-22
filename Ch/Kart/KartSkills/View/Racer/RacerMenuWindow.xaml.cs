using System;
using System.Windows;
using System.Windows.Threading;
using KartSkills.Lib;
using KartSkills.Models;
using KartSkills.View.Dialogs;

namespace KartSkills.View.Racer
{
    /// <summary>
    /// Логика взаимодействия для RacerMenuWindow.xaml
    /// </summary>
    public partial class RacerMenuWindow : Window
    {

        private User _user;
        
        public RacerMenuWindow(User user)
        {
            this._user = user;
            InitializeComponent();
        }
        
        public RacerMenuWindow()
        {
            InitializeComponent();
        }

        private void StartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Timer.start((text => { TextTimer.Text = text; }));
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new MainWindow());
            Close();
        }

        private void Contacts_Click(object sender, RoutedEventArgs e)
        {
            var contact = new ContactsWindow();
            contact.ShowDialog();
        }

        private void RaceRegiseter_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new RaceRegisterWindow(this._user));
            Close();
        }

        private void ProfileEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new ProfileEditWindow(this._user));
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new ResultsWindow());
            Close();
        }
    }
}

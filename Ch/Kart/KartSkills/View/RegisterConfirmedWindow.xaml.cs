using System;
using System.Windows;
using System.Windows.Threading;
using KartSkills.Lib;
using KartSkills.Models;
using KartSkills.View.Racer;

namespace KartSkills.View
{
    /// <summary>
    /// Логика взаимодействия для RegisterConfirmedWindow.xaml
    /// </summary>
    public partial class RegisterConfirmedWindow : Window
    {
        public RegisterConfirmedWindow()
        {
            InitializeComponent();
        }
        
        private User _user;
        public RegisterConfirmedWindow(User user)
        {
            InitializeComponent();
            this._user = user;
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

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new RacerMenuWindow(this._user));
            Close();
        }
    }
}

using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using KartSkills.Lib;

namespace KartSkills.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void StartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Timer.start((text => { TextTimer.Text = text; }));
        }

        private void SponsorRegister_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WindowHelper.OpenNewWindow(new SponsorWindow());
            Close();
        }

        private void Information_Click(object sender, MouseButtonEventArgs e)
        {
            WindowHelper.OpenNewWindow(new InfoWindow());
            Close();
        }

        private void Login_Click(object sender, MouseButtonEventArgs e)
        {
            WindowHelper.OpenNewWindow(new LoginWindow());
            Close();
        }

        private void Register_Click(object sender, MouseButtonEventArgs e)
        {
            WindowHelper.OpenNewWindow(new CheckRacerWindow());
            Close();
        }
    }
}

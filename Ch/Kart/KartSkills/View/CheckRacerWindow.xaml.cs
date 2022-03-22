using System;
using System.Windows;
using System.Windows.Threading;
using KartSkills.Lib;
using KartSkills.View.Racer;

namespace KartSkills.View
{
    /// <summary>
    /// Логика взаимодействия для CheckRacerWindow.xaml
    /// </summary>
    public partial class CheckRacerWindow : Window
    {
        public CheckRacerWindow()
        {
            InitializeComponent();
        }
       
        private void StartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Timer.start((text => { TextTimer.Text = text; }));
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new MainWindow());
            Close();
        }
        private void WasInRace_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new LoginWindow());
            Close();
        }

        private void WasntInRace_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new RacerRegisterWindow());
            Close();
        }
    }
}

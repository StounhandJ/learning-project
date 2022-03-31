using System;
using System.Windows;
using System.Windows.Threading;
using KartSkills.Lib;

namespace KartSkills.View
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
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

        private void CharityButton_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new CharityListWindow());
            Close();
        }

        private void KartSkills_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new KartSkillsWindow());
            Close();
        }
    }
}

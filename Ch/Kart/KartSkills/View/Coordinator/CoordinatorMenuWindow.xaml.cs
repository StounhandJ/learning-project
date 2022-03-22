using System;
using System.Windows;
using System.Windows.Threading;
using KartSkills.Lib;

namespace KartSkills.View.Coordinator
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorMenuWindow.xaml
    /// </summary>
    public partial class CoordinatorMenuWindow : Window
    {
        public CoordinatorMenuWindow()
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
    }
}

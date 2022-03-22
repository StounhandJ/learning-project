using System.Windows;
using KartSkills.Lib;
using KartSkills.Models;

namespace KartSkills.View.Racer
{
    /// <summary>
    /// Логика взаимодействия для AllResultsWindow.xaml
    /// </summary>
    public partial class AllResultsWindow : Window
    {
        public AllResultsWindow()
        {
            InitializeComponent();
        }
        
        private User _user;
        
        public AllResultsWindow(User user)
        {
            InitializeComponent();
            this._user = user;
        }
        
        private void StartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Timer.start((text => { TextTimer.Text = text; }));
        }
        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new RacerMenuWindow(this._user));
            Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new MainWindow());
            Close();
        }
    }
}

using System.Windows;
using KartSkills.Lib;
using KartSkills.Models;

namespace KartSkills.View.Racer
{
    /// <summary>
    /// Логика взаимодействия для ResultsWindow.xaml
    /// </summary>
    public partial class ResultsWindow : Window
    {
        public ResultsWindow()
        {
            InitializeComponent();
        }
        
        private User _user;
        
        public ResultsWindow(User user)
        {
            InitializeComponent();
            this._user = user;
        }

        private void AllResultsButton_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new AllResultsWindow(this._user));
            Close();
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

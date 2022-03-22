using System.Windows;
using KartSkills.Lib;
using KartSkills.Models;

namespace KartSkills.View.Admin
{
    /// <summary>
    /// Логика взаимодействия для CreateOrganizationWindow.xaml
    /// </summary>
    public partial class CreateOrganizationWindow : Window
    {
        public CreateOrganizationWindow()
        {
            InitializeComponent();
        }
        
        private User _admin;
        public CreateOrganizationWindow(User admin)
        {
            InitializeComponent();
            this._admin = admin;
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
        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new AdminMenuWindow(this._admin));
            Close();
        }
    }
}

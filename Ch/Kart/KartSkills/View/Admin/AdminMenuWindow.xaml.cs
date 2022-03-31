using System.Windows;
using KartSkills.Lib;
using KartSkills.Models;

namespace KartSkills.View.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminMenuWindow.xaml
    /// </summary>
    public partial class AdminMenuWindow : Window
    {
        public AdminMenuWindow()
        {
            InitializeComponent();
        }

        private User _admin;
        public AdminMenuWindow(User admin)
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new ManagementUserWindow(this._admin));
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new ManagementCharityWindow(this._admin));
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new ManagementVolunteerWindow(this._admin));
            Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new InventoryWindow(this._admin));
            Close();
        }
    }
}

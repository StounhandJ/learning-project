using System.Data;
using System.Linq;
using System.Windows;
using KartSkills.Lib;
using KartSkills.Models;

namespace KartSkills.View.Admin
{
    /// <summary>
    /// Логика взаимодействия для ManagementCharityWindow.xaml
    /// </summary>
    public partial class ManagementCharityWindow : Window
    {
        public ManagementCharityWindow()
        {
            InitializeComponent();
        }
        
        private User _admin;
        public ManagementCharityWindow(User admin)
        {
            InitializeComponent();
            this._admin = admin;
            
            rezult.ItemsSource = SqlHelper.GetTableFromSql($@"select * from [Charity]").AsEnumerable().ToList().ConvertAll(d=>new Charity(d));
        }
        
        private void StartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Timer.start((text => { TextTimer.Text = text; }));
        }
        
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new AdminMenuWindow(this._admin));
            Close();
        }
        
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new MainWindow());
            Close();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new CreateOrganizationWindow(this._admin));
            Close();
        }
    }
}

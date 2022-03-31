using System.Data;
using System.Linq;
using System.Windows;
using KartSkills.Lib;
using KartSkills.Models;

namespace KartSkills.View.Admin
{
    /// <summary>
    /// Логика взаимодействия для ManagementUserWindow.xaml
    /// </summary>
    public partial class ManagementUserWindow : Window
    {
        public ManagementUserWindow()
        {
            InitializeComponent();
        }

        private User _admin;
        public ManagementUserWindow(User admin)
        {
            InitializeComponent();
            this._admin = admin;
            
            RoleComboBox.ItemsSource = SqlHelper.GetTableFromSql($@"select * from [Role]").AsEnumerable().ToList().ConvertAll(d=>new Role(d));
            RoleComboBox.DisplayMemberPath = "RoleName";
            RoleComboBox.SelectedValuePath = "IdRole";
            
            UserComboBox.ItemsSource = SqlHelper.GetTableFromSql($@"select * from [User]").AsEnumerable().ToList().ConvertAll(d=>new User(d));
            UserComboBox.DisplayMemberPath = "LastName";
            UserComboBox.SelectedValuePath = "Email";
            
            rezult.ItemsSource = SqlHelper.GetTableFromSql($@"select * from [Racer]").AsEnumerable().ToList().ConvertAll(d=>new Models.Racer(d));
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
            WindowHelper.OpenNewWindow(new CreateUserWindow(this._admin));
            Close();
        }
    }
}
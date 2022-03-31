using System.Data;
using System.Linq;
using System.Windows;
using KartSkills.Lib;
using KartSkills.Models;

namespace KartSkills.View.Admin
{
    /// <summary>
    /// Логика взаимодействия для ManagementVolunteerWindow.xaml
    /// </summary>
    public partial class ManagementVolunteerWindow : Window
    {
        public ManagementVolunteerWindow()
        {
            InitializeComponent();
        }

        private User _admin;

        public ManagementVolunteerWindow(User admin)
        {
            InitializeComponent();
            this._admin = admin;

            VolunteerComboBox.ItemsSource = SqlHelper.GetTableFromSql($@"select * from [Volunteer]").AsEnumerable()
                .ToList().ConvertAll(d => new Volunteer(d));
            VolunteerComboBox.DisplayMemberPath = "LastName";
            VolunteerComboBox.SelectedValuePath = "IdVolunteer";
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
            WindowHelper.OpenNewWindow(new ParserVolunteerWindow(this._admin));
            Close();
        }
    }
}
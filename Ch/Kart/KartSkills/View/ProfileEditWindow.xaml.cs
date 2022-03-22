using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using KartSkills.Lib;
using KartSkills.Models;
using KartSkills.View.Racer;
using Microsoft.Win32;

namespace KartSkills.View
{
    /// <summary>
    /// Логика взаимодействия для ProfileEditWindow.xaml
    /// </summary>
    public partial class ProfileEditWindow : Window
    {
        private User _user;

        public ProfileEditWindow(User user)
        {
            this._user = user;
            InitializeComponent();
            ComboBoxGender.ItemsSource = SqlHelper.GetTableFromSql($@"select * from [Gender]").AsEnumerable().ToList()
                .ConvertAll(d => new Gender(d));
            ComboBoxGender.DisplayMemberPath = "GenderName";
            ComboBoxGender.SelectedValuePath = "IdGender";

            CountryComboBox.ItemsSource = SqlHelper.GetTableFromSql($@"select * from [Country]").AsEnumerable().ToList()
                .ConvertAll(d => new Country(d));
            CountryComboBox.DisplayMemberPath = "CountryName";
            CountryComboBox.SelectedValuePath = "IdCountry";

            EmailBox.Text = this._user.Email;
            PasswordBox.Text = this._user.Password;
            PaswordRepeatBox.Text = this._user.Password;
            NameBox.Text = this._user.FirstName;
            LastNameBox.Text = this._user.LastName;


            var data = SqlHelper
                .GetTableFromSql(
                    $@"select top 1 * from [Racer] where First_Name='{NameBox.Text}' and Last_Name='{LastNameBox.Text}'")
                .AsEnumerable().ToList();
            Models.Racer r = new Models.Racer(data[0]);

            if (r.Photo != null)
            {
                photoPath = Directory.GetCurrentDirectory() + $@"\RacersImages\{r.Photo}";
                photoName = r.Photo;

                Photo.Source = new BitmapImage(new Uri(photoPath));
                BoxFileName.Text = photoName;
                
                ComboBoxGender.SelectedIndex = ComboBoxGender.Items.IndexOf(new Gender() { IdGender = r.Gender });
                CountryComboBox.SelectedIndex = CountryComboBox.Items.IndexOf(new Country() { IdCountry = r.IdCountry });
                DateOfBirthBox.SelectedDate = r.DateOfBirth;
            }
        }

        public ProfileEditWindow()
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

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new RacerMenuWindow(this._user));
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Text != "" && PaswordRepeatBox.Text.Equals(PasswordBox.Text) &&
                ComboBoxGender.SelectedValue != null && NameBox.Text.Length > 1 && LastNameBox.Text.Length > 1 &&
                CountryComboBox.SelectedValue != null && photoName != "" && DateOfBirthBox.SelectedDate != null)
            {
                if (!MailAddress.TryCreate(EmailBox.Text, out _))
                {
                    MessageBox.Show("Неправильная почта");
                    return;
                }

                try
                {
                    SqlHelper.GetTableFromSql(
                        $@"update [User] SET Email = N'{EmailBox.Text}', [Password] = N'{PasswordBox.Text}', First_Name = N'{NameBox.Text}', Last_Name = N'{LastNameBox.Text}' where First_Name='{NameBox.Text}' and Last_Name='{LastNameBox.Text}'");
                    SqlHelper.GetTableFromSql(
                        $@"update [dbo].[Racer] SET [First_Name] = N'{NameBox.Text}', [Last_Name] = N'{LastNameBox.Text}', [Gender] = N'{ComboBoxGender.SelectedValue}', [DateOfBirth] = N'{DateOfBirthBox.Text}', [ID_Country] = N'{CountryComboBox.SelectedValue}', [Photo] = N'{photoName}' where First_Name='{NameBox.Text}' and Last_Name='{LastNameBox.Text}'");

                    if (!Directory.Exists(Directory.GetCurrentDirectory() + $@"\RacersImages"))
                    {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + $@"\RacersImages");
                    }

                    if (!File.Exists(Directory.GetCurrentDirectory() + $@"\RacersImages\{photoName}"))
                    {
                        File.Copy(photoPath, Directory.GetCurrentDirectory() + $@"\RacersImages\{photoName}");
                    }

                    WindowHelper.OpenNewWindow(new RacerMenuWindow(this._user));
                    Close();
                }
                catch
                {
                    MessageBox.Show("Ведены неправильные данные");
                }
            }
        }

        string photoName = "";
        string photoPath = "";

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                photoPath = openFileDialog.FileName;
                photoName = System.IO.Path.GetFileName(photoPath);

                Photo.Source = new BitmapImage(new Uri(photoPath));
                BoxFileName.Text = photoName;
            }
        }
    }
}
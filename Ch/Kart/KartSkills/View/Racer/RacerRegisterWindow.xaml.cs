using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using KartSkills.Lib;
using KartSkills.Models;
using Microsoft.Win32;

namespace KartSkills.View.Racer
{
    /// <summary>
    /// Логика взаимодействия для RacerRegisterWindow.xaml
    /// </summary>
    public partial class RacerRegisterWindow : Window
    {
        
        //TODO заполнить списки правильно
        public RacerRegisterWindow()
        {
            InitializeComponent();
            ComboBoxGender.ItemsSource = SqlHelper.GetTableFromSql($@"select * from [Gender]").AsEnumerable().ToList().ConvertAll(d=>new Gender(d));
            ComboBoxGender.DisplayMemberPath = "GenderName";
            ComboBoxGender.SelectedValuePath = "IdGender";
            
            CountryComboBox.ItemsSource = SqlHelper.GetTableFromSql($@"select * from [Country]").AsEnumerable().ToList().ConvertAll(d=>new Country(d));
            CountryComboBox.DisplayMemberPath = "CountryName";
            CountryComboBox.SelectedValuePath = "IdCountry";
        }

        string photoName = "";
        string photoPath = "";

        private void StartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Timer.start((text => { TextTimer.Text = text; }));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new MainWindow());
            Close();
        }

        private void RRegister_Click(object sender, RoutedEventArgs e)
        {
            if (EmailBox.Text != "" && PasswordBox.Text != "" && PaswordRepeatBox.Text.Equals(PasswordBox.Text) &&
                ComboBoxGender.SelectedValue != null && NameBox.Text.Length > 1 && LastNameBox.Text.Length > 1 &&
                CountryComboBox.SelectedValue != null && photoName != "" && DateOfBirthBox.SelectedDate != null)
            {
                if (!MailAddress.TryCreate(EmailBox.Text, out _))
                {
                    MessageBox.Show("Неправильная почта");
                    return;
                }

                DataTable findIDEmploy =
                    SqlHelper.GetTableFromSql(
                        $@"select * from [User] where Email='{EmailBox.Text}'");
                if (findIDEmploy.Rows.Count != 0)
                {
                    MessageBox.Show("Введите другую почту");
                    return;
                }

                try
                {
                    SqlHelper.GetTableFromSql(
                        $@"INSERT INTO [dbo].[User] (Email, [Password], First_Name, Last_Name, ID_Role) values (N'{EmailBox.Text}',N'{PasswordBox.Text}',	N'{NameBox.Text}',	N'{LastNameBox.Text}',	N'R')");
                    SqlHelper.GetTableFromSql(
                        $@"INSERT INTO [dbo].[Racer] ( [First_Name], [Last_Name], [Gender], [DateOfBirth], [ID_Country], [Photo]) VALUES ( N'{NameBox.Text}', N'{LastNameBox.Text}', N'{ComboBoxGender.SelectedValue}', N'{DateOfBirthBox.Text}', N'{CountryComboBox.SelectedValue}', N'{photoName}')");

                    if (!Directory.Exists(Directory.GetCurrentDirectory() + $@"\RacersImages"))
                    {
                        Directory.CreateDirectory(Directory.GetCurrentDirectory() + $@"\RacersImages");
                    }
                    
                    File.Copy(photoPath, Directory.GetCurrentDirectory() + $@"\RacersImages\{photoName}");
                    MessageBox.Show("Вы успешно зарегестрировались");
                    
                    DataTable table = SqlHelper.GetTableFromSql(
                $"select * from [User] where [Email] = '{EmailBox.Text}' and [Password] = '{PasswordBox.Text}'");
                    
                    WindowHelper.OpenNewWindow(new RaceRegisterWindow(new User(table.Rows[0])));
                    Close();
                }
                catch
                {
                    MessageBox.Show("Ведены неправильные данные");
                }
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
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
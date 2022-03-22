using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using KartSkills.Lib;
using KartSkills.Models;

namespace KartSkills.View.Racer
{
    /// <summary>
    /// Логика взаимодействия для RaceRegisterWindow.xaml
    /// </summary>
    public partial class RaceRegisterWindow : Window
    {

        private User _user;

        public RaceRegisterWindow(User user)
        {
            InitializeComponent();
            this._user = user;

            ComboBoxCharity.ItemsSource = SqlHelper.GetTableFromSql($@"select * from [Charity]").AsEnumerable().ToList()
                .ConvertAll(d => new Charity(d));
            ComboBoxCharity.DisplayMemberPath = "CharityName";
            ComboBoxCharity.SelectedValuePath = "IdСharity";

            update();
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

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new RegisterConfirmedWindow(this._user));
            Close();
        }

        private int _amount;

        private void update()
        {
            TextAmount.Text = "$" + this._amount;
        }

        private void ToggleButton_OnChecked(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(((CheckBox)sender).Tag.ToString() ?? string.Empty);
            if (((CheckBox)sender).IsChecked ?? false)
            {
                _amount += a;
            }

            if (!((CheckBox)sender).IsChecked ?? false)
            {
                _amount -= a;
            }

            update();
        }

        private void RadioA_OnChecked(object sender, RoutedEventArgs e)
        {
            int a = int.Parse(((RadioButton)sender).Tag.ToString() ?? string.Empty);
            if (((RadioButton)sender).IsChecked ?? false)
            {
                _amount += a;
            }

            if (!((RadioButton)sender).IsChecked ?? false)
            {
                _amount -= a;
            }

            update();
        }

    }
}
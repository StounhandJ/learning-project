using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using KartSkills.Lib;

namespace KartSkills.View
{
    /// <summary>
    /// Логика взаимодействия для SponsorWindow.xaml
    /// </summary>
    public partial class SponsorWindow : Window
    {
        public SponsorWindow()
        {
            InitializeComponent();
            RacerComboBox.ItemsSource = SqlHelper.GetTableFromSql($@"select * from [Racer]").AsEnumerable().ToList()
                .ConvertAll(d => new Models.Racer(d));
            RacerComboBox.DisplayMemberPath = "FIO";
            RacerComboBox.SelectedValuePath = "IdRacer";
        }

        private void StartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Timer.start((text => { TextTimer.Text = text; }));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new MainWindow());
            Close();
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            if (RacerComboBox.SelectedValue == null || NameTextBox.Text.Length == 0 ||
                OwnerCardTextBox.Text.Length == 0 || NumberCardTextBox.Text.Length != 16 ||
                MonthTextBox.Text.Length != 2 || YearTextBox.Text.Length != 4 || CvcTextBox.Password.Length != 3 ||
                AmountTextBox.Text.Length == 0)
            {
                MessageBox.Show("Не все данные заполнены");
                return;
            }

            if (!long.TryParse(NumberCardTextBox.Text, out _))
            {
                MessageBox.Show("Неккоректный номер карты");
                return;
            }

            if (!int.TryParse(MonthTextBox.Text, out _))
            {
                MessageBox.Show("Неккоректный cрок действия");
                return;
            }

            if (!int.TryParse(YearTextBox.Text, out _))
            {
                MessageBox.Show("Неккоректный cрок действия");
                return;
            }

            if (!int.TryParse(CvcTextBox.Password, out _))
            {
                MessageBox.Show("Неккоректный CVC");
                return;
            }

            if (MonthTextBox.Text[0] == '0' || Convert.ToInt32(MonthTextBox.Text) > 12)
            {
                MessageBox.Show("Неккоректный cрок действия");
                return;
            }

            DateTime date = new DateTime(Convert.ToInt32(YearTextBox.Text), Convert.ToInt32(MonthTextBox.Text), 1);
            if (DateTime.Today > date)
            {
                MessageBox.Show("Срок действия карты истек");
                return;
            }

            SqlHelper.GetTableFromSql(
                $@"insert into Sponsorship (SponsorName, Amount) values('{NameTextBox.Text}','{AmountTextBox.Text}')");
            WindowHelper.OpenNewWindow(new SponsorThanksWindow(NameTextBox.Text, AmountTextBox.Text));
            Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void AmountTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            TextAmount.Text = AmountTextBox.Text;
        }

        private void ButtonBaseM_OnClick(object sender, RoutedEventArgs e)
        {
            TextAmount.Text = (Convert.ToInt32(AmountTextBox.Text) - 25).ToString();
            AmountTextBox.Text = (Convert.ToInt32(AmountTextBox.Text) - 25).ToString();
        }

        private void ButtonBaseP_OnClick(object sender, RoutedEventArgs e)
        {
            TextAmount.Text = (Convert.ToInt32(AmountTextBox.Text) + 25).ToString();
            AmountTextBox.Text = (Convert.ToInt32(AmountTextBox.Text) + 25).ToString();
        }
    }
}
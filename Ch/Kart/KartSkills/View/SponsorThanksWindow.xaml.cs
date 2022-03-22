using System;
using System.Windows;
using System.Windows.Threading;
using KartSkills.Lib;

namespace KartSkills.View
{
    /// <summary>
    /// Логика взаимодействия для SponsorThanksWindow.xaml
    /// </summary>
    public partial class SponsorThanksWindow : Window
    {
        public SponsorThanksWindow(string name, string amount)
        {
            InitializeComponent();
            TextAmount.Text = "$" + amount;
            TextName.Text = name;
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
    }
}
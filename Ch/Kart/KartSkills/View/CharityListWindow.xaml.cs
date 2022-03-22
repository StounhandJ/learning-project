using System;
using System.Windows;
using System.Windows.Threading;
using KartSkills.Lib;
using KartSkills.View.UserControll;

namespace KartSkills.View
{
    /// <summary>
    /// Логика взаимодействия для CharityListWindow.xaml
    /// </summary>
    public partial class CharityListWindow : Window
    {
        public CharityListWindow()
        {
            InitializeComponent();
        }
        
        private void StartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Timer.start((text => { TextTimer.Text = text; }));
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new InfoWindow());
            Close();
        }

        private void InsertDataInList()
        {
            for (int i = 0; i < 3; i++)
                ListCharity.Items.Add(new CharityCard());
        }
    }
}

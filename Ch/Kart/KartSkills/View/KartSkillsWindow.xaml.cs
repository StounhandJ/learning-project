using System;
using System.Windows;
using System.Windows.Threading;
using KartSkills.Lib;

namespace KartSkills.View
{
    /// <summary>
    /// Логика взаимодействия для KartSkillsWindow.xaml
    /// </summary>
    public partial class KartSkillsWindow : Window
    {
        public KartSkillsWindow()
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

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            WindowHelper.OpenNewWindow(new MapWindow());
            Close();
        }
    }
}

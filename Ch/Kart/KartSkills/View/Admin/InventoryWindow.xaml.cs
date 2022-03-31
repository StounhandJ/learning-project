using System.Collections.Generic;
using System.Windows;
using KartSkills.Lib;
using KartSkills.Models;

namespace KartSkills.View.Admin
{
    /// <summary>
    /// Логика взаимодействия для InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        public InventoryWindow()
        {
            InitializeComponent();
        }

        private User _admin;
        public InventoryWindow(User admin)
        {
            InitializeComponent();
            this._admin = admin;
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

        
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
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
using KartSkills.Lib;
using KartSkills.Models;

namespace KartSkills.View.Admin
{
    /// <summary>
    /// Логика взаимодействия для ParserVolunteerWindow.xaml
    /// </summary>
    public partial class ParserVolunteerWindow : Window
    {
        public ParserVolunteerWindow()
        {
            InitializeComponent();
        }
        
        private User _admin;
        public ParserVolunteerWindow(User admin)
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
            WindowHelper.OpenNewWindow(new ManagementVolunteerWindow(this._admin));
            Close();
        }
    }
}

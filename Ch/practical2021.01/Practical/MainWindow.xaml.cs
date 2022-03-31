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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Practical
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContent.Content = new TablesPage.StudentPage();
        }

        private void PersonalMatters_OnClick(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TablesPage.PersonalMattersPage();
        }
        
        private void Student_OnClick(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TablesPage.StudentPage();
        }

        private void Teacher_OnClick(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TablesPage.TeacherPage();
        }

        private void Faculty_OnClick(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TablesPage.FacultyPage();
        }

        private void Group_OnClick(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TablesPage.GroupPage();
        }

        private void Lesson_OnClick(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TablesPage.LessonPage();
        }

        private void PriceTuition_OnClick(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TablesPage.PriceTuitionPage();
        }

        private void Marks_OnClick(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TablesPage.MarksPage();
        }

        private void Schedule_OnClick(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TablesPage.SchedulePage();
        }

        private void Workload_OnClick(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new TablesPage.WorkloadPage();
        }
    }
}

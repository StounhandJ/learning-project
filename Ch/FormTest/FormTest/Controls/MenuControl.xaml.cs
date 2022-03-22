using System;
using System.Windows;
using System.Windows.Controls;

namespace FormTest.Controls
{
    public partial class MenuControl : UserControl
    {
        public event Action Exit;
        
        public event Action UserMenu;
        
        public event Action GroupMenu;
        
        public event Action LessonMenu;

        public event Action CreateFormMenu;
        
        public event Action ShowResultMenu;

        public event Action PassageFormMenu;
        
        public event Action ShowResultStudentMenu;

        private bool _isAdmin;
        public bool IsAdmin
        {
            get
            {
                return _isAdmin;
            }
            set
            {
                if (value)
                {
                    AdminMenuItem.Visibility = Visibility.Visible;
                    AdminMenuItem.IsEnabled = true;
                }
                else
                {
                    AdminMenuItem.Visibility = Visibility.Hidden;
                    AdminMenuItem.IsEnabled = false;
                }
                _isAdmin = value;
            }
        }
        
        private bool _isTeacher;
        public bool IsTeacher
        {
            get
            {
                return _isTeacher;
            }
            set
            {
                if (value)
                {
                    TeacherMenuItem.Visibility = Visibility.Visible;
                    TeacherMenuItem.IsEnabled = true;
                }
                else
                {
                    TeacherMenuItem.Visibility = Visibility.Hidden;
                    TeacherMenuItem.IsEnabled = false;
                }
                _isTeacher = value;
            }
        }
        
        private bool _isStudent;
        public bool IsStudent
        {
            get
            {
                return _isStudent;
            }
            set
            {
                if (value)
                {
                    StudentMenuItem.Visibility = Visibility.Visible;
                    StudentMenuItem.IsEnabled = true;
                }
                else
                {
                    StudentMenuItem.Visibility = Visibility.Hidden;
                    StudentMenuItem.IsEnabled = false;
                }
                _isStudent = value;
            }
        }

        public MenuControl()
        {
            InitializeComponent();
        }

        private void Exit_OnClick(object sender, RoutedEventArgs e)
        {
            Exit?.Invoke();
        }
        
        private void UserMenu_OnClick(object sender, RoutedEventArgs e)
        {
            UserMenu?.Invoke();
        }
        
        private void GroupMenu_OnClick(object sender, RoutedEventArgs e)
        {
            GroupMenu?.Invoke();
        }
        
        private void LessonMenu_OnClick(object sender, RoutedEventArgs e)
        {
            LessonMenu?.Invoke();
        }
        
        private void CreateFormMenu_OnClick(object sender, RoutedEventArgs e)
        {
            CreateFormMenu?.Invoke();
        }
        
        private void ShowResultMenu_OnClick(object sender, RoutedEventArgs e)
        {
            ShowResultMenu?.Invoke();
        }

        private void PassageFormMenu_OnClick(object sender, RoutedEventArgs e)
        {
            PassageFormMenu?.Invoke();
        }

        private void ShowResultStudentMenu_OnClick(object sender, RoutedEventArgs e)
        {
            ShowResultStudentMenu?.Invoke();
        }
    }
}
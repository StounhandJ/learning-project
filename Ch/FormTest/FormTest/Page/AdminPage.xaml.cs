using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using FormTest.Enums;
using FormTest.Structs;

namespace FormTest.Page
{
    public partial class AdminPage : System.Windows.Controls.Page
    {
        public event Action Exit;

        private UsersController _usersController;
        
        private GroupsController _groupsController;
        
        private LessonController _lesonsController;

        public AdminPage()
        {
            InitializeComponent();
            this._usersController = new UsersController();
            this._groupsController = new GroupsController();
            this._lesonsController = new LessonController();

            this.allUpdateCheckBox();

            this.MenuControl_OnUserMenu();
        }

        // Работа с пользователями //
        private void ChangeUserControl_OnCreateUser(string login, string password, string fio, TypeOfUser typeOfUser)
        {
            this._usersController.createUser(login, password, fio, typeOfUser);
            
            this.allUpdateCheckBox();
        }
        
        private void ChangeUserControl_OnChangeUser(User user, string login, string password, string fio, TypeOfUser typeOfUser)
        {
            this._usersController.changeUser(user.id, login, password, fio, typeOfUser);
            
            this.allUpdateCheckBox();
        }
        
        private void ChangeUserControl_OnDeleteUser(User user)
        {
            this._usersController.delUser(user.id);
            
            this.allUpdateCheckBox();
        }
        
        // Работа с группами //
        private void ChangeGroupControl_OnCreateGroup(string name, List<User> students)
        {
            this._groupsController.createGroup(name, students);
            
            this.allUpdateCheckBox();
        }
        
        private void ChangeGroupControl_OnChangeGroup(Group group, string name, List<User> students)
        {
            this._groupsController.changeGroup(group.id, name, students);
            
            this.allUpdateCheckBox();
        }

        private void ChangeGroupControl_OnDeleteGroup(Group group)
        {
            this._groupsController.delGroup(group.id);
            
            this.allUpdateCheckBox();
        }
        
        // Работа с предметами //
        private void ChangeLessonControl_OnCreateLesson(string name, User teacher, List<Group> groups)
        {
            this._lesonsController.createLesson(name, teacher, groups);
            
            this.allUpdateCheckBox();
        }

        private void ChangeLessonControl_OnChangeLesson(Lesson lesson, string name, User teacher, List<Group> groups)
        {
            this._lesonsController.changeLesson(lesson.id, name, teacher, groups);
            
            this.allUpdateCheckBox();
        }

        private void ChangeLessonControl_OnDeleteLesson(Lesson lesson)
        {
            this._lesonsController.delLesson(lesson.id);
            
            this.allUpdateCheckBox();
        }

        private void MenuControl_OnUserMenu()
        {
            HiddenAllChangeControl();
            
            ChangeUserControl.Visibility = Visibility.Visible;
            ChangeUserControl.IsEnabled = true;
        }
        
        private void MenuControl_OnGroupMenu()
        {
            HiddenAllChangeControl();
            
            ChangeGroupControl.Visibility = Visibility.Visible;
            ChangeGroupControl.IsEnabled = true;
        }

        private void MenuControl_OnLessonMenu()
        {
            HiddenAllChangeControl();
            
            ChangeLessonControl.Visibility = Visibility.Visible;
            ChangeLessonControl.IsEnabled = true;
        }

        private void HiddenAllChangeControl()
        {
            ChangeUserControl.Visibility = Visibility.Hidden;
            ChangeUserControl.IsEnabled = false;
            
            ChangeGroupControl.Visibility = Visibility.Hidden;
            ChangeGroupControl.IsEnabled = false;
            
            ChangeLessonControl.Visibility = Visibility.Hidden;
            ChangeLessonControl.IsEnabled = false;
        }

        private void allUpdateCheckBox()
        {
            this.ChangeUserControl.Users = this._usersController.users;
            
            this.ChangeGroupControl.Groups = this._groupsController.groups;
            this.ChangeGroupControl.Students = this._usersController.getUsersTypeOf(TypeOfUser.Studen);
            
            this.ChangeLessonControl.Groups = this._groupsController.groups;
            this.ChangeLessonControl.Lessons = this._lesonsController.lessons;
            this.ChangeLessonControl.Teachers = this._usersController.getUsersTypeOf(TypeOfUser.Teachaer);
        }
        private void Close()
        {
            Exit?.Invoke();
        }
    }
}
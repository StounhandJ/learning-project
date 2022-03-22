using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using InventoryOfEquipment.Command;
using InventoryOfEquipment.Lib;
using InventoryOfEquipment.Models;

namespace InventoryOfEquipment.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            ActivityRegister = true;
            ActivityAuthorization = true;
            _clickCommand = new ChangePageCommand(this);
            _exitCommand = new RelayCommand(obj =>
            {
                Content = new Page();
                User = null;
            });
            Roles = new ObservableCollection<Role>(Role.getAll());
            Users = new ObservableCollection<User>(User.getAll());
            Departments = new ObservableCollection<Department>(Department.getAll());
        }

        private User _user;

        public User User
        {
            get => _user;
            set
            {
                _user = value;
                checkUser();
                this.OnPropertyChanged(nameof(User));
            }
        }

        private ObservableCollection<Role> _roles;

        public ObservableCollection<Role> Roles
        {
            get => _roles;
            set
            {
                _roles = value;
                this.OnPropertyChanged(nameof(Roles));
            }
        }
        
        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                this.OnPropertyChanged(nameof(Users));
            }
        }
        
         private ObservableCollection<Department> _departments;

        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set
            {
                _departments = value;
                this.OnPropertyChanged(nameof(Departments));
            }
        }

        private bool _activityRegister { get; set; }

        public bool ActivityRegister
        {
            get => _activityRegister;
            set
            {
                _activityRegister = value;
                this.OnPropertyChanged(nameof(ActivityRegister));
            }
        }

        private bool _activityAuthorization { get; set; }

        public bool ActivityAuthorization
        {
            get => _activityAuthorization;
            set
            {
                _activityAuthorization = value;
                this.OnPropertyChanged(nameof(ActivityAuthorization));
            }
        }

        private bool _activityAccounting { get; set; }

        public bool ActivityAccounting
        {
            get => _activityAccounting;
            set
            {
                _activityAccounting = value;
                this.OnPropertyChanged(nameof(ActivityAccounting));
            }
        }

        private bool _activityEmployee { get; set; }

        public bool ActivityEmployee
        {
            get => _activityEmployee;
            set
            {
                _activityEmployee = value;
                this.OnPropertyChanged(nameof(ActivityEmployee));
            }
        }

        private bool _activityAdministrator { get; set; }

        public bool ActivityAdministrator
        {
            get => _activityAdministrator;
            set
            {
                _activityAdministrator = value;
                this.OnPropertyChanged(nameof(ActivityAdministrator));
            }
        }

        private Page _content { get; set; }

        public Page Content
        {
            get => _content;
            set
            {
                _content = value;
                this.OnPropertyChanged(nameof(Content));
            }
        }

        private ICommand _clickCommand;

        public ICommand ClickCommand
        {
            get { return _clickCommand; }
        }

        private ICommand _exitCommand;

        public ICommand ExitCommand
        {
            get { return _exitCommand; }
        }

        public void checkUser()
        {
            ActivityRegister = false;
            ActivityAuthorization = false;
            ActivityAccounting = false;
            ActivityEmployee = false;
            ActivityAdministrator = false;
            if (User != null)
            {
                if (User.Role.ID == Role.Accountant)
                {
                    ActivityAccounting = true;
                }

                if (User.Role.ID == Role.Employee)
                {
                    ActivityEmployee = true;
                }

                if (User.Role.ID == Role.AdministratorDB)
                {
                    ActivityAdministrator = true;
                }
            }
            else
            {
                ActivityRegister = true;
                ActivityAuthorization = true;
            }
        }
    }
}
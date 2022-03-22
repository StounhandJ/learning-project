using System.Windows.Input;
using InventoryOfEquipment.Command;
using InventoryOfEquipment.Models;

namespace InventoryOfEquipment.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel()
        {
            _registerCommand = new RegisterCommand(this);
        }
        
        private ICommand _registerCommand;

        public ICommand RegisterCommand
        {
            get { return _registerCommand; }
        }

        private string _surname;

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                this.OnPropertyChanged(nameof(Surname));
            }
        }
        
        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                this.OnPropertyChanged(nameof(FirstName));
            }
        }
        
        private string _patronymic;

        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                this.OnPropertyChanged(nameof(Patronymic));
            }
        }
        
        private Role _role;

        public Role Role
        {
            get => _role;
            set
            {
                _role = value;
                this.OnPropertyChanged(nameof(Role));
            }
        }
        
        private MainViewModel _dataContext;

        public MainViewModel DataContext
        {
            get => _dataContext;
            set
            {
                _dataContext = value;
                this.OnPropertyChanged(nameof(DataContext));
            }
        }
    }
}
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using InventoryOfEquipment.Annotations;
using InventoryOfEquipment.Lib;
using InventoryOfEquipment.Models;

namespace InventoryOfEquipment.ViewModels
{
    public class AdministratorViewModel : BaseViewModel
    {
        public AdministratorViewModel()
        {
            _deleteCommand = new RelayCommand(obj =>
            {
                if (SelectedItem != null)
                {
                    SelectedItem.delete();
                    DataContext.Users.Remove(SelectedItem);
                    this.OnPropertyChanged(nameof(FilterUsers));
                }
            });
        }

        private ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get { return _deleteCommand; }
        }
        public ObservableCollection<User> FilterUsers
        {
            get
            {
                if (FilterSeletedDepartment == null)
                {
                    return DataContext.Users;
                }

                return new ObservableCollection<User>(DataContext.Users.Where(equ =>
                    equ.Role.Department.ID == FilterSeletedDepartment.ID));
            }
        }
        
        [CanBeNull] private Department _filterSeletedDate;

        [CanBeNull]
        public Department FilterSeletedDepartment
        {
            get => _filterSeletedDate;
            set
            {
                _filterSeletedDate = value;
                this.OnPropertyChanged(nameof(FilterSeletedDepartment));
                this.OnPropertyChanged(nameof(FilterUsers));
            }
        }
        
        [CanBeNull] private User _selectedItem;

        [CanBeNull]
        public User SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;

                this.OnPropertyChanged(nameof(SelectedItem));
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
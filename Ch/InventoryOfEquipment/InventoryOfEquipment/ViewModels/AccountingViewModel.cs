using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using InventoryOfEquipment.Annotations;
using InventoryOfEquipment.Command;
using InventoryOfEquipment.Lib;
using InventoryOfEquipment.Models;

namespace InventoryOfEquipment.ViewModels
{
    public class AccountingViewModel : BaseViewModel
    {
        public AccountingViewModel()
        {
            _createEquipmentCommand = new CreateEquipmentCommand(this);
            _editEquipmentCommand = new EditEquipmentCommand(this);
            _deleteEquipmentCommand = new RelayCommand(obj =>
            {
                if (SelectedItem != null)
                {
                    SelectedItem.delete();
                    Equipments.Remove(SelectedItem);
                }
            });
            Equipments = new ObservableCollection<Equipment>(Equipment.getAll());
        }

        private ICommand _createEquipmentCommand;

        public ICommand CreateEquipmentCommand
        {
            get { return _createEquipmentCommand; }
        }

        private ICommand _editEquipmentCommand;

        public ICommand EditEquipmentCommand
        {
            get { return _editEquipmentCommand; }
        }

        private ICommand _deleteEquipmentCommand;

        public ICommand DeleteEquipmentCommand
        {
            get { return _deleteEquipmentCommand; }
        }

        private User _selectedUser;

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                this.OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private ObservableCollection<Equipment> _equipments;

        public ObservableCollection<Equipment> Equipments
        {
            get => _equipments;
            set
            {
                _equipments = value;
                this.OnPropertyChanged(nameof(Equipments));
                this.OnPropertyChanged(nameof(FilterEquipments));
            }
        }

        public ObservableCollection<Equipment> FilterEquipments
        {
            get
            {
                if (FilterSeletedDate == null)
                {
                    return Equipments;
                }

                return new ObservableCollection<Equipment>(Equipments.Where(equ =>
                    equ.expirationDate == FilterSeletedDate));
            }
        }

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                this.OnPropertyChanged(nameof(Name));
            }
        }

        private string _manufacturer;

        public string Manufacturer
        {
            get => _manufacturer;
            set
            {
                _manufacturer = value;
                this.OnPropertyChanged(nameof(Manufacturer));
            }
        }

        private string _price;

        public string Price
        {
            get => _price;
            set
            {
                _price = value;
                this.OnPropertyChanged(nameof(Price));
            }
        }

        private string _nomer;

        public string Nomer
        {
            get => _nomer;
            set
            {
                _nomer = value;
                this.OnPropertyChanged(nameof(Nomer));
            }
        }

        private DateTime? _expirationDate;

        public DateTime? ExpirationDate
        {
            get => _expirationDate;
            set
            {
                _expirationDate = value;
                this.OnPropertyChanged(nameof(ExpirationDate));
            }
        }

        private DateTime? _datePurchase;

        public DateTime? DatePurchase
        {
            get => _datePurchase;
            set
            {
                _datePurchase = value;
                this.OnPropertyChanged(nameof(DatePurchase));
            }
        }

        private DateTime? _filterSeletedDate;

        public DateTime? FilterSeletedDate
        {
            get => _filterSeletedDate;
            set
            {
                _filterSeletedDate = value;
                this.OnPropertyChanged(nameof(FilterSeletedDate));
                this.OnPropertyChanged(nameof(FilterEquipments));
            }
        }

        [CanBeNull] private Equipment _selectedItem;

        [CanBeNull]
        public Equipment SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                if (value == null)
                {
                    SelectedUser = DataContext.Users.First();
                    Name = "";
                    Manufacturer = "";
                    Price = "";
                    Nomer = "";
                    ExpirationDate = null;
                    DatePurchase = null;
                }
                else
                {
                    SelectedUser = value.User;
                    Name = value.name;
                    Manufacturer = value.manufacturer;
                    Price = value.price.ToString();
                    Nomer = value.nomer.ToString();
                    ExpirationDate = value.expirationDate;
                    DatePurchase = value.datePurchase;
                }

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
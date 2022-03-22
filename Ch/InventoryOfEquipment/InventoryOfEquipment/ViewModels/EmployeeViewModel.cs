using System;
using System.Collections.ObjectModel;
using System.Linq;
using InventoryOfEquipment.Models;

namespace InventoryOfEquipment.ViewModels
{
    public class EmployeeViewModel : BaseViewModel
    {

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

        private MainViewModel _dataContext;

        public MainViewModel DataContext
        {
            get => _dataContext;
            set
            {
                _dataContext = value;
                Equipments = new ObservableCollection<Equipment>(Equipment.getAllForUser(value.User));
                this.OnPropertyChanged(nameof(DataContext));
            }
        }
    }
}
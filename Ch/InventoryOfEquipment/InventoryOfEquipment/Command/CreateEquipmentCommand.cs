using System;
using System.Windows.Input;
using InventoryOfEquipment.Models;
using InventoryOfEquipment.ViewModels;

namespace InventoryOfEquipment.Command
{
    public class CreateEquipmentCommand : ICommand
    {
        private readonly AccountingViewModel m_viewModel;

        public CreateEquipmentCommand(AccountingViewModel mViewModel)
        {
            m_viewModel = mViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (string.IsNullOrWhiteSpace(m_viewModel.Name) || m_viewModel.Name.Length > 30)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(m_viewModel.Manufacturer) || m_viewModel.Manufacturer.Length > 30)
            {
                return;
            }

            int nomer;
            if (!int.TryParse(m_viewModel.Nomer, out nomer))
            {
                return;
            }

            double price;
            if (!double.TryParse(m_viewModel.Price, out price))
            {
                return;
            }


            if (m_viewModel.DatePurchase == null)
            {
                return;
            }

            if (m_viewModel.ExpirationDate == null)
            {
                return;
            }

            Equipment equipment = new Equipment(m_viewModel.Name, m_viewModel.Manufacturer,
                m_viewModel.ExpirationDate.Value, m_viewModel.DatePurchase.Value, price, nomer,
                m_viewModel.SelectedUser);
            equipment.save();
            m_viewModel.Equipments.Add(equipment);
        }

        public event EventHandler CanExecuteChanged;
    }
}
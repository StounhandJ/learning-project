using System;
using System.Windows.Input;
using InventoryOfEquipment.ViewModels;

namespace InventoryOfEquipment.Command
{
    public class EditEquipmentCommand: ICommand
    {
        private readonly AccountingViewModel m_viewModel;

        public EditEquipmentCommand(AccountingViewModel mViewModel)
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

            if (m_viewModel.SelectedItem == null)
            {
                return;
            }

            m_viewModel.SelectedItem.name = m_viewModel.Name;
        m_viewModel.SelectedItem.manufacturer = m_viewModel.Manufacturer;
        m_viewModel.SelectedItem.expirationDate = m_viewModel.ExpirationDate.Value;
        m_viewModel.SelectedItem.datePurchase = m_viewModel.DatePurchase.Value;
        m_viewModel.SelectedItem.price = price;
        m_viewModel.SelectedItem.nomer = nomer;
        m_viewModel.SelectedItem.User = m_viewModel.SelectedUser;
        
        m_viewModel.SelectedItem.save();
        }

        public event EventHandler CanExecuteChanged;
    }
}
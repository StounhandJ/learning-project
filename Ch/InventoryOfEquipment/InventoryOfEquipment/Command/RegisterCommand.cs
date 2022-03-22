using System;
using System.Windows.Controls;
using System.Windows.Input;
using InventoryOfEquipment.Models;
using InventoryOfEquipment.ViewModels;

namespace InventoryOfEquipment.Command
{
    public class RegisterCommand : ICommand
    {
        private readonly RegisterViewModel m_viewModel;

        public RegisterCommand(RegisterViewModel vm)
        {
            m_viewModel = vm;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (string.IsNullOrWhiteSpace(m_viewModel.Surname) || m_viewModel.Surname.Length>30)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(m_viewModel.FirstName) || m_viewModel.FirstName.Length>30)
            {
                return;
            }
            if (m_viewModel.Patronymic.Length>30)
            {
                return;
            }
            User user = new User(m_viewModel.Surname, m_viewModel.FirstName, m_viewModel.Patronymic, m_viewModel.Role);
            user.save();
            m_viewModel.DataContext.Users.Add(user);
            m_viewModel.DataContext.Content = new Page();
        }

        public event EventHandler CanExecuteChanged;
    }
}
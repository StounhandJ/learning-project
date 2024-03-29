﻿using System;
using System.Windows.Controls;
using System.Windows.Input;
using InventoryOfEquipment.Models;
using InventoryOfEquipment.ViewModels;

namespace InventoryOfEquipment.Command
{
    public class AuthorizationCommand : ICommand
    {
        private readonly AuthorizationViewModel m_viewModel;

        public AuthorizationCommand(AuthorizationViewModel vm)
        {
            m_viewModel = vm;
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (string.IsNullOrWhiteSpace(m_viewModel.Login) || m_viewModel.Login.Length>20)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(((PasswordBox)parameter).Password) || ((PasswordBox)parameter).Password.Length>20)
            {
                return;
            }
            User user = User.getByLoginPassword(m_viewModel.Login, ((PasswordBox)parameter).Password);
            if (user.exists())
            {
                m_viewModel.DataContext.User = user;
                m_viewModel.DataContext.Content = new Page();
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
using System;
using System.Windows.Input;
using InventoryOfEquipment.Pages;
using InventoryOfEquipment.ViewModels;

namespace InventoryOfEquipment.Command
{
    public class ChangePageCommand : ICommand
    {
        private readonly MainViewModel m_viewModel;

        public ChangePageCommand(MainViewModel vm)
        {
            m_viewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            switch (parameter)
            {
                case "RegisterPage":
                    if (m_viewModel.ActivityRegister)
                    {
                        m_viewModel.Content = new RegisterPage()
                        {
                            DataContext = new RegisterViewModel() { DataContext = m_viewModel }
                        };
                    }

                    break;
                case "AuthorizationPage":
                    if (m_viewModel.ActivityAuthorization)
                    {
                        m_viewModel.Content = new AuthorizationPage()
                        {
                            DataContext = new AuthorizationViewModel() { DataContext = m_viewModel }
                        };
                    }

                    break;
                case "AccountingPage":
                    if (m_viewModel.ActivityAccounting)
                    {
                        m_viewModel.Content = new AccountingPage()
                        {
                            DataContext = new AccountingViewModel() { DataContext = m_viewModel }
                        };
                    }

                    break;
                case "EmployeePage":
                    if (m_viewModel.ActivityEmployee)
                    {
                        m_viewModel.Content = new EmployeePage()
                        {
                            DataContext = new EmployeeViewModel(){DataContext = m_viewModel}
                        };
                    }

                    break;
                case "AdministratorPage":
                    if (m_viewModel.ActivityAdministrator)
                    {
                        m_viewModel.Content = new AdministratorPage()
                        {
                            DataContext = new AdministratorViewModel(){DataContext = m_viewModel}
                        };
                    }

                    break;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
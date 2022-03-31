using System;
using FormTest.Structs;

namespace FormTest.Page
{
    public partial class AuthPage : System.Windows.Controls.Page
    {
        public event Action<User> EndAuth;

        private UsersController _usersController;
        
        public AuthPage()
        {
            InitializeComponent();
            this._usersController = new UsersController();
        }

        private void LoginControl_OnLogin(string login, string password)
        {
            User? user = this._usersController.getUser(login, password);
            if (user.HasValue)
            {
                EndAuth?.Invoke(user.Value);
            }
            else
            {
                LoginControl.showError("Неправильные данные");
            }
        }
    }
}
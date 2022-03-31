using System;
using System.Windows;
using System.Windows.Controls;

namespace FormTest.Controls
{
    public partial class LoginControl : UserControl
    {
        public event Action<string, string> Login;

        public LoginControl()
        {
            InitializeComponent();
        }

        public void showError(string text)
        {
            ErrorTextBlock.Text = text;
        }

        private void Login_OnClick(object sender, RoutedEventArgs e)
        {
            Login?.Invoke(LoginTextBox.Text, PasswordTextBox.Text);
        }

        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            LoginButton.IsEnabled = LoginTextBox.Text != "" && PasswordTextBox.Text != "" && LoginTextBox.Text.Length>3 && PasswordTextBox.Text.Length>3 ;
        }
    }
}
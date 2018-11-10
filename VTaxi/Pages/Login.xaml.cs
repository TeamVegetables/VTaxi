using System;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Ninject;
using VTaxi.BLL.DTO;
using VTaxi.BLL.Interfaces;
using VTaxi.BLL.Services;
using VTaxi.Util;

namespace VTaxi.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private readonly IAuthenticationService _service;

        public Login()
        {
            InitializeComponent();
            _service = Services.Kernel.Get<AuthenticationService>();
        }

        private void OnClickRegister(object sender, EventArgs e)
        {
            NavigationCommands.GoToPage.Execute("Pages/Register.xaml", this);
        }

        private void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckData();
                _service.LogIn(new UserDto
                {
                    Email = EmailTextBox.Text,
                    Password = PasswordBox.Password
                });
                NavigationCommands.GoToPage.Execute("Pages/Profile.xaml", this);
            }
            catch (FormatException formatException)
            {
                ErrorTextBlock.Text = formatException.Message;
            }
            catch (Exception exception)
            {
                ErrorTextBlock.Text = exception.Message;
            }
        }

        private void CheckData()
        {
            var mail = new MailAddress(EmailTextBox.Text);
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                throw new FormatException("Password can't be empty!");
            }
        }
    }
}

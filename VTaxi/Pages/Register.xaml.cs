using System;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using Ninject;
using VTaxi.BLL.DTO;
using VTaxi.BLL.Interfaces;
using VTaxi.BLL.Services;
using VTaxi.Util;

namespace VTaxi.Pages
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        private readonly IAuthenticationService _service;

        public Register()
        {
            InitializeComponent();
            _service = Services.Kernel.Get<AuthenticationService>();
        }

        private void RegisterButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckData();
                _service.Register(new UserDto
                {
                    Email = EmailTextBox.Text,
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    Password = PasswordBox.Password
                });
            }
            catch (FormatException formatException)
            {
                ErrorMessage.Text = formatException.Message;
            }
            catch (Exception exception)
            {
                ErrorMessage.Text = exception.Message;
            }
        }

        private void CheckData()
        {
            var mail = new MailAddress(EmailTextBox.Text);
            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                throw new FormatException("Password can't be empty!");
            }

            if (string.IsNullOrEmpty(ConfirmPasswordBox.Password))
            {
                throw new FormatException("Confirm password!");
            }

            if (!string.Equals(PasswordBox.Password, ConfirmPasswordBox.Password))
            {
                throw new FormatException("Passwords do not match!");
            }

            if (string.IsNullOrEmpty(FirstNameTextBox.Text))
            {
                throw new FormatException("First Name field can't be empty!");
            }

            if (string.IsNullOrEmpty(LastNameTextBox.Text))
            {
                throw new FormatException("Last Name field can't be empty!");
            }
        }
    }
}

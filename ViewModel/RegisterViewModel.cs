using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PawsitivePlace.Model.Entities;
using PawsitivePlace.Model;
using PawsitivePlace.View;
using Microsoft.Extensions.Hosting;

namespace PawsitivePlace.ViewModel
{
    public partial class RegisterViewModel : ObservableObject
    {
        public string Title => TitleRegister.Title;

        [ObservableProperty]
        private string userNameText = TitleRegister.UserNameText;

        [ObservableProperty]
        private string passwordText = TitleRegister.PasswordText;

        [ObservableProperty]
        private string passwordConfirm = TitleRegister.PasswordConfirm;

        [ObservableProperty]
        private ImageSource registerButton = Buttons.RegisterButton;

        public RegisterViewModel()
        {

        }

        [RelayCommand]
        private async Task Register()
        {
            // Validation
            if (string.IsNullOrWhiteSpace(UserNameText) || string.IsNullOrWhiteSpace(PasswordText))
            {
                await Shell.Current.DisplayAlertAsync(Title, "Please fill in all fields", "OK");
                return;
            }

            if (PasswordText != PasswordConfirm)
            {
                await Shell.Current.DisplayAlertAsync(Title, "Passwords don't match", "OK");
                return;
            }

            // Try to add the user
            bool success = Credentials.AddUser(UserNameText, PasswordText);

            if (success)
            {
                await Shell.Current.DisplayAlertAsync("Success", "Account created successfully!", "OK");
                // Navigate to login page or results page
                await Shell.Current.GoToAsync($"/{nameof(LoginPage)}");
            }
            else
            {
                await Shell.Current.DisplayAlertAsync("Error", "Username already exists", "OK");
            }

        }

    }
}
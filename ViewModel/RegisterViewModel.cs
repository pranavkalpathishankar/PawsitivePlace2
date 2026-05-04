using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PawsitivePlace.Model.Entities;
using PawsitivePlace.Model;
using PawsitivePlace.View;

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

        public RegisterViewModel()
        {

        }

        [RelayCommand]
        private async Task LoginButtonClicked()
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        [RelayCommand]
        private async Task Register()
        {
            // Validation
            if (string.IsNullOrEmpty(userNameText) || string.IsNullOrEmpty(passwordText))
            {
                await Shell.Current.DisplayAlert(Title, "Please fill in all fields", "OK");
                return;
            }

            if (passwordText != passwordConfirm)
            {
                await Shell.Current.DisplayAlert(Title, "Passwords don't match", "OK");
                return;
            }

            // Try to add the user
            bool success = Credentials.AddUser(userNameText, passwordText);

            if (success)
            {
                await Shell.Current.DisplayAlert("Success", "Account created successfully!", "OK");
                // Navigate to login page or results page
                await Shell.Current.GoToAsync($"/{nameof(LoginPage)}");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Username already exists", "OK");
            }

        }

    }
}
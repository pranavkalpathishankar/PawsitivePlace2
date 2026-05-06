using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PawsitivePlace.Model;
using PawsitivePlace.View;
using PawsitivePlace.Model.Entities;
namespace PawsitivePlace.ViewModel;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    private ImageSource submitButton = Buttons.SubmitButton;

   
    public string Title => TitleLogin.Title;

    [ObservableProperty]
    private string userNameText = TitleLogin.UserNameText;

    [ObservableProperty]
    private string passText = TitleLogin.PassText;

    public LoginViewModel()
    {

    }

    [RelayCommand]
    private async Task Submit()
    {
        // Check if username exists and password matches
        bool isValidLogin = !string.IsNullOrEmpty(UserNameText) &&
                           Credentials.UserCredentials.ContainsKey(UserNameText) &&
                           Credentials.UserCredentials[UserNameText] == PassText;

        if (isValidLogin)
        {
            await Shell.Current.GoToAsync($"/{nameof(LoginResultsPage)}");
        }
        else
        {
            // Check what specifically is wrong for better error messages
            bool userExists = !string.IsNullOrEmpty(UserNameText) &&
                             Credentials.UserCredentials.ContainsKey(UserNameText);

            if (userExists)
            {
                await Shell.Current.DisplayAlertAsync(Title, "Incorrect password for this user", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlertAsync(Title, "Username not found", "Ok");
            }
        }
    }


}
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PawsitivePlace.Model;
using PawsitivePlace.View;
using PawsitivePlace.Model.Entities;
namespace PawsitivePlace.ViewModel;

public partial class LoginPageViewModel : ObservableObject
{
    [ObservableProperty]
    private ImageSource submitButton = Buttons.SubmitButton;
    public string Title => TitleLogin.Title;

    [ObservableProperty]
    private string userNameString = TitleLogin.UserNameString;

    [ObservableProperty]
    private string passwordString = TitleLogin.PasswordString;

    public LoginPageViewModel()
    {

    }

    [RelayCommand]
    private async Task SubmitClicked()
    {
        if(string.IsNullOrEmpty(userNameString) && string.IsNullOrEmpty(passwordString))
        {
            await App.Current.MainPage.DisplayAlert("null!","Cannot be null","continue");
        }
        await Shell.Current.GoToAsync(nameof(LoginResultsPage));
    }
}
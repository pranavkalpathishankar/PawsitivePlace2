using PawsitivePlace.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using PawsitivePlace.View;
using CommunityToolkit.Mvvm.Input;

namespace PawsitivePlace.ViewModel
{
    public partial class LoginPageViewModel : ObservableObject
    {
        public string Title => TitleLogin.Title;

        [ObservableProperty]
        private string userNameString = TitleLogin.UserNameString;

        [ObservableProperty]
        private string passwordString = TitleLogin.PasswordString;

        public LoginPageViewModel()
        {

        }



    }
}
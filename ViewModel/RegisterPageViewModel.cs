using PawsitivePlace.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using PawsitivePlace.View;
using CommunityToolkit.Mvvm.Input;

namespace PawsitivePlace.ViewModel
{
    public partial class RegisterPageViewModel : ObservableObject
    {
        public string Title => TitleRegister.Title;

        [ObservableProperty]
        private string userNameText = TitleRegister.UserNameText;

        [ObservableProperty]
        private string passwordText = TitleRegister.PasswordText;

        [ObservableProperty]
        private string passwordConfirm = TitleRegister.PasswordConfirm;

        public RegisterPageViewModel()
        {

        }

    }
}
using PawsitivePlace.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using PawsitivePlace.View;
using CommunityToolkit.Mvvm.Input;

namespace PawsitivePlace.ViewModel
{
	public partial class MainViewModel : ObservableObject
	{
		public string Title => TitleMain.Title;

		[ObservableProperty]
		public string buttonTextLogin = TitleMain.ButtonTextLogin;

        [ObservableProperty]
        public string buttonTextRegister = TitleMain.ButtonTextRegister;

        public MainViewModel()
        {

        }

		[RelayCommand]
		private async Task OnLoginClickedAsync()
		{
			await Shell.Current.GoToAsync(nameof(LoginPage));
        }

        [RelayCommand]
        private async Task OnRegisterClickedAsync()
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }
    }
}
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
		private string buttonTextLogin = TitleMain.ButtonTextLogin;

        [ObservableProperty]
        private string buttonTextRegister = TitleMain.ButtonTextRegister;

        public MainViewModel()
        {

        }
	}
}
using PawsitivePlace.ViewModel;
namespace PawsitivePlace.View;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel();
	}
}
using PawsitivePlace.ViewModel;

namespace PawsitivePlace.View;

public partial class LoginResultsPage : ContentPage
{
	public LoginResultsPage()
	{
		InitializeComponent();
		BindingContext = new LoginResultsViewModel();
	}
}
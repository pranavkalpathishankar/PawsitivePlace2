using PawsitivePlace.ViewModel;
namespace PawsitivePlace.View;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (BindingContext is LoginViewModel viewModel)
        {
            // Get the list of usernames
            if (query.TryGetValue("UserNameText", out var usernameValue) &&
               usernameValue is string usernames)
            {
                viewModel.UserNameText = usernames;
            }

            // Get the single password
            if (query.TryGetValue("PassText", out var passwordValue) &&
               passwordValue is string password)
            {
                viewModel.PassText = password;
            }
        }

    }
}
using PawsitivePlace.ViewModel;

namespace PawsitivePlace.View;

public partial class CartPage : ContentPage
{
    public CartPage()
    {
        InitializeComponent();
        BindingContext = new CartViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Refresh cart items when page appears
        var vm = (CartViewModel)BindingContext;
        vm.RefreshCart();
    }
}

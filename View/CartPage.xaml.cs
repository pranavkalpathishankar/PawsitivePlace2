using PawsitivePlace.ViewModel;

namespace PawsitivePlace.View;

public partial class CartPage : ContentPage
{
    public CartPage()
    {
        InitializeComponent();
        BindingContext = new CartViewModel();
    }
}

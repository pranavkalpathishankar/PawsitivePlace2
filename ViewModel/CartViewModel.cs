using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PawsitivePlace.Model.Entities;
using PawsitivePlace.Model.Services;
using PawsitivePlace.View;

namespace PawsitivePlace.ViewModel
{
    public partial class CartViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<CartItem> cartItems;

        public string Title => "Shopping Cart";

        public CartViewModel()
        {
            LoadCartItems();
        }

        private void LoadCartItems()
        {
            CartItems = new List<CartItem>(CartService.GetCartItems());
        }

        [RelayCommand]
        private void RemoveItem(CartItem item)
        {
            if (item != null)
            {
                CartService.RemoveFromCart(item);
                LoadCartItems();
                OnPropertyChanged(nameof(CartItems));
            }
        }

        [RelayCommand]
        private async Task Back()
        {
            await Shell.Current.GoToAsync($"/{nameof(LoginResultsPage)}");
        }

        [RelayCommand]
        private async Task Checkout()
        {
            await Shell.Current.DisplayAlertAsync(Title, "Order placed successfully!", "OK");
            CartService.ClearCart();
            LoadCartItems();
            OnPropertyChanged(nameof(CartItems));
            await Shell.Current.GoToAsync($"/{nameof(LoginResultsPage)}");
        }
    }
}

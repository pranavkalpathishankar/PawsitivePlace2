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

        public void RefreshCart()
        {
            LoadCartItems();
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
            if (CartItems == null || CartItems.Count == 0)
            {
                await Shell.Current.DisplayAlertAsync(Title, "Your cart is empty!", "OK");
                return;
            }

            // Display order confirmation with total items and arrival dates
            string itemsList = string.Join("\n", CartItems.Select(item => $"• {item.AnimalName} (Arrives in: {item.arrival})"));
            await Shell.Current.DisplayAlertAsync(Title, $"Order placed successfully!\nItems:\n{itemsList}", "OK");

            CartService.ClearCart();
            LoadCartItems();
            OnPropertyChanged(nameof(CartItems));
            await Shell.Current.GoToAsync($"/{nameof(LoginResultsPage)}");
        }
    }
}

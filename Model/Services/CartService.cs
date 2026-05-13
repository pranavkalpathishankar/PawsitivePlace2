using PawsitivePlace.Model.Entities;

namespace PawsitivePlace.Model.Services
{
    public static class CartService
    {
        private static List<CartItem> _cartItems = new List<CartItem>();

        public static List<CartItem> GetCartItems() => _cartItems;

        public static void AddToCart(string animalType, string arrivalDate, string animalName, string imageSource)
        {
            var cartItem = new CartItem
            {
                AnimalType = animalType,
                AnimalName = animalName,
                arrival = arrivalDate,
                ImageSource = imageSource
            };
            _cartItems.Add(cartItem);
        }

        public static void RemoveFromCart(CartItem item)
        {
            _cartItems.Remove(item);
        }

        public static void ClearCart()
        {
            _cartItems.Clear();
        }

        public static int GetCartCount() => _cartItems.Count;
    }
}

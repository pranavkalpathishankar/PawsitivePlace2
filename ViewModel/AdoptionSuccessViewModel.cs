using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PawsitivePlace.Model.Services;
using PawsitivePlace.View;

namespace PawsitivePlace.ViewModel;

public partial class AdoptionSuccessViewModel : ObservableObject
{
    [ObservableProperty]
    private string animalType;

    [ObservableProperty]
    private string animalName;

    [ObservableProperty]
    private string imageSource;

    public string Title => "Success";

    public AdoptionSuccessViewModel()
    {
    }

    public void Initialize(string type, string name, string image)
    {
        AnimalType = type;
        AnimalName = name;
        ImageSource = image;
    }

    [RelayCommand]
    private async Task Back()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task AddToCart()
    {
        CartService.AddToCart(AnimalType, AnimalName, ImageSource);
        await Shell.Current.DisplayAlertAsync(Title, $"{AnimalName} added to cart!", "OK");
        await Shell.Current.GoToAsync($"/{nameof(CartPage)}");
    }
}

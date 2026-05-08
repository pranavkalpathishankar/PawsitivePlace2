using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PawsitivePlace.Model;
using PawsitivePlace.Model.Entities;
using PawsitivePlace.View;
namespace PawsitivePlace.ViewModel;

public partial class LoginResultsViewModel : ObservableObject
{
    [ObservableProperty]
    private ImageSource adoptButton = Buttons.AdoptButton;

    public string Title => "Adoption Results";

    public LoginResultsViewModel()
    {

    }

    [RelayCommand]
    private async Task Adopt(string animalType)
    {
        await Shell.Current.GoToAsync($"/{nameof(AdoptionSuccessPage)}");
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PawsitivePlace.Model;
using PawsitivePlace.Model.Entities;
using PawsitivePlace.Model.Services;
using PawsitivePlace.View;

namespace PawsitivePlace.ViewModel;

public partial class LoginResultsViewModel : ObservableObject
{
    [ObservableProperty]
    private ImageSource adoptButton = Buttons.AdoptButton;

    // Store selected animal data
    public static (string type, string name, string image)? SelectedAnimal { get; set; }

    private Dictionary<string, (string name, string image)> animals = new()
    {
        { "americancurl", ("American Curl", "americancurl.jpg") },
        { "britishshorthair", ("British Shorthair", "britishshorthair.jpg") },
        { "burmese", ("Burmese", "burmese.jpg") },
        { "finch", ("Finch", "finch.jpg") },
        { "german_shepherd", ("German Shepherd", "german_shepherd.png") },
        { "golden_retriever", ("Golden Retriever", "golden_retriever.jpg") },
        { "parakeet", ("Parakeet", "parakeet.jpg") },
        { "rottweiler", ("Rottweiler", "rottweiler.jpg") },
        { "scarletmacaw", ("Scarlet Macaw", "scarletmacaw.jpg") }
    };

    public string Title => "Adoption Results";

    public LoginResultsViewModel()
    {
    }

    [RelayCommand]
    private async Task Adopt(string animalKey)
    {
        if (animals.TryGetValue(animalKey, out var animal))
        {
            SelectedAnimal = (GetAnimalType(animalKey), animal.name, animal.image);
        }
        
        await Shell.Current.GoToAsync($"/{nameof(AdoptionSuccessPage)}");
    }

    private string GetAnimalType(string animalKey)
    {
        return animalKey switch
        {
            "americancurl" or "britishshorthair" or "burmese" => "cat",
            "finch" or "parakeet" or "scarletmacaw" => "bird",
            "german_shepherd" or "golden_retriever" or "rottweiler" => "dog",
            _ => "unknown"
        };
    }
}

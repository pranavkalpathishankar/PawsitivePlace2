using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PawsitivePlace.Model;
using PawsitivePlace.Model.Entities;
using PawsitivePlace.Model.Services;
using PawsitivePlace.View;
using System.Collections.ObjectModel;

namespace PawsitivePlace.ViewModel;

public class AnimalGridItem
{
    public string animalKey { get; set; }
    public string imageFile { get; set; }
}

public partial class LoginResultsViewModel : ObservableObject
{
    [ObservableProperty]
    private ImageSource adoptButton = Buttons.AdoptButton;

    [ObservableProperty]
    private string selectedFilter = "All";

    [ObservableProperty]
    private ObservableCollection<AnimalGridItem> filteredAnimalsGrid;

    // Store selected animal data
    public static (string type, string name, string dateOfarrival, string image)? SelectedAnimal { get; set; }

    private Dictionary<string, (string name, string dateOfarrival, string image)> animals = new()
    {
        { "americancurl", ("American Curl", "1 months" ,"americancurl.jpg") },
        { "britishshorthair", ("British Shorthair","2 months" , "britishshorthair.jpg") },
        { "burmese", ("Burmese","3 months" , "burmese.jpg") },
        { "finch", ("Finch","4 months" , "finch.jpg") },
        { "german_shepherd", ("German Shepherd", "5 months" , "german_shepherd.png") },
        { "golden_retriever", ("Golden Retriever", "6 months" , "golden_retriever.jpg") },
        { "parakeet", ("Parakeet", "7 months" , "parakeet.jpg") },
        { "rottweiler", ("Rottweiler", "6 months" , "rottweiler.jpg") },
        { "scarletmacaw", ("Scarlet Macaw", "5 months" , "scarletmacaw.jpg") }
    };

    private Dictionary<string, List<string>> animalsByCategory = new()
    {
        { "cat", new List<string> { "americancurl", "britishshorthair", "burmese" } },
        { "dog", new List<string> { "german_shepherd", "golden_retriever", "rottweiler" } },
        { "bird", new List<string> { "finch", "parakeet", "scarletmacaw" } }
    };

    public string Title => "Adoption Results";

    public LoginResultsViewModel()
    {
        FilteredAnimalsGrid = new ObservableCollection<AnimalGridItem>();
        PopulateAnimals("All");
    }

    [RelayCommand]
    private void FilterByCategory(string category)
    {
        SelectedFilter = category == "All" ? "All Animals" : $"{char.ToUpper(category[0])}{category.Substring(1)}s";
        PopulateAnimals(category);
    }

    private void PopulateAnimals(string category)
    {
        FilteredAnimalsGrid.Clear();

        List<string> animalKeys = new List<string>();

        if (category.Equals("All", StringComparison.OrdinalIgnoreCase))
        {
            // Show all animals
            animalKeys.AddRange(new[] 
            { 
                "americancurl", "britishshorthair", "burmese", 
                "finch", "german_shepherd", "golden_retriever", 
                "parakeet", "rottweiler", "scarletmacaw" 
            });
        }
        else if (animalsByCategory.TryGetValue(category.ToLower(), out var categoryAnimals))
        {
            // Show animals from specific category
            animalKeys.AddRange(categoryAnimals);
        }

        // Populate the grid
        foreach (var animalKey in animalKeys)
        {
            if (animals.TryGetValue(animalKey, out var animal))
            {
                FilteredAnimalsGrid.Add(new AnimalGridItem 
                { 
                    animalKey = animalKey, 
                    imageFile = animal.image 
                });
            }
        }
    }

    [RelayCommand]
    private async Task Adopt(string animalKey)
    {
        if (animals.TryGetValue(animalKey, out var animal))
        {
            SelectedAnimal = (GetAnimalType(animalKey), animal.name, animal.dateOfarrival, animal.image);
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
           
        };
    }
}

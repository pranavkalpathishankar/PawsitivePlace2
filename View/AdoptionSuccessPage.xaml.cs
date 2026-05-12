using PawsitivePlace.ViewModel;

namespace PawsitivePlace.View;

public partial class AdoptionSuccessPage : ContentPage
{
    public AdoptionSuccessPage()
    {
        InitializeComponent();
        BindingContext = new AdoptionSuccessViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        // Get animal data from LoginResultsViewModel
        if (LoginResultsViewModel.SelectedAnimal.HasValue)
        {
            var animal = LoginResultsViewModel.SelectedAnimal.Value;
            var vm = (AdoptionSuccessViewModel)BindingContext;
            vm.Initialize(animal.type, animal.name, animal.image);
        }
    }
}

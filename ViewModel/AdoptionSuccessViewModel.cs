using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PawsitivePlace.View;
namespace PawsitivePlace.ViewModel;

public partial class AdoptionSuccessViewModel : ObservableObject
{
    public string Title => "Success";

    public AdoptionSuccessViewModel()
    {

    }

    [RelayCommand]
    private async Task Back()
    {
        await Shell.Current.GoToAsync("..");
    }
}

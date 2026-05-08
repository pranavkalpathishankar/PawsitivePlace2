using PawsitivePlace.ViewModel;

namespace PawsitivePlace.View;

public partial class AdoptionSuccessPage : ContentPage
{
    public AdoptionSuccessPage()
    {
        InitializeComponent();
        BindingContext = new AdoptionSuccessViewModel();
    }
}

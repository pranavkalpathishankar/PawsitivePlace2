using PawsitivePlace.ViewModel;
namespace PawsitivePlace.View
{ 
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
    }
}
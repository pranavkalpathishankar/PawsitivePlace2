using PawsitivePlace.View;
using PawsitivePlace;
using PawsitivePlace.View;

namespace PawsitivePlace
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
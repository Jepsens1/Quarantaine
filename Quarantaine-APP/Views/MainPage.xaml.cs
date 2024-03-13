using Quarantaine_APP.ViewModels;
using Quarantaine_APP.Views;

namespace Quarantaine_APP
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
        public MainPage()
        {
            InitializeComponent();
        }
    }

}

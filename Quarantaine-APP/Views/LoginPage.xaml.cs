using Quarantaine_APP.ViewModels;

namespace Quarantaine_APP.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}
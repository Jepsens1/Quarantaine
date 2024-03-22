using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Quarantaine_APP.Interfaces;

namespace Quarantaine_APP.ViewModels
{
    public partial class LoginPageViewModel : ObservableObject
    {
        private readonly ILoginService _login;
        [ObservableProperty]
        string username = string.Empty;
        [ObservableProperty]
        string password = string.Empty;
        public LoginPageViewModel(ILoginService login)
        {
            _login = login;
        }
        [RelayCommand]
        async Task LoginAsync()
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
                return;

            _login.Login("oauth_token", "secret-oauth-token-value");
            await Shell.Current.GoToAsync($"..");

        }
    }
}

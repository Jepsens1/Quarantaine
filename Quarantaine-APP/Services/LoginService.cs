using Quarantaine_APP.Interfaces;

namespace Quarantaine_APP.Services
{
    public class LoginService : ILoginService
    {

        public async Task<string?> GetToken(string token)
        {
            return await SecureStorage.Default.GetAsync(token);
        }

        public async Task Login(string token, string value)
        {
            await SecureStorage.Default.SetAsync(token, value);
        }
    }
}

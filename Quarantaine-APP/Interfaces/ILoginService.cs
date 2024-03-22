
namespace Quarantaine_APP.Interfaces
{
    public interface ILoginService
    {
        Task<string?> GetToken(string token);
        Task Login(string token,string value);
    }
}
using LgpDuvidas.Models;
using System.Threading.Tasks;

namespace LgpDuvidas.Interfaces
{
    public interface IAuthService
    {
        Task<AuthModel> Register(AuthModel input);
        Task<AuthModel> Login(AuthModel input);
        Task<AuthModel> GetAuth();
        Task<AuthModel> Refresh();
    }
}

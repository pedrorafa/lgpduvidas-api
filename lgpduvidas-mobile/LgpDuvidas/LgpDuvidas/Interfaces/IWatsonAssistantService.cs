using LgpDuvidas.Models;
using System.Threading.Tasks;

namespace LgpDuvidas.Interfaces
{
    public interface IWatsonAssistantService
    {
        Task<WatsonMessage> Send(WatsonMessage input);
    }
}

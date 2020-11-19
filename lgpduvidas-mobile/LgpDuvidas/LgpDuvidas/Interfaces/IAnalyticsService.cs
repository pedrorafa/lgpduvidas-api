using LgpDuvidas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LgpDuvidas.Interfaces
{
    public interface IAnalyticsService
    {
        Task<IEnumerable<Entity>> GetMessages();
    }
}

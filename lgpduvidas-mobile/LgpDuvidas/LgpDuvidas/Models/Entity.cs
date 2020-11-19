using System.Collections.Generic;

namespace LgpDuvidas.Models
{
    public class Entity
    {
        public string Description { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}

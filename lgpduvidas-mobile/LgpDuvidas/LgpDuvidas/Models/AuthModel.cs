using SQLite;

namespace LgpDuvidas.Models
{
    [Table("Auth")]
    public class AuthModel
    {
        [PrimaryKey]
        public string user { get; set; }
        public string pass { get; set; }
        public string Token { get; set; }
    }
}

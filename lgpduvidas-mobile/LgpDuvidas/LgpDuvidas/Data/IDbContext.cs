using SQLite;

namespace LgpDuvidas.Data
{
    public interface IDbContext
    {
        SQLiteConnection Connection { get; }
    }
}

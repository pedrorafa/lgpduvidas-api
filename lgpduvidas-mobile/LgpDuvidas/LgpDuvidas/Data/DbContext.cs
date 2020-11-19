using LgpDuvidas.Models;
using SQLite;
using System;
using System.IO;

namespace LgpDuvidas.Data
{
    public class DbContext : IDbContext, IDisposable
    {
        public SQLiteConnection Connection => new SQLiteConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "lgdb.db3"));

        public DbContext()
        {
            Connection.CreateTable<AuthModel>();
        }

        public bool _disposed = false;
        public void Dispose()
        {
            if (_disposed)
                return;

            if (Connection != null)
                Connection.Dispose();

            this.Dispose();
            _disposed = true;
        }
    }
}

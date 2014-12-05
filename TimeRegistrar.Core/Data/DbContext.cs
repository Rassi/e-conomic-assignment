using System.Configuration;
using System.Reflection;
using SQLite;

namespace TimeRegistrar.Core.Data
{
    public interface IDbContext
    {
        SQLiteConnection Connection();
    }

    public class DbContext : IDbContext
    {
        public SQLiteConnection Connection()
        {
            return new SQLiteConnection("trs.db");
        }
    }
}
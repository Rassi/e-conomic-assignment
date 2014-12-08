using SQLite;
using TimeRegistrar.Core.Data;

namespace TimeRegistrar.Tests.TestHelpers
{
    public class TestDbContext : IDbContext
    {
        public SQLiteConnection Connection()
        {
            return new SQLiteConnection("test_trs.db");
        }
    }
}
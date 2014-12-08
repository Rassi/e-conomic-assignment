using SQLite;
using TimeRegistrar.Core.Data;

namespace webtest2.Tests.TestHelpers
{
    public class TestDbContext : IDbContext
    {
        public SQLiteConnection Connection()
        {
            return new SQLiteConnection("test_trs.db");
        }
    }
}
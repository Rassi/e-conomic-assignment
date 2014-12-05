using System;
using SQLite;
using TimeRegistrar.Core.Data;

namespace webtest2.Tests.TestHelpers
{
    public class TestDbContext : IDbContext
    {
        private static readonly Lazy<SQLiteConnection> SqlConnection = new Lazy<SQLiteConnection>(() => new SQLiteConnection(":memory:"));
        
        public SQLiteConnection Connection()
        {
            return new SQLiteConnection("test_trs.db");
            return new SQLiteConnection(":memory:", SQLiteOpenFlags.SharedCache);
            return SqlConnection.Value;
        }
    }
}
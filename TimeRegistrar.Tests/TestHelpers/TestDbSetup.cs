using NUnit.Framework;
using TimeRegistrar.Core.Data;
using TimeRegistrar.Core.Models;

namespace TimeRegistrar.Tests.TestHelpers
{
    [SetUpFixture]
    public class TestDbSetup
    {
        private static TestDbContext _testDbContext;

        [SetUp]
        public void SetupDb()
        {
            _testDbContext = new TestDbContext();
            ClearDb();
            var dbSetup = new DbSetup(_testDbContext);
            dbSetup.SetupDatabase();
        }

        private static void ClearDb()
        {
            using (var connection = _testDbContext.Connection())
            {
                connection.DropTable<TimeRegistration>();
                connection.DropTable<Project>();
            }
        }
    }
}
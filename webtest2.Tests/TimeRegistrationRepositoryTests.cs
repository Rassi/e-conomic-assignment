using NUnit.Framework;
using TimeRegistrar.Core.Data;
using TimeRegistrar.Core.Models;
using webtest2.Tests.TestHelpers;

namespace webtest2.Tests
{
    [TestFixture]
    public class TimeRegistrationRepositoryTests
    {
        [Test]
        public void ShouldInsert()
        {
            // Arrange
            var repo = new TimeRegistrationRepository(new TestDbContext());
            var timeReg = new TimeRegistration("TestProject");

            // Act
            repo.Insert(timeReg);
            
            // Assert
            var actual = repo.FindById(timeReg.Id);
            Assert.That(actual.Id, Is.EqualTo(timeReg.Id));
            Assert.That(actual.ProjectName, Is.EqualTo(timeReg.ProjectName));
        }
    }
}
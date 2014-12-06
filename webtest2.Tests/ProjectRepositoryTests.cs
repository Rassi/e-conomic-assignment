using NUnit.Framework;
using TimeRegistrar.Core.Data;
using TimeRegistrar.Core.Models;
using webtest2.Tests.TestHelpers;

namespace webtest2.Tests
{
    [TestFixture]
    public class ProjectRepositoryTests
    {
        [Test]
        public void ShouldSave()
        {
            // Arrange
            var repo = new ProjectRepository(new TestDbContext());
            var project = new Project("TestProject");

            // Act
            repo.Insert(project);

            // Assert
            var actual = repo.FindById(project.Id);
            Assert.That(actual.Name, Is.EqualTo(project.Name));
        }
    }
}
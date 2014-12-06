using NUnit.Framework;
using TimeRegistrar.Core.Data;
using TimeRegistrar.Core.Models;
using webtest2.Tests.TestHelpers;

namespace webtest2.Tests
{
    [TestFixture]
    public class TimeRegistrationRepositoryTests
    {
        private TestDbContext _testDbContext;
        private ProjectRepository _projectRepository;
        private TimeRegistrationRepository _timeRegistrationRepository;

        [SetUp]
        public void SetUp()
        {
            _testDbContext = new TestDbContext();
            _projectRepository = new ProjectRepository(_testDbContext);
            _timeRegistrationRepository = new TimeRegistrationRepository(_testDbContext, _projectRepository);
        }

        [Test]
        public void ShouldInsert()
        {
            // Arrange
            var project = new Project("TestProject");
            _projectRepository.Insert(project);
            var timeReg = new TimeRegistration(project.Id);

            // Act
            _timeRegistrationRepository.Insert(timeReg);
            
            // Assert
            var actual = _timeRegistrationRepository.FindById(timeReg.Id);
            Assert.That(actual.Id, Is.EqualTo(timeReg.Id));
        }
    }
}
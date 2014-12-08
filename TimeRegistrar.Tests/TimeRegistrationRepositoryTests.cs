using System;
using NUnit.Framework;
using TimeRegistrar.Core.Data;
using TimeRegistrar.Core.Models;
using TimeRegistrar.Tests.TestHelpers;

namespace TimeRegistrar.Tests
{
    [TestFixture]
    public class TimeRegistrationRepositoryTests : TestDbSetup
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
            _projectRepository.Save(project);
            var timeReg = new TimeRegistration(project.Id);

            // Act
            _timeRegistrationRepository.Save(timeReg);
            
            // Assert
            var actual = _timeRegistrationRepository.FindById(timeReg.Id);
            Assert.That(actual.Id, Is.EqualTo(timeReg.Id));
        }

        [Test]
        public void ShouldSaveExisting()
        {
            // Arrange
            var project = new Project("TestProject");
            _projectRepository.Save(project);
            var timeReg = new TimeRegistration(project.Id)
            {
                Time = TimeSpan.FromHours(2)
            
            };
            _timeRegistrationRepository.Save(timeReg);
            
            timeReg.Time = TimeSpan.FromHours(4);
            
            // Act
            _timeRegistrationRepository.Save(timeReg);

            // Assert
            var actual = _timeRegistrationRepository.FindById(timeReg.Id);
            Assert.That(actual.Id, Is.Not.EqualTo(default(int)));
            Assert.That(actual.Time, Is.EqualTo(TimeSpan.FromHours(4)));
        }

    }
}
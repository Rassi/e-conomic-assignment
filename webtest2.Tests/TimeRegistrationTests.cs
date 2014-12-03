using System;
using NUnit.Framework;
using webtest2.Models;

namespace webtest2.Tests
{
    [TestFixture]
    public class TimeRegistrationTests
    {
        [Test]
        public void ShouldAssociateProject()
        {
            // Arrange
            // Act
            var timeReg = new TimeRegistration("NewProject");

            // Assert
            Assert.That(timeReg.ProjectName, Is.EqualTo("NewProject"));
        }
        
        [Test]
        public void ShouldContainTime()
        {
            // Arrange
            // Act
            var timeReg = new TimeRegistration("")
            {
                Time = TimeSpan.FromHours(8.5)
            };

            // Assert
            Assert.That(timeReg.Time, Is.EqualTo(TimeSpan.FromHours(8.5)));
        }

        [Test]
        public void ShouldContainRegistrationTime()
        {
            // Arrange
            var date = DateTimeOffset.Parse("2012-01-01");

            // Act
            var timeReg = new TimeRegistration("")
            {
                RegistrationDate = date
            
            };

            // Assert
            Assert.That(timeReg.RegistrationDate, Is.EqualTo(date));
        }
    }
}
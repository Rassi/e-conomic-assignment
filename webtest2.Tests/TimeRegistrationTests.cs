using System;
using NUnit.Framework;
using TimeRegistrar.Core.Models;

namespace webtest2.Tests
{
    [TestFixture]
    public class TimeRegistrationTests
    {
        [Test]
        public void ShouldContainTime()
        {
            // Arrange
            // Act
            var timeReg = new TimeRegistration(0)
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
            var timeReg = new TimeRegistration(0)
            {
                Date = date
            
            };

            // Assert
            Assert.That(timeReg.Date, Is.EqualTo(date));
        }
    }
}

using DateTimeExercise.Contracts;
using DateTimeExercise.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DateTimeTest.Test
{
    [TestFixture]
    public class AddDaysTests
    {
        private IDateTime sut;

        [SetUp]
        public void TestInit()
        {
            this.sut = new MyDateTime();
        }

        [Test]
        public void NowShouldReturnCurrentDate()
        {
            // Arrange 
            var expectedValue = DateTime.Now.Date;

            // Assert
            Assert.AreEqual(expectedValue, this.sut.Now().Date);
        }

        [Test]
        public void AddingADayToTheLastOneOfAMonthShouldResultInTheFirstDayOfTheNextMonth()
        {
            // Arrange
            var testDate = new DateTime(2000, 10, 31);
            var expectedDate = new DateTime(2000, 11, 1);

            // Act
            testDate = testDate.AddDays(1);

            // Assert
            Assert.AreEqual(expectedDate, testDate);
        }

        [Test]
        public void AddingNegativeNumberOfDays()
        {
            // Arrange
            var testDate = new DateTime(2016, 10, 31);
            var expectedDate = new DateTime(2016, 10, 21);

            // Act
            testDate = testDate.AddDays(-10);

            // Assert
            Assert.AreEqual(expectedDate, testDate);
        }

        [Test]
        public void AddingDaysLeapYear()
        {
            // Arrange
            var testDate = new DateTime(2008, 02, 28);
            var expectedDate = new DateTime(2008, 02, 29);

            // Act
            testDate = testDate.AddDays(1);

            // Assert
            Assert.AreEqual(expectedDate, testDate);
        }

        [Test]
        public void AddingDaysNotLeapYear()
        {
            // Arrange
            var testDate = new DateTime(2007, 02, 28);
            var expectedDate = new DateTime(2007, 03, 01);

            // Act
            testDate = testDate.AddDays(1);

            // Assert
            Assert.AreEqual(expectedDate, testDate);
        }
    }
}

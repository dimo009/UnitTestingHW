using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Hack;

namespace HackTest.Test
{
    [TestFixture]
    public class HackTest
    {
        
        private Mock<MathFunctions> math;

        [SetUp]
        public void TestInit()
        {
            math = new Mock<MathFunctions>();
        }

        [Test]
        public void ReturnTheAbsoluteValue()
        {
            var obj = math.Object.GetTheAbsoluteValue(-100);
            Assert.AreEqual(100, obj);
        }

        [Test]
        public void ReturnMathCeilingValue()
        {
            //Arrange
            decimal value = 7.28m;
            decimal expectedValue = 7;
            var obj = math.Object.ReturnMathFloor(value);
            Assert.That(obj, Is.EqualTo(expectedValue));
        }
    }
}

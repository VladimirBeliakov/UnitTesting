using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinjaUnitTests.Fundamentals
{
    [TestFixture]
    public class DemeritPointsCalculatorUnitTests
    {
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedOutOfRange_ThrowsEx(int speed)
        {
            // Arrange
            var demPointCal = DemPointCalFactory();

            // Act
            TestDelegate del = () => demPointCal.CalculateDemeritPoints(speed);

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(del);
        }

        [TestCase(65)]
        [TestCase(64)]
        public void CalculateDemeritPoints_SpeedBelowOrEqualToLimit_ReturnsZero(int speed)
        {
            // Arrange
            var demPointCal = DemPointCalFactory();

            // Act
            var result = demPointCal.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.Zero);
        }

        [Test]
        public void CalculateDemeritPoints_ValidSpeed_ReturnsCorrectResult()
        {
            // Arrange
            var demPointCal = DemPointCalFactory();
            int speed = 100;
            int expected = (speed - 65) / 5;

            // Act
            var result = demPointCal.CalculateDemeritPoints(speed);

            // Assert
            Assert.AreEqual(expected, result);
        }

        private DemeritPointsCalculator DemPointCalFactory()
        {
            return new DemeritPointsCalculator();
        }
    }
}

using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinjaUnitTests.Fundamentals
{
    [TestFixture]
    public class FizzBuzzUnitTests
    {
        [Test]
        public void GetOutput_NumberMultipleOfThreeAndFive_ReturnsFizzBuzz()
        {
            // Arrange
            int number = 15;

            // Act
            var result = FizzBuzz.GetOutput(number);

            // Assert
            Assert.AreEqual("FizzBuzz", result);
        }

        [Test]
        public void GetOutput_NumberMultipleOfThree_ReturnsFizz()
        {
            // Arrange
            var number = 9;

            // Act
            var result = FizzBuzz.GetOutput(number);

            // Assert
            Assert.AreEqual("Fizz", result);
        }

        [Test]
        public void GetOutput_NumberMultipleOfFive_ReturnsBuzz()
        {
            // Arrange
            var number = 10;

            // Act
            var result = FizzBuzz.GetOutput(number);

            // Assert
            Assert.AreEqual("Buzz", result);
        }

        [Test]
        public void GetOutput_NumberNotMultipleOfThreeAndFive_ReturnsStringedNumber()
        {
            // Arrange
            var number = 11;

            // Act
            var result = FizzBuzz.GetOutput(number);

            // Assert
            Assert.AreEqual("11", result);
        }
    }
}

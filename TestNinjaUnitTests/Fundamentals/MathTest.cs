using System;
using TestNinja.Fundamentals;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;
using System.Linq;
using FluentAssertions;

namespace TestNinjaUnitTests.Fundamentals
{
    [TestFixture]
    public class MathTest
    {
        [Test]
        public void Add_TwoValues_ReturnsSum()
        {
            // Arrange
            var a = 5;
            var b = 8;
            var c = a + b;
            var math = new TestNinja.Fundamentals.Math();

            // Act
            var result = math.Add(a, b);

            // Assert
            Assert.AreEqual(c, result);
        }

        [Test]
        public void Max_FirstArgHignerSecond_ReturnsFirst()
        {
            // Arrange
            var math = new TestNinja.Fundamentals.Math();
            var firstArg = 10;
            var secondArg = 8;

            // Act
            var result = math.Max(firstArg, secondArg);

            // Assert
            Assert.AreEqual(firstArg, result);
        }

        [Test]
        public void Max_FirstArgLowerSecond_ReturnsSecond()
        {
            // Arrange
            var math = new TestNinja.Fundamentals.Math();
            var firstArg = 8;
            var secondArg = 10;

            // Act
            var result = math.Max(firstArg, secondArg);

            // Assert
            Assert.AreEqual(secondArg, result);
        }

        [Test]
        public void GetOddNumbers_Limit9_ReturnsListOfOddNumbers()
        {
            // Arrange
            var math = new TestNinja.Fundamentals.Math();
            var limit = 12;
            var oddList = new List<int>() { 1, 3, 5, 7, 9, 11 };

            // Act
            var result = math.GetOddNumbers(limit).ToList();

            #region Using Regex
            //var result = math.GetOddNumbers(limit).ToList();
            //var resultStr = new List<string>(); // Using Regex
            //foreach (int item in result)
            //{
            //    resultStr.Add(item.ToString());
            //}

            //Assert.That(resultStr, Is.All.Match("^[13579]+$")); // Using Regex
            #endregion

            // Assert
            result.Should().BeEquivalentTo(oddList);
        }
    }
}
// Arrange


// Act


// Assert

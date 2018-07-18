using System;
using TestNinja.Fundamentals;
using NUnit.Framework;
using System.Collections.Generic;

namespace TestNinjaUnitTests
{
    [TestFixture]
    public class PhoneNumberTests
    {
        [Test]
        public void PhoneNumberIs_Empty_ThrowsEx()
        {
            // Arrange
            string pn = "";

            // Act
            TestDelegate del = () => PhoneNumber.Parse(pn);

            // Assert
            Assert.Throws<ArgumentException>(del, "Phone number cannot be blank.");
        }

        [Test]
        public void PhoneNumberIs_NotTenDigits_ThrowsEx()
        {
            // Arrange
            string pn = "123456789";

            // Act
            TestDelegate del = () => PhoneNumber.Parse(pn);

            // Assert
            Assert.Throws<ArgumentException>(del, "Phone number should be 10 digits long.");
        }

        [Test]
        public void PhoneNumberIs_TenDigits_ReturnsTypePhoneNumber()
        {
            // Arrange
            string pn = "0123456789";

            // Act
            var result = PhoneNumber.Parse(pn);

            // Assert
            Assert.That(result, Is.TypeOf<PhoneNumber>());
        }

        [Test]
        public void PhoneNumberIs_TenDigits_ReturnsObjectPhoneNumber()
        {
            // Arrange
            var pn = "0123456789";

            // Act
            PhoneNumber result = PhoneNumber.Parse(pn);

            // Assert
            Assert.That(result, Has.Property("Area").EqualTo("012")
                               .And.Property("Major").EqualTo("345")
                               .And.Property("Minor").EqualTo("6789"));
        }

        [Test]
        public void Parse_TenDigitsWithDiffAssert_ReturnsObjectPhoneNumber()
        {
            // Arrange
            var number = "0123456789";
            var pn = new PhoneNumber("012", "345", "6789");

            // Act
            PhoneNumber result = PhoneNumber.Parse(number);

            // Assert
            Assert.That(result, Is.EqualTo(pn));
        }

        [Test]
        public void ToString_TenDigits_ReturnsPhoneNumberFormatted()
        {
            // Arrange
            var number = "0123456789";

            // Act
            var result = PhoneNumber.Parse(number).ToString();

            // Assert
            Assert.AreEqual("(012)345-6789", result);
        }
    }
}
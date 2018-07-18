using FluentAssertions;
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
    public class CustomerControllerUnitTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnsNotFound()
        {
            // Arrange
            var custContr = CustContrFactory();
            var id = 0;

            // Act
            var result = custContr.GetCustomer(id);

            // Assert
            Assert.That(result, Is.InstanceOf<ActionResult>());
        }

        [Test]
        public void GetCustomer_IdIsNonZero_ReturnsOk()
        {
            // Arrange
            var custContr = CustContrFactory();
            var id = 1;

            // Act
            var result = custContr.GetCustomer(id);

            // Assert
            result.Should().BeOfType<Ok>("because a {0} is set", typeof(Ok));
        }

        private CustomerController CustContrFactory()
        {
            return new CustomerController();
        }
    }
}

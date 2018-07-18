using NSubstitute;
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
    public class ErrorLoggerUnitTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void Log_EmptyOrWithSpacesError_ThrowsEx(string error)
        {
            // Arrange
            var erLogger = ErrorLoggerFactory();

            // Act
            TestDelegate del = () => erLogger.Log(error);

            // Assert
            Assert.Throws<ArgumentNullException>(del);
        }

        [Test]
        public void Log_PassingError_PropHasError()
        {
            // Arrange
            var erLogger = ErrorLoggerFactory();
            var error = "error message";

            // Act
            erLogger.Log(error);

            // Assert
            Assert.AreEqual(error, erLogger.LastError);
        }

        [Test]
        public void Log_Subscribing_EventRaised()
        {
            // Arrange
            var erLogger = ErrorLoggerFactory();
            var error = "error message";
            var wasRaised = false;

            // Act
            erLogger.ErrorLogged += (sender, args) => wasRaised = true;
            erLogger.Log(error);

            // Assert
            Assert.IsTrue(wasRaised);
        }

        [Test]
        public void Log_Subscribing_ArgsIsGuidAndHasNonZeroValue()
        {
            // Arrange
            var erLogger = ErrorLoggerFactory();
            var error = "error message";
            Guid guid = new Guid();

            // Act
            erLogger.ErrorLogged += (sender, args) => guid = args;
            erLogger.Log(error);

            // Assert
            Assert.That(guid, Is.TypeOf(typeof(Guid)).And.Not.EqualTo(new Guid()));
        }

        private ErrorLogger ErrorLoggerFactory()
        {
            return new ErrorLogger();
        }
    }
}

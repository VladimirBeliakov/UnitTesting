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
    public class HtmlFormatterUnitTests
    {
        [Test]
        public void FormatAsBold_AnyContent_ReturnsHtmlFormattedContent()
        {
            // Arrange
            var htmlFormatter = new HtmlFormatter();
            string content = "Blah Blah Blah";

            // Act
            var result = htmlFormatter.FormatAsBold(content);

            // Assert
            Assert.AreEqual($"<strong>{content}</strong>", result);
        }
    }
}

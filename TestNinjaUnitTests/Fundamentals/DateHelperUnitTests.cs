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
    public class DateHelperUnitTests
    {
        [Test]
        public void FirstOfNextMonth_MonthIsTwelve_IncreasesYearByOne()
        {
            // Arrange
            var date = new DateTime(2018, 12, 3);
            // Act
            var result = DateHelper.FirstOfNextMonth(date);

            // Assert
            result.Should().HaveYear(2019).And.HaveMonth(1).And.HaveDay(1);
        }

        [Test]
        public void FirstOfNextMonth_MonthIsLessThanTwelve_IncreasesMonthByOne()

        {
            // Arrange
            var date = new DateTime(2018, 10, 3);

            // Act
            var result = DateHelper.FirstOfNextMonth(date);

            // Assert
            result.Should().HaveYear(2018).And.HaveMonth(11).And.HaveDay(1);
        }
    }
}

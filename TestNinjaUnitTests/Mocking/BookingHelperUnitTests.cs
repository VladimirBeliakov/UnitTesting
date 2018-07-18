using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Mocking;

namespace TestNinjaUnitTests.Mocking
{
    [TestFixture]
    public class BookingHelperUnitTests
    {
        [Test]
        public void OverlappingBookingsExist_StatuseCanceled_ReturnsEmptyString()
        {
            // Arrange
            var booking = new Booking()
            {
                ArrivalDate = new DateTime(2018, 1, 1),
                DepartureDate = new DateTime(2018, 1, 11),
                Id = 1,
                Reference = "reference #1",
                Status = "Canceled"
            };

            // Act
            var result = BookingHelper.OverlappingBookingsExist(booking);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_NoOverlapping_ReturnsEmptyString()
        {
            // Arrange
            var stubList = ListWithBookingOn_2018_1_12_Thru_2018_1_22_Factory();
            var stubUnitOfWork = IUnitOfWorkFactory();

            stubUnitOfWork.Query<Booking>().Returns(stubList.AsQueryable());
            BookingHelper.UnitOfWork = stubUnitOfWork;

            var booking = new Booking()
            {
                ArrivalDate = new DateTime(2018, 1, 1),
                DepartureDate = new DateTime(2018, 1, 11),
                Id = 2,
                Reference = "reference #2",
                Status = "Acknowledged"
            };

            // Act
            var result = BookingHelper.OverlappingBookingsExist(booking);

            // Assert
            Assert.That(result, Is.Empty);
        }

        [Test]
        public void OverlappingBookingsExist_ArrivalDateOverlapping_ReturnsReference()
        {
            // Arrange
            var stubList = ListWithBookingOn_2018_1_12_Thru_2018_1_22_Factory();
            var stubUnitOfWork = IUnitOfWorkFactory();

            stubUnitOfWork.Query<Booking>().Returns(stubList.AsQueryable());
            BookingHelper.UnitOfWork = stubUnitOfWork;

            var booking = new Booking()
            {
                ArrivalDate = new DateTime(2018, 1, 14),
                DepartureDate = new DateTime(2018, 1, 24),
                Id = 2,
                Reference = "reference #2",
                Status = "Acknowledged"
            };

            // Act
            var result = BookingHelper.OverlappingBookingsExist(booking);

            // Assert
            Assert.AreEqual(stubList[0].Reference, result);
        }

        [Test]
        public void OverlappingBookingsExist_DepartureDateOverlapping_ReturnsReference()
        {
            // Arrange
            var stubList = ListWithBookingOn_2018_1_12_Thru_2018_1_22_Factory();
            var stubUnitOfWork = IUnitOfWorkFactory();

            stubUnitOfWork.Query<Booking>().Returns(stubList.AsQueryable());
            BookingHelper.UnitOfWork = stubUnitOfWork;

            var booking = new Booking()
            {
                ArrivalDate = new DateTime(2018, 1, 10),
                DepartureDate = new DateTime(2018, 1, 20),
                Id = 2,
                Reference = "reference #2",
                Status = "Acknowledged"
            };

            // Act
            var result = BookingHelper.OverlappingBookingsExist(booking);

            // Assert
            Assert.AreEqual(stubList[0].Reference, result);
        }

        private IUnitOfWork IUnitOfWorkFactory()
        {
            return Substitute.For<IUnitOfWork>();
        }

        private List<Booking> ListWithBookingOn_2018_1_12_Thru_2018_1_22_Factory()
        {
            return new List<Booking>()
            {
                new Booking()
                {
                    ArrivalDate = new DateTime(2018, 1, 12),
                    DepartureDate = new DateTime(2018, 1, 22),
                    Id = 1,
                    Reference = "reference #1",
                    Status = "Accommodated"
                }
            };
        }
    }

    [TestFixture]
    public class UnitOfWorkUnitTests
    {
        [Test]
        public void Query_WasCalled()
        {
            // Arrange
            var mockUnitOfWork = IUnitOfWorkFactory();
            BookingHelper.UnitOfWork = mockUnitOfWork;

            var booking = new Booking()
            {
                ArrivalDate = new DateTime(2018, 1, 10),
                DepartureDate = new DateTime(2018, 1, 20),
                Id = 2,
                Reference = "reference #2",
                Status = "Acknowledged"
            };

            // Act
            BookingHelper.OverlappingBookingsExist(booking);

            // Assert
            mockUnitOfWork.Received().Query<Booking>();
        }

        private IUnitOfWork IUnitOfWorkFactory()
        {
            return Substitute.For<IUnitOfWork>();
        }
    }
}

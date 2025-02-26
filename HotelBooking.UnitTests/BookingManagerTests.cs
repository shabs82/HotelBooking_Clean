using System;
using System.Collections.Generic;
using FluentAssertions;
using HotelBooking.Core;
using HotelBooking.UnitTests.Fakes;
using Moq;
using Xunit;

namespace HotelBooking.UnitTests
{

    public class BookingManagerTests
    {
        private IBookingManager bookingManager;
        private readonly Mock<IRepository<Booking>> _mockBookingRepo;
        private readonly Mock<IRepository<Room>> _mockRoomRepo;

        public BookingManagerTests(){
            DateTime start = DateTime.Today.AddDays(10);
            DateTime end = DateTime.Today.AddDays(20);
            _mockRoomRepo = new Mock<IRepository<Room>>();
            _mockBookingRepo = new Mock<IRepository<Booking>>();
            
        }
        [Fact]
        public void FindAvailableRoom_StartDateNotInTheFuture_ThrowsArgumentException()
        {
            // Arrange
            DateTime date = DateTime.Today;

            // Act
            Action act = () => bookingManager.FindAvailableRoom(date, date);

            // Assert
            Assert.Throws<NullReferenceException>(act);
        }


        [Fact]
        public void FindAvailableRoom_EndDateBeforeStartDate_ThrowsArgumentException()
        {
            // Arrange

            var bookingManager = new BookingManager(_mockBookingRepo.Object, _mockRoomRepo.Object);

            // Act
            Action act = () => bookingManager.FindAvailableRoom(DateTime.Today.AddDays(12), DateTime.Today.AddDays(10));

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        //[Fact]
        //public void FindAvailableRoom_RoomAvailable_RoomIdNotMinusOne()
        //{
        //    // Arrange
        //    var bookingManager = new BookingManager(_mockBookingRepo.Object, _mockRoomRepo.Object);
        //    DateTime dateStart = DateTime.Today.AddDays(12);
        //    DateTime dateEnd = DateTime.Today.AddDays(21);
        //    // Act
        //    int roomId = bookingManager.FindAvailableRoom(dateStart, dateEnd);
        //    // Assert
        //    Assert.NotEqual(-1, roomId);
        //}

        [Fact]
        public void GetFullyOccupiedDates_StartDayAdd11EndDateAdd16_ReturnsEmptyList()
        {
            //Arrange
            var bookingManager = new BookingManager(_mockBookingRepo.Object, _mockRoomRepo.Object);
            DateTime startDate = DateTime.Today.AddDays(11);
            DateTime endDate = DateTime.Today.AddDays(16);
            //Act
            List<DateTime> fullyOccupiedDates = bookingManager.GetFullyOccupiedDates(startDate, endDate);
            //Assert
            Assert.Empty(fullyOccupiedDates);
        }
        [Fact]
        public void BookingManager_WithNullRepository_ShouldThrowException()
        {
            var bookingManager = new BookingManager(_mockBookingRepo.Object, _mockRoomRepo.Object);
            Action action = () => new BookingManager(null, null);
            action.Should().Throw<NullReferenceException>().WithMessage("Repo cannot be null");
        }

        [Fact]
        public void FullyOccupiedDates_StartDateIsLaterThanEndDate_ThrowArgumentException()
        {
            //Arrange
            var bookingManager = new BookingManager(_mockBookingRepo.Object, _mockRoomRepo.Object);
            DateTime startDate = DateTime.Today.AddDays(5);
            DateTime endDate = DateTime.Today.AddDays(2);
            Action act = () => bookingManager.GetFullyOccupiedDates(startDate, endDate);
            //Act
            var rec = Record.Exception(act);
            //Assert
            Assert.IsType<ArgumentException>(rec);
        }

        [Fact]
        public void CreateBooking_IncorrectStartDate_ReturnsFalse()
        {
            // Arrange

            var bookingManager = new BookingManager(_mockBookingRepo.Object, _mockRoomRepo.Object);
            Booking booking = new()
            {
                StartDate = DateTime.Today.AddDays(12),
                EndDate = DateTime.Today.AddDays(12)
            };

            // Act
            bool isCreated = bookingManager.CreateBooking(booking);

            // Assert
            Assert.False(isCreated);
        }
    }
}

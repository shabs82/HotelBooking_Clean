using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoDi;
using HotelBooking.Core;
using Moq;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public class BookingHooks
    {
        private readonly IObjectContainer container;
        private readonly ScenarioContext _scenarioContext;
        private readonly Mock<IRepository<Booking>> _mockBookingRepo;
        private readonly Mock<IRepository<Room>> _mockRoomRepo;

        public BookingHooks(ScenarioContext scenarioContext, IObjectContainer container)
        {
            this.container = container;
            _scenarioContext = scenarioContext;
            _mockRoomRepo = new Mock<IRepository<Room>>();
            _mockBookingRepo = new Mock<IRepository<Booking>>();
        }

        [BeforeScenario]
        public void InitializeBookingManager()
        {
            var bookingManager = new BookingManager(_mockBookingRepo.Object, _mockRoomRepo.Object);
            container.RegisterInstanceAs<IBookingManager>(bookingManager);
        }
    }
}

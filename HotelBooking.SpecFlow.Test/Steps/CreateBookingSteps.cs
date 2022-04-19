using HotelBooking.Core;
using System;
using TechTalk.SpecFlow;

namespace HotelBooking.SpecFlow.Test.Features
{
    [Binding]
    public class CreateBookingSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly BookingManager _bookingManager;

        public CreateBookingSteps(ScenarioContext scenarioContext, BookingManager bookingManager)
        {
            _scenarioContext = scenarioContext;
            _bookingManager = bookingManager;
        }

        [Given(@"the starting date is a week ago from today")]
        public void GivenTheStartingDateIsAWeekAgoFromToday(Booking booking)
        {
            _scenarioContext["Booking"] = new Booking { Id = 1, StartDate = DateTime.Today.AddDays(-1) , EndDate = DateTime.Today.AddDays(+1), IsActive = true};
        }
        
        [When(@"the create booking button is clicked")]
        public void WhenTheCreateBookingButtonIsClicked()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"it should not allow to create a booking")]
        public void ThenItShouldNotAllowToCreateABooking()
        {
            ScenarioContext.Current.Pending();
        }

    }
}

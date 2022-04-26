using System;
using BoDi;
using HotelBooking.Core;
using Moq;
using SpecFlowProject1.Hooks;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class AddExamplesSteps
    {
        DateTime startDate, endDate;
        Action act;

        private readonly ScenarioContext _scenarioContext;
        private readonly IBookingManager _bookingManager;

        public AddExamplesSteps(ScenarioContext scenarioContext, IBookingManager bookingManager)
        {
            _scenarioContext = scenarioContext;
            _bookingManager = bookingManager;
        }

        [Given(@"I have entered (.*) into the app")]
        public void GivenIHaveEnteredIntoTheApp(string dateA)
        {
            startDate = DateTime.ParseExact(
                  dateA,
                  "yyyy-MM-dd",
                  System.Globalization.DateTimeFormatInfo.InvariantInfo);
        }
        
        [Given(@"I have also entered (.*) into the app")]
        public void GivenIHaveAlsoEnteredIntoTheApp(string dateB)
        {
            endDate = Convert.ToDateTime(dateB);
        }
        
        [When(@"I press confirm")]
        public void WhenIPressConfirm()
        {
            act = () => _bookingManager.FindAvailableRoom(startDate, endDate);
        }
        
        [Then(@"the result should be exception on the screen")]
        public void ThenTheResultShouldBeExceptionOnTheScreen()
        {
            Assert.Throws<ArgumentException>(act);
        }
    }
}

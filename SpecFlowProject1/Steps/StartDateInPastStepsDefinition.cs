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
        private readonly IObjectContainer container;
        private readonly ScenarioContext _scenarioContext;
        private readonly IBookingManager _bookingManager;

        public AddExamplesSteps(ScenarioContext scenarioContext,  IObjectContainer container,
            IBookingManager bookingManager)
        {
            this.container = container;
            _scenarioContext = scenarioContext;
            _bookingManager = bookingManager;
        }

        [Given(@"I have entered (.*) into the app")]
        public void GivenIHaveEnteredIntoTheApp(string dateA)
        {
            startDate = Convert.ToDateTime(dateA);
        }
        
        [Given(@"I have also entered (.*) into the app")]
        public void GivenIHaveAlsoEnteredIntoTheApp(string dateB)
        {
            endDate = Convert.ToDateTime(dateB);
        }
        
        [When(@"I press confirm")]
        public void WhenIPressConfirm()
        {
            //try
            //{
            //    act = () => BookingManager.FindAvailableRoom(startDate, endDate);
            //}
            //catch (ArgumentException err)
            //{
            //    ScenarioContext.Current[("Error")] = err;
            //}

            act = () => _bookingManager.FindAvailableRoom(startDate, endDate);
        }
        
        [Then(@"the result should be exception on the screen")]
        public void ThenTheResultShouldBeExceptionOnTheScreen()
        {
            //Assert.True(ScenarioContext.Current.ContainsKey("Error"));
            Assert.Throws<NullReferenceException>(act);
        }
    }
}

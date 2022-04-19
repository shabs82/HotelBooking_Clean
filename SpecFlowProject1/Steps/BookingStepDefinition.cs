using HotelBooking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace SpecFlowProject1.Steps
{
    [Binding]
    public class BookingStepDefinition
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly BookingManager _bookingManager;

        public BookingStepDefinition(ScenarioContext scenarioContext, BookingManager bookingManager)
        {
            _scenarioContext = scenarioContext;
            _bookingManager = bookingManager;
        }

        [Given(@"the start date is yesterday")]
        public void GivenTheStartDateIsYesterday()
        {
            _scenarioContext["StartDate"] = DateTime.Today;
        }

        [When(@"create button is clicked")]
        public void WhenCreateButtonIsClicked()
        {
            try
            {
                var today = (DateTime)_scenarioContext["StartDate"];

                _bookingManager.FindAvailableRoom(today, DateTime.Today.AddDays(2));
            }
            catch (ArgumentException err)
            {
                ScenarioContext.Current[("Error")] = err;
            }
        }

        [Then(@"the system should throw an invalid date exception")]
        public void ThenTheSystemShouldThrowAnInvalidDateException()
        {
            Assert.True(ScenarioContext.Current.ContainsKey("Error"));
        }


    }


}

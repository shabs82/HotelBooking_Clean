using HotelBooking.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

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
            _bookingManager.CreateBooking(DateTime.Today.AddDays(-1), DateTime.Today.AddDays(1));
        }




    }


}

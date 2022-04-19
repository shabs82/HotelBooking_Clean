Feature: CreateBooking
	Simple calculator for adding two numbers

@mytag
Scenario: Create Booking with Start Date in the past
	Given the start date is yesterday
	When create button is clicked
	Then the system should throw an invalid date exception
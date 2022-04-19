Feature: CreateBooking
	checks if a hotel booking can be made

@mytag
Scenario: Checking if a room can be booked if the date has already passed
	Given the starting date is a week ago from today
	When the create booking button is clicked
	Then it should not allow to create a booking
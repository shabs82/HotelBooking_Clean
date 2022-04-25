Feature: AddExamples
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario Outline: Try book in the past
	Given I have entered <startDate> into the app
	And I have also entered <endDate> into the app
	When I press confirm
	Then the result should be <exception> on the screen

	Examples:
	| startDate | endDate | exception |
	| "2022-04-20" | "2005-05-05" | exception |
	| "2005-04-21" | "2005-05-10" | exception |
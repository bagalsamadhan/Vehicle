Feature: Vehicle
As a consuming system 
I want the vehicle status from from Vehicle Status App
so that I can send the vehicle status in the correct channel.

Background:
	Given all vehicle status in the system are:
		| CityName   | VehicleType | PassedDates         |
		| Gotherburg | Car         | 2013-04-30T08:02:00 |

@wip
Scenario: Retrieve vehicle status with invalid input
	Given vehcile status request is invalid
	When I request vehcile status from the system, with '/vehicle'
	Then I get http status code 'BadRequest' in response

Examples:
	| path         |
	| /vehicle     |
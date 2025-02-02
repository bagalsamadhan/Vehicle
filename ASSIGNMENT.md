Scenario:
Our company has a number of connected vehicles that belongs to a number of customers.
We have a need to be able to view the status of the connection among these vehicles on a monitoring display.

The vehicles send the status of the connection one time per minute.
The status can be compared with a ping (network trace); no request from the vehicle means no connection.

Task:
Your task will be to create a data store that keeps these vehicles with their status and the customers who own them, as well as a GUI (web-based) that displays the status.
How the GUI is designed is up to you, as well as how you choose to implement the features and use suitable technologies.

Obviously, for this task, there are no real vehicles available that can respond to your "ping" request.
This can either be solved by using static values or ​​by creating a separate machinery that returns random fake status.

Requirement:
 A- Business Requirements:
	- Build API for the following:
		- List the vehicles along with its status.
		- Filter the vehicles for a specific customer.
	- Build a single page to display the vehicles along with the status consuming the API

Data:
Below you have all customers from the system; their addresses and the vehicles they own.

Save the information that you think is needed to solve the task above.
If you feel that databases and/or database design isn't something you are comfortable with, you're welcome to store the information in an object in the code.

|-----------------------------------|
| Kalles Grustransporter AB         |
| Cementvägen 8, 111 11 Södertälje  |
|-----------------------------------|
| VIN (VehicleId)       Reg. nr.    |
|-----------------------------------|
| YS2R4X20005399401     ABC123      |
| VLUR4X20009093588     DEF456      |
| VLUR4X20009048066     GHI789      |
|-----------------------------------|

|-----------------------------------|
| Johans Bulk AB                    |
| Balkvägen 12, 222 22 Stockholm    |
|-----------------------------------|
| VIN (VehicleId)       Reg. nr.    |
|-----------------------------------|
| YS2R4X20005388011     JKL012      |
| YS2R4X20005387949     MNO345      |
------------------------------------|

|-----------------------------------|
| Haralds Värdetransporter AB       |
| Budgetvägen 1, 333 33 Uppsala     |
|-----------------------------------|
| VIN (VehicleId)       Reg. nr.    |
|-----------------------------------|
| YS2R4X20005387765     PQR678      |
| YS2R4X20005387055     STU901      |
|-----------------------------------|
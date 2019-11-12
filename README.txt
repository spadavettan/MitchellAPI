ASSUMPTIONS:
Upon viewing the example API, I wrote this project assuming whoever is evaluating has Visual Studio. One only needs this to test the unit tests however, and it should be no issue to still 
test the API using the example client given.

DEPLOYMENT INSTRUCTIONS:
Recommended to run unit tests before messing with test client interactions. This is because the unit tests are designed to operate with Id=0 elements, and posting/deleting to client continues to increment Id
(if we post, then delete, then post again, Id of the single element in the list will be 1 and not 0). This is to mirror the given test client behavior. Unit tests will fail if not tested first.

To run unit tests, simply build the UnitTest project and Run All in Test Explorer. All should pass.

The URL to test the webservice is: https://mitchellapi.azurewebsites.net/api/

This URL only works in the test client. To visually see the json by copy pasting link into browser, you must use https://mitchellapi.azurewebsites.net/api/vehicles

All test client behavior operates as specified by given API.


PROJECT FUNCTIONALITY:
This API is capable of basic CRUD operations on Vehicle objects. 

Vehicle objects are as follows: 

public class Vehicle
    {
        public int Id { get; set; }

        public int Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }
    }

Vehicle objects are stored in a List<Vehicle> vehicles.
Vehicle Id's are incremented using an int vehicleId.


SUPPORTED CALLS: 
GET(int id) will return a vehicle with the given "id" parameter
	
	We specify this using an optional route {id} as a URI parameter, and it will locate the element based on Id in the List using the Find function, then it will return that vehicle.

GET() will return the entire list of vehicles

	We specify this using no parameters - it will simply return the entire List of vehicles.

POST(Vehicle vehicle) will append the vehicle to the list

	We take the vehicle, assign an Id based on the vehicleId variable, then we increment the counter for next append.

PUT(Vehicle vehicle) will update a given vehicle's make/model/year (based on the Id)

	We find the index vehicle based on its Id in the List, then update it to match the parameter vehicle (this is used for update)

DELETE(int id) will delete the vehicle specified by Id from the list
	
	We simply Find and Remove the element with the specified Id from the list



All logic for the controllers is handled in the Models section in the VehicleLogic.cs file under BLL (Business Level Logic). This is to ensure mantainability and readibility when looking at the controller.

The controller itself merely calls Get,Post, etc. functions located in the VehicleLogic.cs file


TESTS:
Unit tests are written using RestSharp package, a simple, easy to use package for RESTful services. They are designed to test every operation in sequence. Getting from empty list, posting,
getting after posting, updating, deleting, deleting from empty list. These can be seen and ran from the UnitTest project as part of the overall solution. Build, Open Test Explorer, Run All BEFORE 
using client to manually test functionality.

Thank you for evaluating my project, and I hope to hear back soon. This was a fun experience!









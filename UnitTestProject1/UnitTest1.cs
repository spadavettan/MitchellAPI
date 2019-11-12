using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

//UNIT TESTS SHOULD BE RUN BEFORE ANY CLIENT OPERATION
//UNIT TESTS SHOULD BE DONE AFTER FRESH REBUILD

//This is due to the incrementation issue with the Id counter - unit tests are designed
//to merely test one element (Id of 0), but the counter always increments unless the project
//is rebuilt/republished - Tests will fail due to Id errors otherwise.

//Tests are built using RestSharp package - commonly used package to test RESTful services
namespace MitchellTest
{
    //class used for testing
    public class Vehicle {
        public int Id { get; set; }

        public int Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }
    }
    [TestClass]
    public class APITest
    {

        //Test if getting from empty list works
        [TestMethod]
        public void GetFromEmpty()
        {

            //call get request with no params
            RestClient restClient = new RestClient("https://mitchellapi.azurewebsites.net/api/vehicles");

            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;

            //if we don't get an empty list, fail
            if (!Equals(response, "[]")) {
                Assert.Fail("get from empty did not return empty list");
            }

        }

        //Test if getting from empty list works
        [TestMethod]
        public void GetWithIdFromEmpty() {

            //call get request at id=0 route 
            RestClient restClient = new RestClient("https://mitchellapi.azurewebsites.net/api/vehicles/0");

            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;

            //if not null, we failed
            if (!Equals(response, "null"))
            {
                Assert.Fail("get from empty did not return null");
            }
        }


        //Test if posting(Creating) works
        [TestMethod]
        public void PostToyota()
        {

            // Post request using a simple Toyota vehicle json
            RestClient restClient = new RestClient("https://mitchellapi.azurewebsites.net/api/vehicles");
  

            RestRequest restRequest = new RestRequest(Method.POST);
           
            restRequest.RequestFormat = DataFormat.Json;

            restRequest.AddJsonBody(
             new
            {   Id = "0",
                Year = "2010",
                Make = "Toyota",
                Model = "Camry"});


            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;

            //if we don't see toyota in our response, we failed
            if (!response.Contains("Toyota")) {
                Assert.Fail("Post failure");
            }

        }

        //Test if READ works
        [TestMethod]
        public void GetAll()
        {

            //get request with no params
            RestClient restClient = new RestClient("https://mitchellapi.azurewebsites.net/api/vehicles");

            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;

            Console.WriteLine(response);

            //if we don't see toyota, fail
            if (!response.Contains("Toyota"))
            {
                Assert.Fail("Failed to find Toyota");
            }

        }

        //Test if READ works
        [TestMethod]
        public void GetWithIdToyota()
        {
            //get request for id=0
            RestClient restClient = new RestClient("https://mitchellapi.azurewebsites.net/api/vehicles/0");

            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;
            Console.WriteLine(response);

            //if we don't see toyota, fail
            if (!response.Contains("Toyota"))
            {
                Assert.Fail("Failed to find Toyota");
            }
        }
        //Test if UPDATE works
        [TestMethod]
        public void PutMazerati()
        {

            //Call a put request to update our element with Mazerati instead of Toyota
            RestClient restClient = new RestClient("https://mitchellapi.azurewebsites.net/api/vehicles");

            RestRequest restRequest = new RestRequest(Method.PUT);
            //Specifies request content type as Json
            restRequest.RequestFormat = DataFormat.Json;

            //Create a body with specifies parameters as json

            restRequest.AddJsonBody(
             new
             {
                 Id = "0",
                 Year = "2020",
                 Make = "Mazerati",
                 Model = "Bodega"
             });


            IRestResponse restResponse = restClient.Execute(restRequest);

            //Call a get request to see if we actually changed anything
            RestClient restClient2 = new RestClient("https://mitchellapi.azurewebsites.net/api/vehicles");

            RestRequest restRequest2 = new RestRequest(Method.GET);

            IRestResponse restResponse2 = restClient.Execute(restRequest2);

            string response2 = restResponse2.Content;
            Console.WriteLine(response2);

            //if we don't see Mazerati, fail
            if (!response2.Contains("Mazerati"))
            {
                Assert.Fail("Put failure");
            }

        }

        //Test if DELETE works
        [TestMethod]
        public void DeleteMazerati() {
            //Delete the element and call a get request to see if it still exists
            RestClient restClient = new RestClient("https://mitchellapi.azurewebsites.net/api/vehicles/0");

            RestRequest restRequest = new RestRequest(Method.DELETE);
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = restClient.Execute(restRequest);

            RestClient restClient2 = new RestClient("https://mitchellapi.azurewebsites.net/api/vehicles");

            RestRequest restRequest2 = new RestRequest(Method.GET);

            IRestResponse restResponse2 = restClient.Execute(restRequest2);

            string response2 = restResponse2.Content;

            //if we see Mazerati, it still exists, so we failed
            if (response2.Contains("Mazerati"))
            {
                Assert.Fail("Delete failure");
            }



        }


        //Test if DELETE works on empty list
        [TestMethod]
        public void DeleteMazeratiFromEmpty() {

            //call a delete on an empty list
            RestClient restClient = new RestClient("https://mitchellapi.azurewebsites.net/api/vehicles/0");

            RestRequest restRequest = new RestRequest(Method.DELETE);
            restRequest.RequestFormat = DataFormat.Json;

            IRestResponse restResponse = restClient.Execute(restRequest);

            string response = restResponse.Content;

            //if we don't get SUCCESS, something went wrong, and we fail
            if (!response.Contains("SUCCESS"))
            {
                Assert.Fail("Delete failure");
            }
        }
    }







    }


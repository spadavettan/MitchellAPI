using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Learn.MVC.Models;


/// <summary>
/// This controller is what handles all API calls, they call functions written in VehicleLogic.cs located in the
/// BLL folder according to their respective HTTP request. They have been modeled after the given API.
/// All of the logic has been stored in the BLL for maintainability and readibility.
/// </summary>
namespace Learn.MVC.Controllers
{

    //enable CORS for the test client
    [EnableCors(origins: "https://estimate-dev.mymitchell.com", headers: "*", methods: "*")]
    [RoutePrefix("api/vehicles")]
    public class ApiVehicleController : ApiController
    {

        //The get request can take either an int or no params (hence the "int? id=null"). If there is an int param
        //given, it will be handled differently than if no params are given (see VehicleLogic.cs)

        //Similar concept applies for {id} route - not necessary, but if given, use it as resource

        [HttpGet]
        [Route("{id?}")]
        public HttpResponseMessage GetVehicles(int? id = null, string make = null, string model = null)
        {
            return VehicleLogic.GetVehicles(Request, id);
        }


        //Post takes a vehicle and appends it to list, further details are in VehicleLogic.cs
        [HttpPost]
        [Route("")]
        public HttpResponseMessage PostVehicles(Vehicle vehicle)
        {
            return VehicleLogic.PostVehicles(Request, vehicle);
        }


        //Put will update an existing vehicle in the list based on Id, further details in VehicleLogic.cs
        [HttpPut]
        [Route("")]
        public HttpResponseMessage PutVehicles(Vehicle vehicle)
        {
            return VehicleLogic.PutVehicles(Request, vehicle);
        }


        //Delete merely removes an element from the list, further details in VehicleLogic.cs
        //Similar to GET above, uses id as URI param, so we include in our Route
        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage DeleteVehicles(int id)
        {
            return VehicleLogic.DeleteVehicles(Request, id);
        }
    }
}

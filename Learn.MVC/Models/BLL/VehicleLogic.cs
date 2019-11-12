using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;

namespace Learn.MVC.Models
{
    public class VehicleLogic
    {
        //important data variables
        //vehicleId increments every time something is appended to the list through a POST
        //vehicles is the list that holds all Vehicles
        public static int vehicleId = 0;
        public static List<Vehicle> vehicles = new List<Vehicle>();


        //Logic for GET requests
        //May take an int or no params
        public static HttpResponseMessage GetVehicles(HttpRequestMessage request, int? id = null)
        {
            try
            {

                //if we are given an id, find that vehicle in the list and return success
                if (id != null) {

                    Vehicle vehicle = vehicles.Find(v => v.Id == id);
                    return request.CreateResponse(HttpStatusCode.OK, vehicle, JsonMediaTypeFormatter.DefaultMediaType);
                }

                //if we are not given an id, return entire list of vehicles
                else
                {
                    return request.CreateResponse(HttpStatusCode.OK, vehicles, JsonMediaTypeFormatter.DefaultMediaType);
                }
            }

            //return conflict if exception occurs
            catch (Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.Conflict, ex);
            }
        }


        //Logic for POST requests
        //Takes request and vehicle object to append to list
        public static HttpResponseMessage PostVehicles(HttpRequestMessage request, Vehicle vehicle)
        {
            try
            {
                //set the vehicles Id to match our counter, then increment the vehicleId counter
                vehicle.Id = vehicleId;
                vehicleId++;

                //add to list and return OK with vehicle object in response
                vehicles.Add(vehicle);
                return request.CreateResponse(HttpStatusCode.OK, vehicle, JsonMediaTypeFormatter.DefaultMediaType);
            }

            //return conflict if exception occurs
            catch(Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.Conflict, ex);
            }
        }


        //Logic for PUT requests
        //Used for handling updates - replaces element in the list with corresponding Id with the new vehicle param
        public static HttpResponseMessage PutVehicles(HttpRequestMessage request, Vehicle vehicle)
        {
            try
            {
                //find the old vehicle, and remove it
                Vehicle oldVehicle = vehicles.Find(v => v.Id == vehicle.Id);
                vehicles.Remove(oldVehicle);

                //add the modified vehicle and return SUCCESS
                vehicles.Add(vehicle);
                return request.CreateResponse(HttpStatusCode.OK, "SUCCESS");
            }

            //return conflict if exception occurs
            catch(Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.Conflict, ex);
            }
        }


        //Logic for DELETE requests
        //Used for handling deletion - if the vehicle with param id is in the list, remove it
        public static HttpResponseMessage DeleteVehicles(HttpRequestMessage request, int id)
        {
            try
            {

                //find and remove vehicle with given id, if it exists
                Vehicle vehicle = VehicleLogic.vehicles.Find(v => v.Id == id);
                if (vehicle != null)
                {
                    VehicleLogic.vehicles.Remove(vehicle);
                }

                //return SUCCESS
                return request.CreateResponse(HttpStatusCode.OK, "SUCCESS");
            }

            //return conflict if exception occurs
            catch(Exception ex)
            {
                return request.CreateResponse(HttpStatusCode.Conflict, ex);
            }
        }




    }
}
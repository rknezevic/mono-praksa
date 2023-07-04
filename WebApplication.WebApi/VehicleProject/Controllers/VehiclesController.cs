using Antlr.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using VehicleProject.Models;

namespace VehicleProject.Controllers
{
    
    public class VehiclesController : ApiController
    {
        private static List<Vehicle> vehicles;

        public List<Vehicle> Vehicles
        {
            get
            {
                if (vehicles == null)
                {
                    vehicles = new List<Vehicle>(); 
                    vehicles.Add(new Vehicle("Car", 1, 210, 170000));
                    vehicles.Add(new Vehicle("Car", 2, 270, 270000));
                    vehicles.Add(new Vehicle("Bicycle", 3, 20, 100));
                    vehicles.Add(new Vehicle("Aeroplane", 4, 210, 410000));
                }
                return vehicles;
            }
        }
        //GET all vehicles
        public HttpResponseMessage Get()
        {
            if(Vehicles == null)
            {
                Request.CreateResponse(HttpStatusCode.NotFound);
            }

            List<VehicleView> vehicleViews = new List<VehicleView>();

            foreach(Vehicle vehicle in Vehicles)
            {
                vehicleViews.Add(new VehicleView(vehicle.Type, vehicle.MaxSpeed, vehicle.KilometersTraveled));
            }

            return Request.CreateResponse(HttpStatusCode.OK, vehicleViews);
           
        }
       
        //GET vehicle by id
        public HttpResponseMessage GetVehicleById(int id)
        {
            Vehicle foundVehicle = Vehicles.FirstOrDefault(getVehicle => getVehicle.Id == id);
            
            if (foundVehicle == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            VehicleViewById vehicle = new VehicleViewById(foundVehicle.Id, foundVehicle.Type, foundVehicle.MaxSpeed, foundVehicle.KilometersTraveled);

            return Request.CreateResponse(HttpStatusCode.OK, vehicle);
            
        }

        //POST vehicle
        public HttpResponseMessage PostNewVehicle(CreateVehicle vehicle)
        {
            int id = GenerateId();
            
            Vehicle newVehicle = new Vehicle
            {
                Id = id,
                Type = vehicle.Type,
                KilometersTraveled = vehicle.KilometersTraveled, 
                MaxSpeed = vehicle.MaxSpeed
            };

            vehicles.Add(newVehicle);

            return Request.CreateResponse(HttpStatusCode.OK, newVehicle);
        }

        // PUT api/values
        public HttpResponseMessage Put(int id, [FromBody] UpdateVehicle vehicle)
        {
           
            Vehicle targetVehicle = Vehicles.Find(v => v.Id == id);

            if (targetVehicle == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                targetVehicle.Type = vehicle.Type;
                targetVehicle.KilometersTraveled = vehicle.KilometersTraveled;
                targetVehicle.MaxSpeed = vehicle.MaxSpeed;

                return Request.CreateResponse(HttpStatusCode.OK, targetVehicle);

            }

        }
        // DELETE api/Vehicles/{id}
        public HttpResponseMessage DeleteVehicleById(int id)
        {
            Vehicle vehicle = Vehicles.FirstOrDefault(deleteVehicle => deleteVehicle.Id == id);

            if (vehicle == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            Vehicles.Remove(vehicle);
            return Request.CreateResponse(HttpStatusCode.OK, Vehicles);

             
            
        }
        private int GenerateId()
        {
            return Vehicles.Max(vehicle => vehicle.Id) + 1;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleProject.Models
{
    public class Vehicle
    {
        public string Type { get; set; }

        public int Id { get; set; }

        public int MaxSpeed { get; set; }

        public long KilometersTraveled { get; set; }

       public Vehicle(string type, int id, int maxSpeed, long kmTraveled)
        {
            Type = type; 
            Id = id; 
            MaxSpeed = maxSpeed;
            KilometersTraveled = kmTraveled;
        }

        public Vehicle()
        {
        }
    }
}
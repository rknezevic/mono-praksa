using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleProject.Models
{
    public class VehicleViewById
    {
        public int Id { get; set; } 
        public string Type { get; set; }

        public int MaxSpeed { get; set; }

        public long KilometersTraveled { get; set; }

        public VehicleViewById(int id, string type, int maxSpeed, long kmTraveled)
        {
            Id = id;
            Type = type;
            MaxSpeed = maxSpeed;
            KilometersTraveled = kmTraveled;
        }
        public VehicleViewById() { }
    }
}
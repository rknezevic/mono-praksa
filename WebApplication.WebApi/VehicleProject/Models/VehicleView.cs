using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleProject.Models
{
    public class VehicleView
    {
        public string Type { get; set; }

        public int MaxSpeed { get; set; }

        public long KilometersTraveled { get; set; }

        public VehicleView(string type, int maxSpeed, long kmTraveled)
        {
            Type = type;
            MaxSpeed = maxSpeed;
            KilometersTraveled = kmTraveled;
        }
        public VehicleView() { }
    }
}
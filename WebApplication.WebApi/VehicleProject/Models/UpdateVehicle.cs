using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleProject.Models
{
    public class UpdateVehicle
    {
        public string Type { get; set; }

        public int MaxSpeed { get; set; }

        public long KilometersTraveled { get; set; }

    }
}
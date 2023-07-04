using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.WebApi.Models
{
    public class Vehicle
    {
        public string Type { get; set; }

        public Guid Id { get; set; }

        public int MaxSpeed { get; set; }

        public int KilometersTraveled { get; set; }

        public Vehicle() { }
        



    }
}
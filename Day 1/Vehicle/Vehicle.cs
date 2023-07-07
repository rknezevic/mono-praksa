using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    public abstract class Vehicle
    {

        public Vehicle()
        {

        }

        public abstract string GetVehicleType();


        public abstract double CalculateTripTime(double distance);


    }
}

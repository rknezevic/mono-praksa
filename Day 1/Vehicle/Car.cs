using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    public class Car : Vehicle, IVehicle, IRoadVehicle
    {
   

        public string Make { get; private set; }

        public double Speed { get; private set; }

        public string FuelType { get; private set; }    

        public double FuelConsumption { get; private set; }

        public Car() { }
        public Car(double speed, string make, string fuelType, double fuelConsumption )
        {
            
            Speed = speed;
            Make = make;    
            FuelType = fuelType;
            FuelConsumption = fuelConsumption;  

        }

        public override double CalculateTripTime(double distance)
        {
            return distance / Speed;
        }

        public string GetPrice()
        {
            return "7000 $";
        }

        public double CalculatateFuelConsumption(double distance) 
        {
            return distance / 100 * FuelConsumption;
        }
        public bool IsPoweredByEngine()
        {
            return true;
        }

        public int NumberOfWheels()
        {
            return 4;
        }

        public override string GetVehicleType()
        {
            return "This is a car.";
        }

    }
}

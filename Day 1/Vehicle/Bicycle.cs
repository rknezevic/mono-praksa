using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    public class Bicycle : Vehicle, IRoadVehicle, IVehicle
    {
        private double lungsCapacity = 0.0;
        public double LungsCapacity
        {
            get { return lungsCapacity; }

            private set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException();
                }
                lungsCapacity = value;
            }
        }

        public string Make { get; private set; }

        private int numberOfGears;

        private double phisicalityLevel =0.0;
        public double PhisicalityLevel { get { return phisicalityLevel; } 
           
            private set 
            {
                if(value < 0.0 || value > 1.0) 
                {
                    throw new ArgumentException();
                }
               phisicalityLevel = value;    
            } 
        }


        public Bicycle(string make, int numberOfGears, double lungsCapacity, double phisicalityLevel)
        {
            Make = make;
            this.numberOfGears = numberOfGears;  
            LungsCapacity = lungsCapacity;
            PhisicalityLevel = phisicalityLevel;
      
        }

        public override double CalculateTripTime(double distance)
        {
            return distance / (LungsCapacity * numberOfGears * PhisicalityLevel);    
        }

        public int NumberOfWheels()
        {
            return 2;
        }

        public bool IsPoweredByEngine()
        {
            return false;
        }

        public string GetPrice()
        {
            return "500 $";
        }

        public override string GetVehicleType()
        {
            return "This is bicycle.";
        }

    }
}

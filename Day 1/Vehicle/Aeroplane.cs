using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    public class Aeroplane : Vehicle, IVehicle, IFlyableVehicles
    {
        public string Make { get; private set; }

        public int WingsSpan { get; private set; }  

        public double Speed { get; private set; }

        public Aeroplane(string make, double speed, int wingsSpan)
        {
            Make = make;
            Speed = speed;
            WingsSpan = wingsSpan;
        }

        public double GetWingsSpan()
        {
            return WingsSpan;
        }

        

        public bool IsPoweredByEngine()
        {
            return true;
        }

        public virtual string GetPrice()
        {
            return "270 000$";
        }

        public override double CalculateTripTime(double distance)
        {
            return distance / Speed;
        }
        public override string GetVehicleType()
        {
            return "This is aeroplane.";
        }
    }
}

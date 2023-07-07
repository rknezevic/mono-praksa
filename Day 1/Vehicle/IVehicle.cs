using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle
{
    public interface IVehicle
    {
        bool IsPoweredByEngine();

        string GetPrice();  
    }
}

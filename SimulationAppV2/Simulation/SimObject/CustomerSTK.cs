using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.SimObject
{
    internal class CustomerSTK : Customer
    {
        public CarType Car { get; set; }
        public CustomerSTK(CarType car) 
        { 
            Car = car;
        }
    }

    enum CarType
    {
        PersonalCar,
        Van,
        Truck
    }
}

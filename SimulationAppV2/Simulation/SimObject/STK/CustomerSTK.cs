using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.SimObject.STK
{
    internal class CustomerSTK : Customer
    {
        public CarType Car { get; set; }
        public int ID { get; }
        public Status Status { get; set; }
        public CustomerSTK(CarType car, int id)
        {
            Car = car;
            ID = id;
            Status = 0;
        }
    }

    enum CarType
    {
        None = 0,
        PersonalCar,
        Van,
        Truck
    }

    enum Status
    {
        None = 0,
        WaitingTakeOver,
        TakingOver,
        WaitingControlling,
        Controlling,
        WaitingPaying,
        Paying
    }
}

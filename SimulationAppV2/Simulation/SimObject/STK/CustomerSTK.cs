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
        public double Arrival {get; set; }
        public CustomerSTK(CarType car, int id, double arrival)
        {
            Car = car;
            ID = id;
            Status = 0;
            Arrival = arrival;
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

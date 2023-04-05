using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.SimObject.STK
{
    internal class TechnicianSTK : EmployerSTK
    {
        public CarType ControlledCar { get; set; }
        public TechnicianWork WorkingOn { get; set; }
        public int CustomerID { get; set; }
        public TechnicianSTK(int id) : base(id)
        { 
            ControlledCar = CarType.None;
            WorkingOn = TechnicianWork.Break;
        }
        public void TechnicianBreak()
        {
            CustomerID = 0;
            ControlledCar = CarType.None;
            WorkingOn = TechnicianWork.Break;
        }
        public void StartWork(int customerID, CarType car)
        {
            CustomerID = customerID;
            WorkingOn = STK.TechnicianWork.Controling;
            ControlledCar = car;
        }
    }

    enum TechnicianWork
    {
        Break,
        Controling
    }
}

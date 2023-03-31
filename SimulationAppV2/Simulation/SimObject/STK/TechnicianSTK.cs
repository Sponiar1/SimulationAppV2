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
        public TechnicianSTK(int id) : base(id)
        { 
            ControlledCar = CarType.None;
            WorkingOn = TechnicianWork.Break;
        }

    }

    enum TechnicianWork
    {
        Break,
        Controling
    }
}

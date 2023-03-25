using SimulationAppV2.Simulation.SimObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class ControlStartSTK : EventSTK
    {
        public ControlStartSTK(SimSTK sim, Customer paCustomer)
            : base(sim, paCustomer) { }

        public override void Exec()
        {
            ControlEndSTK controlEndSTK = new ControlEndSTK(myCore, customer);
            controlEndSTK.Time = myCore.CurrentTime + myCore.getCarType();
            myCore.addEvent(controlEndSTK);
        }
    }
}

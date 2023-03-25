using System;
using SimulationAppV2.Simulation.SimObject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class TakeOverStartSTK : EventSTK
    {
        public TakeOverStartSTK(SimSTK sim, Customer paCustomer)
            : base(sim, paCustomer) { }

        public override void Exec()
        {
            TakeOverEndSTK takeOverEndSTK = new TakeOverEndSTK(myCore, customer);
            takeOverEndSTK.Time = myCore.CurrentTime + myCore.getshopParkingTime();
            myCore.addEvent(takeOverEndSTK);
        }
    }
}

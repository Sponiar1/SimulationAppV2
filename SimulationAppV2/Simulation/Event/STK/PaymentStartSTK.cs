using SimulationAppV2.Simulation.SimObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class PaymentStartSTK : EventSTK
    {
        public PaymentStartSTK(SimSTK sim, Customer paCustomer)
            : base(sim, paCustomer) { }

        public override void Exec()
        {

        }
    }
}

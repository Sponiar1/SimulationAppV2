using SimulationAppV2.Simulation.SimObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class EventSTK : Event
    {
        protected Customer customer;
        protected SimSTK myCore;

        public EventSTK(SimSTK myCore, Customer customer)
            : base(myCore)
        {
            this.myCore = myCore;
            this.customer = customer;
        }
    }
}

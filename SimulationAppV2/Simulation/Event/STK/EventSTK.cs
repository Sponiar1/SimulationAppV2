﻿using SimulationAppV2.Simulation.SimObject.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class EventSTK : Event
    {
        protected CustomerSTK customer;
        protected SimSTK myCore;

        public EventSTK(SimSTK myCore, CustomerSTK customer)
            : base(myCore)
        {
            this.myCore = myCore;
            this.customer = customer;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event
{
    internal class Event
    {
        public double Time { get; set; }
        protected SimEventCore myCore;

        public Event(SimEventCore core)
        {
            myCore = core;
        }
        public virtual void Exec()
        {

        }
    }
}

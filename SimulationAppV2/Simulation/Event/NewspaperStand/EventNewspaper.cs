using ScottPlot.SnapLogic;
using System;
using SimulationAppV2.Simulation.SimObject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.NewspaperStand
{
    internal class EventNewspaper : Event
    {
        protected Customer customer;
        protected Simulation.SimNewspaper myCore;

        public EventNewspaper(SimNewspaper simEventCore, Customer paCustomer) : base(simEventCore)
        {
            myCore = simEventCore;
            customer = paCustomer;
        }
    }
}

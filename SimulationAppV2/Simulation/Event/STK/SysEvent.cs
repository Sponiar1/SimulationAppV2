using SimulationAppV2.Simulation.SimObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class SysEvent : Event
    {
        public SysEvent(SimEventCore sim)
            : base(sim)
        {

        }

        public override void Exec()
        {
            if (!myCore.Turbo)
            {
                Thread.Sleep(myCore.Delay);
                this.Time = myCore.CurrentTime + myCore.RefreshTime;
                myCore.addEvent(this);
            }
        }
    }
}

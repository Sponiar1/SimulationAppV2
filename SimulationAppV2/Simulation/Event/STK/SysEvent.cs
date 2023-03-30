using SimulationAppV2.Simulation.SimObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class SysEvent : EventSTK
    {
        public SysEvent(SimSTK sim)
            : base(sim, null)
        {

        }

        public override void Exec()
        {
            Thread.Sleep(100);
            this.Time = myCore.RefreshTime + myCore.CurrentTime;
            myCore.addEvent(this);
        }
    }
}

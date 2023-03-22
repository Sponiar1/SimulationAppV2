using SimulationAppV2.Simulation.SimObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.NewspaperStand
{
    internal class EndOfService : EventNewspaper
    {
        public EndOfService(SimNewspaper core, Customer paCustomer)
            : base(core, paCustomer)
        {

        }

        public override void Exec()
        {
            if (myCore.QueueSize() == 0)
            {
                myCore.ServiceWorking = false;
            }
            else
            {
                ServiceStart serviceEvent = new ServiceStart(myCore, myCore.getCustomerFromQueue());
                serviceEvent.Time = myCore.CurrentTime;
                myCore.addEvent(serviceEvent);
            }
        }
    }
}

using System;
using SimulationAppV2.Simulation.SimObject;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.NewspaperStand
{
    internal class ArrivalEvent : EventNewspaper
    {
        public ArrivalEvent(SimNewspaper simCore, Customer paCustomer)
            : base(simCore, paCustomer)
        {
        }

        public override void Exec()
        {
            Time = myCore.getArrivalTime() + myCore.CurrentTime;
            myCore.addEvent(this);
            customer.WaitingStartAt = myCore.CurrentTime;

            if (myCore.ServiceWorking)
            {
                myCore.addToQueue(customer);
                myCore.updateQueueStats();
            }
            else
            {
                ServiceStart serviceEvent = new ServiceStart(myCore, customer);
                serviceEvent.Time = myCore.CurrentTime;
                myCore.addEvent(serviceEvent);
                myCore.ServiceWorking = true;
            }
            Customer newCustomer = new Customer();
            this.customer = newCustomer;
        }
    }
}

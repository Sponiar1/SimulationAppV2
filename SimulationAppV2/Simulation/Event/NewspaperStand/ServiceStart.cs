using SimulationAppV2.Simulation.SimObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.NewspaperStand
{
    internal class ServiceStart : EventNewspaper
    {
        public ServiceStart(SimNewspaper core, Customer paCustomer)
            : base(core, paCustomer)
        {

        }

        public override void Exec()
        {
            myCore.StatisticSum += myCore.CurrentTime - customer.WaitingStartAt;
            myCore.StatisticCount++;
            EndOfService serviceEnd = new EndOfService(myCore, customer);
            serviceEnd.Time = myCore.getServiceTime() + myCore.CurrentTime;
            myCore.addEvent(serviceEnd);
            myCore.updateQueueStats();
        }
    }
}

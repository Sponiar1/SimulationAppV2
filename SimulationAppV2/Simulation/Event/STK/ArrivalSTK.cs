using SimulationAppV2.Simulation.SimObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class ArrivalSTK : EventSTK
    {
        public ArrivalSTK(SimSTK simCore, Customer paCustomer) 
        : base(simCore, paCustomer)
        { }

        public override void Exec()
        {
            Time = myCore.CurrentTime + myCore.getArrivalTime();
            myCore.addEvent(this);

            if(myCore.Cashiers == 0 || myCore.Customers.Count != 0 || myCore.ControlWaiting.Count() >= 5)
            {
                myCore.addCustomerToQueue(customer);
            }
            else
            {
                TakeOverStartSTK takeOver = new TakeOverStartSTK(myCore, customer);
                takeOver.Time = myCore.CurrentTime;
                myCore.addEvent(takeOver);
                myCore.Cashiers--;
                myCore.addCustomerToControl(customer);
            }
            Customer newCustomer = new Customer();
            this.customer = newCustomer;
        }
    }
}

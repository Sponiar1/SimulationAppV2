using SimulationAppV2.Simulation.SimObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class ControlStartSTK : EventSTK
    {
        public ControlStartSTK(SimSTK sim, Customer paCustomer)
            : base(sim, paCustomer) { }

        public override void Exec()
        {
            ControlEndSTK controlEndSTK = new ControlEndSTK(myCore, customer);
            controlEndSTK.Time = myCore.CurrentTime + myCore.getCarTime();
            myCore.addEvent(controlEndSTK);
            
            if(myCore.Customers.Count() > 0 && myCore.Cashiers > 0 && myCore.PaymentQueue.Count() == 0) 
            {
                TakeOverStartSTK takeOver = new TakeOverStartSTK(myCore, myCore.Customers.Dequeue());
                takeOver.Time = myCore.CurrentTime;
                myCore.Cashiers--;
                myCore.AvailableSpots--;
                myCore.addEvent(takeOver);
            }
        }
    }
}

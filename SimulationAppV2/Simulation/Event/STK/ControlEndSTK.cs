using SimulationAppV2.Simulation.SimObject.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class ControlEndSTK : EventSTK
    {
        public ControlEndSTK(SimSTK sim, CustomerSTK paCustomer)
            : base(sim, paCustomer) { }

        public override void Exec()
        {
            if(myCore.ControlWaiting.Count() > 0)
            {
                ControlStartSTK controlStartSTK = new ControlStartSTK(myCore, myCore.ControlWaiting.Dequeue());
                controlStartSTK.Time = myCore.CurrentTime;
                myCore.addEvent(controlStartSTK);
                myCore.AvailableSpots++;
            }
            else
            {
                myCore.AvailableTechnicians++;
            }

            if(myCore.PaymentQueue.Count() == 0 && myCore.AvailableCashiers > 0)
            {
                PaymentStartSTK paymentStartSTK = new PaymentStartSTK(myCore, customer);
                paymentStartSTK.Time = myCore.CurrentTime;
                myCore.addEvent(paymentStartSTK);
                myCore.AvailableCashiers--;
            }
            else
            {
                myCore.PaymentQueue.Enqueue(customer);
            }
        }
    }
}

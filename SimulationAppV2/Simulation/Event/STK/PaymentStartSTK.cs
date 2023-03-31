using SimulationAppV2.Simulation.SimObject.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class PaymentStartSTK : EventSTK
    {
        public PaymentStartSTK(SimSTK sim, CustomerSTK paCustomer)
            : base(sim, paCustomer) { }

        public override void Exec()
        {
            PaymentEndSTK paymentEndSTK = new PaymentEndSTK(myCore, customer);
            paymentEndSTK.Time = myCore.CurrentTime + myCore.getshopPaymentTime();
            myCore.addEvent(paymentEndSTK);
        }
    }
}

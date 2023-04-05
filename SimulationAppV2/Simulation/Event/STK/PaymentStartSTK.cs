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
        CashierSTK cashier;
        public PaymentStartSTK(SimSTK sim, CustomerSTK paCustomer, CashierSTK cashier)
            : base(sim, paCustomer) { this.cashier = cashier; }

        public override void Exec()
        {
            customer.Status = Status.Paying;
            cashier.BeginPayment(customer.ID);
            PaymentEndSTK paymentEndSTK = new PaymentEndSTK(myCore, customer, cashier);
            paymentEndSTK.Time = myCore.CurrentTime + myCore.GetshopPaymentTime();
            myCore.addEvent(paymentEndSTK);
        }
    }
}

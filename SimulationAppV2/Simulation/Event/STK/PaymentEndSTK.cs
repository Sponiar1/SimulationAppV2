using SimulationAppV2.Simulation.SimObject.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class PaymentEndSTK : EventSTK
    {
        CashierSTK cashier;
        public PaymentEndSTK(SimSTK sim, CustomerSTK paCustomer, CashierSTK cashier)
            : base(sim, paCustomer) { this.cashier = cashier; }

        public override void Exec()
        {
            if(myCore.PaymentQueue.Count() > 0)
            {
                PaymentStartSTK paymentStartSTK = new PaymentStartSTK(myCore, myCore.PaymentQueue.Dequeue(), cashier);
                paymentStartSTK.Time = this.Time;
                myCore.addEvent(paymentStartSTK);
            }
            else if (myCore.Customers.Count() > 0 && myCore.AvailableSpots > 0)
            {
                TakeOverStartSTK takeOverStartSTK = new TakeOverStartSTK(myCore,myCore.Customers.Dequeue(), cashier);
                takeOverStartSTK.Time = this.Time;
                myCore.addEvent(takeOverStartSTK);
                myCore.AvailableSpots--;
            }
            else
            {
                //myCore.AvailableCashiers++;
                cashier.BeginBreak();
                myCore.AvailableCashiers.Enqueue(cashier);
            }
            myCore.CustomersInSystem.Remove(customer.ID);
            myCore.Left++;
            myCore.AverageTimeInSystem.Add(Time - customer.Arrival);
        }
    }
}

using SimulationAppV2.Simulation.SimObject.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class TakeOverEndSTK : EventSTK
    {
        CashierSTK cashier;
        public TakeOverEndSTK(SimSTK sim, CustomerSTK paCustomer, CashierSTK cashier)
            : base(sim, paCustomer) { this.cashier = cashier; }

        public override void Exec()
        {
            if(myCore.PaymentQueue.Count() > 0) 
            {
                PaymentStartSTK paymentStartSTK = new PaymentStartSTK(myCore, myCore.PaymentQueue.Dequeue(), cashier);
                paymentStartSTK.Time = myCore.CurrentTime;
                myCore.addEvent(paymentStartSTK);
            }
            else if(myCore.Customers.Count() > 0 && myCore.AvailableSpots > 0)
            {
                TakeOverStartSTK takeOver = new TakeOverStartSTK(myCore, myCore.Customers.Dequeue(), cashier);
                takeOver.Time = myCore.CurrentTime;
                myCore.addEvent(takeOver);
                myCore.AvailableSpots--;
                //myCore.ControlWaiting.Enqueue(customer);
            }
            else
            {
                //myCore.AvailableCashiers++;
                cashier.BeginBreak();
                myCore.AvailableCashiers.Enqueue(cashier);
            }

            if(myCore.AvailableTechnicians.Count() > 0) 
            {
                ControlStartSTK controlStartSTK = new ControlStartSTK(myCore, customer, myCore.AvailableTechnicians.Dequeue());
                controlStartSTK.Time = myCore.CurrentTime;
                myCore.addEvent(controlStartSTK);
                //myCore.AvailableTechnicians--;
                myCore.AvailableSpots++;
            }
            else
            {
                customer.Status = Status.WaitingControlling;
                myCore.ControlWaiting.Enqueue(customer);
            }
        }
    }
}

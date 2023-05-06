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
            customer.WaitingStartAt = Time;
            if(myCore.PaymentQueue.Count() > 0) 
            {
                myCore.AveragePaymentQueue.Add(myCore.PaymentQueue.Count(), Time);
                PaymentStartSTK paymentStartSTK = new PaymentStartSTK(myCore, myCore.PaymentQueue.Dequeue(), cashier);
                paymentStartSTK.Time = myCore.CurrentTime;
                myCore.addEvent(paymentStartSTK);
            }
            else if(myCore.Customers.Count() > 0 && myCore.AvailableSpots > 0)
            {
                myCore.AveragePeopleWaitingForTakeOver.Add(myCore.Customers.Count(), myCore.CurrentTime);
                TakeOverStartSTK takeOver = new TakeOverStartSTK(myCore, myCore.Customers.Dequeue(), cashier);
                takeOver.Time = myCore.CurrentTime;
                myCore.addEvent(takeOver);
                myCore.AverageFreeSpots.Add(myCore.AvailableSpots, Time);
                myCore.AvailableSpots--;
            }
            else
            {
                cashier.BeginBreak();
                myCore.AverageFreeCashier.Add(myCore.AvailableCashiers.Count(), myCore.CurrentTime);
                myCore.AvailableCashiers.Enqueue(cashier);
            }

            if(myCore.AvailableTechnicians.Count() > 0) 
            {
                myCore.AverageFreeTechnician.Add(myCore.AvailableTechnicians.Count(), myCore.CurrentTime);
                ControlStartSTK controlStartSTK = new ControlStartSTK(myCore, customer, myCore.AvailableTechnicians.Dequeue());
                controlStartSTK.Time = myCore.CurrentTime;
                myCore.addEvent(controlStartSTK);
                myCore.AverageFreeSpots.Add(myCore.AvailableSpots, Time);
                myCore.AvailableSpots++;
            }
            else
            {
                myCore.AverageControlQueue.Add(myCore.ControlWaiting.Count(), Time);
                customer.Status = Status.WaitingControlling;
                myCore.ControlWaiting.Enqueue(customer);
            }
        }
    }
}

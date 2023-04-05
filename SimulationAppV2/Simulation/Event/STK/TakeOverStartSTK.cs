using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationAppV2.Simulation.SimObject.STK;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class TakeOverStartSTK : EventSTK
    {
        CashierSTK cashier;
        public TakeOverStartSTK(SimSTK sim, CustomerSTK paCustomer, CashierSTK cashier)
            : base(sim, paCustomer) { this.cashier = cashier; }

        public override void Exec()
        {
            cashier.BeginTakeOver(customer.ID);
            myCore.TakeOverWaiting.Add(Time - customer.Arrival);
            customer.Status = Status.TakingOver;
            TakeOverEndSTK takeOverEndSTK = new TakeOverEndSTK(myCore, customer, cashier);
            takeOverEndSTK.Time = myCore.CurrentTime + myCore.GetshopParkingTime();
            myCore.addEvent(takeOverEndSTK);
        }
    }
}

﻿using SimulationAppV2.Simulation.SimObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class PaymentEndSTK : EventSTK
    {
        public PaymentEndSTK(SimSTK sim, Customer paCustomer)
            : base(sim, paCustomer) { }

        public override void Exec()
        {
            if(myCore.PaymentQueue.Count > 0)
            {
                PaymentStartSTK paymentStartSTK = new PaymentStartSTK(myCore, myCore.PaymentQueue.Dequeue());
                paymentStartSTK.Time = this.Time;
                myCore.addEvent(paymentStartSTK);
            }
            else if (myCore.Customers.Count > 0 && myCore.ControlWaiting.Count() < 5)
            {
                TakeOverStartSTK takeOverStartSTK = new TakeOverStartSTK(myCore,myCore.Customers.Dequeue());
                takeOverStartSTK.Time = this.Time;
                myCore.addEvent(takeOverStartSTK);
            }
            else
            {
                myCore.Cashiers++;
            }
        }
    }
}
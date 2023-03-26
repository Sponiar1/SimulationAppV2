﻿using SimulationAppV2.Simulation.SimObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class TakeOverEndSTK : EventSTK
    {
        public TakeOverEndSTK(SimSTK sim, Customer paCustomer)
            : base(sim, paCustomer) { }

        public override void Exec()
        {
            if(myCore.PaymentQueue.Count() > 0) 
            {
                PaymentStartSTK paymentStartSTK = new PaymentStartSTK(myCore, myCore.PaymentQueue.Dequeue());
                paymentStartSTK.Time = myCore.CurrentTime;
                myCore.addEvent(paymentStartSTK);
            }
            else if(myCore.Customers.Count() > 0 && myCore.ControlWaiting.Count() < 5)
            {
                TakeOverStartSTK takeOver = new TakeOverStartSTK(myCore, myCore.Customers.Dequeue());
                takeOver.Time = myCore.CurrentTime;
                myCore.addEvent(takeOver);
                myCore.addCustomerToControl(customer);
            }
            else
            {
                myCore.Cashiers++;
            }

            if(myCore.Technicians > 0) 
            {
                ControlStartSTK controlStartSTK = new ControlStartSTK(myCore, customer);
                controlStartSTK.Time = myCore.CurrentTime;
                myCore.addEvent(controlStartSTK);
                myCore.Technicians--;
            }
            else
            {
                myCore.addCustomerToControl(customer);
            }
        }
    }
}
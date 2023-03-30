﻿using SimulationAppV2.Simulation.SimObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class ArrivalSTK : EventSTK
    {
        public ArrivalSTK(SimSTK simCore, CustomerSTK paCustomer) 
        : base(simCore, paCustomer)
        { }

        public override void Exec()
        {
            Time = myCore.CurrentTime + myCore.getArrivalTime();
            if (Time < myCore.STKDetails.StopAccepting)
            {
                myCore.addEvent(this);
                myCore.Arrived++;
            }

            //   neni volny pokladnik    stoja v rade                       neni miesto pred kontrolou                                  neni otvorene
            if(myCore.Cashiers == 0 || myCore.Customers.Count() != 0 || /*myCore.ControlWaiting.Count() + */myCore.AvailableSpots  == 0 /*|| myCore.CurrentTime < myCore.STKDetails.Opening*/)
            {
                myCore.Customers.Enqueue(customer);
            }
            else
            {
                TakeOverStartSTK takeOver = new TakeOverStartSTK(myCore, customer);
                if(myCore.CurrentTime >= myCore.STKDetails.Opening)
                {
                    takeOver.Time = myCore.CurrentTime;
                }
                else
                {
                    takeOver.Time = myCore.STKDetails.Opening;
                }
                myCore.addEvent(takeOver);
                myCore.Cashiers--;
                myCore.AvailableSpots--;
                //myCore.ControlWaiting.Enqueue(customer);
            }
            CustomerSTK newCustomer = new CustomerSTK(myCore.getCarType());
            this.customer = newCustomer;
        }
    }
}

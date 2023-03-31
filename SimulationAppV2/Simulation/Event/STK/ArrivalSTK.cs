﻿using SimulationAppV2.Simulation.SimObject.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class ArrivalSTK : EventSTK
    {
        int customerId = 2;
        public ArrivalSTK(SimSTK simCore, CustomerSTK paCustomer) 
        : base(simCore, paCustomer)
        { }

        public override void Exec()
        {
            myCore.CustomersInSystem.Add(customer.ID, customer);
            Time = myCore.CurrentTime + myCore.getArrivalTime();
            if (Time < myCore.STKDetails.StopAccepting)
            {
                myCore.addEvent(this);
            }

            //   neni volny pokladnik    stoja v rade                       neni miesto pred kontrolou                                  neni otvorene
            if(myCore.AvailableCashiers.Count() == 0 || myCore.Customers.Count() != 0 || /*myCore.ControlWaiting.Count() + */myCore.AvailableSpots  == 0 /*|| myCore.CurrentTime < myCore.STKDetails.Opening*/)
            {
                customer.Status = Status.WaitingTakeOver;
                myCore.Customers.Enqueue(customer);
            }
            else
            {
                TakeOverStartSTK takeOver = new TakeOverStartSTK(myCore, customer, myCore.AvailableCashiers.Dequeue());
                if(myCore.CurrentTime >= myCore.STKDetails.Opening)
                {
                    takeOver.Time = myCore.CurrentTime;
                }
                else
                {
                    takeOver.Time = myCore.STKDetails.Opening;
                }
                myCore.addEvent(takeOver);
                //myCore.AvailableCashiers--;
                myCore.AvailableSpots--;

                //myCore.ControlWaiting.Enqueue(customer);
            }
            CustomerSTK newCustomer = new CustomerSTK(myCore.getCarType(), customerId);
            customerId++;
            this.customer = newCustomer;
        }
    }
}

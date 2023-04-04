using SimulationAppV2.Simulation.SimObject.STK;
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
            //myCore.AverageCustomersInSystem();
            myCore.AveragePeopleInSystem.Add(myCore.CustomersInSystem.Count(), myCore.CurrentTime);
            myCore.Arrived++;
            myCore.CustomersInSystem.Add(customer.ID, customer);
            Time = myCore.CurrentTime + myCore.getArrivalTime();
            if (Time < myCore.STKDetails.StopAccepting)
            {
                myCore.addEvent(this);
            }

            if(myCore.AvailableCashiers.Count() == 0 || myCore.Customers.Count() != 0 || /*myCore.ControlWaiting.Count() + */myCore.AvailableSpots  == 0)
            {
                customer.Status = Status.WaitingTakeOver;
                customer.WaitingStartAt = myCore.CurrentTime;
                myCore.AveragePeopleWaitingForTakeOver.Add(myCore.Customers.Count(), myCore.CurrentTime);
                myCore.Customers.Enqueue(customer);
            }
            else
            {
                //myCore.updateAverageCashiersInSystem();
                myCore.AverageFreeCashier.Add(myCore.AvailableCashiers.Count(), myCore.CurrentTime);
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
                myCore.AvailableSpots--;

            }
            CustomerSTK newCustomer = new CustomerSTK(myCore.getCarType(), customerId, Time);
            customerId++;
            this.customer = newCustomer;
        }
    }
}

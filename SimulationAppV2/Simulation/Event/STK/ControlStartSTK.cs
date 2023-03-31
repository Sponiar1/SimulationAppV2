using SimulationAppV2.Simulation.SimObject.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class ControlStartSTK : EventSTK
    {
        TechnicianSTK technicianSTK;
        public ControlStartSTK(SimSTK sim, CustomerSTK paCustomer, TechnicianSTK technician)
            : base(sim, paCustomer) { technicianSTK = technician; }

        public override void Exec()
        {
            technicianSTK.WorkingOn = TechnicianWork.Controling;
            technicianSTK.ControlledCar = customer.Car;
            ControlEndSTK controlEndSTK = new ControlEndSTK(myCore, customer, technicianSTK);
            controlEndSTK.Time = myCore.CurrentTime + myCore.getCarTime(customer.Car);
            myCore.addEvent(controlEndSTK);
            
            if(myCore.Customers.Count() > 0 && myCore.AvailableCashiers > 0 && myCore.PaymentQueue.Count() == 0) 
            {
                TakeOverStartSTK takeOver = new TakeOverStartSTK(myCore, myCore.Customers.Dequeue());
                takeOver.Time = myCore.CurrentTime;
                myCore.AvailableCashiers--;
                myCore.AvailableSpots--;
                myCore.addEvent(takeOver);
            }
        }
    }
}

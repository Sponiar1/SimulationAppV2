using SimulationAppV2.Simulation.SimObject;
using SimulationAppV2.Simulation.SimObject.STK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.Event.STK
{
    internal class ControlEndSTK : EventSTK
    {
        TechnicianSTK technicianSTK;
        public ControlEndSTK(SimSTK sim, CustomerSTK paCustomer, TechnicianSTK technician)
            : base(sim, paCustomer) { technicianSTK = technician; }

        public override void Exec()
        {
            if(myCore.ControlWaiting.Count() > 0)
            {
                ControlStartSTK controlStartSTK = new ControlStartSTK(myCore, myCore.ControlWaiting.Dequeue(), technicianSTK);
                controlStartSTK.Time = myCore.CurrentTime;
                myCore.addEvent(controlStartSTK);
                myCore.AvailableSpots++;
                technicianSTK.ControlledCar = customer.Car;
            }
            else
            {
                //myCore.AvailableTechnicians++;
                myCore.AvailableTechnicians.Enqueue(technicianSTK);
                technicianSTK.ControlledCar = CarType.None;
            }

            if(myCore.PaymentQueue.Count() == 0 && myCore.AvailableCashiers > 0)
            {
                PaymentStartSTK paymentStartSTK = new PaymentStartSTK(myCore, customer);
                paymentStartSTK.Time = myCore.CurrentTime;
                myCore.addEvent(paymentStartSTK);
                myCore.AvailableCashiers--;
            }
            else
            {
                myCore.PaymentQueue.Enqueue(customer);
            }
        }
    }
}

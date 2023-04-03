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
                myCore.updateAverageTechniciansInSystem();
                myCore.AvailableTechnicians.Enqueue(technicianSTK);
                technicianSTK.WorkingOn = TechnicianWork.Break;
                technicianSTK.ControlledCar = CarType.None;
            }

            if(myCore.PaymentQueue.Count() == 0 && myCore.AvailableCashiers.Count() > 0)
            {
                myCore.updateAverageCashiersInSystem();
                PaymentStartSTK paymentStartSTK = new PaymentStartSTK(myCore, customer, myCore.AvailableCashiers.Dequeue());
                paymentStartSTK.Time = myCore.CurrentTime;
                myCore.addEvent(paymentStartSTK);
            }
            else
            {
                customer.Status = Status.WaitingPaying;
                myCore.PaymentQueue.Enqueue(customer);
            }
        }
    }
}

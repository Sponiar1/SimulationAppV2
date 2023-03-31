using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.SimObject.STK
{
    internal class CashierSTK : EmployerSTK
    {
        public CarType WorkOnCar { get; set; }
        public CashierWork WorkingOn { get; set; }
        public CashierSTK(int id) : base (id)
        {
            WorkOnCar = CarType.None;
            WorkingOn = CashierWork.Break;
        }

        public void BeginTakeOver(CarType car)
        {
            WorkOnCar = car;
            WorkingOn = CashierWork.TakingOver;
        }

        public void BeginBreak()
        {
            WorkOnCar = CarType.None;
            WorkingOn= CashierWork.Break;
        }

        public void BeginPayment()
        {
            WorkingOn = CashierWork.CashRegister;
        }
    }

    enum CashierWork
    {
        Break,
        TakingOver,
        CashRegister
    }
}

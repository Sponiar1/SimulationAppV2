using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.SimObject.STK
{
    internal class CashierSTK : EmployerSTK
    {
        public int customerID { get; set; }
        public CashierWork WorkingOn { get; set; }
        public CashierSTK(int id) : base (id)
        {
            customerID = 0;
            WorkingOn = CashierWork.Break;
        }

        public void BeginTakeOver(int customerId)
        {
            customerID = customerId;
            WorkingOn = CashierWork.TakingOver;
        }

        public void BeginBreak()
        {
            customerID = 0;
            WorkingOn= CashierWork.Break;
        }

        public void BeginPayment(int customerId)
        {
            customerID = customerId;
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

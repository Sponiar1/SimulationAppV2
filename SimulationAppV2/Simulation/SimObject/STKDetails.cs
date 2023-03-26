using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation.SimObject
{
    internal class STKDetails
    {
        public double Opening { get; }
        public double Closing { get; }
        public double StopAccepting { get; }
        public double Heating { get; }

        public int[] VanTime { get; }
        public double[] VanTimeProb { get; }
        public int[] TruckTime { get; }
        public double[] TruckTimeProb { get; }
        public STKDetails()
        {
            Opening = 9 * 60;
            Closing = 17 * 60;
            StopAccepting = 15 * 60 + 45;
            Heating = 8 * 60;
            VanTime = new int[] { 35, 37, 38, 40, 41, 47, 48, 52 };
            VanTimeProb = new double[] { 0.2, 0.35, 0.3, 0.15 };
            TruckTime = new int[] { 37, 42, 43, 45, 46, 47, 48, 51, 52, 55, 56, 65 };
            TruckTimeProb = new double[] { 0.05, 0.1, 0.15, 0.4, 0.25, 0.05 };
        }
    }
}

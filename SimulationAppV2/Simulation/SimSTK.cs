using SimulationAppV2.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation
{
    internal class SimSTK
    {
        Random seedGen = new Random();
        Probability arrivalProb;
        Probability shopParkingProb;
        Probability paymentProb;
        double opening = 9 * 60;
        double closeing = 17 * 60;
        double stopAccepting = 15 * 60 + 45;
        Probability personalCarProb;
        Empiric vanProb;
        int[] vanTime = { 35, 37, 38, 40, 41, 47, 48, 52 };
        double[] vanTimeProb = { 0.2, 0.35, 0.3, 0.15 };
        Empiric truckProb;
        int[] truckTime = { 37, 42, 43, 45, 46, 47, 48, 51, 52, 55, 56, 65 };
        double[] truckTimeProb = { 0.05, 0.1, 0.15, 0.4, 0.25, 0.05 };

        public SimSTK()
        {
            arrivalProb = new Exponential(60 / 23, new Random(seedGen.Next()));
            shopParkingProb = new Triangular(180, 695, 431, new Random(seedGen.Next()));
            paymentProb = new Continuous(65, 177, new Random(seedGen.Next()));
            personalCarProb = new Discrete(31, 45, new Random(seedGen.Next()));
            vanProb = new Empiric(vanTime, vanTimeProb, new Random(seedGen.Next()));
            truckProb = new Empiric(truckTime, truckTimeProb, new Random(seedGen.Next()));

        }
    }
}

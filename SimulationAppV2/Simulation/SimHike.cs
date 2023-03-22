using SimulationAppV2.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation
{
    internal class SimHike : SimCore
    {
        Random seedGen = new Random();
        int[] cmMinMax = { 3, 10, 11, 20, 21, 34, 35, 52, 53, 59, 60, 95, 96, 110 };
        double[] cmProbs = { 0.2, 0.2, 0.3, 0.1, 0.15, 0.03, 0.02 };
        int[] ecMinMax = { 230, 243, 244, 280, 281, 350 };
        double[] ecProbs = { 0.3, 0.5, 0.2 };
        Probability probAB;
        Probability probBC;
        Probability probDE;
        Empiric probCMforA;
        Empiric probCMforB;
        Empiric probEC;
        double resultA = 0;
        double resultB = 0;
        int succesfulB = 0;
        int total = 0;
        double currentBprob = 0;

        double arriveB = 13 * 60; //kedy prišlo B v 1.úlohe
        double beginA = 10 * 60 + 55; //kedy začína A v 1.úlohe

        double beginB = 7 * 60 + 40; //kedy začína B v 2.úlohe

        public event EventHandler<SimulationCompletedEventArgs> SimulationCompleted;
        public event EventHandler<ResultSendEventArgs> ResultSend;
        public SimHike()
        {

        }

        public override void BeforeSimulation()
        {
            probAB = new Discrete(39, 64, new Random(seedGen.Next()));
            probBC = new Deterministic(57);
            probDE = new Continuous(19, 36, new Random(seedGen.Next()));
            probCMforA = new Empiric(cmMinMax, cmProbs, seedGen);
            probCMforB = new Empiric(cmMinMax, cmProbs, seedGen);
            probEC = new Empiric(ecMinMax, ecProbs, seedGen);
            total = 0;
            resultA = 0;
            resultB = 0;
            succesfulB = 0;
            currentBprob = 0;
        }

        public override void AfterSimulation()
        {
            resultA = resultA / (double)total;
            resultB = (double)succesfulB / total;
            SimulationCompleted?.Invoke(this, new SimulationCompletedEventArgs(resultA, resultB));

        }

        public override void BeforeReplication()
        {

        }

        public override void AfterReplication()
        {
            double oneStep = NumberOfReplications * 0.6 / 1000;
            if ((total % oneStep == 0) && total > base.NumberOfReplications * 0.4)
            {
                double partialResultA = resultA / (double)total;
                double partialResultB = (double)succesfulB / total;
                SimulationCompleted?.Invoke(this, new SimulationCompletedEventArgs(partialResultA, partialResultB));
                ResultSend?.Invoke(this, new ResultSendEventArgs(total, partialResultB));
            }
        }

        public override void Replication()
        {
            int abProb;
            int bcProb;
            int cmAsideProb;

            double deProb;
            int ecProb;
            int cmBsideProb;
            double resultOne;
            double resultTwo;


            total++;

            abProb = (int)probAB.getValue();                         //rozdelenie ab
            bcProb = (int)probBC.getValue();                    //rozdelenie bc
            cmAsideProb = (int)probCMforA.getDiscreteEmpiricProbability();    //rozdelenie cm pre výstup A
            resultOne = beginA + abProb + bcProb + cmAsideProb; //kedy príde A
            if (resultOne - arriveB > 0)
            {
                resultA += resultOne - arriveB; //koľko mešká A
            }

            deProb = probDE.getValue();   //rozdelenie de
            ecProb = (int)probEC.getDiscreteEmpiricProbability();    //rozdelenie ec
            cmBsideProb = (int)probCMforB.getDiscreteEmpiricProbability();   //rozdelenie cm pre výstup B
            resultTwo = beginB + deProb + ecProb + cmBsideProb; //kedy príde B

            if (resultTwo < 13 * 60)                   //prišlo b pred 13:00
            {
                succesfulB++;
            }
        }

        public String getResultB()
        {
            currentBprob = (double)succesfulB / total;
            return currentBprob.ToString();
        }

        public String getResultA()
        {
            return (resultA / (double)total).ToString();
        }
    }

    public class SimulationCompletedEventArgs : EventArgs
    {
        public double ResultA { get; set; }
        public double ResultB { get; set; }

        public SimulationCompletedEventArgs(double resultA, double resultB)
        {
            ResultA = resultA;
            ResultB = resultB;
        }
    }

    public class ResultSendEventArgs : EventArgs
    {
        public double XAxis { get; set; }
        public double YAxis { get; set; }

        public ResultSendEventArgs(double total, double currentBprob)
        {
            XAxis = total;
            YAxis = currentBprob;
        }
    }
}

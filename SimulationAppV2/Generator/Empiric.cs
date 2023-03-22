using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Generator
{
    internal class Empiric
    {
        Discrete[] empProbs;
        double[] probability;
        Random gen;
        public Empiric(int[] minMax, double[] prob, Random seedGen)
        {
            empProbs = new Discrete[prob.Length];
            for (int i = 0; i < minMax.Length / 2; i++)
            {
                empProbs[i] = new Discrete(minMax[i * 2], minMax[i * 2 + 1], new Random(seedGen.Next()));
            }
            probability = (double[])prob.Clone();
            for (int i = 1; i < prob.Length; i++)
            {
                probability[i] = probability[i - 1] + prob[i];
            }
            gen = new Random(seedGen.Next());
        }

        public double getDiscreteEmpiricProbability()
        {
            double prob = gen.NextDouble();
            for (int i = 0; i < probability.Length; i++)
            {
                if (prob <= probability[i])
                {
                    return empProbs[i].getValue();
                }
            }
            return empProbs[empProbs.Length - 1].getValue();
        }
    }
}

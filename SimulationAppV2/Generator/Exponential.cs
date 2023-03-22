using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Generator
{
    internal class Exponential : Probability
    {
        double mean;
        Random random;
        public Exponential(double mean, Random randomPa)
        {
            this.mean = mean;
            this.random = randomPa;
        }

        public override double getValue()
        {
            return (-Math.Log(random.NextDouble())) / (1 / mean);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Generator
{
    internal class Continuous : Probability
    {
        protected int min;
        protected int max;
        protected Random random;

        public Continuous(int min, int max, Random random)
        {
            this.min = min;
            this.max = max;
            this.random = random;
        }

        public override double getValue()
        {
            double pom = random.NextDouble();
            pom = pom * ((double)max - (double)min) + (double)min;
            return pom;
        }
    }
}

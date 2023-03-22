using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Generator
{
    internal class Discrete : Probability
    {
        protected int min;
        protected int max;
        protected Random random;

        public Discrete(int min, int max, Random random)
        {
            this.min = min;
            this.max = max;
            this.random = random;
        }

        public override double getValue()
        {
            return random.Next(max - min + 1) + min;
        }
    }
}

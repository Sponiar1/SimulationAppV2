using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Generator
{
    internal class Deterministic : Probability
    {
        int value;
        public Deterministic(int value)
        {
            this.value = value;
        }

        public override double getValue()
        {
            return value;
        }
    }
}

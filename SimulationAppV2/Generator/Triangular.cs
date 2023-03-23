using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Generator
{
    internal class Triangular : Probability
    {
        double min;
        double max;
        double modus;
        Random random;

        public Triangular(double min, double max, double modus, Random random)
        {
            this.min = min;
            this.max = max;
            this.modus = modus;
            this.random = random;
        }

        public override double getValue()
        {
            double F = (modus - min) / (max - min);
            double u = random.NextDouble();
            if (u < F)
            {
                return min + Math.Sqrt(u * (max - min) * (modus - min));
            }
            else
            {
                return max - Math.Sqrt((1 - u) * (max - min) * (max - modus));
            }
        }
    }
}

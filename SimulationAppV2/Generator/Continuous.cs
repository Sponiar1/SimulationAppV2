﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Generator
{
    internal class Continuous : Probability
    {
        protected double min;
        protected double max;
        protected Random random;

        public Continuous(double min, double max, Random random)
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

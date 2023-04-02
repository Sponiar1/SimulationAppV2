using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Statistics
{
    internal class WeightedAverage
    {
        double weightedSum = 0;
        double sum = 0;
        public WeightedAverage() { }

        public void add(double weightedValue, double value) 
        {
            weightedSum += weightedValue;
            sum += value;
        }

        public double getWeightedAverage()
        { 
            return weightedSum/sum;
        }
    }
}

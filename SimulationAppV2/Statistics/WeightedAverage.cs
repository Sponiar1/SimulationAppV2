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
        double timeSinceLastChange;
        public WeightedAverage(double time)
        {
            this.timeSinceLastChange = time;
        }

        /*public void add(double weightedValue, double value) 
        {
            weightedSum += weightedValue;
            sum += value;
        }
        */
        public void Add(double weight, double changeTime)
        {
            weightedSum += (weight * (changeTime - timeSinceLastChange)) ;
            sum += changeTime - timeSinceLastChange;
            timeSinceLastChange = changeTime;
        }
        public double getWeightedAverage()
        {
            if (sum != 0)
            {
                return weightedSum / sum;
            }
            else return 0;
        }
    }
}

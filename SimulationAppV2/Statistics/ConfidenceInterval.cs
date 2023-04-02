using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Statistics
{
    internal class ConfidenceInterval
    {
        double standardDeviation;
        int numberOfValues = 0;
        double sumX = 0;
        double sumSquaredX = 0;
        double ninetyFive = 1.96;
        double ninety = 1.645;
        public ConfidenceInterval()
        {

        }

        public void add(double value)
        {
            numberOfValues++;
            sumX += value;
            sumSquaredX += Math.Pow(value, 2);
        }
        public void setStandardDeviation()
        {
            standardDeviation = (sumSquaredX - (Math.Pow(sumX, 2)/numberOfValues))/(numberOfValues-1);
        }
        public double getLeftSideNinety()
        {
           return (sumX/(double)numberOfValues)-(standardDeviation*ninety/Math.Sqrt(numberOfValues));
        }

        public double getRightSideNinety()
        {
            return (sumX / (double)numberOfValues) + (standardDeviation * ninety / Math.Sqrt(numberOfValues));
        }

        public double getLeftSideNinetyFive()
        {
            return (sumX / (double)numberOfValues) - (standardDeviation * ninetyFive / Math.Sqrt(numberOfValues));
        }

        public double getRightSideNinetyFive()
        {
            return (sumX / (double)numberOfValues) + (standardDeviation * ninetyFive / Math.Sqrt(numberOfValues));
        }
    }
}

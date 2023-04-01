using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Statistics
{
    internal class Average
    {
        double sum = 0;
        int numberOfRecords = 0;
        public Average() { }

        public void Add(double value)
        {
            sum += value;
            numberOfRecords++;
        }

        public double getActualAverage()
        {
            return sum / numberOfRecords;
        }
    }
}

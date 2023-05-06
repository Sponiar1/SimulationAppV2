using SimulationAppV2.Generator;
using SimulationAppV2.Simulation.SimObject;
using SimulationAppV2.Simulation.Event.NewspaperStand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation
{
    internal class SimNewspaper : SimEventCore
    {
        Random seedGen = new Random();
        Probability arrivalProb;
        Probability serviceProb;
        public Boolean ServiceWorking { get; set; }
        double waitingTimeSum;
        double numberOfWaiting;
        double waitingChange;
        public double StatisticSum { get; set; }
        public double StatisticCount { get; set; }

        Queue<Customer> queue = new Queue<Customer>();
        public SimNewspaper()
        {
            arrivalProb = new Exponential(5, new Random(seedGen.Next()));
            serviceProb = new Exponential(4, new Random(seedGen.Next()));
        }

        public double getArrivalTime()
        {
            return arrivalProb.getValue();
        }

        public double getServiceTime()
        {
            return serviceProb.getValue();
        }
        public override void BeforeReplication()
        {
            Event.Event helpEvent;
            helpEvent = new ArrivalEvent(this, new Customer());
            helpEvent.Time = 0;
            addEvent(helpEvent);
        }

        public void addToQueue(Customer customer)
        {
            queue.Enqueue(customer);
        }
        public Customer getCustomerFromQueue()
        {
            return queue.Dequeue();
        }
        public int QueueSize()
        {
            return queue.Count;
        }

        public double getStats()
        {
            return StatisticSum / StatisticCount;
        }

        public void updateQueueStats()
        {
            double currentTime = CurrentTime;
            double timeSinceLastChange = currentTime - waitingChange;
            waitingTimeSum += timeSinceLastChange * queue.Count;
            numberOfWaiting += timeSinceLastChange;
            waitingChange = currentTime;
        }

        public double getQueueStats()
        {
            double averageQueueSize = waitingTimeSum / numberOfWaiting;
            return averageQueueSize;
        }
    }
}

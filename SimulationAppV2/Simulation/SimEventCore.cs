using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation
{
    internal class SimEventCore : SimCore
    {
        PriorityQueue<Event.Event, double> timeline = new PriorityQueue<Event.Event, double>();
        public double CurrentTime { get; set; }

        public void Simulate(double maxTime)
        {
            Event.Event helpEvent;
            while (timeline.Count != 0 || CurrentTime > maxTime)
            {
                helpEvent = timeline.Dequeue();
                CurrentTime = helpEvent.Time;
                if (CurrentTime > maxTime)
                {
                    break;
                }
                helpEvent.Exec();
            }
        }

        //dorobiť výnimku
        public void addEvent(Event.Event e)
        {
            if (CurrentTime <= e.Time)
            {
                timeline.Enqueue(e, e.Time);
            }
            else
            {
                throw new Exception("Záporný čas");
            }
        }
    }
}

﻿using System;
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
        public double MaxTime { get; set; }
        public Boolean Pause { get; set; }
        public Boolean Turbo { get; set; }
        public override void Replication()
        {
            Event.Event helpEvent;
            while (timeline.Count != 0 || CurrentTime > MaxTime)
            {
                helpEvent = timeline.Dequeue();
                CurrentTime = helpEvent.Time;
                while(Pause)
                {
                    Thread.Sleep(350);
                }
                if (CurrentTime > MaxTime || base.CancellationToken.IsCancellationRequested)
                {
                    break;
                }
                helpEvent.Exec();
            }
        }

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

        public void switchTurbo()
        {
            Turbo = (Turbo == false) ? Turbo = true : Turbo = false;
        }

        public void switchPause()
        {
            Pause = (Pause == false) ? Pause = true : Pause = false;
        }
    }
}

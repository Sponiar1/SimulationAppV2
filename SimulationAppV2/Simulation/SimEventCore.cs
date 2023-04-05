using SimulationAppV2.Simulation.Event.STK;
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
        public double MaxTime { get; set; }
        public Boolean Pause { get; set; } = false;
        public Boolean Turbo { get; set; } = false;
        public int Delay { get; set; } = 500;
        public double RefreshTime { get; set; } = 1;
        public override void Replication()
        {
            Event.Event helpEvent;
            AddSystemEvent();
            while (timeline.Count != 0 || CurrentTime > MaxTime)
            {
                helpEvent = timeline.Dequeue();
                CurrentTime = helpEvent.Time;
                while(Pause)
                {
                    Thread.Sleep(500);
                }
                if (CurrentTime > MaxTime || base.CancellationToken.IsCancellationRequested)
                {
                    break;
                }
                helpEvent.Exec();
                if (!Turbo)
                {
                    RefreshGui();
                }
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

        public void SwitchTurbo()
        {
            if (Turbo)
            {
                Turbo = false;
                Event.Event sysEvent = new SysEvent(this);
                sysEvent.Time = CurrentTime;
                addEvent(sysEvent);
            }
            else
            {
                Turbo = true;
            }
        }

        public void SwitchPause()
        {
            Pause = (Pause == false) ? Pause = true : Pause = false;
        }

        public override void BeforeReplication()
        {
            timeline.Clear();
        }

        public void AddSystemEvent()
        {
            if (!Turbo)
            {
                Event.Event sysEvent = new SysEvent(this);
                sysEvent.Time = CurrentTime;
                addEvent(sysEvent);
            }
        }
        public virtual void RefreshGui()
        {

        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationAppV2.Simulation
{
    internal class SimCore
    {
        public int NumberOfReplications { get; set; }
        public int ReplicationsDone { get; set; } = 0;
        public CancellationToken CancellationToken { get; set; }
        public SimCore() { }
        public async Task Simulate(int replications, CancellationToken cancelToken)
        {
            NumberOfReplications = replications;
            CancellationToken = cancelToken;
            BeforeSimulation();
            for (ReplicationsDone = 0; ReplicationsDone < NumberOfReplications; ReplicationsDone++)
            {
                BeforeReplication();
                Replication();
                AfterReplication();
                if (cancelToken.IsCancellationRequested)
                {
                    break;
                }
            }
            AfterSimulation();
        }

        public virtual void BeforeSimulation()
        {

        }

        public virtual void AfterSimulation()
        {

        }

        public virtual void BeforeReplication()
        {

        }

        public virtual void AfterReplication()
        {

        }

        public virtual void Replication()
        {

        }
    }
}

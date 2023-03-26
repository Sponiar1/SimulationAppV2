using SimulationAppV2.Simulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulationAppV2
{
    public partial class FormNewspaper : Form
    {
        CancellationTokenSource cancellationTokenSource;
        SimNewspaper simPaper = new SimNewspaper();
        public FormNewspaper()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            SimNewspaper simPaper = new SimNewspaper();
            //simPaper.BeforeSimulation();
            simPaper.MaxTime = 10000;
            simPaper.Simulate(1,cancellationTokenSource.Token);
            //simPaper.Replication();
            label1.Text = simPaper.getStats().ToString();
            label2.Text = simPaper.getQueueStats().ToString();
        }
    }
}

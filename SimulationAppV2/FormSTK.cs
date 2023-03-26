using SimulationAppV2.Simulation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimulationAppV2
{
    public partial class FormSTK : Form
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        SimSTK simSTK;
        String label1Text;
        public FormSTK()
        {
            InitializeComponent();
            simSTK = new SimSTK();
            simSTK.SimulationTime += SimulationTimeHandler;
            label3.Text = "Otvárací čas: " + (simSTK.STKDetails.Opening / 60) + ":" + (simSTK.STKDetails.Opening % 60);
            label4.Text = "Zatvára sa o: " + (simSTK.STKDetails.Closing / 60) + ":" + (simSTK.STKDetails.Closing % 60);
        }

        private void SimulationTimeHandler(object? sender, SimulationTimeEventArgs e)
        {

            label1Text = "Aktuálny čas: " + (int)e.Time / 60 + ":" + e.Time % 60;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            label2.Text = "Working";
            timer1.Enabled = true;
            Task.Run(() => simSTK.Simulate(1, cts.Token));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = label1Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            simSTK.switchPause();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            simSTK.switchTurbo();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
        }
    }
}

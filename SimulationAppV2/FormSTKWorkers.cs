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
    public partial class FormSTKWorkers : Form
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        SimSTK simSTK;
        readonly double[] ValuesCashiers = new double[16];
        readonly double[] ValuesTechnicians = new double[26];
        Boolean doingCashiers;
        int highestIndex = 1;
        readonly ScottPlot.Plottable.SignalPlot SignalPlotCashiers;
        readonly ScottPlot.Plottable.SignalPlot SignalPlotTechnicians;
        public FormSTKWorkers()
        {
            simSTK = new SimSTK();
            simSTK.Turbo = true;
            InitializeComponent();
            simSTK.GlobalDetails += GlobalDetailsHandler;
            SignalPlotCashiers = formsPlot1.Plot.AddSignal(ValuesCashiers);
            SignalPlotTechnicians = formsPlot2.Plot.AddSignal(ValuesTechnicians);
        }

        private void GlobalDetailsHandler(object? sender, GlobalDetailsEventArgs e)
        {
            if (doingCashiers)
            {
                ValuesCashiers[highestIndex] = e.GlobalTakeOverWaiting;
            }
            else
            {
                ValuesTechnicians[highestIndex] = e.GlobalAverage;
            }
        }

        public void doTests()
        {
            cts = new CancellationTokenSource();
            simSTK.NumberOfTechnicians = 20;
            doingCashiers = true;
            for (int i = 1; i <= 15; i++)
            {
                simSTK.NumberOfCashier = i;
                Task.Run(() => simSTK.Simulate(100000, cts.Token));
                highestIndex++;
            }
            highestIndex = 10;

            simSTK.NumberOfCashier = 8;
            for (int i = 10; i <= 25; i++)
            {
                simSTK.NumberOfTechnicians = i;
                Task.Run(() => simSTK.Simulate(100000, cts.Token));
                highestIndex++;
            }

            formsPlot1.Plot.AxisAuto();
            formsPlot2.Plot.AxisAuto();
            formsPlot1.Render();
            formsPlot2.Render();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            doTests();
        }
    }
}

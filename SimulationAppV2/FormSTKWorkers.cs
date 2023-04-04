using ScottPlot.Plottable;
using ScottPlot.Renderable;
using ScottPlot;
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
        double[] xValuesCashiers;
        double[] yValuesCashiers;
        double[] xValuesTechnicians;
        double[] yValuesTechnicians;
        Boolean doingCashiers;
        int highestIndex = 0;
        ScottPlot.Plottable.SignalPlotXY SignalPlotCashiers;
        ScottPlot.Plottable.SignalPlotXY SignalPlotTechnicians;
        public FormSTKWorkers()
        {
            simSTK = new SimSTK();
            simSTK.Turbo = true;
            InitializeComponent();
            simSTK.GlobalDetails += GlobalDetailsHandler;
            formsPlot1.Plot.YLabel("Priemerného počtu čakajúcich na prebratie auta");
            formsPlot1.Plot.XLabel("Počet pracovníkov sk1. (sk.2 = 20)");
            formsPlot1.Plot.Title("Závislosť priemerného počtu čakajúcich na prebratie auta od pracovníkov sk.1");
            formsPlot2.Plot.YLabel("Priemerného dĺžka pobytu v prevádzke");
            formsPlot2.Plot.XLabel("Počet pracovníkov sk.2 (sk.1 = 8)");
            formsPlot2.Plot.Title("Závislosť priemernej dĺžky pobytu zákazníka v systéme od pracovníkov sk.2");
        }

        private void GlobalDetailsHandler(object? sender, GlobalDetailsEventArgs e)
        {
            if (doingCashiers)
            {
                xValuesCashiers[highestIndex] = simSTK.NumberOfCashier;
                yValuesCashiers[highestIndex] = e.GlobalTakeOverWaiting;
            }
            else
            {
                xValuesTechnicians[highestIndex] = simSTK.NumberOfTechnicians;
                yValuesTechnicians[highestIndex] = e.GlobalAverage;
            }
        }

        public async void doTests()
        {
            cts = new CancellationTokenSource();
            simSTK.NumberOfTechnicians = 20;
            doingCashiers = true;
            for (int i = 1; i <= 15; i++)
            {
                simSTK.NumberOfCashier = i;
                await Task.Run(() => simSTK.Simulate(1000, cts.Token));
                highestIndex++;
            }
            highestIndex = 0;

            doingCashiers = false;
            simSTK.NumberOfCashier = 8;
            for (int i = 10; i <= 25; i++)
            {
                simSTK.NumberOfTechnicians = i;
                await Task.Run(() => simSTK.Simulate(1000, cts.Token));
                highestIndex++;
            }
            RefreshGraph();
        }

        public void RefreshGraph()
        {
            formsPlot1.Plot.AxisAuto();
            formsPlot2.Plot.AxisAuto();
            formsPlot1.Render();
            formsPlot2.Render();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            initializeGraph();
            doTests();
        }
        private void initializeGraph()
        {
            formsPlot1.Plot.Clear();
            formsPlot2.Plot.Clear();
            xValuesCashiers = new double[15];
            yValuesCashiers = new double[15];
            xValuesTechnicians = new double[16];
            yValuesTechnicians = new double[16];
            SignalPlotCashiers = formsPlot1.Plot.AddSignalXY(xValuesCashiers, yValuesCashiers);
            SignalPlotCashiers = formsPlot2.Plot.AddSignalXY(xValuesTechnicians, yValuesTechnicians);
        }
    }
}

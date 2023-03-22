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
    public partial class FormHiking : Form
    {
        double resulta;
        double resultb;
        double[] xAxis;
        double[] yAxis;
        int numberOFData = 0;
        int axisLimit = 1000;
        ScottPlot.Plottable.SignalPlotXY SignalPlot;
        SimHike simHike;
        CancellationTokenSource cancellationTokenSource;
        public FormHiking()
        {
            InitializeComponent();
            simHike = new SimHike();
            simHike.SimulationCompleted += SimulationCompletedHandler;
            simHike.ResultSend += ResultSendHandler;
            formsPlot1.Plot.YLabel("Pravdepodobnosť");
            formsPlot1.Plot.XLabel("Počet replikácií");
            formsPlot1.Plot.Title("Pravdeposobnosť príchodu skupiny B pred 13:00");
        }

        private void ResultSendHandler(object? sender, ResultSendEventArgs e)
        {
            xAxis[numberOFData] = e.XAxis;
            yAxis[numberOFData] = e.YAxis;
            numberOFData++;
            SignalPlot.MaxRenderIndex = numberOFData - 1;
        }

        public void showResult(String resultA, String resultB)
        {
            label1.Text = "Vysledok 1.úlohy " + resultA;
            label2.Text = "Vysledok 2.úlohy " + resultB;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            initializeGraph();
            Task.Run(() => simHike.Simulate(int.Parse(textBox1.Text), cancellationTokenSource.Token));
            timer2.Enabled = true;
        }

        private void SimulationCompletedHandler(object sender, SimulationCompletedEventArgs e)
        {
            resulta = Math.Round(e.ResultA, 7);
            resultb = Math.Round(e.ResultB, 7);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
            timer2.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            showResult(resulta.ToString(), resultb.ToString());
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            formsPlot1.Plot.AxisAuto();
            formsPlot1.Render();
            if (yAxis[axisLimit - 1] != 0)
            {
                timer2.Enabled = false;
            }
        }

        private void initializeGraph()
        {
            formsPlot1.Plot.Clear();
            numberOFData = 0;
            xAxis = new double[axisLimit];
            yAxis = new double[axisLimit];
            SignalPlot = formsPlot1.Plot.AddSignalXY(xAxis, yAxis);
        }
    }
}

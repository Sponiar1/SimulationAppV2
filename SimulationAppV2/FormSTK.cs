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
        String actualTime;
        String checkInQueue;
        String inspectionQueue;
        String paymentQueue;
        String freeCashiers;
        String freeTechnician;
        public FormSTK()
        {
            InitializeComponent();
            simSTK = new SimSTK();
            simSTK.SimulationDetails += SimulationDetailsHandler;
            label3.Text = "Otvárací čas: " + (simSTK.STKDetails.Opening / 60) + ":" + (simSTK.STKDetails.Opening % 60);
            label4.Text = "Zatvára sa o: " + (simSTK.STKDetails.Closing / 60) + ":" + (simSTK.STKDetails.Closing % 60);
        }

        private void SimulationDetailsHandler(object? sender, SimulationDetailsEventArgs e)
        {

            actualTime = "Aktuálny čas: " + (int)e.Time / 60 + ":" + (int)e.Time % 60;
            checkInQueue = "Počet ľudí čakajúcich na prevzatie: " + e.CheckInQueue;
            inspectionQueue = "Počet áut na parkovisku pred inšpekciou: " + e.InspectionParkingLot;
            paymentQueue = "Počet ľudí čakajúcich na zaplatenie: " + e.PaymentQueue;
            freeCashiers = "Počet voľných pokladníkov(Pracovníci 1): " + e.FreeCashiers;
            freeTechnician = "Počet voľných technikov(Pracovníci 2): " + e.FreeTechnicians;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            timer1.Enabled = true;
            Task.Run(() => simSTK.Simulate(1, cts.Token));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = actualTime;
            label8.Text = checkInQueue;
            label2.Text = inspectionQueue;
            label5.Text = paymentQueue;
            label6.Text = freeCashiers;
            label7.Text = freeTechnician;
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

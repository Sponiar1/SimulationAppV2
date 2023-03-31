using SimulationAppV2.Simulation;
using SimulationAppV2.Simulation.SimObject.STK;
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
        String customersInShop;
        TechnicianSTK[] technicianSTKs;
        CashierSTK[] cashierSTKs;
        Dictionary<int, CustomerSTK> customersInSystem;
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
            //inspectionQueue = "Počet áut na parkovisku pred inšpekciou: " + e.InspectionParkingLot;
            inspectionQueue = "Počet voľných miest na parkovisku pred inšpekciou: " + e.InspectionParkingLot;
            paymentQueue = "Počet ľudí čakajúcich na zaplatenie: " + e.PaymentQueue;
            freeCashiers = "Počet voľných pokladníkov(Pracovníci 1): " + e.FreeCashiers;
            freeTechnician = "Počet voľných technikov(Pracovníci 2): " + e.FreeTechnicians;
            technicianSTKs = e.Technicians;
            cashierSTKs = e.Cashier;
            customersInSystem = e.customersInSystem;
            customersInShop = "Počet zákazníkov v systéme: " + customersInSystem.Count();
            this.Invoke(new Action(() => Refresh()));

        }

        private void Refresh()
        {
            label1.Text = actualTime;
            label8.Text = checkInQueue;
            label2.Text = inspectionQueue;
            label5.Text = paymentQueue;
            label6.Text = freeCashiers;
            label7.Text = freeTechnician;
            label9.Text = customersInShop;
            dataGridView1.Rows.Clear();
            foreach (var worker in technicianSTKs)
            {
                dataGridView1.Rows.Add(worker.ID, worker.WorkingOn, worker.ControlledCar);
            }
            dataGridView2.Rows.Clear();
            foreach (var worker in cashierSTKs)
            {
                dataGridView2.Rows.Add(worker.ID, worker.WorkingOn, worker.customerID);
            }
            dataGridView3.Rows.Clear();
            foreach (var customer in customersInSystem)
            {
                dataGridView3.Rows.Add(customer.Value.ID, customer.Value.Car, customer.Value.Status);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            RefreshTable();
            //timer1.Enabled = true;
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

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            simSTK.Delay = trackBar1.Value;
        }

        public void RefreshTable()
        {
            dataGridView1.Columns.Add("TechnicianID", "Technician ID");
            dataGridView1.Columns.Add("Status", "Status");
            dataGridView1.Columns.Add("ControlledCar", "Controlled Car");

            dataGridView2.Columns.Add("CashierID", "Cashier ID");
            dataGridView2.Columns.Add("Status", "Status");
            dataGridView2.Columns.Add("Serving", "Serving Customer");

            dataGridView3.Columns.Add("CustomerID", "Customer ID");
            dataGridView3.Columns.Add("Car", "Car");
            dataGridView3.Columns.Add("Status", "Status");
        }
    }
}

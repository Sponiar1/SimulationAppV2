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
        String averageActual;
        String numberOfReplication;
        String globalAverageActual;
        String globalAverageVisits;
        String leftInSystem;
        String averageWaitingTakeOver;
        String globalWaitingTakeOver;
        Boolean showCustomers = false;
        Boolean showTechnicians = false;
        Boolean showCashiers = false;
        public FormSTK()
        {
            InitializeComponent();
            simSTK = new SimSTK();
            simSTK.SimulationDetails += SimulationDetailsHandler;
            simSTK.GlobalDetails += GlobalDetailsHandler;
            label3.Text = "Otvárací čas: " + (simSTK.STKDetails.Opening / 60) + ":" + (simSTK.STKDetails.Opening % 60);
            label4.Text = "Zatvára sa o: " + (simSTK.STKDetails.Closing / 60) + ":" + (simSTK.STKDetails.Closing % 60);
        }

        private void GlobalDetailsHandler(object? sender, GlobalDetailsEventArgs e)
        {
            globalAverageActual = "Priemerný čas strávený v prevádzke(global): " + e.GlobalAverage;
            numberOfReplication = "Replikácia no. " + e.NumberOfReplication;
            globalAverageVisits = "Priemerný počet ľudí za deň: " + e.GlobalVisits;
            leftInSystem = "Priemerný počet ľudí v systéme po uzávierke: " + e.GlobalLeftInSystem;
            globalWaitingTakeOver = "Globálne priemerné čakanie na odovzdanie auta: " + e.GlobalTakeOverWaiting;
            this.Invoke(new Action(() => RefreshGlobal()));
        }
        public void RefreshGlobal()
        {
            labelGlobalTimeSpent.Text = globalAverageActual;
            labelReplication.Text = numberOfReplication;
            label11.Text = globalAverageVisits;
            labelLeftInSystem.Text = leftInSystem;
            labelGlobalTakeOver.Text = globalWaitingTakeOver;
        }
        private void SimulationDetailsHandler(object? sender, SimulationDetailsEventArgs e)
        {

            actualTime = "Aktuálny čas: " + (int)e.Time / 60 + ":" + (int)e.Time % 60;
            checkInQueue = "Počet ľudí čakajúcich na prevzatie: " + e.CheckInQueue;
            inspectionQueue = "Počet čakjúcich áut na parkovisku pred inšpekciou: " + e.InspectionParkingLot;
            paymentQueue = "Počet ľudí čakajúcich na zaplatenie: " + e.PaymentQueue;
            freeCashiers = "Počet voľných pokladníkov(Pracovníci 1): " + e.FreeCashiers + "/" + (int)numericCashier.Value;
            freeTechnician = "Počet voľných technikov(Pracovníci 2): " + e.FreeTechnicians + "/" + (int)numericTechnician.Value;
            technicianSTKs = e.Technicians;
            cashierSTKs = e.Cashier;
            customersInSystem = e.customersInSystem;
            customersInShop = "Počet zákazníkov v systéme: " + customersInSystem.Count();
            averageActual = "Priemerný čas strávený v prevádzke: " + e.AverageActual;
            averageWaitingTakeOver = "Priemerný čas čakania v rade na prevzatie: " + e.AverageTakeOverWaiting;
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
            label12.Text = averageWaitingTakeOver;
            label10.Text = averageActual;
            dataGridView1.Rows.Clear();
            if (showTechnicians)
            {
                foreach (var worker in technicianSTKs)
                {
                    dataGridView1.Rows.Add(worker.ID, worker.WorkingOn, worker.ControlledCar);
                }
            }
            dataGridView2.Rows.Clear();
            if (showCashiers)
            {
                foreach (var worker in cashierSTKs)
                {
                    dataGridView2.Rows.Add(worker.ID, worker.WorkingOn, worker.customerID);
                }
            }
            dataGridView3.Rows.Clear();
            if (showCustomers)
            {
                foreach (var customer in customersInSystem)
                {
                    dataGridView3.Rows.Add(customer.Value.ID, customer.Value.Car, customer.Value.Status);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            RefreshTable();
            simSTK.NumberOfCashier = (int)numericCashier.Value;
            simSTK.NumberOfTechnicians = (int)numericTechnician.Value;
            Task.Run(() => simSTK.Simulate((int)numericReplications.Value, cts.Token));
        }


        private void button2_Click(object sender, EventArgs e)
        {
            simSTK.switchPause();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                simSTK.Turbo = true;
            }
            else
            {
                simSTK.Turbo = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWorker2.Checked)
            {
                showTechnicians = true;
            }
            else { showTechnicians = false; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxWorker1.Checked)
            {
                showCashiers = true;
            }
            else { showCashiers = false; }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCustomers.Checked)
            {
                showCustomers = true;
            }
            else
            {
                showCustomers = false;
            }
        }
    }
}

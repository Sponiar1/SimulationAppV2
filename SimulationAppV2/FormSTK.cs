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
        #region Label attributes
        String actualTime;
        String checkInQueue;
        String inspectionQueue;
        String paymentQueue;
        String freeCashiers;
        String freeTechnician;
        String customersInShop;
        String averageActual;
        String numberOfReplication;
        String globalAverageActual;
        String globalAverageVisits;
        String leftInSystem;
        String averageWaitingTakeOver;
        String globalWaitingTakeOver;
        String averagePeopleInSystem;
        String globalAveragePeopleInSystem;
        String averageFreeCashiers;
        String globalAverageFreeCashiers;
        String averageFreeTechnicians;
        String globalAverageFreeTechnicians;
        String averagePeopleWaitingForTakeOver;
        String globalAveragePeopleWaitingForTakeOver;
        String conIntervalTimeInSystem;
        String conIntervalPeopleInSystem;
        #endregion

        #region Table stuff
        Boolean showCustomers = false;
        Boolean showTechnicians = false;
        Boolean showCashiers = false;
        TechnicianSTK[] technicianSTKs;
        CashierSTK[] cashierSTKs;
        Dictionary<int, CustomerSTK> customersInSystem;
        #endregion
        public FormSTK()
        {
            InitializeComponent();
            simSTK = new SimSTK();
            simSTK.SimulationDetails += SimulationDetailsHandler;
            simSTK.GlobalDetails += GlobalDetailsHandler;
            simSTK.AfterSimulationDetails += AfterSimulationHandler;
            labelCurrentTime.Text = "Aktuálny čas: " + TimeSpan.FromMinutes(simSTK.STKDetails.Opening).ToString(@"hh\:mm");
            labelOpening.Text = "Otvárací čas: " + TimeSpan.FromMinutes(simSTK.STKDetails.Opening).ToString(@"hh\:mm");
            labelClosing.Text = "Zatvára sa o: " + TimeSpan.FromMinutes(simSTK.STKDetails.Closing).ToString(@"hh\:mm");
            InitializeTables();
        }
        private void AfterSimulationHandler(object? sender, AfterSimulationDetailsEventArgs e)
        {
            conIntervalTimeInSystem = "90 % Interval spoľahlivosti pre priemerný strávený čas v systéme(min): <" + e.CITimeInSystemLeft + "," + e.CITimeInSystemRight + ">";
            conIntervalPeopleInSystem = "95 % Interval spoľahlivosti pre priemerný počet ľudí v systéme:" + new string(' ', 11) + "<" + e.CIAverageCustomersLeft + "," + e.CIAverageCustomersRight + ">";
            this.Invoke(new Action(() => RefreshIntervals()));
            this.Invoke(new Action(() => button1.Enabled = true));
        }
        private void RefreshIntervals()
        {
            labelCIPeopleInSystem.Text = conIntervalPeopleInSystem;
            labelCITimeInSystem.Text = conIntervalTimeInSystem;
        }
        private void GlobalDetailsHandler(object? sender, GlobalDetailsEventArgs e)
        {
            globalAverageActual = "Priemerný čas strávený v prevádzke(min): " + new string(' ', 49) + e.GlobalAverage;
            numberOfReplication = "Replikácia no. " + e.NumberOfReplication;
            globalAverageVisits = "Priemerný počet ľudí za deň: " + new string(' ', 68) + e.GlobalVisits;
            leftInSystem = "Priemerný počet ľudí v systéme po uzávierke: " + new string(' ', 42) + e.GlobalLeftInSystem;
            globalWaitingTakeOver = "Priemerné čakanie na odovzdanie auta(min): " + new string(' ', 43) + e.GlobalTakeOverWaiting;
            globalAveragePeopleInSystem = "Priemerný počet ľudí v systéme: " + new string(' ', 64) + e.GlobalAveragePeopleInSystem;
            globalAverageFreeCashiers = "Priemerný počet voľných pracovníkov sk.1: " + new string(' ', 46) + e.GlobalAverageFreeCashiers;
            globalAverageFreeTechnicians = "Priemerný počet voľných pracovníkov sk.2: " + new string(' ', 46) + e.GlobalAverageFreeTechnicians;
            globalAveragePeopleWaitingForTakeOver = "Priemerná veľkosť radu na prevzatie: " + new string(' ', 55) + e.GlobalAveragePeopleWaitingForTakeOver;

            this.Invoke(new Action(() => RefreshGlobal()));
            this.Invoke(new Action(() => label2.Text = "Priemerná dĺžka radu na platenie: " + e.GlobalAveragePaymentQueue));
            this.Invoke(new Action(() => label3.Text = "Priemerná dĺžka čakania na platenie: " + e.GlobalAveragePaymentWaiting));
            this.Invoke(new Action(() => label4.Text = "Priemerná dĺžka radu na kontrolu: " + e.GlobalAverageControlQueue));
            this.Invoke(new Action(() => label5.Text = "Priemerná dĺžka čakania na kontrolu: " + e.GlobalAverageControlWaiting));
            this.Invoke(new Action(() => label6.Text = "Priemerná obsadenie parkoviska: " + e.GlobalAverageEmptySpots));
        }

        public void RefreshGlobal()
        {
            labelGlobalTimeSpent.Text = globalAverageActual;
            labelReplication.Text = numberOfReplication;
            labelAverageVisits.Text = globalAverageVisits;
            labelLeftInSystem.Text = leftInSystem;
            labelGlobalTakeOver.Text = globalWaitingTakeOver;
            labelGlobalAveragePeopleInSystem.Text = globalAveragePeopleInSystem;
            labelGlobalAverageFreeCashiers.Text = globalAverageFreeCashiers;
            labelGlobalAverageFreeTechnicians.Text = globalAverageFreeTechnicians;
            labelGlobalAveragePeopleWaitingForTakeOver.Text = globalAveragePeopleWaitingForTakeOver;
        }
        private void SimulationDetailsHandler(object? sender, SimulationDetailsEventArgs e)
        {

            actualTime = "Aktuálny čas: " + TimeSpan.FromMinutes(e.Time).ToString(@"hh\:mm");
            checkInQueue = "Počet ľudí čakajúcich na prevzatie: " + e.CheckInQueue;
            inspectionQueue = "Počet čakjúcich áut na parkovisku pred inšpekciou: " + e.InspectionParkingLot;
            paymentQueue = "Počet ľudí čakajúcich na zaplatenie: " + e.PaymentQueue;
            freeCashiers = "Počet voľných pokladníkov(Pracovníci 1): " + e.FreeCashiers + "/" + (int)numericCashier.Value;
            freeTechnician = "Počet voľných technikov(Pracovníci 2): " + e.FreeTechnicians + "/" + (int)numericTechnician.Value;
            technicianSTKs = e.Technicians;
            cashierSTKs = e.Cashier;
            customersInSystem = e.customersInSystem;
            customersInShop = "Počet zákazníkov v systéme: " + customersInSystem.Count();
            averageActual = "Priemerný čas strávený v prevádzke(min): " + e.AverageActual;
            averageWaitingTakeOver = "Priemerný čas čakania v rade na prevzatie(min): " + e.AverageTakeOverWaiting;
            averagePeopleInSystem = "Priemerný počet ľudí v systéme: " + e.AveragePeopleInSystem;
            averageFreeCashiers = "Priemerný počet voľných pracovníkov sk.1: " + e.AverageFreeCashiers;
            averageFreeTechnicians = "Priemerný počet voľných pracovníkov sk.2: " + e.AverageFreeTechnician;
            averagePeopleWaitingForTakeOver = "Priemerná veľkosť radu na prevzatie: " + e.AveragePeopleWaitingForTakeOver;
            this.Invoke(new Action(() => Refresh()));
        }

        private void Refresh()
        {
            #region Local stats label set
            labelCurrentTime.Text = actualTime;
            labelCheckInWait.Text = checkInQueue;
            labelControlParking.Text = inspectionQueue;
            labelPaymentQueue.Text = paymentQueue;
            labelCashiers.Text = freeCashiers;
            labelTechnician.Text = freeTechnician;
            labelCustomersInSystem.Text = customersInShop;
            labelAverageTakeOver.Text = averageWaitingTakeOver;
            labelAverageTimeInSystem.Text = averageActual;
            labelAveragePeopleInSystem.Text = averagePeopleInSystem;
            labelAverageFreeCashiers.Text = averageFreeCashiers;
            labelAverageFreeTechnicians.Text = averageFreeTechnicians;
            labelAverageWaitingForTakeOver.Text = averagePeopleWaitingForTakeOver;
            #endregion
            #region Table refresh
            dataGridView1.Rows.Clear();
            if (showTechnicians && technicianSTKs != null)
            {
                foreach (var worker in technicianSTKs)
                {
                    dataGridView1.Rows.Add(worker.ID, worker.WorkingOn, worker.ControlledCar, worker.CustomerID);
                }
            }
            dataGridView2.Rows.Clear();
            if (showCashiers && cashierSTKs != null)
            {
                foreach (var worker in cashierSTKs)
                {
                    dataGridView2.Rows.Add(worker.ID, worker.WorkingOn, worker.customerID);
                }
            }
            dataGridView3.Rows.Clear();
            if (showCustomers && customersInSystem != null)
            {
                foreach (var customer in customersInSystem)
                {
                    dataGridView3.Rows.Add(customer.Value.ID, customer.Value.Car, customer.Value.Status);
                }
            }
            #endregion
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            ClearData();
            simSTK.NumberOfCashier = (int)numericCashier.Value;
            simSTK.NumberOfTechnicians = (int)numericTechnician.Value;
            button1.Enabled = false;
            Task.Run(() => simSTK.Simulate((int)numericReplications.Value, cts.Token));
        }


        private void button2_Click(object sender, EventArgs e)
        {
            simSTK.SwitchPause();
            if (button2.Text == "Pause")
            {
                button2.Text = "Unpause";
            }
            else
            {
                button2.Text = "Pause";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
            button1.Enabled = true;
            button2.Text = "Pause";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            simSTK.Delay = trackBar1.Value;
        }

        public void InitializeTables()
        {

            dataGridView1.Columns.Add("TechnicianID", "Technician ID");
            dataGridView1.Columns.Add("Status", "Status");
            dataGridView1.Columns.Add("ControlledCar", "Controlled Car");
            dataGridView1.Columns.Add("CustomerID", "Customer ID");

            dataGridView2.Columns.Add("CashierID", "Cashier ID");
            dataGridView2.Columns.Add("Status", "Status");
            dataGridView2.Columns.Add("Serving", "Serving Customer");

            dataGridView3.Columns.Add("CustomerID", "Customer ID");
            dataGridView3.Columns.Add("Car", "Car");
            dataGridView3.Columns.Add("Status", "Status");
        }

        public void ClearData()
        {
            actualTime = "Aktuálny čas: ";

            customersInShop = "Počet zákazníkov v systéme: ";
            checkInQueue = "Počet ľudí čakajúcich na prevzatie: ";
            paymentQueue = "Počet ľudí čakajúcich na zaplatenie: ";

            freeTechnician = "Počet voľných technikov(Pracovníci 2): ";
            inspectionQueue = "Počet čakjúcich áut na parkovisku pred inšpekciou: ";

            freeCashiers = "Počet voľných pokladníkov(Pracovníci 1): ";

            averageActual = "Priemerný čas strávený v prevádzke(min): ";
            averageWaitingTakeOver = "Priemerný čas čakania v rade na prevzatie(min): ";
            averagePeopleInSystem = "Priemerný počet ľudí v systéme: ";
            averagePeopleWaitingForTakeOver = "Priemerná veľkosť radu na prevzatie: ";

            numberOfReplication = "Replikácia no. ";
            globalAverageVisits = "Priemerný počet ľudí za deň: ";
            leftInSystem = "Priemerný počet ľudí v systéme po uzávierke: ";
            globalWaitingTakeOver = "Priemerné čakanie na odovzdanie auta(min): ";
            globalAverageActual = "Priemerný čas strávený v prevádzke(min): ";
            globalAveragePeopleInSystem = "Priemerný počet ľudí v systéme: ";
            globalAveragePeopleWaitingForTakeOver = "Priemerná veľkosť radu na prevzatie: ";
            conIntervalTimeInSystem = "90 % Interval spoľahlivosti pre priemerný strávený čas v systéme(min):";
            conIntervalPeopleInSystem = "95 % Interval spoľahlivosti pre priemerný počet ľudí v systéme:";
            /*technicianSTKs = new TechnicianSTK[1];
            cashierSTKs = new CashierSTK[1];
            customersInSystem = new Dictionary<int, CustomerSTK>();*/
            Refresh();
            RefreshGlobal();
            RefreshIntervals();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            /*if (checkBox1.Checked)
            {
                simSTK.Turbo = true;
            }
            else
            {
                simSTK.Turbo = false;
            }*/
            simSTK.SwitchTurbo();
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            FormSTKWorkers formStkWorker = new FormSTKWorkers();
            formStkWorker.Show();
            this.Enabled = true;
        }
    }
}

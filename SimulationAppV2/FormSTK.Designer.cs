namespace SimulationAppV2
{
    partial class FormSTK
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            labelCurrentTime = new Label();
            labelOpening = new Label();
            labelClosing = new Label();
            button2 = new Button();
            button4 = new Button();
            labelControlParking = new Label();
            labelPaymentQueue = new Label();
            labelCashiers = new Label();
            labelTechnician = new Label();
            labelCheckInWait = new Label();
            trackBar1 = new TrackBar();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            labelCustomersInSystem = new Label();
            labelAverageTimeInSystem = new Label();
            labelReplication = new Label();
            numericCashier = new NumericUpDown();
            numericTechnician = new NumericUpDown();
            numericReplications = new NumericUpDown();
            labelGlobalTimeSpent = new Label();
            labelAverageVisits = new Label();
            labelLeftInSystem = new Label();
            checkBox1 = new CheckBox();
            labelAverageTakeOver = new Label();
            checkBoxWorker2 = new CheckBox();
            checkBoxWorker1 = new CheckBox();
            checkBoxCustomers = new CheckBox();
            labelGlobalTakeOver = new Label();
            labelCITimeInSystem = new Label();
            labelCIPeopleInSystem = new Label();
            labelGlobalAveragePeopleInSystem = new Label();
            labelAveragePeopleInSystem = new Label();
            labelAverageFreeCashiers = new Label();
            labelAverageFreeTechnicians = new Label();
            labelGlobalAverageFreeCashiers = new Label();
            labelGlobalAverageFreeTechnicians = new Label();
            button3 = new Button();
            groupBox1 = new GroupBox();
            labelGlobalAveragePeopleWaitingForTakeOver = new Label();
            labelAverageWaitingForTakeOver = new Label();
            labelCash = new Label();
            labelTech = new Label();
            labelNumberOfReplications = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCashier).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericTechnician).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericReplications).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(113, 42);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // labelCurrentTime
            // 
            labelCurrentTime.AutoSize = true;
            labelCurrentTime.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            labelCurrentTime.Location = new Point(355, 218);
            labelCurrentTime.Name = "labelCurrentTime";
            labelCurrentTime.Size = new Size(160, 25);
            labelCurrentTime.TabIndex = 1;
            labelCurrentTime.Text = "Aktuálny čas: 9:00";
            // 
            // labelOpening
            // 
            labelOpening.AutoSize = true;
            labelOpening.Location = new Point(306, 262);
            labelOpening.Name = "labelOpening";
            labelOpening.Size = new Size(74, 15);
            labelOpening.TabIndex = 3;
            labelOpening.Text = "Otvárací čas:";
            // 
            // labelClosing
            // 
            labelClosing.AutoSize = true;
            labelClosing.Location = new Point(498, 262);
            labelClosing.Name = "labelClosing";
            labelClosing.Size = new Size(76, 15);
            labelClosing.TabIndex = 4;
            labelClosing.Text = "Zatvára sa o: ";
            // 
            // button2
            // 
            button2.Location = new Point(12, 60);
            button2.Name = "button2";
            button2.Size = new Size(113, 43);
            button2.TabIndex = 5;
            button2.Text = "Pause";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 109);
            button4.Name = "button4";
            button4.Size = new Size(113, 42);
            button4.TabIndex = 7;
            button4.Text = "Stop";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // labelControlParking
            // 
            labelControlParking.AutoSize = true;
            labelControlParking.Location = new Point(1088, 283);
            labelControlParking.Name = "labelControlParking";
            labelControlParking.Size = new Size(279, 15);
            labelControlParking.TabIndex = 8;
            labelControlParking.Text = "Počet čakjúcich áut na parkovisku pred inšpekciou: ";
            // 
            // labelPaymentQueue
            // 
            labelPaymentQueue.AutoSize = true;
            labelPaymentQueue.Location = new Point(1082, 753);
            labelPaymentQueue.Name = "labelPaymentQueue";
            labelPaymentQueue.Size = new Size(195, 15);
            labelPaymentQueue.TabIndex = 9;
            labelPaymentQueue.Text = "Počet ľudí čakajúcich na zaplatenie:";
            // 
            // labelCashiers
            // 
            labelCashiers.AutoSize = true;
            labelCashiers.Location = new Point(718, 253);
            labelCashiers.Name = "labelCashiers";
            labelCashiers.Size = new Size(226, 15);
            labelCashiers.TabIndex = 10;
            labelCashiers.Text = "Počet voľných pokladníkov(Pracovníci 1):";
            // 
            // labelTechnician
            // 
            labelTechnician.AutoSize = true;
            labelTechnician.Location = new Point(1088, 253);
            labelTechnician.Name = "labelTechnician";
            labelTechnician.Size = new Size(213, 15);
            labelTechnician.TabIndex = 11;
            labelTechnician.Text = "Počet voľných technikov(Pracovníci 2):";
            // 
            // labelCheckInWait
            // 
            labelCheckInWait.AutoSize = true;
            labelCheckInWait.Location = new Point(1082, 723);
            labelCheckInWait.Name = "labelCheckInWait";
            labelCheckInWait.Size = new Size(189, 15);
            labelCheckInWait.TabIndex = 12;
            labelCheckInWait.Text = "Počet ľudí čakajúcich na prevzatie:";
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 250;
            trackBar1.Location = new Point(259, 80);
            trackBar1.Maximum = 1000;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(230, 45);
            trackBar1.SmallChange = 100;
            trackBar1.TabIndex = 500;
            trackBar1.Value = 500;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(1082, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(358, 217);
            dataGridView1.TabIndex = 14;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(718, 12);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(358, 217);
            dataGridView2.TabIndex = 15;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(1082, 342);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(358, 333);
            dataGridView3.TabIndex = 16;
            // 
            // labelCustomersInSystem
            // 
            labelCustomersInSystem.AutoSize = true;
            labelCustomersInSystem.Location = new Point(1082, 697);
            labelCustomersInSystem.Name = "labelCustomersInSystem";
            labelCustomersInSystem.Size = new Size(158, 15);
            labelCustomersInSystem.TabIndex = 17;
            labelCustomersInSystem.Text = "Počet zákazníkov v systéme: ";
            // 
            // labelAverageTimeInSystem
            // 
            labelAverageTimeInSystem.AutoSize = true;
            labelAverageTimeInSystem.Location = new Point(718, 425);
            labelAverageTimeInSystem.Name = "labelAverageTimeInSystem";
            labelAverageTimeInSystem.Size = new Size(196, 15);
            labelAverageTimeInSystem.TabIndex = 18;
            labelAverageTimeInSystem.Text = "Priemerný čas strávený v prevádzke:";
            // 
            // labelReplication
            // 
            labelReplication.AutoSize = true;
            labelReplication.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            labelReplication.Location = new Point(172, 19);
            labelReplication.Name = "labelReplication";
            labelReplication.Size = new Size(131, 28);
            labelReplication.TabIndex = 19;
            labelReplication.Text = "Replikácia no.";
            // 
            // numericCashier
            // 
            numericCashier.Location = new Point(305, 31);
            numericCashier.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericCashier.Name = "numericCashier";
            numericCashier.Size = new Size(120, 23);
            numericCashier.TabIndex = 502;
            numericCashier.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // numericTechnician
            // 
            numericTechnician.Location = new Point(459, 31);
            numericTechnician.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericTechnician.Name = "numericTechnician";
            numericTechnician.Size = new Size(120, 23);
            numericTechnician.TabIndex = 503;
            numericTechnician.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // numericReplications
            // 
            numericReplications.Increment = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericReplications.Location = new Point(157, 31);
            numericReplications.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            numericReplications.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericReplications.Name = "numericReplications";
            numericReplications.Size = new Size(120, 23);
            numericReplications.TabIndex = 504;
            numericReplications.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            // 
            // labelGlobalTimeSpent
            // 
            labelGlobalTimeSpent.AutoSize = true;
            labelGlobalTimeSpent.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelGlobalTimeSpent.Location = new Point(6, 283);
            labelGlobalTimeSpent.Name = "labelGlobalTimeSpent";
            labelGlobalTimeSpent.Size = new Size(301, 20);
            labelGlobalTimeSpent.TabIndex = 505;
            labelGlobalTimeSpent.Text = "Priemerný čas strávený v prevádzke(global): ";
            // 
            // labelAverageVisits
            // 
            labelAverageVisits.AutoSize = true;
            labelAverageVisits.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelAverageVisits.Location = new Point(6, 105);
            labelAverageVisits.Name = "labelAverageVisits";
            labelAverageVisits.Size = new Size(202, 20);
            labelAverageVisits.TabIndex = 506;
            labelAverageVisits.Text = "Priemerný počet ľudí za deň: ";
            // 
            // labelLeftInSystem
            // 
            labelLeftInSystem.AutoSize = true;
            labelLeftInSystem.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelLeftInSystem.Location = new Point(6, 135);
            labelLeftInSystem.Name = "labelLeftInSystem";
            labelLeftInSystem.Size = new Size(310, 20);
            labelLeftInSystem.TabIndex = 507;
            labelLeftInSystem.Text = "Priemerný počet ľudí v systéme po uzávierke: ";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 224);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(57, 19);
            checkBox1.TabIndex = 508;
            checkBox1.Text = "Turbo";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // labelAverageTakeOver
            // 
            labelAverageTakeOver.AutoSize = true;
            labelAverageTakeOver.Location = new Point(718, 398);
            labelAverageTakeOver.Name = "labelAverageTakeOver";
            labelAverageTakeOver.Size = new Size(231, 15);
            labelAverageTakeOver.TabIndex = 509;
            labelAverageTakeOver.Text = "Priemerný čas čakania v rade na prevzatie: ";
            // 
            // checkBoxWorker2
            // 
            checkBoxWorker2.AutoSize = true;
            checkBoxWorker2.Location = new Point(12, 279);
            checkBoxWorker2.Name = "checkBoxWorker2";
            checkBoxWorker2.Size = new Size(191, 19);
            checkBoxWorker2.TabIndex = 510;
            checkBoxWorker2.Text = "Zobraziť tabuľku pracovníkov 2";
            checkBoxWorker2.UseVisualStyleBackColor = true;
            checkBoxWorker2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBoxWorker1
            // 
            checkBoxWorker1.AutoSize = true;
            checkBoxWorker1.Location = new Point(12, 249);
            checkBoxWorker1.Name = "checkBoxWorker1";
            checkBoxWorker1.Size = new Size(191, 19);
            checkBoxWorker1.TabIndex = 511;
            checkBoxWorker1.Text = "Zobraziť tabuľku pracovníkov 1";
            checkBoxWorker1.UseVisualStyleBackColor = true;
            checkBoxWorker1.CheckedChanged += checkBox3_CheckedChanged;
            // 
            // checkBoxCustomers
            // 
            checkBoxCustomers.AutoSize = true;
            checkBoxCustomers.Location = new Point(12, 309);
            checkBoxCustomers.Name = "checkBoxCustomers";
            checkBoxCustomers.Size = new Size(185, 19);
            checkBoxCustomers.TabIndex = 512;
            checkBoxCustomers.Text = "Zobraziť zákazníkov v systéme";
            checkBoxCustomers.UseVisualStyleBackColor = true;
            checkBoxCustomers.CheckedChanged += checkBox4_CheckedChanged;
            // 
            // labelGlobalTakeOver
            // 
            labelGlobalTakeOver.AutoSize = true;
            labelGlobalTakeOver.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelGlobalTakeOver.Location = new Point(6, 163);
            labelGlobalTakeOver.Name = "labelGlobalTakeOver";
            labelGlobalTakeOver.Size = new Size(325, 20);
            labelGlobalTakeOver.TabIndex = 513;
            labelGlobalTakeOver.Text = "Priemerné čakanie na odovzdanie auta(global): ";
            // 
            // labelCITimeInSystem
            // 
            labelCITimeInSystem.AutoSize = true;
            labelCITimeInSystem.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelCITimeInSystem.Location = new Point(6, 311);
            labelCITimeInSystem.Name = "labelCITimeInSystem";
            labelCITimeInSystem.Size = new Size(435, 20);
            labelCITimeInSystem.TabIndex = 514;
            labelCITimeInSystem.Text = "90% Interval spoľahlibosti pre priemerný strávený čas v systéme: ";
            // 
            // labelCIPeopleInSystem
            // 
            labelCIPeopleInSystem.AutoSize = true;
            labelCIPeopleInSystem.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelCIPeopleInSystem.Location = new Point(6, 379);
            labelCIPeopleInSystem.Name = "labelCIPeopleInSystem";
            labelCIPeopleInSystem.Size = new Size(418, 20);
            labelCIPeopleInSystem.TabIndex = 515;
            labelCIPeopleInSystem.Text = "95% Interval spoľahlivosti pre priemerný počet ľudí v systéme:";
            // 
            // labelGlobalAveragePeopleInSystem
            // 
            labelGlobalAveragePeopleInSystem.AutoSize = true;
            labelGlobalAveragePeopleInSystem.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelGlobalAveragePeopleInSystem.Location = new Point(6, 349);
            labelGlobalAveragePeopleInSystem.Name = "labelGlobalAveragePeopleInSystem";
            labelGlobalAveragePeopleInSystem.Size = new Size(269, 20);
            labelGlobalAveragePeopleInSystem.TabIndex = 516;
            labelGlobalAveragePeopleInSystem.Text = "Priemerný počet ľudí v sytéme(global): ";
            // 
            // labelAveragePeopleInSystem
            // 
            labelAveragePeopleInSystem.AutoSize = true;
            labelAveragePeopleInSystem.Location = new Point(718, 373);
            labelAveragePeopleInSystem.Name = "labelAveragePeopleInSystem";
            labelAveragePeopleInSystem.Size = new Size(174, 15);
            labelAveragePeopleInSystem.TabIndex = 517;
            labelAveragePeopleInSystem.Text = "Priemerný počet ľudí v sytéme: ";
            // 
            // labelAverageFreeCashiers
            // 
            labelAverageFreeCashiers.AutoSize = true;
            labelAverageFreeCashiers.Location = new Point(718, 283);
            labelAverageFreeCashiers.Name = "labelAverageFreeCashiers";
            labelAverageFreeCashiers.Size = new Size(233, 15);
            labelAverageFreeCashiers.TabIndex = 518;
            labelAverageFreeCashiers.Text = "Priemerný počet voľlých pracovníkov sk.1: ";
            // 
            // labelAverageFreeTechnicians
            // 
            labelAverageFreeTechnicians.AutoSize = true;
            labelAverageFreeTechnicians.Location = new Point(1088, 309);
            labelAverageFreeTechnicians.Name = "labelAverageFreeTechnicians";
            labelAverageFreeTechnicians.Size = new Size(234, 15);
            labelAverageFreeTechnicians.TabIndex = 519;
            labelAverageFreeTechnicians.Text = "Priemerný počet voľných pracovníkov sk.2:";
            // 
            // labelGlobalAverageFreeCashiers
            // 
            labelGlobalAverageFreeCashiers.AutoSize = true;
            labelGlobalAverageFreeCashiers.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelGlobalAverageFreeCashiers.Location = new Point(6, 191);
            labelGlobalAverageFreeCashiers.Name = "labelGlobalAverageFreeCashiers";
            labelGlobalAverageFreeCashiers.Size = new Size(340, 20);
            labelGlobalAverageFreeCashiers.TabIndex = 520;
            labelGlobalAverageFreeCashiers.Text = "Priemerný počet voľných pracovníkov sk.1(global):";
            // 
            // labelGlobalAverageFreeTechnicians
            // 
            labelGlobalAverageFreeTechnicians.AutoSize = true;
            labelGlobalAverageFreeTechnicians.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelGlobalAverageFreeTechnicians.Location = new Point(6, 221);
            labelGlobalAverageFreeTechnicians.Name = "labelGlobalAverageFreeTechnicians";
            labelGlobalAverageFreeTechnicians.Size = new Size(340, 20);
            labelGlobalAverageFreeTechnicians.TabIndex = 521;
            labelGlobalAverageFreeTechnicians.Text = "Priemerný počet voľných pracovníkov sk.2(global):";
            // 
            // button3
            // 
            button3.Location = new Point(12, 162);
            button3.Name = "button3";
            button3.Size = new Size(113, 44);
            button3.TabIndex = 522;
            button3.Text = "Experiment závislostí";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelGlobalAveragePeopleWaitingForTakeOver);
            groupBox1.Controls.Add(labelGlobalAverageFreeCashiers);
            groupBox1.Controls.Add(labelGlobalAverageFreeTechnicians);
            groupBox1.Controls.Add(labelReplication);
            groupBox1.Controls.Add(labelGlobalTakeOver);
            groupBox1.Controls.Add(labelAverageVisits);
            groupBox1.Controls.Add(labelGlobalAveragePeopleInSystem);
            groupBox1.Controls.Add(labelLeftInSystem);
            groupBox1.Controls.Add(labelCIPeopleInSystem);
            groupBox1.Controls.Add(labelGlobalTimeSpent);
            groupBox1.Controls.Add(labelCITimeInSystem);
            groupBox1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(12, 354);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(700, 409);
            groupBox1.TabIndex = 523;
            groupBox1.TabStop = false;
            groupBox1.Text = "Globálne štatistiky";
            // 
            // labelGlobalAveragePeopleWaitingForTakeOver
            // 
            labelGlobalAveragePeopleWaitingForTakeOver.AutoSize = true;
            labelGlobalAveragePeopleWaitingForTakeOver.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            labelGlobalAveragePeopleWaitingForTakeOver.Location = new Point(8, 251);
            labelGlobalAveragePeopleWaitingForTakeOver.Name = "labelGlobalAveragePeopleWaitingForTakeOver";
            labelGlobalAveragePeopleWaitingForTakeOver.Size = new Size(308, 20);
            labelGlobalAveragePeopleWaitingForTakeOver.TabIndex = 522;
            labelGlobalAveragePeopleWaitingForTakeOver.Text = "Priemerná veľkosť radu na prevzatie(global): ";
            // 
            // labelAverageWaitingForTakeOver
            // 
            labelAverageWaitingForTakeOver.AutoSize = true;
            labelAverageWaitingForTakeOver.Location = new Point(718, 309);
            labelAverageWaitingForTakeOver.Name = "labelAverageWaitingForTakeOver";
            labelAverageWaitingForTakeOver.Size = new Size(202, 15);
            labelAverageWaitingForTakeOver.TabIndex = 524;
            labelAverageWaitingForTakeOver.Text = "Priemerná veľkosť radu na prevzatie: ";
            // 
            // labelCash
            // 
            labelCash.AutoSize = true;
            labelCash.Location = new Point(305, 12);
            labelCash.Name = "labelCash";
            labelCash.Size = new Size(128, 15);
            labelCash.TabIndex = 525;
            labelCash.Text = "Počet pracovníkov sk.1";
            // 
            // labelTech
            // 
            labelTech.AutoSize = true;
            labelTech.Location = new Point(459, 12);
            labelTech.Name = "labelTech";
            labelTech.Size = new Size(128, 15);
            labelTech.TabIndex = 526;
            labelTech.Text = "Počet pracovníkov sk.2";
            // 
            // labelNumberOfReplications
            // 
            labelNumberOfReplications.AutoSize = true;
            labelNumberOfReplications.Location = new Point(157, 12);
            labelNumberOfReplications.Name = "labelNumberOfReplications";
            labelNumberOfReplications.Size = new Size(87, 15);
            labelNumberOfReplications.TabIndex = 527;
            labelNumberOfReplications.Text = "Počet replikácií";
            // 
            // FormSTK
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1476, 775);
            Controls.Add(labelNumberOfReplications);
            Controls.Add(labelTech);
            Controls.Add(labelCash);
            Controls.Add(labelAverageWaitingForTakeOver);
            Controls.Add(groupBox1);
            Controls.Add(button3);
            Controls.Add(labelAverageFreeTechnicians);
            Controls.Add(labelAverageFreeCashiers);
            Controls.Add(labelAveragePeopleInSystem);
            Controls.Add(checkBoxCustomers);
            Controls.Add(checkBoxWorker1);
            Controls.Add(checkBoxWorker2);
            Controls.Add(labelAverageTakeOver);
            Controls.Add(checkBox1);
            Controls.Add(numericReplications);
            Controls.Add(numericTechnician);
            Controls.Add(numericCashier);
            Controls.Add(labelAverageTimeInSystem);
            Controls.Add(labelCustomersInSystem);
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(trackBar1);
            Controls.Add(labelCheckInWait);
            Controls.Add(labelTechnician);
            Controls.Add(labelCashiers);
            Controls.Add(labelPaymentQueue);
            Controls.Add(labelControlParking);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(labelClosing);
            Controls.Add(labelOpening);
            Controls.Add(labelCurrentTime);
            Controls.Add(button1);
            Name = "FormSTK";
            Text = "FormSTK";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericCashier).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericTechnician).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericReplications).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label labelCurrentTime;
        private Label labelOpening;
        private Label labelClosing;
        private Button button2;
        private Button button4;
        private Label labelControlParking;
        private Label labelPaymentQueue;
        private Label labelCashiers;
        private Label labelTechnician;
        private Label labelCheckInWait;
        private TrackBar trackBar1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private Label labelCustomersInSystem;
        private Label labelAverageTimeInSystem;
        private Label labelReplication;
        private NumericUpDown numericCashier;
        private NumericUpDown numericTechnician;
        private NumericUpDown numericReplications;
        private Label labelGlobalTimeSpent;
        private Label labelAverageVisits;
        private Label labelLeftInSystem;
        private CheckBox checkBox1;
        private Label labelAverageTakeOver;
        private CheckBox checkBoxWorker2;
        private CheckBox checkBoxWorker1;
        private CheckBox checkBoxCustomers;
        private Label labelGlobalTakeOver;
        private Label labelCITimeInSystem;
        private Label labelCIPeopleInSystem;
        private Label labelGlobalAveragePeopleInSystem;
        private Label labelAveragePeopleInSystem;
        private Label labelAverageFreeCashiers;
        private Label labelAverageFreeTechnicians;
        private Label labelGlobalAverageFreeCashiers;
        private Label labelGlobalAverageFreeTechnicians;
        private Button button3;
        private GroupBox groupBox1;
        private Label labelAverageWaitingForTakeOver;
        private Label labelGlobalAveragePeopleWaitingForTakeOver;
        private Label labelCash;
        private Label labelTech;
        private Label labelNumberOfReplications;
    }
}
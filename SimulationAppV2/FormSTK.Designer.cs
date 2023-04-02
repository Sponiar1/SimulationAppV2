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
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            button2 = new Button();
            button4 = new Button();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            trackBar1 = new TrackBar();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            label9 = new Label();
            label10 = new Label();
            labelReplication = new Label();
            numericCashier = new NumericUpDown();
            numericTechnician = new NumericUpDown();
            numericReplications = new NumericUpDown();
            labelGlobalTimeSpent = new Label();
            label11 = new Label();
            labelLeftInSystem = new Label();
            checkBox1 = new CheckBox();
            label12 = new Label();
            checkBoxWorker2 = new CheckBox();
            checkBoxWorker1 = new CheckBox();
            checkBoxCustomers = new CheckBox();
            labelGlobalTakeOver = new Label();
            labelCITimeInSystem = new Label();
            labelCIPeopleInSystem = new Label();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericCashier).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericTechnician).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericReplications).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(27, 677);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(405, 639);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 1;
            label1.Text = "Aktuálny čas: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(385, 703);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 3;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(577, 703);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 4;
            label4.Text = "label4";
            // 
            // button2
            // 
            button2.Location = new Point(385, 531);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "Pause";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(540, 531);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 7;
            button4.Text = "Stop";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1220, 283);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 8;
            label2.Text = "label2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1220, 772);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 9;
            label5.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(934, 253);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 10;
            label6.Text = "label6";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1220, 253);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 11;
            label7.Text = "label7";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1220, 742);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 12;
            label8.Text = "label8";
            // 
            // trackBar1
            // 
            trackBar1.LargeChange = 250;
            trackBar1.Location = new Point(385, 591);
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
            dataGridView1.Location = new Point(1214, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(358, 217);
            dataGridView1.TabIndex = 14;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(850, 12);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(358, 217);
            dataGridView2.TabIndex = 15;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(1214, 322);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(358, 360);
            dataGridView3.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1220, 716);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 17;
            label9.Text = "label9";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(706, 497);
            label10.Name = "label10";
            label10.Size = new Size(44, 15);
            label10.TabIndex = 18;
            label10.Text = "label10";
            // 
            // labelReplication
            // 
            labelReplication.AutoSize = true;
            labelReplication.Location = new Point(706, 531);
            labelReplication.Name = "labelReplication";
            labelReplication.Size = new Size(91, 15);
            labelReplication.TabIndex = 19;
            labelReplication.Text = "labelReplication";
            // 
            // numericCashier
            // 
            numericCashier.Location = new Point(27, 613);
            numericCashier.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            numericCashier.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericCashier.Name = "numericCashier";
            numericCashier.Size = new Size(120, 23);
            numericCashier.TabIndex = 502;
            numericCashier.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // numericTechnician
            // 
            numericTechnician.Location = new Point(194, 613);
            numericTechnician.Maximum = new decimal(new int[] { 25, 0, 0, 0 });
            numericTechnician.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericTechnician.Name = "numericTechnician";
            numericTechnician.Size = new Size(120, 23);
            numericTechnician.TabIndex = 503;
            numericTechnician.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // numericReplications
            // 
            numericReplications.Increment = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericReplications.Location = new Point(108, 558);
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
            labelGlobalTimeSpent.Location = new Point(706, 566);
            labelGlobalTimeSpent.Name = "labelGlobalTimeSpent";
            labelGlobalTimeSpent.Size = new Size(122, 15);
            labelGlobalTimeSpent.TabIndex = 505;
            labelGlobalTimeSpent.Text = "labelGlobalTimeSpent";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(706, 594);
            label11.Name = "label11";
            label11.Size = new Size(44, 15);
            label11.TabIndex = 506;
            label11.Text = "label11";
            // 
            // labelLeftInSystem
            // 
            labelLeftInSystem.AutoSize = true;
            labelLeftInSystem.Location = new Point(706, 621);
            labelLeftInSystem.Name = "labelLeftInSystem";
            labelLeftInSystem.Size = new Size(100, 15);
            labelLeftInSystem.TabIndex = 507;
            labelLeftInSystem.Text = "labelLeftInSystem";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(231, 681);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(57, 19);
            checkBox1.TabIndex = 508;
            checkBox1.Text = "Turbo";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(706, 468);
            label12.Name = "label12";
            label12.Size = new Size(44, 15);
            label12.TabIndex = 509;
            label12.Text = "label12";
            // 
            // checkBoxWorker2
            // 
            checkBoxWorker2.AutoSize = true;
            checkBoxWorker2.Location = new Point(850, 703);
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
            checkBoxWorker1.Location = new Point(850, 673);
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
            checkBoxCustomers.Location = new Point(850, 733);
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
            labelGlobalTakeOver.Location = new Point(706, 649);
            labelGlobalTakeOver.Name = "labelGlobalTakeOver";
            labelGlobalTakeOver.Size = new Size(266, 15);
            labelGlobalTakeOver.TabIndex = 513;
            labelGlobalTakeOver.Text = "Globálne priemerné čakanie na odovzdanie auta: ";
            // 
            // labelCITimeInSystem
            // 
            labelCITimeInSystem.AutoSize = true;
            labelCITimeInSystem.Location = new Point(706, 439);
            labelCITimeInSystem.Name = "labelCITimeInSystem";
            labelCITimeInSystem.Size = new Size(347, 15);
            labelCITimeInSystem.TabIndex = 514;
            labelCITimeInSystem.Text = "90% Interval spoľahlibosti pre priemerný strávený čas v systéme: ";
            // 
            // labelCIPeopleInSystem
            // 
            labelCIPeopleInSystem.AutoSize = true;
            labelCIPeopleInSystem.Location = new Point(706, 414);
            labelCIPeopleInSystem.Name = "labelCIPeopleInSystem";
            labelCIPeopleInSystem.Size = new Size(333, 15);
            labelCIPeopleInSystem.TabIndex = 515;
            labelCIPeopleInSystem.Text = "95% Interval spoľahlivosti pre priemerný počet ľudí v systéme:";
            // 
            // FormSTK
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1579, 807);
            Controls.Add(labelCIPeopleInSystem);
            Controls.Add(labelCITimeInSystem);
            Controls.Add(labelGlobalTakeOver);
            Controls.Add(checkBoxCustomers);
            Controls.Add(checkBoxWorker1);
            Controls.Add(checkBoxWorker2);
            Controls.Add(label12);
            Controls.Add(checkBox1);
            Controls.Add(labelLeftInSystem);
            Controls.Add(label11);
            Controls.Add(labelGlobalTimeSpent);
            Controls.Add(numericReplications);
            Controls.Add(numericTechnician);
            Controls.Add(numericCashier);
            Controls.Add(labelReplication);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(trackBar1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label3;
        private Label label4;
        private Button button2;
        private Button button4;
        private Label label2;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TrackBar trackBar1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private Label label9;
        private Label label10;
        private Label labelReplication;
        private NumericUpDown numericCashier;
        private NumericUpDown numericTechnician;
        private NumericUpDown numericReplications;
        private Label labelGlobalTimeSpent;
        private Label label11;
        private Label labelLeftInSystem;
        private CheckBox checkBox1;
        private Label label12;
        private CheckBox checkBoxWorker2;
        private CheckBox checkBoxWorker1;
        private CheckBox checkBoxCustomers;
        private Label labelGlobalTakeOver;
        private Label labelCITimeInSystem;
        private Label labelCIPeopleInSystem;
    }
}
namespace SimulationAppV2
{
    partial class FormSTKWorkers
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
            formsPlot1 = new ScottPlot.FormsPlot();
            formsPlot2 = new ScottPlot.FormsPlot();
            button1 = new Button();
            SuspendLayout();
            // 
            // formsPlot1
            // 
            formsPlot1.Location = new Point(26, 40);
            formsPlot1.Margin = new Padding(4, 3, 4, 3);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(467, 346);
            formsPlot1.TabIndex = 0;
            // 
            // formsPlot2
            // 
            formsPlot2.Location = new Point(591, 40);
            formsPlot2.Margin = new Padding(4, 3, 4, 3);
            formsPlot2.Name = "formsPlot2";
            formsPlot2.Size = new Size(467, 346);
            formsPlot2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(200, 493);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormSTKWorkers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1149, 641);
            Controls.Add(button1);
            Controls.Add(formsPlot2);
            Controls.Add(formsPlot1);
            Name = "FormSTKWorkers";
            Text = "FormSTKWorkers";
            ResumeLayout(false);
        }

        #endregion

        private ScottPlot.FormsPlot formsPlot1;
        private ScottPlot.FormsPlot formsPlot2;
        private Button button1;
    }
}
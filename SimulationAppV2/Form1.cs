namespace SimulationAppV2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHiking formHiking = new FormHiking();
            formHiking.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormNewspaper formNewspaper = new FormNewspaper();
            formNewspaper.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormSTK formStk = new FormSTK();
            formStk.Show();
        }
    }
}
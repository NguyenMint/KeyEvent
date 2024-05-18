namespace KeyEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
              this.KeyPreview = true;
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
             //labelOutput.Text += $" {e.KeyChar}";
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            labelOutput.Text += $" {e.KeyCode}";

        }
    }
}
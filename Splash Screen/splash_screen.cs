using Main_Screen;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Splash_Screen
{
    public partial class splash_screen : Form
    {
        public splash_screen()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            progressBar1.Increment(2);
            if (progressBar1.Value == 100)
            {
                {
                    timer1.Enabled = false;
                    Form1 form = new Form1();
                    form.Show();
                    this.Hide();
                }
            }
        }
    }
}

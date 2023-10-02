using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIAssignment.Forms.CommonForms
{
    public partial class TrojanHorseForm : ChildForm
    {
        public TrojanHorseForm()
        {
            InitializeComponent();
        }

        private void Drive_Click(object sender, EventArgs e)
        {
            ActiveUser.InGps = true;
        }
        public override bool UnsavedChangesDetected()
        {
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Open_CheckedChanged(object sender, EventArgs e)
        {
            if (Open.Checked)
            {
                pictureBox4.Size = new Size(108, 161);
                pictureBox4.Image = Image.FromFile("../../Resources/open.png");
                NotFullyOpened.Checked = false;
                Closed.Checked = false;
            }
        }

        private void NotFullyOpened_CheckedChanged(object sender, EventArgs e)
        {
            if (NotFullyOpened.Checked)
            {
                pictureBox4.Size = new Size(100, 153);
                pictureBox4.Image = Image.FromFile("../../Resources/semiopen.png");
                Open.Checked = false;
                Closed.Checked = false;
            }
        }

        private void Closed_CheckedChanged(object sender, EventArgs e)
        {
            if (Closed.Checked)
            {
                pictureBox4.Size = new Size(92, 146);
                pictureBox4.Image = Image.FromFile("../../Resources/closed.png");
                Open.Checked = false;
                NotFullyOpened.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label4.Text == "Ανεβασμένη")
            {
                label4.Text = "Κατεβασμένη";
                button1.Text = "Πάτα για ανέβασμα της σκάλας";
                pictureBox1.Size = new Size(164, 243);
                pictureBox1.Image = Image.FromFile("../../Resources/Semi-Fully-open-large-1.jpg");
            }
            else
            {
                label4.Text = "Ανεβασμένη";
                button1.Text = "Πάτα για κατέβασμα της σκάλας";
                pictureBox1.Size = new Size(164, 177);
                pictureBox1.Image = Image.FromFile("../../Resources/Semi-Hopen-White-BG-remote-1-768x667.png");
            }
        }
    }
}

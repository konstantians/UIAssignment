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
    public partial class PrivatePoolForm : Form
    {
        public PrivatePoolForm()
        {
            InitializeComponent();
            trackBar1.Value = ActiveUser.Customer.Room.Pool.WaterLevel;
            checkWaterLevel();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            checkWaterLevel();
        }

        private void checkWaterLevel()
        {
            switch (trackBar1.Value)
            {
                case 0:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool0Percent;
                    break;
                case 1:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool10Percent;
                    break;
                case 2:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool20Percent;
                    break;
                case 3:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool30Percent;
                    break;
                case 4:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool40Percent;
                    break;
                case 5:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool50Percent;
                    break;
                case 6:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool60Percent;
                    break;
                case 7:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool70Percent;
                    break;
                case 8:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool80Percent;
                    break;
                case 9:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool90Percent;
                    break;
                case 10:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool100Percent;
                    break;
            }
        }
    }
}

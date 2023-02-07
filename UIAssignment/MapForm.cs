using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIAssignment
{
    public partial class MapForm : Form
    {
        public MapForm()
        {
            InitializeComponent();
        }

        private void MapForm_Load(object sender, EventArgs e)
        {

        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cool_button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void Apartment_MouseHover(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void Apartment_MouseLeave(object sender, EventArgs e)
        {
            panel2.Visible=false;
        }

        private void Restaurant_MouseHover(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void Restaurant_MouseLeave(object sender, EventArgs e)
        {
            panel3.Visible=false;
        }

        private void Pool_MouseHover(object sender, EventArgs e)
        {
            panel4.Visible= true;
        }

        private void Pool_MouseLeave(object sender, EventArgs e)
        {
            panel4.Visible= false;
        }

        private void TrojanHorse_MouseHover(object sender, EventArgs e)
        {
            panel5.Visible= true;
        }

        private void TrojanHorse_MouseLeave(object sender, EventArgs e)
        {
            panel5.Visible= false;
        }
    }
}

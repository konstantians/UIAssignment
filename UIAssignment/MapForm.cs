using System;
using System.Drawing;
using System.Windows.Forms;

namespace UIAssignment
{
    public partial class MapForm : Form
    {
        private Form activeForm = null;

        public MapForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            //apartmentIconPictureBox.BringToFront();
            openChildForm(new Menu());
        }

        private void apartmentSectionButton_MouseEnter(object sender, EventArgs e)
        {
            hiddenApartmentPanel.Visible = true;
            apartmentSectionButton.BackgroundImage = Properties.Resources.BlackMarbleBackground;
            apartmentSectionButton.TextColor = Color.White;
            hiddenApartmentPanel.BringToFront();
        }

        private void apartmentSectionButton_MouseLeave(object sender, EventArgs e)
        {
            hiddenApartmentPanel.Visible = false;
            apartmentSectionButton.BackgroundImage = null;
            apartmentSectionButton.TextColor = Color.Black;
        }

        private void restaurantSectionButton_MouseEnter(object sender, EventArgs e)
        {
            hiddenRestaurantPanel.Visible = true;
            restaurantSectionButton.BackgroundImage = Properties.Resources.BlackMarbleBackground;
            restaurantSectionButton.TextColor = Color.White;
            hiddenRestaurantPanel.BringToFront();
        }

        private void restaurantSectionButton_MouseLeave(object sender, EventArgs e)
        {
            hiddenRestaurantPanel.Visible = false;
            restaurantSectionButton.BackgroundImage = null;
            restaurantSectionButton.TextColor = Color.Black;
        }

        private void poolSectionButton_MouseEnter(object sender, EventArgs e)
        {
            hiddenPoolPanel.Visible = true;
            poolSectionButton.BackgroundImage = Properties.Resources.BlackMarbleBackground;
            poolSectionButton.TextColor = Color.White;
            hiddenPoolPanel.BringToFront();
        }

        private void poolSectionButton_MouseLeave(object sender, EventArgs e)
        {
            hiddenPoolPanel.Visible = false;
            poolSectionButton.BackgroundImage = null;
            poolSectionButton.TextColor = Color.Black;
        }

        private void trojanHorseSectionButton_MouseEnter(object sender, EventArgs e)
        {
            hiddenTroyanHorsePanel.Visible = true;
            trojanHorseSectionButton.BackgroundImage = Properties.Resources.BlackMarbleBackground;
            trojanHorseSectionButton.TextColor = Color.White;
            hiddenTroyanHorsePanel.BringToFront();
        }

        private void trojanHorseSectionButton_MouseLeave(object sender, EventArgs e)
        {
            hiddenTroyanHorsePanel.Visible = false;
            trojanHorseSectionButton.BackgroundImage = null;
            trojanHorseSectionButton.TextColor = Color.Black;
        }

        private void logoutSectionButton_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            foreignFormPanel.Controls.Add(childForm);
            foreignFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void apartmentSectionButton_Click(object sender, EventArgs e)
        {
            
        }

        private void logoutSectionButton_MouseEnter(object sender, EventArgs e)
        {
            logoutSectionButton.BackgroundImage = Properties.Resources.BlackMarbleBackground;
            logoutSectionButton.TextColor = Color.White;
        }

        private void logoutSectionButton_MouseLeave(object sender, EventArgs e)
        {
            logoutSectionButton.BackgroundImage = null;
            logoutSectionButton.TextColor = Color.Black;
        }

        private void helpSectionButton_MouseEnter(object sender, EventArgs e)
        {
            helpSectionButton.BackgroundImage = Properties.Resources.BlackMarbleBackground;
            helpSectionButton.TextColor = Color.White;
        }

        private void helpSectionButton_MouseLeave(object sender, EventArgs e)
        {
            helpSectionButton.BackgroundImage = null;
            helpSectionButton.TextColor = Color.Black;
        }
    }
}

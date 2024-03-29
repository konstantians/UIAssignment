﻿using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIAssignment.Forms.CommonForms;

namespace UIAssignment.Forms.CustomerForms
{
    public partial class SidebarCustomerForm : Form
    {
        private ChildForm activeForm = null;
        private bool closedFromLogOut = false;

        public SidebarCustomerForm()
        {
            InitializeComponent();
            DoubleBufferingForForms.SetDoubleBuffer(panelSideMenu, true);
            DoubleBufferingForForms.SetDoubleBuffer(panelLogo, true);
            DoubleBufferingForForms.SetDoubleBuffer(apartmentSectionButton, true);
            DoubleBufferingForForms.SetDoubleBuffer(restaurantSectionButton, true);
            DoubleBufferingForForms.SetDoubleBuffer(poolSectionButton, true);
            DoubleBufferingForForms.SetDoubleBuffer(trojanHorseSectionButton, true);
            DoubleBufferingForForms.SetDoubleBuffer(LogoutAndHelpSectionPanel, true);

            openChildForm(new MainForm());
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
            if (ActiveUser.Parked)
            {
                if (activeForm.UnsavedChangesDetected())
                    return;
                closedFromLogOut = true;
                activeForm.Close();
                this.Close();
                ActiveUser.User = null;
                ActiveUser.Customer = null;
                ActiveUser.Employee = null;
                Application.OpenForms[0].Show();
            }
            else
            {
                MessageBox.Show("Πρέπει να σταθμεύσεις όλους τους Δούρειους Ίππους προτού αποσυνδεθείς.");
            }
            /*if (activeForm.UnsavedChangesDetected())
              return;
            closedFromLogOut = true;
            activeForm.Close();
            this.Close();
            ActiveUser.User = null;
            ActiveUser.Customer = null;
            ActiveUser.Employee = null;
            Application.OpenForms[0].Show();*/
        }

        private async void openChildForm(ChildForm childForm)
        {
            if (activeForm != null && activeForm.UnsavedChangesDetected())
                return;
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            ActiveUser.OpenCartForm = false;

            if (typeof(MainForm) != childForm.GetType() && typeof(LoadingForm) != childForm.GetType())
            {
                LoadingForm loadingForm = new LoadingForm();
                loadingForm.Size = this.Size;
                loadingForm.Show();
                await Task.Delay(200);

                openChildFormHelperMethod(activeForm);

                await Task.Delay(1600);
                loadingForm.Close();
                return;
            }

            openChildFormHelperMethod(activeForm);
        }

        private void openChildFormHelperMethod(ChildForm childForm)
        {
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            foreignFormPanel.Controls.Add(childForm);
            foreignFormPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
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

        private void apartmentSectionButton_Click(object sender, EventArgs e)
        {
            if (ActiveUser.Parked)
            {
                openChildForm(new RoomForm());
                timer1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Πρέπει να σταθμεύσεις όλους τους Δούρειους Ίππους προτού μεταβείς στο μενού του Διαμερίσματος.");
            }
            /*openChildForm(new RoomForm());
            timer1.Enabled = false;*/
        }

        private void restaurantSectionButton_Click(object sender, EventArgs e)
        {
            if (ActiveUser.Parked)
            {
                openChildForm(new RestaurantForm());
                timer1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Πρέπει να σταθμεύσεις όλους τους Δούρειους Ίππους προτού μεταβείς στο μενού του Εστιατορίου.");
            }
            /*openChildForm(new RestaurantForm());
            timer1.Enabled = false;*/
        }

        private void poolSectionButton_Click(object sender, EventArgs e)
        {
            if (ActiveUser.Parked)
            {
                openChildForm(new PrivatePoolForm());
                timer1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Πρέπει να σταθμεύσεις όλους τους Δούρειους Ίππους προτού μεταβείς στο μενού της Πισίνας.");
            }
            /*openChildForm(new PrivatePoolForm());
            timer1.Enabled = false;*/
        }
        private void trojanHorseSectionButton_Click(object sender, EventArgs e)
        {
            openChildForm(new DrivingForm());
            ActiveUser.InGps = true;
            //openChildForm(new TrojanHorseForm());
            timer1.Enabled = true;
        }

        private void SidebarCustomerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //check if the user pressed the x button and they pressed the cancel button on the unsaved changes warning
            if (!closedFromLogOut && activeForm.UnsavedChangesDetected())
            {
                // If they pressed cancel then prevent the app from closing
                e.Cancel = true; 
                return;
            }
            //check if the user logged out
            if(!closedFromLogOut)
                //if not close the app
                Application.OpenForms[0].Close();

        }

        private void helpSectionButton_Click(object sender, EventArgs e)
        {
            if (activeForm.GetType() == typeof(PrivatePoolForm))
            {
                Help.ShowHelp(this, "../On-line_Help.chm", HelpNavigator.Topic, "mk:@MSITStore:D:\\ΠΑ.ΠΕΙ\\5οΕξάμηνο\\Αλληλεπίδραση_Ανθρώπου_Υπολογιστή\\Project4\\UIAssignment\\bin\\On-line_Help.chm::/html/hs30.htm");
            }
            else if (activeForm.GetType() == typeof(RoomForm))
            {
                Help.ShowHelp(this, "../On-line_Help.chm", HelpNavigator.Topic, "mk:@MSITStore:D:\\ΠΑ.ΠΕΙ\\5οΕξάμηνο\\Αλληλεπίδραση_Ανθρώπου_Υπολογιστή\\Project4\\UIAssignment\\bin\\On-line_Help.chm::/html/hs20.htm");
            }
            else if (activeForm.GetType() == typeof(RestaurantForm))
            {
                Help.ShowHelp(this, "../On-line_Help.chm", HelpNavigator.Topic, "mk:@MSITStore:D:\\ΠΑ.ΠΕΙ\\5οΕξάμηνο\\Αλληλεπίδραση_Ανθρώπου_Υπολογιστή\\Project4\\UIAssignment\\bin\\On-line_Help.chm::/html/hs50.htm");
            }
            else if ((activeForm.GetType() == typeof(DrivingForm)) || (activeForm.GetType() == typeof(TrojanHorseForm)))
            {
                Help.ShowHelp(this, "../On-line_Help.chm", HelpNavigator.Topic, "mk:@MSITStore:D:\\ΠΑ.ΠΕΙ\\5οΕξάμηνο\\Αλληλεπίδραση_Ανθρώπου_Υπολογιστή\\HelpScribble\\On-line_Help.chm::/html/hs40.htm");
            }
            else
            {
                Help.ShowHelp(this, "../On-line_Help.chm", HelpNavigator.Topic, "mk:@MSITStore:D:\\ΠΑ.ΠΕΙ\\5οΕξάμηνο\\Αλληλεπίδραση_Ανθρώπου_Υπολογιστή\\Project4\\UIAssignment\\bin\\On-line_Help.chm::/html/hs17.htm");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void checkStaticChangesTimer_Tick(object sender, EventArgs e)
        {
            if (ActiveUser.OpenCartForm)
                openChildForm(new CartForm());
            else if(ActiveUser.OpenOrderForm)
                openChildForm(new OrdersForm());
            //the line ActiveUser.SwapToInteractive = InteractiveModeEnum.None; is added to avoid a bug where multiple warning appear 
            //if the user does not click fast enough a choice on the warning
            else if (ActiveUser.SwapToInteractive == InteractiveModeEnum.InteractiveMode)
            {
                ActiveUser.SwapToInteractive = InteractiveModeEnum.None;
                openChildForm(new InteractiveRoomForm());
            }
            else if (ActiveUser.SwapToInteractive == InteractiveModeEnum.NonInteractiveMode)
            {
                ActiveUser.SwapToInteractive = InteractiveModeEnum.None;
                openChildForm(new RoomForm());
            }
            else if (ActiveUser.InGps == true && activeForm.GetType() == typeof(TrojanHorseForm))
            {
                openChildForm(new DrivingForm());
            }
            else if (ActiveUser.InGps == false && activeForm.GetType() == typeof(DrivingForm))
            {
                openChildForm(new TrojanHorseForm());
                MessageBox.Show("Επιτυχής στάθμευση Δουρείου Ίππου!");
            }
        }
    }
}

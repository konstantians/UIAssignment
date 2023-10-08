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
using UIAssignment.Resources;

namespace UIAssignment.Forms.EmployeeForms
{
    public partial class PoolSelectionForm : ChildForm
    {
        private int startingPoint = 0;
        public PoolSelectionForm()
        {
            InitializeComponent();
            setUpPoolSections();
        }

        public override bool UnsavedChangesDetected()
        {
            return false;
        }

        private void setUpPoolSections()
        {
            setUpPoolSectionsHelper(poolPanelOne, ActiveUser.Employee.Rooms[startingPoint].Pool);
            setUpPoolSectionsHelper(poolPanelTwo, ActiveUser.Employee.Rooms[startingPoint + 1].Pool);
            if (startingPoint + 2 > 7)
            {
                poolPanelThree.Visible = false;
                return;
            }
            else
            {
                poolPanelThree.Visible = true;
                setUpPoolSectionsHelper(poolPanelThree, ActiveUser.Employee.Rooms[startingPoint + 2].Pool);
            }
        }

        private void setUpPoolSectionsHelper(Panel panel, Pool pool)
        {
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("poolTitleLabel")).Text =
                $"Πισίνα {pool.PoolId}";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("poolWaterLevelValueLabel")).Text =
                $"{pool.WaterLevel * 10}%";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("poolTemperatureValueLabel")).Text =
                $"{pool.PoolTemperature}C";
            setWaterLevelPicture(panel.Controls.OfType<PictureBox>().FirstOrDefault(), pool.WaterLevel);
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("poolAlarmValueLabel")).Text = 
                pool.PoolAlert.IsPoolAlertOn ? "Ενεργός" : "Ανενεργός";
        }

        private void setWaterLevelPicture(PictureBox pictureBox, int waterLevelValue)
        {
            switch (waterLevelValue)
            {
                case 0:
                    pictureBox.BackgroundImage = Properties.Resources.Pool0Percent;
                    break;
                case 1:
                    pictureBox.BackgroundImage = Properties.Resources.Pool10Percent;
                    break;
                case 2:
                    pictureBox.BackgroundImage = Properties.Resources.Pool20Percent;
                    break;
                case 3:
                    pictureBox.BackgroundImage = Properties.Resources.Pool30Percent;
                    break;
                case 4:
                    pictureBox.BackgroundImage = Properties.Resources.Pool40Percent;
                    break;
                case 5:
                    pictureBox.BackgroundImage = Properties.Resources.Pool50Percent;
                    break;
                case 6:
                    pictureBox.BackgroundImage = Properties.Resources.Pool60Percent;
                    break;
                case 7:
                    pictureBox.BackgroundImage = Properties.Resources.Pool70Percent;
                    break;
                case 8:
                    pictureBox.BackgroundImage = Properties.Resources.Pool80Percent;
                    break;
                case 9:
                    pictureBox.BackgroundImage = Properties.Resources.Pool90Percent;
                    break;
                case 10:
                    pictureBox.BackgroundImage = Properties.Resources.Pool100Percent;
                    break;
            }
        }

        private void previousSectionButton_Click(object sender, EventArgs e)
        {
            nextSectionButton.Enabled = true;
            startingPoint -= 3;
            if(startingPoint == 0)
                previousSectionButton.Enabled = false;
            setUpPoolSections();
            sectionButtonCount.Text = (startingPoint/3 + 1).ToString();
        }

        private void nextSectionButton_Click(object sender, EventArgs e)
        {
            previousSectionButton.Enabled = true;
            startingPoint += 3;
            if (startingPoint == 6)
                nextSectionButton.Enabled = false;
            setUpPoolSections();
            sectionButtonCount.Text = (startingPoint/3 + 1).ToString();
        }

        private void moreInformationButtonOne_Click(object sender, EventArgs e)
        {
            ActiveUser.ChosenPool = ActiveUser.Employee.Rooms[startingPoint].Pool;
        }

        private void moreInformationButtonTwo_Click(object sender, EventArgs e)
        {
            ActiveUser.ChosenPool = ActiveUser.Employee.Rooms[startingPoint + 1].Pool;
        }

        private void moreInformationButtonThree_Click(object sender, EventArgs e)
        {
            ActiveUser.ChosenPool = ActiveUser.Employee.Rooms[startingPoint + 2].Pool;
        }

        private void coolButton_MouseEnter(object sender, EventArgs e)
        {
            Cool_button coolButton = (Cool_button)sender;
            coolButton.BackgroundImage = Properties.Resources.BlackMarbleBackground;
            coolButton.TextColor = Color.White;
        }

        private void coolButton_MouseLeave(object sender, EventArgs e)
        {
            Cool_button coolButton = (Cool_button)sender;
            coolButton.BackgroundImage = null;
            coolButton.TextColor = Color.Black;
        }
    }
}

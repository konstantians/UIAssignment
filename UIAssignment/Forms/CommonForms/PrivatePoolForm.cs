using DataAccess.Logic;
using DataAccess.Models;
using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;

namespace UIAssignment.Forms.CommonForms
{
    public partial class PrivatePoolForm : ChildForm
    {
        private double poolTemperature = 0.0;
        private bool reverseTimer = false;
        public PrivatePoolForm()
        {
            InitializeComponent();

            //set the pool value of the slider
            translationHelper();
            poolTemperature = ActiveUser.Customer.Room.Pool.PoolTemperature;

            //set the water level value of the slider
            poolWaterLevelTrackBar.Value = ActiveUser.Customer.Room.Pool.WaterLevel;
            checkWaterLevel();

            fromAlertCustomDateTimePicker.Format = DateTimePickerFormat.Custom;
            fromAlertCustomDateTimePicker.CustomFormat = "HH:mm";
            fromAlertCustomDateTimePicker.ShowUpDown = true;

            untilAlertCustomDateTimePicker.Format = DateTimePickerFormat.Custom;
            untilAlertCustomDateTimePicker.CustomFormat = "HH:mm";
            untilAlertCustomDateTimePicker.ShowUpDown = true;

            //set the alarm
            if (ActiveUser.Customer != null)
            {
                fromAlertCustomDateTimePicker.Value = ActiveUser.Customer.Room.Pool.PoolAlert.From;
                untilAlertCustomDateTimePicker.Value = ActiveUser.Customer.Room.Pool.PoolAlert.Until;
                if (ActiveUser.Customer.Room.Pool.PoolAlert.SoundTrack == "Simple")
                    alarmSoundTrackCustomComboBox.SelectedIndex = 0;
                else if (ActiveUser.Customer.Room.Pool.PoolAlert.SoundTrack == "Simple2")
                    alarmSoundTrackCustomComboBox.SelectedIndex = 1;
                else
                    alarmSoundTrackCustomComboBox.SelectedIndex = 2;
                activateDeactivateToggleButton.Checked = ActiveUser.Customer.Room.Pool.PoolAlert.IsPoolAlertOn ? true : false;
            }
        }

        private void poolWaterLevelTrackBar_Scroll(object sender, EventArgs e)
        {
            checkWaterLevel();
        }

        private void poolTemperatureTrackBar_Scroll(object sender, EventArgs e)
        {
            double oldPoolValue = poolTemperature;
            translationHelper(true);
            if (oldPoolValue > poolTemperature)
            {
                hiddenTemperaturePictureBox.BackgroundImage = Properties.Resources.TemperatureDecreaseImage;
                hiddenTemperaturePictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                hiddenTemperaturePictureBox.BackgroundImage = Properties.Resources.TemperatureIncreaseImage;
                hiddenTemperaturePictureBox.BackgroundImageLayout = ImageLayout.Stretch;
            }
            hiddenTemperatureTimer.Enabled = true;
        }

        private void checkWaterLevel()
        {
            switch (poolWaterLevelTrackBar.Value)
            {
                case 0:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool0Percent;
                    poolWaterLevelTitleValueLabel.Text = "0%";
                    break;
                case 1:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool10Percent;
                    poolWaterLevelTitleValueLabel.Text = "10%";
                    break;
                case 2:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool20Percent;
                    poolWaterLevelTitleValueLabel.Text = "20%";
                    break;
                case 3:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool30Percent;
                    poolWaterLevelTitleValueLabel.Text = "30%";
                    break;
                case 4:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool40Percent;
                    poolWaterLevelTitleValueLabel.Text = "40%";
                    break;
                case 5:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool50Percent;
                    poolWaterLevelTitleValueLabel.Text = "50%";
                    break;
                case 6:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool60Percent;
                    poolWaterLevelTitleValueLabel.Text = "60%";
                    break;
                case 7:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool70Percent;
                    poolWaterLevelTitleValueLabel.Text = "70%";
                    break;
                case 8:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool80Percent;
                    poolWaterLevelTitleValueLabel.Text = "80%";
                    break;
                case 9:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool90Percent;
                    poolWaterLevelTitleValueLabel.Text = "90%";
                    break;
                case 10:
                    privatePoolPictureBox.BackgroundImage = Properties.Resources.Pool100Percent;
                    poolWaterLevelTitleValueLabel.Text = "100%";
                    break;
            }
        }

        private void translationHelper(bool reverse = false)
        {
            if (!reverse)
            {
                switch (ActiveUser.Customer.Room.Pool.PoolTemperature)
                {
                    case 27.0:
                        poolTemperatureTrackBar.Value = 0;
                        break;
                    case 27.5:
                        poolTemperatureTrackBar.Value = 1;
                        break;
                    case 28.0:
                        poolTemperatureTrackBar.Value = 2;
                        break;
                    case 28.5:
                        poolTemperatureTrackBar.Value = 3;
                        break;
                    case 29.0:
                        poolTemperatureTrackBar.Value = 4;
                        break;
                    case 29.5:
                        poolTemperatureTrackBar.Value = 5;
                        break;
                    case 30:
                        poolTemperatureTrackBar.Value = 6;
                        break;
                    case 30.5:
                        poolTemperatureTrackBar.Value = 7;
                        break;
                    case 31:
                        poolTemperatureTrackBar.Value = 8;
                        break;
                    case 31.5:
                        poolTemperatureTrackBar.Value = 9;
                        break;
                    case 32:
                        poolTemperatureTrackBar.Value = 10;
                        break;
                }
            }
            else
            {
                switch (poolTemperatureTrackBar.Value)
                {
                    case 0:
                        poolTemperature = 27;
                        poolTemperatureTitleValueLabel.Text = "27C";
                        break;
                    case 1:
                        poolTemperature = 27.5;
                        poolTemperatureTitleValueLabel.Text = "27.5C";
                        break;
                    case 2:
                        poolTemperature = 28;
                        poolTemperatureTitleValueLabel.Text = "28C";
                        break;
                    case 3:
                        poolTemperature = 28.5;
                        poolTemperatureTitleValueLabel.Text = "28.5C";
                        break;
                    case 4:
                        poolTemperature = 29;
                        poolTemperatureTitleValueLabel.Text = "29C";
                        break;
                    case 5:
                        poolTemperature = 29.5;
                        poolTemperatureTitleValueLabel.Text = "29.5C";
                        break;
                    case 6:
                        poolTemperature = 30;
                        poolTemperatureTitleValueLabel.Text = "30C";
                        break;
                    case 7:
                        poolTemperature = 30.5;
                        poolTemperatureTitleValueLabel.Text = "30.5C";
                        break;
                    case 8:
                        poolTemperature = 31;
                        poolTemperatureTitleValueLabel.Text = "31C";
                        break;
                    case 9:
                        poolTemperature = 31.5;
                        poolTemperatureTitleValueLabel.Text = "31.5C";
                        break;
                    case 10:
                        poolTemperature = 32;
                        poolTemperatureTitleValueLabel.Text = "32C";
                        break;
                }
            }

        }

        private void hiddenTemperatureTimer_Tick(object sender, EventArgs e)
        {
            hiddenTemperaturePictureBox.BringToFront();

            //do this until the image is fully visible
            if (!reverseTimer)
                hiddenTemperaturePictureBox.Opacity -= 0.1;
            //do this after it becomes fully visible, until it becomes invisible again
            else
                hiddenTemperaturePictureBox.Opacity += 0.1;

            //reverse timer if the hidden pictureBox is fully visible
            if (hiddenTemperaturePictureBox.Opacity >= 0 && hiddenTemperaturePictureBox.Opacity < 0.1)
            {
                reverseTimer = true;
            }

            //if it reached the invisible state again stop the timer
            if (hiddenTemperaturePictureBox.Opacity > 0.9 && hiddenTemperaturePictureBox.Opacity <= 1)
            {
                reverseTimer = false;
                hiddenTemperatureTimer.Enabled = false;
                hiddenTemperaturePictureBox.SendToBack();
            }
        }
        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            Pool pool = new Pool();
            pool.PoolTemperature = poolTemperature;
            pool.WaterLevel = poolWaterLevelTrackBar.Value;
            PoolAlert poolAlert = new PoolAlert();
            poolAlert.From = fromAlertCustomDateTimePicker.Value;
            poolAlert.Until = untilAlertCustomDateTimePicker.Value;
            if ((string)alarmSoundTrackCustomComboBox.SelectedItem == "Απλός")
                poolAlert.SoundTrack = "Simple";
            else if ((string)alarmSoundTrackCustomComboBox.SelectedItem == "Απλός 2")
                poolAlert.SoundTrack = "Simple2";
            else
                poolAlert.SoundTrack = "Scify";
            poolAlert.IsPoolAlertOn = activateDeactivateToggleButton.Checked ? true : false;


            if (ActiveUser.Customer != null) {
                poolAlert.PoolAlertId = ActiveUser.Customer.Room.Pool.PoolAlert.PoolAlertId;
                //update pool alert and pool
                PoolDataAccess.UpdatePoolAlert(poolAlert);
                PoolDataAccess.UpdatePool(ActiveUser.Customer.Room.Pool.PoolId, pool);

                //update the active user
                ActiveUser.Customer.Room.Pool = pool;
                ActiveUser.Customer.Room.Pool.PoolAlert = poolAlert;
            }

            MessageBox.Show("Changes have been successfully saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        public override bool UnsavedChangesDetected()
        {
            //logic for customer
            if(ActiveUser.Customer != null)
            {
                bool isAlarmActiveSameState = false;
                if (ActiveUser.Customer.Room.Pool.PoolAlert.IsPoolAlertOn && activateDeactivateToggleButton.Checked)
                    isAlarmActiveSameState = true;
                else if (!ActiveUser.Customer.Room.Pool.PoolAlert.IsPoolAlertOn && !activateDeactivateToggleButton.Checked)
                    isAlarmActiveSameState = true;

                string soundTrack;
                if (ActiveUser.Customer.Room.Pool.PoolAlert.SoundTrack == "Simple")
                    soundTrack = "Απλός";
                else if (ActiveUser.Customer.Room.Pool.PoolAlert.SoundTrack == "Simple2")
                    soundTrack = "Απλός 2";
                else
                    soundTrack = "Scify";

                if (poolTemperature != ActiveUser.Customer.Room.Pool.PoolTemperature || (poolWaterLevelTrackBar.Value) != ActiveUser.Customer.Room.Pool.WaterLevel ||
                    (fromAlertCustomDateTimePicker.Value.Hour != ActiveUser.Customer.Room.Pool.PoolAlert.From.Hour || fromAlertCustomDateTimePicker.Value.Minute != ActiveUser.Customer.Room.Pool.PoolAlert.From.Minute) ||
                    (untilAlertCustomDateTimePicker.Value.Hour != ActiveUser.Customer.Room.Pool.PoolAlert.Until.Hour || untilAlertCustomDateTimePicker.Value.Minute != ActiveUser.Customer.Room.Pool.PoolAlert.Until.Minute) ||
                    (string)alarmSoundTrackCustomComboBox.SelectedItem != soundTrack || !isAlarmActiveSameState
                    )
                {
                    DialogResult result = MessageBox.Show("There are unsaved changes. Are you sure you want to leave?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.Cancel)
                    {
                        return true; // Unsaved changes detected
                    }
                }
                return false; // No unsaved changes
            }

            //TODO here do the logic for the employee
            return false;
        }

        private void activateDeactivateToggleButton_CheckedChanged(object sender, EventArgs e)
        {
            if (activateDeactivateToggleButton.Checked)
            {
                poolAlarmTitleValueLabel.Text = "Ενεργός";
                return;
            }
            poolAlarmTitleValueLabel.Text = "Ανενεργός";

        }

        private void alarmSoundTrackCustomComboBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void soundtrackCheckButton_Click(object sender, EventArgs e)
        {
            string selectedItem = (string)alarmSoundTrackCustomComboBox.SelectedItem;
            Stream stream;
            if (selectedItem == "Απλός")
            {
                stream = Properties.Resources.basicAlarm;
            }
            else if (selectedItem == "Απλός 2")
            {
                stream = Properties.Resources.criticalAlarm;
            }
            else
            {
                stream = Properties.Resources.scifyAlarm;
            }
            SoundPlayer player = new SoundPlayer(stream);
            player.Play();
        }

        private void saveChangesButton_MouseEnter(object sender, EventArgs e)
        {
            saveChangesButton.BackgroundImage = Properties.Resources.BlackMarbleBackground;
            saveChangesButton.TextColor = Color.White;
        }

        private void saveChangesButton_MouseLeave(object sender, EventArgs e)
        {
            saveChangesButton.BackgroundImage = null;
            saveChangesButton.TextColor = Color.Black;
        }
    }
}

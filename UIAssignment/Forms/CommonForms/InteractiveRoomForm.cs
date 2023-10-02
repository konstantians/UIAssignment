using DataAccess.Logic;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UIAssignment.Forms.CommonForms
{
    public partial class InteractiveRoomForm : ChildForm
    {
        public int roomTemperature = 0;
        public Television television = new Television();
        public Radio radio = new Radio();
        public bool reverseRadioTimer = false;
        public SoundPlayer soundPlayer = new SoundPlayer();
        public InteractiveRoomForm()
        {
            InitializeComponent();
            hiddenRadioSoundImage.SendToBack();

            if (ActiveUser.Customer != null)
            {
                //set radio for warning checking and the general labels and television combobox and the tv toggle box
                radioSongsComboBox.SelectedItem = ActiveUser.Customer.Room.Radio.RadioSong;
                radio.IsRadioOn = ActiveUser.Customer.Room.Radio.IsRadioOn;
                radio.RadioVolume = ActiveUser.Customer.Room.Radio.RadioVolume;
                radio.RadioSong = ActiveUser.Customer.Room.Radio.RadioSong;
                radio.RadioId = ActiveUser.Customer.Room.Radio.RadioId;

                string radioStateValue = radio.IsRadioOn ? "Ανοιχτό" : "Κλειστό";
                roomRadioStateTitleValueLabel.Text = radioStateValue;
                roomRadioSoundLevelTitleValueLabel.Text = $"{radio.RadioVolume * 20}%";
                roomRadioSongTitleValueLabel.Text = radio.RadioSong;
                activateDeactivateRadioToggleButton.Checked = radio.IsRadioOn;
                radioSoundTrackBar.Value = radio.RadioVolume;
                SetVolume(radio.RadioVolume * 20);

                //set television for warning checking and the general labels and television combobox and the radio toggle box
                tvProgramsComboBox.SelectedItem = ActiveUser.Customer.Room.Television.TelevisionProgram;
                television.IsTelevisionOn = ActiveUser.Customer.Room.Television.IsTelevisionOn;
                television.TelevisionVolume = ActiveUser.Customer.Room.Television.TelevisionVolume;
                television.TelevisionProgram = ActiveUser.Customer.Room.Television.TelevisionProgram;
                television.TelevisionId = ActiveUser.Customer.Room.Television.TelevisionId;

                string televisionStateValue = television.IsTelevisionOn ? "Ανοιχτή" : "Κλειστή";
                roomTelevisionStateTitleValueLabel.Text = televisionStateValue;
                roomTelevisionSoundLevelTitleValueLabel.Text = $"{television.TelevisionVolume * 20}%";
                roomTelevisionProgramTitleValueLabel.Text = television.TelevisionProgram;
                activateDeactivateTVToggleButton.Checked = television.IsTelevisionOn;
                tvSoundTrackBar.Value = television.TelevisionVolume;

                //set the lighting value of the slider and the title labels
                roomLightingTrackBar.Value = ActiveUser.Customer.Room.RoomLighting;
                roomLightingTitleValueLabel.Text = $"{roomLightingTrackBar.Value * 20}%";
                setRoomLighting();

                //set the temperature value of the slider and the title labels
                roomTemperature = ActiveUser.Customer.Room.RoomTemperature;
                roomTemperatureTitleValueLabel.Text = $"{roomTemperature}C";
                translateRoomTemperature();
            }

            //playRadioSoundOrCloseIt();
        }

        public void setRoomLighting()
        {
            switch (roomLightingTrackBar.Value)
            {
                case 0:
                    roomLightingTitleValueLabel.Text = "0%";
                    roomPictureBox.Opacity = 1;
                    break;
                case 1:
                    roomLightingTitleValueLabel.Text = "20%";
                    roomPictureBox.Opacity = 0.8;
                    break;
                case 2:
                    roomLightingTitleValueLabel.Text = "40%";
                    roomPictureBox.Opacity = 0.6;
                    break;
                case 3:
                    roomLightingTitleValueLabel.Text = "60%";
                    roomPictureBox.Opacity = 0.4;
                    break;
                case 4:
                    roomLightingTitleValueLabel.Text = "80%";
                    roomPictureBox.Opacity = 0.2;
                    break;
                case 5:
                    roomLightingTitleValueLabel.Text = "100%";
                    roomPictureBox.Opacity = 0;
                    break;
            }
        }

        public void translateRoomTemperature(bool reverse = false)
        {
            if (!reverse)
            {
                switch (ActiveUser.Customer.Room.RoomTemperature)
                {
                    case 27:
                        roomTemperatureTrackBar.Value = 0;
                        roomTemperatureTitleValueLabel.Text = "27C";
                        setTelevisionOnImageOnAircoditionSet();
                        break;
                    case 28:
                        roomTemperatureTrackBar.Value = 1;
                        roomTemperatureTitleValueLabel.Text = "28C";
                        setTelevisionOnImageOnAircoditionSet();
                        break;
                    case 29:
                        roomTemperatureTrackBar.Value = 2;
                        roomTemperatureTitleValueLabel.Text = "29C";
                        setTelevisionOnImageOnAircoditionSet();
                        break;
                    case 30:
                        roomTemperatureTrackBar.Value = 3;
                        roomTemperatureTitleValueLabel.Text = "30C";
                        setTelevisionOnImageOnAircoditionSet();
                        break;
                    case 31:
                        roomTemperatureTrackBar.Value = 4;
                        roomTemperatureTitleValueLabel.Text = "31C";
                        setTelevisionOnImageOnAircoditionSet();
                        break;
                    case 32:
                        roomTemperatureTrackBar.Value = 5;
                        roomTemperatureTitleValueLabel.Text = "32C";
                        setTelevisionOnImageOnAircoditionSet();
                        break;
                }
                return;
            }
            switch (roomTemperatureTrackBar.Value)
            {
                case 0:
                    roomTemperature = 27;
                    roomTemperatureTitleValueLabel.Text = "27C";
                    setTelevisionOnImageOnAircoditionSet();
                    break;
                case 1:
                    roomTemperature = 28;
                    roomTemperatureTitleValueLabel.Text = "28C";
                    setTelevisionOnImageOnAircoditionSet();
                    break;
                case 2:
                    roomTemperature = 29;
                    roomTemperatureTitleValueLabel.Text = "29C";
                    setTelevisionOnImageOnAircoditionSet();
                    break;
                case 3:
                    roomTemperature = 30;
                    roomTemperatureTitleValueLabel.Text = "30C";
                    setTelevisionOnImageOnAircoditionSet();
                    break;
                case 4:
                    roomTemperature = 31;
                    roomTemperatureTitleValueLabel.Text = "31C";
                    setTelevisionOnImageOnAircoditionSet();
                    break;
                case 5:
                    roomTemperature = 32;
                    roomTemperatureTitleValueLabel.Text = "32C";
                    setTelevisionOnImageOnAircoditionSet();
                    break;
            }
            return;
        }

        public void setTelevisionOnImageOnAircoditionSet()
        {
            if (roomTemperature == 30 && !television.IsTelevisionOn)
                roomPictureBox.BackgroundImage = Properties.Resources.ApartmentImageDefault;
            else if (roomTemperature == 30 && television.IsTelevisionOn && television.TelevisionProgram == "Κανονικό")
                roomPictureBox.BackgroundImage = Properties.Resources.ApartmentImageTVOn;
            else if (roomTemperature == 30 && television.IsTelevisionOn && television.TelevisionProgram == "Netflix")
                roomPictureBox.BackgroundImage = Properties.Resources.ApartmentImageTVOnNetflix;
            //this happens if the aircodition is not 30
            else if (!television.IsTelevisionOn)
                roomPictureBox.BackgroundImage = Properties.Resources.ApartmentImageAirCoditionOn;
            else if (television.IsTelevisionOn && television.TelevisionProgram == "Κανονικό")
                roomPictureBox.BackgroundImage = Properties.Resources.ApartmentImageAirCoditionOnAndTVOn;
            else if (television.IsTelevisionOn && television.TelevisionProgram == "Netflix")
                roomPictureBox.BackgroundImage = Properties.Resources.ApartmentImageAirCoditionOnAndTVOnNetflix;
        }

        public override bool UnsavedChangesDetected()
        {
            //logic for customer
            if (ActiveUser.Customer != null)
            {
                if (roomLightingTrackBar.Value != ActiveUser.Customer.Room.RoomLighting || roomTemperature != ActiveUser.Customer.Room.RoomTemperature ||
                    !EqualityComparer<Radio>.Default.Equals(ActiveUser.Customer.Room.Radio, radio) ||
                    !EqualityComparer<Television>.Default.Equals(ActiveUser.Customer.Room.Television, television)
                    )
                {
                    DialogResult result = MessageBox.Show("Οι αλλαγές σας είναι προσωρινές και θα σβηστούν σε περίπτωση κλήσης της φόρμας.\n" +
                        "Θέλετε να αποθηκευτούν πριν κλείσει ή φόρμα?",
                        "Μη Αποθηκευμένες Αλλαγές", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (result == DialogResult.Cancel)
                    {
                        return true; // Unsaved changes detected
                    }

                    if (result == DialogResult.Yes)
                    {
                        saveChanges();
                    }
                }
                soundPlayer.Stop();
                return false; // No unsaved changes or the user chose the no or the yes option
            }

            //TODO here do the logic for the employee
            return false;
        }

        private void roomLightingTrackBar_Scroll(object sender, EventArgs e)
        {
            setRoomLighting();
        }

        private void roomTemperatureTrackBar_Scroll(object sender, EventArgs e)
        {
            translateRoomTemperature(true);
        }


        private void tvSoundTrackBar_Scroll(object sender, EventArgs e)
        {
            television.TelevisionVolume = tvSoundTrackBar.Value;
            SetThingsAfterTelevisionChanges();
        }

        private void activateDeactivateTVToggleButton_CheckedChanged(object sender, EventArgs e)
        {
            television.IsTelevisionOn = activateDeactivateTVToggleButton.Checked ? true : false;
            SetThingsAfterTelevisionChanges();
        }

        private void tvProgramsComboBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            television.TelevisionProgram = (string)tvProgramsComboBox.SelectedItem;
            SetThingsAfterTelevisionChanges();
        }

        private void SetThingsAfterTelevisionChanges()
        {
            if (!television.IsTelevisionOn && roomTemperature == 30)
            {
                roomPictureBox.BackgroundImage = Properties.Resources.ApartmentImageDefault;
            }
            else if (!television.IsTelevisionOn)
            {
                roomPictureBox.BackgroundImage = Properties.Resources.ApartmentImageAirCoditionOn;
            }
            else if (television.IsTelevisionOn && television.TelevisionProgram == "Κανονικό" && roomTemperature == 30)
            {
                roomPictureBox.BackgroundImage = Properties.Resources.ApartmentImageTVOn;
            }
            else if (television.IsTelevisionOn && television.TelevisionProgram == "Netflix" && roomTemperature == 30)
            {
                roomPictureBox.BackgroundImage = Properties.Resources.ApartmentImageTVOnNetflix;
            }
            else if (television.IsTelevisionOn && television.TelevisionProgram == "Κανονικό")
            {
                roomPictureBox.BackgroundImage = Properties.Resources.ApartmentImageAirCoditionOnAndTVOn;
            }
            else if (television.IsTelevisionOn && television.TelevisionProgram == "Netflix")
            {
                roomPictureBox.BackgroundImage = Properties.Resources.ApartmentImageAirCoditionOnAndTVOnNetflix;
            }

            string televisionStateValue = television.IsTelevisionOn ? "Ανοιχτή" : "Κλειστή";
            roomTelevisionStateTitleValueLabel.Text = televisionStateValue;
            roomTelevisionSoundLevelTitleValueLabel.Text = $"{television.TelevisionVolume * 20}%";
            roomTelevisionProgramTitleValueLabel.Text = television.TelevisionProgram;
            tvSoundTrackBar.Value = television.TelevisionVolume;
        }

        private void activateDeactivateRadioToggleButton_CheckedChanged(object sender, EventArgs e)
        {
            radio.IsRadioOn = activateDeactivateRadioToggleButton.Checked ? true : false;
            string radioState = radio.IsRadioOn ? "Ανοιχτό" : "Κλειστό";
            roomRadioStateTitleValueLabel.Text = radioState;
            if (radio.IsRadioOn)
                hiddenRadioSoundImage.BackgroundImage = Properties.Resources.radioOn;
            else
                hiddenRadioSoundImage.BackgroundImage = Properties.Resources.radioOff;
            hiddenRadioTimer.Enabled = true;

            playRadioSoundOrCloseIt();
        }

        private void playRadioSoundOrCloseIt()
        {

            if (radio.IsRadioOn)
            {
                string selectedItem = (string)radioSongsComboBox.SelectedItem;
                Stream stream;
                if (selectedItem == "Μήλο Μου Κόκκινο")
                {
                    stream = Properties.Resources.MiloMouKokkino;
                }
                else if (selectedItem == "Ιτιά")
                {
                    stream = Properties.Resources.Itia;
                }
                else
                {
                    stream = Properties.Resources.EnasAetos;
                }

                soundPlayer.Stop();
                soundPlayer.Stream = stream;
                soundPlayer.Play();
            }
            else
            {
                soundPlayer.Stop();
            }
        }

        private void radioSoundTrackBar_Scroll(object sender, EventArgs e)
        {
            setRadioSound();
        }

        private void radioSongsComboBox_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            radio.RadioSong = (string)radioSongsComboBox.SelectedItem;
            roomRadioSongTitleValueLabel.Text = radio.RadioSong;
            playRadioSoundOrCloseIt();
        }

        private void hiddenRadioTimer_Tick(object sender, EventArgs e)
        {
            //edge case
            if (roomLightingTrackBar.Value == 0)
            {
                hiddenRadioTimer.Enabled = false;
                return;
            }

            hiddenRadioSoundImage.BringToFront();

            //do this until the image is fully visible
            if (!reverseRadioTimer)
                hiddenRadioSoundImage.Opacity -= 0.1;
            //do this after it becomes fully visible, until it becomes invisible again
            else
                hiddenRadioSoundImage.Opacity += 0.1;

            //reverse timer if the hidden pictureBox is fully visible
            if (hiddenRadioSoundImage.Opacity >= 0 && hiddenRadioSoundImage.Opacity < 0.1)
            {
                reverseRadioTimer = true;
            }

            //if it reached the invisible state again stop the timer
            if (hiddenRadioSoundImage.Opacity > 0.9 && hiddenRadioSoundImage.Opacity <= 1)
            {
                reverseRadioTimer = false;
                hiddenRadioTimer.Enabled = false;
                hiddenRadioSoundImage.SendToBack();
            }
        }

        public void setRadioSound()
        {
            switch (radioSoundTrackBar.Value)
            {
                case 0:
                    SetVolume(0);
                    radio.RadioVolume = 0;
                    roomRadioSoundLevelTitleValueLabel.Text = "0%";
                    break;
                case 1:
                    SetVolume(20);
                    radio.RadioVolume = 1;
                    roomRadioSoundLevelTitleValueLabel.Text = "20%";
                    break;
                case 2:
                    SetVolume(40);
                    radio.RadioVolume = 2;
                    roomRadioSoundLevelTitleValueLabel.Text = "40%";
                    break;
                case 3:
                    SetVolume(60);
                    radio.RadioVolume = 3;
                    roomRadioSoundLevelTitleValueLabel.Text = "60%";
                    break;
                case 4:
                    SetVolume(80);
                    radio.RadioVolume = 4;
                    roomRadioSoundLevelTitleValueLabel.Text = "80%";
                    break;
                case 5:
                    SetVolume(100);
                    radio.RadioVolume = 5;
                    roomRadioSoundLevelTitleValueLabel.Text = "100%";
                    break;
            }
        }

        private void saveChanges()
        {
            //update the radio and the tv
            RoomDataAccess.UpdateRadio(radio.RadioId, radio);
            RoomDataAccess.UpdateTelevision(television.TelevisionId, television);

            //then update the room
            Room room = new Room();
            room.RoomLighting = roomLightingTrackBar.Value;
            room.RoomTemperature = roomTemperature;
            //TODO fix the following line for the employee
            room.RoomId = ActiveUser.Customer != null ? ActiveUser.Customer.Room.RoomId : 0;
            RoomDataAccess.UpdateRoom(room);

            //if the user is a customer
            if (ActiveUser.Customer != null)
            {
                //update the active user
                ActiveUser.Customer.Room.Radio = radio;
                ActiveUser.Customer.Room.Television = television;
                ActiveUser.Customer.Room.RoomLighting = roomLightingTrackBar.Value;
                ActiveUser.Customer.Room.RoomTemperature = roomTemperature;

            }
            //TODO do this for the employee too
        }

        // magic to change the volume of the sound player
        // the below code is copy pasted and I have no idea how it works
        [DllImport("winmm.dll")]
        public static extern int waveOutSetVolume(IntPtr hwo, uint dwVolume);

        // Helper method to adjust the volume (0-100)
        public static void SetVolume(int volume)
        {
            const int MaxVolume = 65535; // Max volume value
            int newVolume = (int)(((double)volume / 100) * MaxVolume);

            waveOutSetVolume(IntPtr.Zero, (uint)newVolume);
        }

        private void nonInteractiveModeButton_Click(object sender, EventArgs e)
        {
            ActiveUser.SwapToInteractive = InteractiveModeEnum.NonInteractiveMode;
        }

        private void lightingHoverTransparentPictureBoxOne_Click(object sender, EventArgs e)
        {
            if (roomLightingHiddenPanel.Visible == false)
                roomLightingHiddenPanel.Visible = true;
            else
                roomLightingHiddenPanel.Visible = false;
        }

        private void lightingHoverTransparentPictureBoxTwo_Click(object sender, EventArgs e)
        {
            if (roomLightingHiddenPanelTwo.Visible == false)
                roomLightingHiddenPanelTwo.Visible = true;
            else
                roomLightingHiddenPanelTwo.Visible = false;
        }

        private void aircoditionHoverTransparentPictureBox_Click(object sender, EventArgs e)
        {
            if (roomtemperatureHiddenPanel.Visible == false)
                roomtemperatureHiddenPanel.Visible = true;
            else
                roomtemperatureHiddenPanel.Visible = false;
        }

        private void televisionHoverTransparentPictureBox_Click(object sender, EventArgs e)
        {
            if (televisionControlsHiddenPanel.Visible == false)
                televisionControlsHiddenPanel.Visible = true;
            else
                televisionControlsHiddenPanel.Visible = false;
        }

        private void radioHoverTransparentPictureBox_Click(object sender, EventArgs e)
        {
            if (radioControlsHiddenPanel.Visible == false)
                radioControlsHiddenPanel.Visible = true;
            else
                radioControlsHiddenPanel.Visible = false;
        }

        private void hiddenRoomLightingXButton_Click(object sender, EventArgs e)
        {
            roomLightingHiddenPanel.Visible = false;
        }

        private void hiddenRoomTemperatureXButton_Click(object sender, EventArgs e)
        {
            roomtemperatureHiddenPanel.Visible = false;
        }

        private void hiddenRoomTelevisionControlsXButton_Click(object sender, EventArgs e)
        {
            televisionControlsHiddenPanel.Visible = false;
        }

        private void hiddenRoomLightingXButtonTwo_Click(object sender, EventArgs e)
        {
            roomLightingHiddenPanelTwo.Visible = false;
        }

        private void hiddenRoomRadioControlsXButton_Click(object sender, EventArgs e)
        {
            radioControlsHiddenPanel.Visible = false;
        }

        private void InteractiveRoomForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}

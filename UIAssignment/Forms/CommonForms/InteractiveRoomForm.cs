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
        private int roomTemperature = 0;
        private Television television = new Television();
        private Radio radio = new Radio();
        private bool reverseRadioTimer = false;
        private SoundPlayer soundPlayer = new SoundPlayer();
        private Room Room = ActiveUser.ChosenRoom;
        private bool doNotDoUnsavedChanges = false;
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

                //set television for warning checking and the general labels and television combobox and the radio toggle box
                tvProgramsComboBox.SelectedItem = ActiveUser.Customer.Room.Television.TelevisionProgram;
                television.IsTelevisionOn = ActiveUser.Customer.Room.Television.IsTelevisionOn;
                television.TelevisionVolume = ActiveUser.Customer.Room.Television.TelevisionVolume;
                television.TelevisionProgram = ActiveUser.Customer.Room.Television.TelevisionProgram;
                television.TelevisionId = ActiveUser.Customer.Room.Television.TelevisionId;

                //set the lighting value of the slider and the title labels
                roomLightingTrackBar.Value = ActiveUser.Customer.Room.RoomLighting;

                //set the temperature value of the slider and the title labels
                roomTemperature = ActiveUser.Customer.Room.RoomTemperature;
            }
            else
            {
                //set the information label Id
                roomInformationLabel.Text = $"Πληροφορίες Δωματίου {Room.RoomId}";

                //set radio for warning checking and the general labels and television combobox and the tv toggle box
                radioSongsComboBox.SelectedItem = Room.Radio.RadioSong;
                radio.IsRadioOn = Room.Radio.IsRadioOn;
                radio.RadioVolume = Room.Radio.RadioVolume;
                radio.RadioSong = Room.Radio.RadioSong;
                radio.RadioId = Room.Radio.RadioId;

                //set television for warning checking and the general labels and television combobox and the radio toggle box
                tvProgramsComboBox.SelectedItem = Room.Television.TelevisionProgram;
                television.IsTelevisionOn = Room.Television.IsTelevisionOn;
                television.TelevisionVolume = Room.Television.TelevisionVolume;
                television.TelevisionProgram = Room.Television.TelevisionProgram;
                television.TelevisionId = Room.Television.TelevisionId;

                //set the lighting value of the slider and the title labels
                roomLightingTrackBar.Value = Room.RoomLighting;

                //set the temperature value of the slider and the title labels
                roomTemperature = Room.RoomTemperature;
            }

            roomLightingTitleValueLabel.Text = $"{roomLightingTrackBar.Value * 20}%";
            setRoomLighting();

            roomTemperatureTitleValueLabel.Text = $"{roomTemperature}C";
            translateRoomTemperature();

            string televisionStateValue = television.IsTelevisionOn ? "Ανοιχτή" : "Κλειστή";
            roomTelevisionStateTitleValueLabel.Text = televisionStateValue;
            roomTelevisionSoundLevelTitleValueLabel.Text = $"{television.TelevisionVolume * 20}%";
            roomTelevisionProgramTitleValueLabel.Text = television.TelevisionProgram;
            activateDeactivateTVToggleButton.Checked = television.IsTelevisionOn;
            tvSoundTrackBar.Value = television.TelevisionVolume;

            string radioStateValue = radio.IsRadioOn ? "Ανοιχτό" : "Κλειστό";
            roomRadioStateTitleValueLabel.Text = radioStateValue;
            roomRadioSoundLevelTitleValueLabel.Text = $"{radio.RadioVolume * 20}%";
            roomRadioSongTitleValueLabel.Text = radio.RadioSong;
            activateDeactivateRadioToggleButton.Checked = radio.IsRadioOn;
            radioSoundTrackBar.Value = radio.RadioVolume;
            SetVolume(radio.RadioVolume * 20);
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
                int roomTemperatureValue = ActiveUser.Customer != null ? ActiveUser.Customer.Room.RoomTemperature : Room.RoomTemperature;
                switch (roomTemperatureValue)
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
            if (doNotDoUnsavedChanges)
                return false;

            //logic for customer
            if (ActiveUser.Customer != null && unsavedChangesHelperMethod(ActiveUser.Customer.Room))
            {
                return true;
            }
            else if(ActiveUser.Customer == null && unsavedChangesHelperMethod(Room))
            {
                return true;
            }

            soundPlayer.Stop();
            return false; // No unsaved changes or the user chose the no or the yes option
        }

        private bool unsavedChangesHelperMethod(Room room)
        {
            if (roomLightingTrackBar.Value != room.RoomLighting || roomTemperature != room.RoomTemperature ||
                    !EqualityComparer<Radio>.Default.Equals(room.Radio, radio) ||
                    !EqualityComparer<Television>.Default.Equals(room.Television, television)
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
            room.RoomId = ActiveUser.Customer != null ? ActiveUser.Customer.Room.RoomId : Room.RoomId;
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
            else
            {
                //update the active user
                Room.Radio = radio;
                Room.Television = television;
                Room.RoomLighting = roomLightingTrackBar.Value;
                Room.RoomTemperature = roomTemperature;
                ActiveUser.Employee.Rooms[Room.RoomId - 1] = Room;
            }
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
            if (ActiveUser.Customer != null && unsavedChangesHelperMethod(ActiveUser.Customer.Room))
            {
                return;
                /*if (roomLightingTrackBar.Value != ActiveUser.Customer.Room.RoomLighting || roomTemperature != ActiveUser.Customer.Room.RoomTemperature ||
                    !EqualityComparer<Radio>.Default.Equals(ActiveUser.Customer.Room.Radio, radio) ||
                    !EqualityComparer<Television>.Default.Equals(ActiveUser.Customer.Room.Television, television)
                    )
                {
                    DialogResult result = MessageBox.Show("Οι αλλαγές σας είναι προσωρινές και θα σβηστούν σε περίπτωση κλήσης της φόρμας.\n" +
                        "Θέλετε να αποθηκευτούν πριν κλείσει ή φόρμα?",
                        "Μη Αποθηκευμένες Αλλαγές", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    //if cancel just do not do anything
                    if (result == DialogResult.Cancel)
                    {
                        return; 
                    }
                    //if yes then save the changes
                    if (result == DialogResult.Yes)
                    {
                        saveChanges();
                    }
                }
                //if yes(this is the continuation of yes) or no just do the typical procedures to change form
                doNotDoUnsavedChanges = true;
                soundPlayer.Stop();
                ActiveUser.SwapToInteractive = InteractiveModeEnum.NonInteractiveMode;*/
            }
            else if(ActiveUser.Customer == null && unsavedChangesHelperMethod(Room))
            {
                return;
            }
            doNotDoUnsavedChanges = true;
            soundPlayer.Stop();
            if(ActiveUser.Customer == null)
                ActiveUser.ChosenRoom = Room;
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

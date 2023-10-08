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
    public partial class RoomSelectionForm : ChildForm
    {
        private int startingPoint = 0;
        public RoomSelectionForm()
        {
            InitializeComponent();
            DoubleBufferingForForms.SetDoubleBuffer(roomPanelOne, true);
            DoubleBufferingForForms.SetDoubleBuffer(roomPanelTwo, true);
            setUpPoolSections();
        }

        private void setUpPoolSections()
        {
            setUpPoolSectionsHelper(roomPanelOne, ActiveUser.Employee.Rooms[startingPoint]);
            setUpPoolSectionsHelper(roomPanelTwo, ActiveUser.Employee.Rooms[startingPoint + 1]);
        }

        private void setUpPoolSectionsHelper(Panel panel, Room room)
        {
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("roomTitleLabel")).Text =
                $"Δωμάτιο {room.RoomId}";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("roomLightingValueLabel")).Text =
                $"{room.RoomLighting * 20}%";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("roomTemperatureValueLabel")).Text =
                $"{room.RoomTemperature}C";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("roomTelevisionStateValueLabel")).Text =
                room.Television.IsTelevisionOn ? "Ανοιχτή" : "Κλειστή";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("roomTelevisionSoundLevelValueLabel")).Text =
                $"{room.Television.TelevisionVolume * 20}%";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("roomTelevisionProgramValueLabel")).Text =
                room.Television.TelevisionProgram;
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("roomRadioStateValueLabel")).Text =
                room.Radio.IsRadioOn ? "Ανοιχτό" : "Κλειστό";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("roomRadioSoundLevelValueLabel")).Text =
                $"{room.Radio.RadioVolume * 20}%";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("roomRadioSongValueLabel")).Text =
                room.Radio.RadioSong;

            setRoomLighting(panel.Controls.OfType<TransparentPictureBox>().FirstOrDefault(), room);
            setRoomPicture(panel.Controls.OfType<TransparentPictureBox>().FirstOrDefault(), room);
        }

        private void setRoomPicture(TransparentPictureBox pictureBox, Room room)
        {
            if (room.RoomTemperature == 30 && !room.Television.IsTelevisionOn)
                pictureBox.BackgroundImage = Properties.Resources.ApartmentImageDefault;
            else if (room.RoomTemperature == 30 && room.Television.IsTelevisionOn && room.Television.TelevisionProgram == "Κανονικό")
                pictureBox.BackgroundImage = Properties.Resources.ApartmentImageTVOn;
            else if (room.RoomTemperature == 30 && room.Television.IsTelevisionOn && room.Television.TelevisionProgram == "Netflix")
                pictureBox.BackgroundImage = Properties.Resources.ApartmentImageTVOnNetflix;
            //this happens if the aircodition is not 30
            else if (!room.Television.IsTelevisionOn)
                pictureBox.BackgroundImage = Properties.Resources.ApartmentImageAirCoditionOn;
            else if (room.Television.IsTelevisionOn && room.Television.TelevisionProgram == "Κανονικό")
                pictureBox.BackgroundImage = Properties.Resources.ApartmentImageAirCoditionOnAndTVOn;
            else if (room.Television.IsTelevisionOn && room.Television.TelevisionProgram == "Netflix")
                pictureBox.BackgroundImage = Properties.Resources.ApartmentImageAirCoditionOnAndTVOnNetflix;
        }

        private void setRoomLighting(TransparentPictureBox pictureBox,Room room)
        {
            switch (room.RoomLighting)
            {
                case 0:
                    pictureBox.Opacity = 1;
                    break;
                case 1:
                    pictureBox.Opacity = 0.8;
                    break;
                case 2:
                    pictureBox.Opacity = 0.6;
                    break;
                case 3:
                    pictureBox.Opacity = 0.4;
                    break;
                case 4:
                    pictureBox.Opacity = 0.2;
                    break;
                case 5:
                    pictureBox.Opacity = 0;
                    break;
            }
        }

        private void moreInformationButtonOne_Click(object sender, EventArgs e)
        {
            ActiveUser.ChosenRoom = ActiveUser.Employee.Rooms[startingPoint];
        }

        private void moreInformationButtonTwo_Click(object sender, EventArgs e)
        {
            ActiveUser.ChosenRoom = ActiveUser.Employee.Rooms[startingPoint + 1];
        }

        private void previousSectionButton_Click(object sender, EventArgs e)
        {
            nextSectionButton.Enabled = true;
            startingPoint -= 2;
            if (startingPoint == 0)
                previousSectionButton.Enabled = false;
            setUpPoolSections();
            sectionButtonCount.Text = (startingPoint / 2 + 1).ToString();
        }

        private void nextSectionButton_Click(object sender, EventArgs e)
        {
            previousSectionButton.Enabled = true;
            startingPoint += 2;
            if (startingPoint == 6)
                nextSectionButton.Enabled = false;
            setUpPoolSections();
            sectionButtonCount.Text = (startingPoint / 2 + 1).ToString();
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

        public override bool UnsavedChangesDetected()
        {
            return false;
        }

    }
}

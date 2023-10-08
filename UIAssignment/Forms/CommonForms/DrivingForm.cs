using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIAssignment.Forms.CommonForms
{
    public partial class DrivingForm : ChildForm
    {
        Button focused = null;
        bool top, mid, bot, palace, garden, stop = true;//false;
        bool parked=false,goLeft, goRight,goUp,goDown;
        int speed = 4, o = 1;//0,begin=1;
        Dictionary<string, List<PictureBox>> My_dict1 =
                       new Dictionary<string, List<PictureBox>>();
        //PictureBox[][] ArrayOfArrows;

        public DrivingForm()
        {
            InitializeComponent();
        }

        private void ExitDrivingMode_Click(object sender, EventArgs e)
        {
            /*if (myTrojanHorse.Focused)
            {
                ActiveUser.Customer.Rooms.TroyanHorse.Location = myTrojanHorse.Location.ToString();
            }
            else if (TrojanHorse1.Focused)
            {
                ActiveUser.Customer.Rooms.TroyanHorse.Location = myTrojanHorse.Location.ToString();
            }*/
            //ActiveUser.Customer.Rooms.TroyanHorse.Location = myTrojanHorse.Location.ToString();
            ActiveUser.InGps = false;
        }
        public override bool UnsavedChangesDetected()
        {
            return false;
        }

        private void DrivingForm_Load(object sender, EventArgs e)
        {
            if (ActiveUser.Employee == null)
            {
                myTrojanHorse.Focus();
                ZeusPalace.FlatAppearance.BorderColor = BackColor;
                ZeusPalace.FlatAppearance.MouseOverBackColor = BackColor;
                ZeusPalace.FlatAppearance.MouseDownBackColor = BackColor;
            }
            else
            {
                //myTrojanHorse.Focus();
                myTrojanHorse.BackColor = Color.Red;
                ZeusPalace.FlatAppearance.BorderColor = BackColor;
                ZeusPalace.FlatAppearance.MouseOverBackColor = BackColor;
                ZeusPalace.FlatAppearance.MouseDownBackColor = BackColor;
            }
            /*myTrojanHorse.Focus();
            ZeusPalace.FlatAppearance.BorderColor = BackColor;
            ZeusPalace.FlatAppearance.MouseOverBackColor = BackColor;
            ZeusPalace.FlatAppearance.MouseDownBackColor = BackColor;*/
            My_dict1.Add("TopTowardsPalace",new List<PictureBox>(){pictureBox54, pictureBox55, pictureBox56, pictureBox26, pictureBox34, pictureBox25, pictureBox24, pictureBox23, pictureBox52, pictureBox21, pictureBox14});
            //ArrayOfArrows[0] = [pictureBox54, pictureBox55, pictureBox56, pictureBox26, pictureBox34, pictureBox25, pictureBox24, pictureBox23, pictureBox52, pictureBox21, pictureBox14];
            My_dict1.Add("TopTowardsGarden", new List<PictureBox>() { pictureBox42, pictureBox27, pictureBox43, pictureBox33, pictureBox8, pictureBox57, pictureBox53, pictureBox48, pictureBox52, pictureBox31, pictureBox32 });
            //ArrayOfArrows[1] = [pictureBox42, pictureBox27, pictureBox43, pictureBox33, pictureBox8, pictureBox57, pictureBox53, pictureBox48, pictureBox52, pictureBox31, pictureBox32];
            My_dict1.Add("MidTowardsPalace", new List<PictureBox>() { pictureBox54, pictureBox11, pictureBox12, pictureBox16, pictureBox50, pictureBox18, pictureBox20 });
            //ArrayOfArrows[2] = [pictureBox54, pictureBox11, pictureBox12, pictureBox16, pictureBox50, pictureBox18, pictureBox20];
            My_dict1.Add("MidTowardsGarden", new List<PictureBox>() { pictureBox41, pictureBox40, pictureBox39, pictureBox30, pictureBox36, pictureBox37, pictureBox38 });
            //ArrayOfArrows[3] = [pictureBox41, pictureBox40, pictureBox39, pictureBox30, pictureBox36, pictureBox37, pictureBox38];
            My_dict1.Add("BotTowardsPalace", new List<PictureBox>() { pictureBox10, pictureBox13, pictureBox15, pictureBox17, pictureBox19, pictureBox51, pictureBox49 });
            //ArrayOfArrows[4] = [pictureBox10, pictureBox13, pictureBox15, pictureBox17, pictureBox19, pictureBox51, pictureBox49];
            My_dict1.Add("BotTowardsGarden", new List<PictureBox>() { pictureBox28, pictureBox29, pictureBox45, pictureBox46, pictureBox47, pictureBox44, pictureBox35 });
            //ArrayOfArrows[5] = [pictureBox28, pictureBox29, pictureBox45, pictureBox46, pictureBox47, pictureBox44, pictureBox35];
            //ActiveUser.Customer.Rooms.TroyanHorse.Location.
            //if (ActiveUser.Customer.Rooms.TroyanHorse.Location == "Starting")
            //{
            //    //myTrojanHorse.Location = new Point(, );
            //}
            //else
            //{
            //    var g = Regex.Replace(ActiveUser.Customer.Rooms.TroyanHorse.Location, @"[\{\}a-zA-Z=]", "").Split(',');
            //    myTrojanHorse.Location = new Point(int.Parse(g[0]), int.Parse(g[1]));
            //}
            timer1.Enabled = true;
            timerStopArrows.Enabled = true;
        }

        private void myTrojanHorse_MouseEnter(object sender, EventArgs e)
        {
            if (myTrojanHorse.Focused)
            {
                pictureBox22.Visible = true;
                pictureBox22.Location = new Point(myTrojanHorse.Location.X + 10, myTrojanHorse.Location.Y - pictureBox22.Height - 2);
            }
            /*pictureBox22.Visible = true;
            pictureBox22.Location = new Point(myTrojanHorse.Location.X+10,myTrojanHorse.Location.Y - pictureBox22.Height-2);*/
        }

        private void myTrojanHorse_MouseLeave(object sender, EventArgs e)
        {
            if (myTrojanHorse.Focused)
            {
                pictureBox22.Visible = false;
            }
            //pictureBox22.Visible=false;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void Park_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            stop = !stop;
            if (getFocused().Location.Y <= 204 || getFocused().Location.X <= 130)
            {
                foreach (PictureBox arrow in My_dict1["TopTowardsGarden"])
                {
                    arrow.Visible = true;
                }
            }
            else if (getFocused().Location.Y >= 440 || getFocused().Location.X >= 778)
            {
                foreach (PictureBox arrow in My_dict1["BotTowardsGarden"])
                {
                    arrow.Visible = true;
                }
            }
            else
            {
                foreach (PictureBox arrow in My_dict1["MidTowardsGarden"])
                {
                    arrow.Visible = true;
                }
            }
            /*if (myTrojanHorse.Location.Y <= 204 || myTrojanHorse.Location.X <= 130)
            {
                foreach (PictureBox arrow in My_dict1["TopTowardsGarden"])
                {
                    arrow.Visible = true;
                }
            }
            else if (myTrojanHorse.Location.Y >= 440 || myTrojanHorse.Location.X >= 778)
            {
                foreach (PictureBox arrow in My_dict1["BotTowardsGarden"])
                {
                    arrow.Visible = true;
                }
            }
            else
            {
                foreach (PictureBox arrow in My_dict1["MidTowardsGarden"])
                {
                    arrow.Visible = true;
                }
            }*/
        }

        private void TrojanHorse1_MouseEnter(object sender, EventArgs e)
        {
            if (TrojanHorse1.Focused)
            {
                pictureBox22.Visible = true;
                pictureBox22.Location = new Point(TrojanHorse1.Location.X + 10, TrojanHorse1.Location.Y - pictureBox22.Height - 2);
            }
        }

        private void TrojanHorse1_MouseLeave(object sender, EventArgs e)
        {
            if (TrojanHorse1.Focused)
            {
                pictureBox22.Visible = false;
            }
        }

        private void TrojanHorse2_MouseEnter(object sender, EventArgs e)
        {
            if (TrojanHorse2.Focused)
            {
                pictureBox22.Visible = true;
                pictureBox22.Location = new Point(TrojanHorse2.Location.X + 10, TrojanHorse2.Location.Y - pictureBox22.Height - 2);
            }
        }

        private void TrojanHorse2_MouseLeave(object sender, EventArgs e)
        {
            if (TrojanHorse2.Focused)
            {
                pictureBox22.Visible = false;
            }
        }

        private void TrojanHorse3_MouseEnter(object sender, EventArgs e)
        {
            if (TrojanHorse3.Focused)
            {
                pictureBox22.Visible = true;
                pictureBox22.Location = new Point(TrojanHorse3.Location.X + 10, TrojanHorse3.Location.Y - pictureBox22.Height - 2);
            }
        }

        private void TrojanHorse3_MouseLeave(object sender, EventArgs e)
        {
            if (TrojanHorse3.Focused)
            {
                pictureBox22.Visible = false;
            }
        }

        private void TrojanHorse4_MouseEnter(object sender, EventArgs e)
        {
            if (TrojanHorse4.Focused)
            {
                pictureBox22.Visible = true;
                pictureBox22.Location = new Point(TrojanHorse4.Location.X + 10, TrojanHorse4.Location.Y - pictureBox22.Height - 2);
            }
        }

        private void TrojanHorse4_MouseLeave(object sender, EventArgs e)
        {
            if (TrojanHorse4.Focused)
            {
                pictureBox22.Visible = false;
            }
        }

        private void TrojanHorse5_MouseEnter(object sender, EventArgs e)
        {
            if (TrojanHorse5.Focused)
            {
                pictureBox22.Visible = true;
                pictureBox22.Location = new Point(TrojanHorse5.Location.X + 10, TrojanHorse5.Location.Y - pictureBox22.Height - 2);
            }
        }

        private void TrojanHorse5_MouseLeave(object sender, EventArgs e)
        {
            if (TrojanHorse5.Focused)
            {
                pictureBox22.Visible = false;
            }
        }

        private void TrojanHorse6_MouseEnter(object sender, EventArgs e)
        {
            if (TrojanHorse6.Focused)
            {
                pictureBox22.Visible = true;
                pictureBox22.Location = new Point(TrojanHorse6.Location.X + 10, TrojanHorse6.Location.Y - pictureBox22.Height - 2);
            }
        }

        private void TrojanHorse6_MouseLeave(object sender, EventArgs e)
        {
            if (TrojanHorse6.Focused)
            {
                pictureBox22.Visible = false;
            }
        }

        private void TrojanHorse7_MouseEnter(object sender, EventArgs e)
        {
            if (TrojanHorse7.Focused)
            {
                pictureBox22.Visible = true;
                pictureBox22.Location = new Point(TrojanHorse7.Location.X + 10, TrojanHorse7.Location.Y - pictureBox22.Height - 2);
            }
        }

        private void TrojanHorse7_MouseLeave(object sender, EventArgs e)
        {
            if (TrojanHorse7.Focused)
            {
                pictureBox22.Visible = false;
            }
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {

        }

        private void ZeusPalacee_Click(object sender, EventArgs e)
        {
            stop = !stop;
            if (getFocused().Location.Y <= 204 || getFocused().Location.X <= 130)
            {
                foreach (PictureBox arrow in My_dict1["TopTowardsPalace"])
                {
                    arrow.Visible = true;
                }
            }
            else if (getFocused().Location.Y >= 440 || getFocused().Location.X >= 778)
            {
                foreach (PictureBox arrow in My_dict1["BotTowardsPalace"])
                {
                    arrow.Visible = true;
                }
            }
            else
            {
                foreach (PictureBox arrow in My_dict1["MidTowardsPalace"])
                {
                    arrow.Visible = true;
                }
            }
        }

        private void Khpoi_Click(object sender, EventArgs e)
        {
            stop = !stop;
            if (getFocused().Location.Y <= 204 || getFocused().Location.X <= 130)
            {
                foreach (PictureBox arrow in My_dict1["TopTowardsGarden"])
                {
                    arrow.Visible = true;
                }
            }
            else if (getFocused().Location.Y >= 440 || getFocused().Location.X >= 778)
            {
                foreach (PictureBox arrow in My_dict1["BotTowardsGarden"])
                {
                    arrow.Visible = true;
                }
            }
            else
            {
                foreach (PictureBox arrow in My_dict1["MidTowardsGarden"])
                {
                    arrow.Visible = true;
                }
            }
        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {

        }

        private void timerStopArrows_Tick(object sender, EventArgs e)
        {
            if (getFocused().Location.X >= 754 && getFocused().Location.Y <= 212 || stop)
            {
                timerForArrows.Enabled = false;
                foreach (PictureBox arrow in My_dict1["TopTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["TopTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["MidTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["MidTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["BotTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["BotTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
            }
            else if (getFocused().Location.Y >= 352 && getFocused().Location.X <= 178)
            {
                timerForArrows.Enabled = false;
                foreach (PictureBox arrow in My_dict1["TopTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["TopTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["MidTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["MidTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["BotTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["BotTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
            }
            /*if (myTrojanHorse.Location.X >=754 && myTrojanHorse.Location.Y <=212 || stop)
            {
                timerForArrows.Enabled = false;
                foreach (PictureBox arrow in My_dict1["TopTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["TopTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["MidTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["MidTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["BotTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["BotTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
            }
            else if (myTrojanHorse.Location.Y >=352 && myTrojanHorse.Location.X <=178)
            {
                timerForArrows.Enabled = false;
                foreach (PictureBox arrow in My_dict1["TopTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["TopTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["MidTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["MidTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["BotTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
                foreach (PictureBox arrow in My_dict1["BotTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                    }
                }
            }
            o = 1;*/
        }

        private void ZeusPalace_Click(object sender, EventArgs e)
        {
            stop = !stop;
            if (getFocused().Location.Y <= 204 || getFocused().Location.X <= 130)
            {
                /*garden = false;
                palace = true;
                bot = false;
                mid = false;
                top = true;
                timerForArrows.Enabled = true;*/
                foreach (PictureBox arrow in My_dict1["TopTowardsPalace"])
                {
                    arrow.Visible = true;
                }
            }
            else if (getFocused().Location.Y >= 440 || getFocused().Location.X >= 778)
            {
                /*garden = false;
                palace = true;
                top = false;
                mid = false;
                bot = true;
                timerForArrows.Enabled = true;*/
                foreach (PictureBox arrow in My_dict1["BotTowardsPalace"])
                {
                    arrow.Visible = true;
                }
            }
            else
            {
                /*garden = false;
                palace = true;
                top = false;
                bot = false;
                mid = true;
                timerForArrows.Enabled = true;*/
                foreach (PictureBox arrow in My_dict1["MidTowardsPalace"])
                {
                    arrow.Visible = true;
                }
            }
            /*if (myTrojanHorse.Location.Y <= 204 || myTrojanHorse.Location.X <= 130)
            {
                *//*garden = false;
                palace = true;
                bot = false;
                mid = false;
                top = true;
                timerForArrows.Enabled = true;*//*
                foreach (PictureBox arrow in My_dict1["TopTowardsPalace"])
                {
                    arrow.Visible = true;
                }
            }
            else if (myTrojanHorse.Location.Y >= 440 || myTrojanHorse.Location.X >= 778)
            {
                *//*garden = false;
                palace = true;
                top = false;
                mid = false;
                bot = true;
                timerForArrows.Enabled = true;*//*
                foreach (PictureBox arrow in My_dict1["BotTowardsPalace"])
                {
                    arrow.Visible = true;
                }
            }
            else
            {
                *//*garden = false;
                palace = true;
                top = false;
                bot = false;
                mid = true;
                timerForArrows.Enabled = true;*//*
                foreach (PictureBox arrow in My_dict1["MidTowardsPalace"])
                {
                    arrow.Visible = true;
                }
            }*/
        }

        private void timerForArrows_Tick(object sender, EventArgs e)
        {
            if (top && palace)
            {
                /*if (begin == 1)
                {
                    My_dict1["TopTowardsPalace"][0].Visible = true;
                    begin = 0;
                    o = 0;
                }*/
                //else
                //{
                    foreach (PictureBox arrow in My_dict1["TopTowardsPalace"])
                    {
                        if (arrow.Visible == true)
                        {
                            arrow.Visible = false;
                            o = 1;
                        }
                        else if (o == 1)
                        {
                            arrow.Visible = true;
                            o = 0;
                        }
                    }
                //}
            }
            else if (top && garden)
            {
                foreach (PictureBox arrow in My_dict1["TopTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                        o = 1;
                    }
                    if (o == 1)
                    {
                        arrow.Visible = true;
                        o = 0;
                    }
                }
            }
            else if (mid && palace)
            {
                foreach (PictureBox arrow in My_dict1["MidTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                        o = 1;
                    }
                    if (o == 1)
                    {
                        arrow.Visible = true;
                        o = 0;
                    }
                }
            }
            else if (mid && garden)
            {
                foreach (PictureBox arrow in My_dict1["MidTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                        o = 1;
                    }
                    if (o == 1)
                    {
                        arrow.Visible = true;
                        o = 0;
                    }
                }
            }
            else if (bot && palace)
            {
                foreach (PictureBox arrow in My_dict1["BotTowardsPalace"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                        o = 1;
                    }
                    if (o == 1)
                    {
                        arrow.Visible = true;
                        o = 0;
                    }
                }
            }
            else if (bot && garden)
            {
                foreach (PictureBox arrow in My_dict1["BotTowardsGarden"])
                {
                    if (arrow.Visible == true)
                    {
                        arrow.Visible = false;
                        o = 1;
                    }
                    if (o == 1)
                    {
                        arrow.Visible = true;
                        o = 0;
                    }
                }
            }
        }

        //private void ProsKhpous_Click(object sender, EventArgs e)
        //{
        //
        //}

        private void DrivingForm_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.A)
            {
                pictureBox7.Visible = true;
                goLeft = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                pictureBox5.Visible = true;
                goRight = true;
            }
            else if (e.KeyCode == Keys.W)
            {
                pictureBox3.Visible = true;
                goUp = true;
            }
            else if (e.KeyCode == Keys.S)
            {
                pictureBox6.Visible = true;
                goDown = true;
            }
        }

        private void DrivingForm_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.A)
            {
                pictureBox7.Visible = false;
                goLeft = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                pictureBox5.Visible = false;
                goRight = false;
            }
            else if (e.KeyCode == Keys.W)
            {
                pictureBox3.Visible = false;
                goUp = false;
            }
            else if (e.KeyCode == Keys.S)
            {
                pictureBox6.Visible = false;
                goDown = false;
            }

            else if (e.KeyCode == Keys.P)
            {
                if (((getFocused().Location.X >= 2) && (getFocused().Location.Y >= 388) && (getFocused().Location.X <= 90) && (getFocused().Location.Y <= 400)) || ((getFocused().Location.X >= 774) && (getFocused().Location.Y >= 0) && (getFocused().Location.X <= 790) && (getFocused().Location.Y <= 106)) || ((getFocused().Location.X >= 830) && (getFocused().Location.Y >= 164) && (getFocused().Location.X <= 938) && (getFocused().Location.Y <= 180)) || ((getFocused().Location.X >= 142) && (getFocused().Location.Y >= 444) && (getFocused().Location.X <= 158) && (getFocused().Location.Y <= 556)))
                {
                    parked = true;
                }
                /*if (((myTrojanHorse.Location.X >= 2) && (myTrojanHorse.Location.Y >= 388) && (myTrojanHorse.Location.X <= 90) && (myTrojanHorse.Location.Y <= 400)) || ((myTrojanHorse.Location.X >= 774) && (myTrojanHorse.Location.Y >= 0) && (myTrojanHorse.Location.X <= 790) && (myTrojanHorse.Location.Y <= 106)) || ((myTrojanHorse.Location.X >= 830) && (myTrojanHorse.Location.Y >= 164) && (myTrojanHorse.Location.X <= 938) && (myTrojanHorse.Location.Y <= 180)) || ((myTrojanHorse.Location.X >= 142) && (myTrojanHorse.Location.Y >= 444) && (myTrojanHorse.Location.X <= 158) && (myTrojanHorse.Location.Y <= 556)))
                {
                    parked = true;
                }*/
                //if ((myTrojanHorse.Location.X >= 2) && (myTrojanHorse.Location.Y >= 388) && (myTrojanHorse.Location.X <= 90) && (myTrojanHorse.Location.Y <= 400))
                //{
                //    parked = true;
                //}
                //if ((myTrojanHorse.Location.X >= 774) && (myTrojanHorse.Location.Y >= 0) && (myTrojanHorse.Location.X <= 790) && (myTrojanHorse.Location.Y <= 106))
                //{
                //    parked = true;
                //}
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (!valid)
            //{
            //    myTrojanHorse.Location.X
            //}
            //if (((myTrojanHorse.Location.X>=118) && (myTrojanHorse.Location.Y>=36) && (myTrojanHorse.Location.X <= 130) && (myTrojanHorse.Location.Y <= 344)) || ((myTrojanHorse.Location.X >= 130) && (myTrojanHorse.Location.Y >= 36) && (myTrojanHorse.Location.X <= 200) && (myTrojanHorse.Location.Y <= 56)) || ((myTrojanHorse.Location.X >= 190) && (myTrojanHorse.Location.Y >= 56) && (myTrojanHorse.Location.X <= 200) && (myTrojanHorse.Location.Y <= 136)) || ((myTrojanHorse.Location.X >= 206) && (myTrojanHorse.Location.Y >= 124) && (myTrojanHorse.Location.X <= 438) && (myTrojanHorse.Location.Y <= 140)) || ((myTrojanHorse.Location.X >= 426) && (myTrojanHorse.Location.Y >= 36) && (myTrojanHorse.Location.X <= 442) && (myTrojanHorse.Location.Y <= 124)) || ((myTrojanHorse.Location.X >= 442) && (myTrojanHorse.Location.Y >= 36) && (myTrojanHorse.Location.X <= 746) && (myTrojanHorse.Location.Y <= 56)) || ((myTrojanHorse.Location.X >= 130) && (myTrojanHorse.Location.Y >= 276) && (myTrojanHorse.Location.X <= 474) && (myTrojanHorse.Location.Y <= 296)) || ((myTrojanHorse.Location.X >= 458) && (myTrojanHorse.Location.Y >= 212) && (myTrojanHorse.Location.X <= 478) && (myTrojanHorse.Location.Y <= 276)) || ((myTrojanHorse.Location.X >= 478) && (myTrojanHorse.Location.Y >= 204) && (myTrojanHorse.Location.X <= 802) && (myTrojanHorse.Location.Y <= 228)) || ((myTrojanHorse.Location.X >= 182) && (myTrojanHorse.Location.Y >= 440) && (myTrojanHorse.Location.X <= 774) && (myTrojanHorse.Location.Y <= 464)) || ((myTrojanHorse.Location.X >= 778) && (myTrojanHorse.Location.Y >= 228) && (myTrojanHorse.Location.X <= 802) && (myTrojanHorse.Location.Y <= 460)) || ((myTrojanHorse.Location.X >= -2) && (myTrojanHorse.Location.Y >= 352) && (myTrojanHorse.Location.X <= 178) && (myTrojanHorse.Location.Y <= 568)) || ((myTrojanHorse.Location.X >= 754) && (myTrojanHorse.Location.Y >= 0) && (myTrojanHorse.Location.X <= 942) && (myTrojanHorse.Location.Y <= 212)))
            //{
            //    valid = true;
            //}
            //if (!(((myTrojanHorse.Location.X >= 118) && (myTrojanHorse.Location.Y >= 36) && (myTrojanHorse.Location.X <= 130) && (myTrojanHorse.Location.Y <= 344)) || ((myTrojanHorse.Location.X >= 130) && (myTrojanHorse.Location.Y >= 36) && (myTrojanHorse.Location.X <= 200) && (myTrojanHorse.Location.Y <= 56)) || ((myTrojanHorse.Location.X >= 190) && (myTrojanHorse.Location.Y >= 56) && (myTrojanHorse.Location.X <= 200) && (myTrojanHorse.Location.Y <= 136)) || ((myTrojanHorse.Location.X >= 206) && (myTrojanHorse.Location.Y >= 124) && (myTrojanHorse.Location.X <= 438) && (myTrojanHorse.Location.Y <= 140)) || ((myTrojanHorse.Location.X >= 426) && (myTrojanHorse.Location.Y >= 36) && (myTrojanHorse.Location.X <= 442) && (myTrojanHorse.Location.Y <= 124)) || ((myTrojanHorse.Location.X >= 442) && (myTrojanHorse.Location.Y >= 36) && (myTrojanHorse.Location.X <= 746) && (myTrojanHorse.Location.Y <= 56)) || ((myTrojanHorse.Location.X >= 130) && (myTrojanHorse.Location.Y >= 276) && (myTrojanHorse.Location.X <= 474) && (myTrojanHorse.Location.Y <= 296)) || ((myTrojanHorse.Location.X >= 458) && (myTrojanHorse.Location.Y >= 212) && (myTrojanHorse.Location.X <= 478) && (myTrojanHorse.Location.Y <= 276)) || ((myTrojanHorse.Location.X >= 478) && (myTrojanHorse.Location.Y >= 204) && (myTrojanHorse.Location.X <= 802) && (myTrojanHorse.Location.Y <= 228)) || ((myTrojanHorse.Location.X >= 182) && (myTrojanHorse.Location.Y >= 440) && (myTrojanHorse.Location.X <= 774) && (myTrojanHorse.Location.Y <= 464)) || ((myTrojanHorse.Location.X >= 778) && (myTrojanHorse.Location.Y >= 228) && (myTrojanHorse.Location.X <= 802) && (myTrojanHorse.Location.Y <= 460)) || ((myTrojanHorse.Location.X >= -2) && (myTrojanHorse.Location.Y >= 352) && (myTrojanHorse.Location.X <= 178) && (myTrojanHorse.Location.Y <= 568)) || ((myTrojanHorse.Location.X >= 754) && (myTrojanHorse.Location.Y >= 0) && (myTrojanHorse.Location.X <= 942) && (myTrojanHorse.Location.Y <= 212))))
            //{
            //    valid = false;
            //}
            label1.Text = getFocused().Location.X.ToString() + " " + getFocused().Location.Y.ToString();
            if (goLeft && getFocused().Location.X > 0 && isValiid(new Point(getFocused().Location.X - 4, getFocused().Location.Y)))
            {
                parked = false;
                //int x = myTrojanHorse.Location.X;
                //int y = myTrojanHorse.Location.Y;
                //myTrojanHorse.Location = new Point(x-speed,y);// -= speed;
                getFocused().Left -= speed;
            }
            if (goRight && getFocused().Location.X + 10 < this.Width && isValiid(new Point(getFocused().Location.X + 4, getFocused().Location.Y)))
            {
                parked = false;
                getFocused().Left += speed;
                //int x = myTrojanHorse.Location.X;
                //int y = myTrojanHorse.Location.Y;
                //myTrojanHorse.Location = new Point(x + speed, y);
            }
            if (goUp && getFocused().Location.Y > 0 && isValiid(new Point(getFocused().Location.X, getFocused().Location.Y - 4)))
            {
                parked = false;
                getFocused().Top -= speed;
                //int x = myTrojanHorse.Location.X;
                //int y = myTrojanHorse.Location.Y;
                //myTrojanHorse.Location = new Point(x , y - speed);
            }
            if (goDown && getFocused().Location.Y + 10 < this.Height && isValiid(new Point(getFocused().Location.X, getFocused().Location.Y + 4)))
            {
                parked = false;
                getFocused().Top += speed;
                //int x = myTrojanHorse.Location.X;
                //int y = myTrojanHorse.Location.Y;
                //myTrojanHorse.Location = new Point(x , y+ speed);
            }
            /*label1.Text = myTrojanHorse.Location.X.ToString() +" "+ myTrojanHorse.Location.Y.ToString();
            if (goLeft && myTrojanHorse.Location.X > 0 && isValiid(new Point(myTrojanHorse.Location.X - 4, myTrojanHorse.Location.Y)))
            {
                parked = false;
                //int x = myTrojanHorse.Location.X;
                //int y = myTrojanHorse.Location.Y;
                //myTrojanHorse.Location = new Point(x-speed,y);// -= speed;
                myTrojanHorse.Left -= speed;
            }
            if (goRight && myTrojanHorse.Location.X + 10 < this.Width && isValiid(new Point(myTrojanHorse.Location.X + 4, myTrojanHorse.Location.Y)))
            {
                parked = false;
                myTrojanHorse.Left += speed;
                //int x = myTrojanHorse.Location.X;
                //int y = myTrojanHorse.Location.Y;
                //myTrojanHorse.Location = new Point(x + speed, y);
            }
            if (goUp && myTrojanHorse.Location.Y > 0 && isValiid(new Point(myTrojanHorse.Location.X, myTrojanHorse.Location.Y-4)))
            {
                parked = false;
                myTrojanHorse.Top -= speed;
                //int x = myTrojanHorse.Location.X;
                //int y = myTrojanHorse.Location.Y;
                //myTrojanHorse.Location = new Point(x , y - speed);
            }
            if (goDown && myTrojanHorse.Location.Y + 10 < this.Height && isValiid(new Point(myTrojanHorse.Location.X, myTrojanHorse.Location.Y+4)))
            {
                parked = false;
                myTrojanHorse.Top += speed;
                //int x = myTrojanHorse.Location.X;
                //int y = myTrojanHorse.Location.Y;
                //myTrojanHorse.Location = new Point(x , y+ speed);
            }*/
            if (parked)
            {
                //timer1.Enabled = false;
                //ExitDrivingMode.PerformClick();
                //MessageBox.Show("Επιτυχής στάθμευση Δουρείου Ίππου!");
                //timer1.Enabled = false;
                ExitDrivingMode.PerformClick();
            }
            if (((getFocused().Location.X >= 2) && (getFocused().Location.Y >= 388) && (getFocused().Location.X <= 90) && (getFocused().Location.Y <= 400)) || ((getFocused().Location.X >= 774) && (getFocused().Location.Y >= 0) && (getFocused().Location.X <= 790) && (getFocused().Location.Y <= 106)) || ((getFocused().Location.X >= 830) && (getFocused().Location.Y >= 164) && (getFocused().Location.X <= 938) && (getFocused().Location.Y <= 180)) || ((getFocused().Location.X >= 142) && (getFocused().Location.Y >= 444) && (getFocused().Location.X <= 158) && (getFocused().Location.Y <= 556)))
            {
                Park.Visible = true;
            }
            if (!(((getFocused().Location.X >= 2) && (getFocused().Location.Y >= 388) && (getFocused().Location.X <= 90) && (getFocused().Location.Y <= 400)) || ((getFocused().Location.X >= 774) && (getFocused().Location.Y >= 0) && (getFocused().Location.X <= 790) && (getFocused().Location.Y <= 106)) || ((getFocused().Location.X >= 830) && (getFocused().Location.Y >= 164) && (getFocused().Location.X <= 938) && (getFocused().Location.Y <= 180)) || ((getFocused().Location.X >= 142) && (getFocused().Location.Y >= 444) && (getFocused().Location.X <= 158) && (getFocused().Location.Y <= 556))))
            {
                Park.Visible = false;
            }
            /*if (((myTrojanHorse.Location.X >= 2) && (myTrojanHorse.Location.Y >= 388) && (myTrojanHorse.Location.X <= 90) && (myTrojanHorse.Location.Y <= 400)) || ((myTrojanHorse.Location.X >= 774) && (myTrojanHorse.Location.Y >= 0) && (myTrojanHorse.Location.X <= 790) && (myTrojanHorse.Location.Y <= 106)) || ((myTrojanHorse.Location.X >= 830) && (myTrojanHorse.Location.Y >= 164) && (myTrojanHorse.Location.X <= 938) && (myTrojanHorse.Location.Y <= 180)) || ((myTrojanHorse.Location.X >= 142) && (myTrojanHorse.Location.Y >= 444) && (myTrojanHorse.Location.X <= 158) && (myTrojanHorse.Location.Y <= 556)))
            {
                Park.Visible=true;
            }
            if (!(((myTrojanHorse.Location.X >= 2) && (myTrojanHorse.Location.Y >= 388) && (myTrojanHorse.Location.X <= 90) && (myTrojanHorse.Location.Y <= 400)) || ((myTrojanHorse.Location.X >= 774) && (myTrojanHorse.Location.Y >= 0) && (myTrojanHorse.Location.X <= 790) && (myTrojanHorse.Location.Y <= 106)) || ((myTrojanHorse.Location.X >= 830) && (myTrojanHorse.Location.Y >= 164) && (myTrojanHorse.Location.X <= 938) && (myTrojanHorse.Location.Y <= 180)) || ((myTrojanHorse.Location.X >= 142) && (myTrojanHorse.Location.Y >= 444) && (myTrojanHorse.Location.X <= 158) && (myTrojanHorse.Location.Y <= 556))))
            {
                Park.Visible = false;
            }*/

            if (myTrojanHorse.Focused)
            {
                myTrojanHorse.BackColor = Color.FromArgb(0, 192, 192);
                TrojanHorse1.BackColor = Color.Red;
                TrojanHorse2.BackColor = Color.Red;
                TrojanHorse3.BackColor = Color.Red;
                TrojanHorse4.BackColor = Color.Red;
                TrojanHorse5.BackColor = Color.Red;
                TrojanHorse6.BackColor = Color.Red;
                TrojanHorse7.BackColor = Color.Red;
            }
            else if (TrojanHorse1.Focused)
            {
                TrojanHorse1.BackColor = Color.FromArgb(0, 192, 192);
                myTrojanHorse.BackColor = Color.Red;
                TrojanHorse2.BackColor = Color.Red;
                TrojanHorse3.BackColor = Color.Red;
                TrojanHorse4.BackColor = Color.Red;
                TrojanHorse5.BackColor = Color.Red;
                TrojanHorse6.BackColor = Color.Red;
                TrojanHorse7.BackColor = Color.Red;
            }
            else if (TrojanHorse2.Focused)
            {
                TrojanHorse2.BackColor = Color.FromArgb(0, 192, 192);
                myTrojanHorse.BackColor = Color.Red;
                TrojanHorse1.BackColor = Color.Red;
                TrojanHorse3.BackColor = Color.Red;
                TrojanHorse4.BackColor = Color.Red;
                TrojanHorse5.BackColor = Color.Red;
                TrojanHorse6.BackColor = Color.Red;
                TrojanHorse7.BackColor = Color.Red;
            }
            else if (TrojanHorse3.Focused)
            {
                TrojanHorse3.BackColor = Color.FromArgb(0, 192, 192);
                myTrojanHorse.BackColor = Color.Red;
                TrojanHorse2.BackColor = Color.Red;
                TrojanHorse1.BackColor = Color.Red;
                TrojanHorse4.BackColor = Color.Red;
                TrojanHorse5.BackColor = Color.Red;
                TrojanHorse6.BackColor = Color.Red;
                TrojanHorse7.BackColor = Color.Red;
            }
            else if (TrojanHorse4.Focused)
            {
                TrojanHorse4.BackColor = Color.FromArgb(0, 192, 192);
                myTrojanHorse.BackColor = Color.Red;
                TrojanHorse2.BackColor = Color.Red;
                TrojanHorse3.BackColor = Color.Red;
                TrojanHorse1.BackColor = Color.Red;
                TrojanHorse5.BackColor = Color.Red;
                TrojanHorse6.BackColor = Color.Red;
                TrojanHorse7.BackColor = Color.Red;
            }
            else if (TrojanHorse5.Focused)
            {
                TrojanHorse5.BackColor = Color.FromArgb(0, 192, 192);
                myTrojanHorse.BackColor = Color.Red;
                TrojanHorse2.BackColor = Color.Red;
                TrojanHorse3.BackColor = Color.Red;
                TrojanHorse4.BackColor = Color.Red;
                TrojanHorse1.BackColor = Color.Red;
                TrojanHorse6.BackColor = Color.Red;
                TrojanHorse7.BackColor = Color.Red;
            }
            else if (TrojanHorse6.Focused)
            {
                TrojanHorse6.BackColor = Color.FromArgb(0, 192, 192);
                myTrojanHorse.BackColor = Color.Red;
                TrojanHorse2.BackColor = Color.Red;
                TrojanHorse3.BackColor = Color.Red;
                TrojanHorse4.BackColor = Color.Red;
                TrojanHorse5.BackColor = Color.Red;
                TrojanHorse1.BackColor = Color.Red;
                TrojanHorse7.BackColor = Color.Red;
            }
            else if (TrojanHorse7.Focused)
            {
                TrojanHorse7.BackColor = Color.FromArgb(0, 192, 192);
                myTrojanHorse.BackColor = Color.Red;
                TrojanHorse2.BackColor = Color.Red;
                TrojanHorse3.BackColor = Color.Red;
                TrojanHorse4.BackColor = Color.Red;
                TrojanHorse5.BackColor = Color.Red;
                TrojanHorse6.BackColor = Color.Red;
                TrojanHorse1.BackColor = Color.Red;
            }

            if (ActiveUser.Employee == null)
            {
                if (getFocused() != myTrojanHorse && getFocused() != ZeusPalace && getFocused() != button1)
                {
                    myTrojanHorse.Focus();
                }
            }
        }
        private bool isValiid(Point location)
        {
            if (((location.X >= 118) && (location.Y >= 36) && (location.X <= 130) && (location.Y <= 352)) || ((location.X >= 130) && (location.Y >= 36) && (location.X <= 208) && (location.Y <= 56)) || ((location.X >= 190) && (location.Y >= 56) && (location.X <= 208) && (location.Y <= 136)) || ((location.X >= 206) && (location.Y >= 124) && (location.X <= 438) && (location.Y <= 140)) || ((location.X >= 426) && (location.Y >= 36) && (location.X <= 442) && (location.Y <= 124)) || ((location.X >= 442) && (location.Y >= 36) && (location.X <= 754) && (location.Y <= 56)) || ((location.X >= 130) && (location.Y >= 276) && (location.X <= 474) && (location.Y <= 296)) || ((location.X >= 458) && (location.Y >= 212) && (location.X <= 478) && (location.Y <= 276)) || ((location.X >= 478) && (location.Y >= 204) && (location.X <= 802) && (location.Y <= 228)) || ((location.X >= 182) && (location.Y >= 440) && (location.X <= 774) && (location.Y <= 464)) || ((location.X >= 778) && (location.Y >= 228) && (location.X <= 802) && (location.Y <= 460)) || ((location.X >= -2) && (location.Y >= 352) && (location.X <= 178) && (location.Y <= 568)) || ((location.X >= 754) && (location.Y >= 0) && (location.X <= 942) && (location.Y <= 212)))
            {
                return true;
            }
            else { return false; }
        }
        private Button getFocused()
        {
            if (myTrojanHorse.Focused)
            {
                return myTrojanHorse;
            }
            else if (TrojanHorse1.Focused)
            {
                return TrojanHorse1;
            }
            else if (TrojanHorse2.Focused)
            {
                return TrojanHorse2;
            }
            else if (TrojanHorse3.Focused)
            {
                return TrojanHorse3;
            }
            else if (TrojanHorse4.Focused)
            {
                return TrojanHorse4;
            }
            else if (TrojanHorse5.Focused)
            {
                return TrojanHorse5;
            }
            else if (TrojanHorse6.Focused)
            {
                return TrojanHorse6;
            }
            else if (TrojanHorse7.Focused)
            {
                return TrojanHorse7;
            }
            else
            {
                return ExitDrivingMode;
            }
        }
    }
}

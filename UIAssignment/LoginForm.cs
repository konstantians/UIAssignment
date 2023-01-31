using DataAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIAssignment
{
    public partial class LoginForm : Form
    {
        bool focusForPassword = false;
        bool focusForUsername = false;
        public LoginForm()
        {
            InitializeComponent();
            signInButton.FlatAppearance.BorderSize = 4;
            signInButton.FlatAppearance.BorderColor = Color.Black;
        }

        private void signInButton_Enter(object sender, EventArgs e)
        {
            signInButton.FlatAppearance.BorderColor = Color.FromArgb(150, 53, 41);
            signInButton.ForeColor = Color.FromArgb(150, 53, 41);
            signInButton.BackColor = Color.Black;
        }

        private void signInButton_MouseEnter(object sender, EventArgs e)
        {
            signInButton.FlatAppearance.BorderColor = Color.FromArgb(150, 53, 41);
            signInButton.ForeColor = Color.FromArgb(150, 53, 41);
            signInButton.BackColor = Color.Black;
        }

        private void signInButton_Leave(object sender, EventArgs e)
        {
            signInButton.FlatAppearance.BorderColor = Color.Black;
            signInButton.ForeColor = Color.Black;
            signInButton.BackColor = Color.FromArgb(150, 53, 41);
        }

        private void signInButton_MouseLeave(object sender, EventArgs e)
        {
            signInButton.FlatAppearance.BorderColor = Color.Black;
            signInButton.ForeColor = Color.Black;
            signInButton.BackColor = Color.FromArgb(150, 53, 41);
        }

        private void registerLabel_MouseEnter(object sender, EventArgs e)
        {
            registerLabel.ForeColor = Color.Black;
        }

        private void registerLabel_MouseLeave(object sender, EventArgs e)
        {
            registerLabel.ForeColor = Color.FromArgb(150, 53, 41);
        }

        private void LoginForm_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.FromArgb(150, 53, 41),2);
            Graphics g = e.Graphics;
            if (focusForPassword)
            {
                g.DrawRectangle(p, new Rectangle(passwordTextbox.Location.X + 1, 
                    passwordTextbox.Location.Y + 1, passwordTextbox.Width,
                    passwordTextbox.Height));
                passwordTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (focusForUsername)
            {
                g.DrawRectangle(p, new Rectangle(usernameTextbox.Location.X + 1,
                    usernameTextbox.Location.Y + 1, usernameTextbox.Width,
                    usernameTextbox.Height));
                usernameTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                passwordTextbox.BorderStyle = BorderStyle.FixedSingle;
                usernameTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void passwordTextbox_Enter(object sender, EventArgs e)
        {
            focusForPassword = true;
            this.Refresh();
        }

        private void passwordTextbox_Leave(object sender, EventArgs e)
        {
            focusForPassword = false;
            this.Refresh();
        }

        private void usernameTextbox_Enter(object sender, EventArgs e)
        {
            focusForUsername = true;
            this.Refresh();
        }

        private void usernameTextbox_Leave(object sender, EventArgs e)
        {
            focusForUsername = false;
            this.Refresh();
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
        }

        private void forgotPasswordLabel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            SmallUsernameDialogForm smallUsernameDialogForm = new SmallUsernameDialogForm();
            smallUsernameDialogForm.Show();
        }

        private void forgotPasswordLabel_MouseEnter(object sender, EventArgs e)
        {
            forgotPasswordLabel.ForeColor = Color.Black;
        }

        private void forgotPasswordLabel_MouseLeave(object sender, EventArgs e)
        {
            forgotPasswordLabel.ForeColor = Color.FromArgb(150, 53, 41);
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            if (usernameTextbox.Text == "" && passwordTextbox.Text == "")
            {
                MessageBox.Show("The username and password field are empty, please fill al the fields.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (usernameTextbox.Text == "")
            {
                MessageBox.Show("The username field is empty, please fill al the fields.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (passwordTextbox.Text == "")
            {
                MessageBox.Show("The password field is empty, please fill al the fields.","Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User user = DataAccessOperations.GetUser(usernameTextbox.Text);
            if(user.Username == null)
            {
                MessageBox.Show("There is no account with the given username.","Account Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTextbox.Text = "";
                passwordTextbox.Text = "";
                customerRadioButton.Checked = true;
                employeeRadioButton.Checked = false;
                return;
            }
            else if(user.Password != passwordTextbox.Text)
            {
                MessageBox.Show("Incorrect password or account type.","False Credentionals",MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextbox.Text = "";
                customerRadioButton.Checked = true;
                employeeRadioButton.Checked = false;
                return;
            }
            else if (user.UserRole == "Customer" && employeeRadioButton.Checked == true)
            {
                MessageBox.Show("Incorrect password or account type.","False Credentionals",MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextbox.Text = "";
                customerRadioButton.Checked = true;
                employeeRadioButton.Checked = false;
                return;
            }
            else if (user.UserRole == "Employee" && customerRadioButton.Checked == true)
            {
                MessageBox.Show("Incorrect password or account type.","False Credentionals", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextbox.Text = "";
                customerRadioButton.Checked = true;
                employeeRadioButton.Checked = false;
                return;
            }

            MessageBox.Show($"Welcome back {user.Username}!");
            
            this.Hide();
            MapForm mapForm = new MapForm();
            mapForm.Show();
        }
    }

    class CustomRadioButton : RadioButton
    {
        private Color checkedColor = Color.FromArgb(150, 53, 41);
        private Color unCheckedColor = Color.Black;
        public Color CheckedColor
        {
            get { return checkedColor; }
            set
            {
                checkedColor = value;
                this.Invalidate();
            }
        }
        public Color UnCheckedColor
        {
            get { return unCheckedColor; }
            set
            {
                unCheckedColor = value;
                this.Invalidate();
            }
        }

        //Overridden methods
        protected override void OnPaint(PaintEventArgs pevent)
        {
            //Fields
            Graphics graphics = pevent.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            float rbBorderSize = 14F;
            float rbCheckSize = 7F;
            RectangleF rectRbBorder = new RectangleF()
            {
                X = 0.5F,
                Y = (this.Height - rbBorderSize) / 2, //Center
                Width = rbBorderSize,
                Height = rbBorderSize
            };
            RectangleF rectRbCheck = new RectangleF()
            {
                X = rectRbBorder.X + ((rectRbBorder.Width - rbCheckSize) / 2), //Center
                Y = (this.Height - rbCheckSize) / 2, //Center
                Width = rbCheckSize,
                Height = rbCheckSize
            };
            //Drawing
            using (Pen penBorder = new Pen(checkedColor, 1.6F))
            using (SolidBrush brushRbCheck = new SolidBrush(checkedColor))
            using (SolidBrush brushText = new SolidBrush(this.ForeColor))
            {
                //Draw surface
                graphics.Clear(this.BackColor);
                //Draw Radio Button
                if (this.Checked)
                {
                    graphics.DrawEllipse(penBorder, rectRbBorder);//Circle border
                    graphics.FillEllipse(brushRbCheck, rectRbCheck); //Circle Radio Check
                }
                else
                {
                    penBorder.Color = unCheckedColor;
                    graphics.DrawEllipse(penBorder, rectRbBorder); //Circle border
                }
                //Draw text
                graphics.DrawString(this.Text, this.Font, brushText,
                    rbBorderSize + 8, (this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2);//Y=Center
            }
        }
    }

}

using DataAccess;
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
    public partial class RegisterForm : Form
    {
        bool focusForPassword = false;
        bool focusForUsername = false;
        bool focusForRepeatPassword = false;
        bool focusForRecoveryAnswer = false;
        bool closedFromNotX = false;
        public RegisterForm()
        {
            InitializeComponent();
            cancelButton.FlatAppearance.BorderSize = 4;
            cancelButton.FlatAppearance.BorderColor = Color.Black;

            registerButton.FlatAppearance.BorderSize = 4;
            registerButton.FlatAppearance.BorderColor = Color.Black;

            recoveryQuestionCombobox.SelectedIndex = 0;
           
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            closedFromNotX = true;
            this.Close();
            Application.OpenForms[0].Show();
        }

        private void RegisterForm_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.FromArgb(150, 53, 41), 2);
            Graphics g = e.Graphics;
            if (focusForPassword)
            {
                g.DrawRectangle(p, new Rectangle(passwordTextbox.Location.X + 1,
                    passwordTextbox.Location.Y + 1, passwordTextbox.Width,
                    passwordTextbox.Height));
                usernameTextbox.BorderStyle = BorderStyle.FixedSingle;
                passwordTextbox.BorderStyle = BorderStyle.FixedSingle;
                recoveryAnswerTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (focusForUsername)
            {
                g.DrawRectangle(p, new Rectangle(usernameTextbox.Location.X + 1,
                    usernameTextbox.Location.Y + 1, usernameTextbox.Width,
                    usernameTextbox.Height));
                usernameTextbox.BorderStyle = BorderStyle.FixedSingle;
                passwordTextbox.BorderStyle = BorderStyle.FixedSingle;
                recoveryAnswerTextbox.BorderStyle = BorderStyle.FixedSingle;

            }
            else if (focusForRepeatPassword)
            {
                g.DrawRectangle(p, new Rectangle(repeatPasswordTextbox.Location.X + 1,
                    repeatPasswordTextbox.Location.Y + 1, repeatPasswordTextbox.Width,
                    repeatPasswordTextbox.Height));
                usernameTextbox.BorderStyle = BorderStyle.FixedSingle;
                passwordTextbox.BorderStyle = BorderStyle.FixedSingle;
                recoveryAnswerTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (focusForRecoveryAnswer)
            {
                g.DrawRectangle(p, new Rectangle(recoveryAnswerTextbox.Location.X + 1,
                    recoveryAnswerTextbox.Location.Y + 1, recoveryAnswerTextbox.Width,
                    recoveryAnswerTextbox.Height));
                usernameTextbox.BorderStyle = BorderStyle.FixedSingle;
                passwordTextbox.BorderStyle = BorderStyle.FixedSingle;
                repeatPasswordTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                repeatPasswordTextbox.BorderStyle = BorderStyle.FixedSingle;
                passwordTextbox.BorderStyle = BorderStyle.FixedSingle;
                usernameTextbox.BorderStyle = BorderStyle.FixedSingle;
                recoveryAnswerTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
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

        private void repeatPasswordTextbox_Enter(object sender, EventArgs e)
        {
            focusForRepeatPassword = true;
            this.Refresh();
        }

        private void repeatPasswordTextbox_Leave(object sender, EventArgs e)
        {
            focusForRepeatPassword = false;
            this.Refresh();
        }

        private void recoveryAnswerTextbox_Enter(object sender, EventArgs e)
        {

            focusForRecoveryAnswer = true;
            this.Refresh();
        }

        private void recoveryAnswerTextbox_Leave(object sender, EventArgs e)
        {
            focusForRecoveryAnswer = false;
            this.Refresh();
        }

        private void cancelButton_MouseEnter(object sender, EventArgs e)
        {
            cancelButton.FlatAppearance.BorderColor = Color.FromArgb(150, 53, 41);
            cancelButton.ForeColor = Color.FromArgb(150, 53, 41);
            cancelButton.BackColor = Color.Black;
        }

        private void cancelButton_MouseLeave(object sender, EventArgs e)
        {
            cancelButton.FlatAppearance.BorderColor = Color.Black;
            cancelButton.ForeColor = Color.Black;
            cancelButton.BackColor = Color.FromArgb(150, 53, 41);
        }

        private void cancelButton_Enter(object sender, EventArgs e)
        {
            cancelButton.FlatAppearance.BorderColor = Color.FromArgb(150, 53, 41);
            cancelButton.ForeColor = Color.FromArgb(150, 53, 41);
            cancelButton.BackColor = Color.Black;
        }

        private void cancelButton_Leave(object sender, EventArgs e)
        {
            cancelButton.FlatAppearance.BorderColor = Color.Black;
            cancelButton.ForeColor = Color.Black;
            cancelButton.BackColor = Color.FromArgb(150, 53, 41);
        }

        private void registerButton_MouseEnter(object sender, EventArgs e)
        {
            registerButton.FlatAppearance.BorderColor = Color.FromArgb(150, 53, 41);
            registerButton.ForeColor = Color.FromArgb(150, 53, 41);
            registerButton.BackColor = Color.Black;
        }

        private void registerButton_MouseLeave(object sender, EventArgs e)
        {
            registerButton.FlatAppearance.BorderColor = Color.Black;
            registerButton.ForeColor = Color.Black;
            registerButton.BackColor = Color.FromArgb(150, 53, 41);
        }

        private void registerButton_Enter(object sender, EventArgs e)
        {
            registerButton.FlatAppearance.BorderColor = Color.FromArgb(150, 53, 41);
            registerButton.ForeColor = Color.FromArgb(150, 53, 41);
            registerButton.BackColor = Color.Black;
        }

        private void registerButton_Leave(object sender, EventArgs e)
        {
            registerButton.FlatAppearance.BorderColor = Color.Black;
            registerButton.ForeColor = Color.Black;
            registerButton.BackColor = Color.FromArgb(150, 53, 41);
        }

        private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(!closedFromNotX)
            {
                Application.Exit();
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            bool valid = true;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("There are empty fields. Please fill the");
            if (usernameTextbox.Text == ""){
                stringBuilder.Append(" username field");
                valid = false;
            }
            if (passwordTextbox.Text == "")
            {
                if (!valid)
                    stringBuilder.Append(", the password field");
                else 
                    stringBuilder.Append(" password field");
                valid = false;
            }
            if(repeatPasswordTextbox.Text == "")
            {
                if (!valid)
                    stringBuilder.Append(", the repeat password field");
                else
                    stringBuilder.Append(" repeat password field");
                valid = false;
            }
            if(recoveryAnswerTextbox.Text == "")
            {
                //that means that other field before that was empty
                if (!valid)
                    stringBuilder.Append(" and the recovery question field");
                else
                    stringBuilder.Append(" recovery question field");
                valid = false;
            }

            if (!valid)
            {
                MessageBox.Show(stringBuilder.ToString(),"Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(passwordTextbox.Text != repeatPasswordTextbox.Text)
            {
                MessageBox.Show($"The password field and the repeat password field do not match.{Environment.NewLine}" +
                    $"Please make sure that they match.","Password Fields Do Not Match",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //that means that another user with that username exist
            if(DataAccessOperations.GetUser(usernameTextbox.Text).Username != null)
            {
                MessageBox.Show($"There is another user with that username. Please pick a different username",
                    "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            User user = new User();
            user.Username = usernameTextbox.Text;
            user.Password = passwordTextbox.Text;
            user.RecoveryQuestion = recoveryQuestionCombobox.Text;
            user.RecoveryAnswer = recoveryAnswerTextbox.Text;
            if (customerRadioButton.Checked)
                user.UserRole = "Customer";
            else
                user.UserRole = "Employee";

            DataAccessOperations.CreateUser(user);

            MessageBox.Show("Your account has been succesfully created!","Account Created Successfully!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Application.OpenForms[0].Show();
            closedFromNotX = true;
            this.Close();
        }
    }
}

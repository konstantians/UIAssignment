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
    public partial class ResetPasswordForm : Form
    {
        public User User { get; set; } = new User();
        bool focusForRecoveryAnswer = false;
        bool focusForPassword = false;
        bool focusForRepeatPassword = false;
        public ResetPasswordForm(User user)
        {
            InitializeComponent();
            User.Username = user.Username;
            User.Password = user.Password;
            User.RecoveryQuestion = user.RecoveryQuestion;
            User.RecoveryAnswer = user.RecoveryAnswer;
            User.UserRole = user.UserRole;

            usernameTextbox.Text = user.Username;
            recoveryQuestionLabel.Text = user.RecoveryQuestion;

            cancelButton.FlatAppearance.BorderSize = 4;
            cancelButton.FlatAppearance.BorderColor = Color.Black;

            confirmButton.FlatAppearance.BorderSize = 4;
            confirmButton.FlatAppearance.BorderColor = Color.Black;
        }

        private void ResetPasswordForm_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.FromArgb(150, 53, 41), 2);
            Graphics g = e.Graphics;
            if (focusForPassword)
            {
                g.DrawRectangle(p, new Rectangle(passwordTextbox.Location.X + 1,
                    passwordTextbox.Location.Y + 1, passwordTextbox.Width,
                    passwordTextbox.Height));
                passwordTextbox.BorderStyle = BorderStyle.FixedSingle;
                recoveryAnswerTextbox.BorderStyle = BorderStyle.FixedSingle;
                repeatPasswordTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (focusForRepeatPassword)
            {
                g.DrawRectangle(p, new Rectangle(repeatPasswordTextbox.Location.X + 1,
                    repeatPasswordTextbox.Location.Y + 1, repeatPasswordTextbox.Width,
                    repeatPasswordTextbox.Height));
                passwordTextbox.BorderStyle = BorderStyle.FixedSingle;
                recoveryAnswerTextbox.BorderStyle = BorderStyle.FixedSingle;
                repeatPasswordTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (focusForRecoveryAnswer)
            {
                g.DrawRectangle(p, new Rectangle(recoveryAnswerTextbox.Location.X + 1,
                    recoveryAnswerTextbox.Location.Y + 1, recoveryAnswerTextbox.Width,
                    recoveryAnswerTextbox.Height));
                passwordTextbox.BorderStyle = BorderStyle.FixedSingle;
                repeatPasswordTextbox.BorderStyle = BorderStyle.FixedSingle;
                recoveryAnswerTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                repeatPasswordTextbox.BorderStyle = BorderStyle.FixedSingle;
                passwordTextbox.BorderStyle = BorderStyle.FixedSingle;
                recoveryAnswerTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
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

        private void confirmButton_MouseEnter(object sender, EventArgs e)
        {
            confirmButton.FlatAppearance.BorderColor = Color.FromArgb(150, 53, 41);
            confirmButton.ForeColor = Color.FromArgb(150, 53, 41);
            confirmButton.BackColor = Color.Black;
        }

        private void confirmButton_MouseLeave(object sender, EventArgs e)
        {
            confirmButton.FlatAppearance.BorderColor = Color.Black;
            confirmButton.ForeColor = Color.Black;
            confirmButton.BackColor = Color.FromArgb(150, 53, 41);
        }

        private void confirmButton_Enter(object sender, EventArgs e)
        {
            confirmButton.FlatAppearance.BorderColor = Color.FromArgb(150, 53, 41);
            confirmButton.ForeColor = Color.FromArgb(150, 53, 41);
            confirmButton.BackColor = Color.Black;
        }

        private void confirmButton_Leave(object sender, EventArgs e)
        {
            confirmButton.FlatAppearance.BorderColor = Color.Black;
            confirmButton.ForeColor = Color.Black;
            confirmButton.BackColor = Color.FromArgb(150, 53, 41);
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            Application.OpenForms[0].Enabled = true;
            this.Close();
            Application.OpenForms[1].Close();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            bool valid = true;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("There are empty fields. Please fill the");

            if (recoveryAnswerTextbox.Text == "")
            {
                stringBuilder.Append(" recovery question field");
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
            if (repeatPasswordTextbox.Text == "")
            {
                if (!valid)
                    stringBuilder.Append(" and the repeat password field");
                else
                    stringBuilder.Append(" repeat password field");
                valid = false;
            }
            

            if (!valid)
            {
                MessageBox.Show(stringBuilder.ToString(), "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (passwordTextbox.Text != repeatPasswordTextbox.Text)
            {
                MessageBox.Show($"The password field and the repeat password field do not match.{Environment.NewLine}" +
                    $"Please make sure that they match.", "Password Fields Do Not Match", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(recoveryAnswerTextbox.Text != User.RecoveryAnswer)
            {
                MessageBox.Show($"This is not the correct recovery answer.{Environment.NewLine}" +
                    $"Please try again.", "False Recovery Answer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //else
            User.Password = passwordTextbox.Text;
            DataAccessOperations.UpdateUser(User);

            MessageBox.Show("Your password has been successfully updated.", "Successful Password Reset!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.OpenForms[0].Show();
            Application.OpenForms[0].Enabled = true;
            this.Close();
            Application.OpenForms[1].Close();
        }

        private void ResetPasswordForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Exit();
        }
    }
}
using DataAccess.Logic;
using DataAccess.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UIAssignment.Forms.CommonForms
{
    public partial class SmallUsernameDialogForm : Form
    {
        bool focusForUsername = false;
        public SmallUsernameDialogForm()
        {
            InitializeComponent();
            cancelButton.FlatAppearance.BorderSize = 4;
            cancelButton.FlatAppearance.BorderColor = Color.Black;

            confirmButton.FlatAppearance.BorderSize = 4;
            confirmButton.FlatAppearance.BorderColor = Color.Black;
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
            Application.OpenForms[0].Enabled = true;
            this.Close();
        }

        private void SmallUsernameDialogForm_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.FromArgb(150, 53, 41), 2);
            Graphics g = e.Graphics;
            if (focusForUsername)
            {
                g.DrawRectangle(p, new Rectangle(accountUsernameTextbox.Location.X + 1,
                    accountUsernameTextbox.Location.Y + 1, accountUsernameTextbox.Width,
                    accountUsernameTextbox.Height));
                accountUsernameTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
            else
            {
                accountUsernameTextbox.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void accountUsernameTextbox_Enter(object sender, EventArgs e)
        {
            focusForUsername = true;
        }

        private void accountUsernameTextbox_Leave(object sender, EventArgs e)
        {
            focusForUsername = false;
        }

        private void SmallUsernameDialogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
             Application.OpenForms[0].Enabled = true;
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if(accountUsernameTextbox.Text == "")
            {
                MessageBox.Show($"The username field is empty.{Environment.NewLine}Please type your username to continue.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if there is no account with the given username
            else if(UserDataAccess.GetUser(accountUsernameTextbox.Text).Item1 == null)
            {
                MessageBox.Show($"The username you have typed does not belong to any account.{Environment.NewLine}Please try again.", "Account Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                //TODO fix that
                User user = UserDataAccess.GetUser(accountUsernameTextbox.Text).Item1;
                this.Hide();
                Application.OpenForms[0].Hide();
                ResetPasswordForm resetPasswordForm = new ResetPasswordForm(user);
                resetPasswordForm.Show();
            }
        }
    }
}

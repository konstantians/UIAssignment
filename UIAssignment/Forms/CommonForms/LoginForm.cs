using DataAccess.Logic;
using DataAccess.Models;
using System;
using System.Drawing;
using System.Windows.Forms;
using UIAssignment.Forms.CustomerForms;


namespace UIAssignment.Forms.CommonForms
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
            if (usernameTextbox.Text.Trim() == "" && passwordTextbox.Text.Trim() == "")
            {
                MessageBox.Show("The username and password field are empty, please fill al the fields.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (usernameTextbox.Text.Trim() == "")
            {
                MessageBox.Show("The username field is empty, please fill al the fields.", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (passwordTextbox.Text.Trim() == "")
            {
                MessageBox.Show("The password field is empty, please fill al the fields.","Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(UserDataAccess.CheckTypeOfUser(usernameTextbox.Text.Trim()) == "Customer")
            {
                
                ActiveUser.Customer = (Customer)UserDataAccess.GetUser(usernameTextbox.Text).Item1;
                ActiveUser.User = ActiveUser.Customer;
            }
            else
            {
                ActiveUser.Employee = (Employee)UserDataAccess.GetUser(usernameTextbox.Text).Item1;
                ActiveUser.User = ActiveUser.Employee;   
            }

            if(ActiveUser.User == null)
            {
                MessageBox.Show("There is no account with the given username.","Account Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                usernameTextbox.Text = "";
                passwordTextbox.Text = "";
                customerRadioButton.Checked = true;
                employeeRadioButton.Checked = false;
                return;
            }
            else if(ActiveUser.User.Password != passwordTextbox.Text)
            {
                MessageBox.Show("Incorrect password or account type.","False Credentionals",MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextbox.Text = "";
                customerRadioButton.Checked = true;
                employeeRadioButton.Checked = false;
                return;
            }
            else if (ActiveUser.User.GetType() == typeof(Customer) && employeeRadioButton.Checked == true)
            {
                MessageBox.Show("Incorrect password or account type.","False Credentionals",MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextbox.Text = "";
                customerRadioButton.Checked = true;
                employeeRadioButton.Checked = false;
                return;
            }
            else if (ActiveUser.User.GetType() == typeof(Employee) && customerRadioButton.Checked == true)
            {
                MessageBox.Show("Incorrect password or account type.","False Credentionals", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordTextbox.Text = "";
                customerRadioButton.Checked = true;
                employeeRadioButton.Checked = false;
                return;
            }

            MessageBox.Show($"Welcome back {ActiveUser.User.Username}!");
            
            this.Hide();
            if (ActiveUser.Customer == null)
            {

            }
            else
            {
                SidebarCustomerForm mapForm = new SidebarCustomerForm();
                mapForm.Show();
            }
        }
    }
}

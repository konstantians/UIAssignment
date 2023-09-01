using UIAssignment.Forms.CommonForms;

namespace UIAssignment.Forms.CommonForms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.registerLabelFake = new System.Windows.Forms.Label();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.logoPicturebox = new System.Windows.Forms.PictureBox();
            this.accountTypeLabel = new System.Windows.Forms.Label();
            this.registerLabel = new System.Windows.Forms.Label();
            this.forgotPasswordLabel = new System.Windows.Forms.Label();
            this.employeeRadioButton = new UIAssignment.CustomRadioButton();
            this.customerRadioButton = new UIAssignment.CustomRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextbox.Location = new System.Drawing.Point(216, 215);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(292, 26);
            this.usernameTextbox.TabIndex = 0;
            this.usernameTextbox.Enter += new System.EventHandler(this.usernameTextbox_Enter);
            this.usernameTextbox.Leave += new System.EventHandler(this.usernameTextbox_Leave);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.Black;
            this.usernameLabel.Location = new System.Drawing.Point(212, 190);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(105, 22);
            this.usernameLabel.TabIndex = 2;
            this.usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.Color.Black;
            this.passwordLabel.Location = new System.Drawing.Point(212, 264);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(105, 22);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password";
            // 
            // signInButton
            // 
            this.signInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(41)))));
            this.signInButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signInButton.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInButton.ForeColor = System.Drawing.Color.Black;
            this.signInButton.Location = new System.Drawing.Point(278, 467);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(168, 47);
            this.signInButton.TabIndex = 3;
            this.signInButton.Text = "Sign In";
            this.signInButton.UseVisualStyleBackColor = false;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            this.signInButton.Enter += new System.EventHandler(this.signInButton_Enter);
            this.signInButton.Leave += new System.EventHandler(this.signInButton_Leave);
            this.signInButton.MouseEnter += new System.EventHandler(this.signInButton_MouseEnter);
            this.signInButton.MouseLeave += new System.EventHandler(this.signInButton_MouseLeave);
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextbox.Location = new System.Drawing.Point(216, 289);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(292, 26);
            this.passwordTextbox.TabIndex = 1;
            this.passwordTextbox.Enter += new System.EventHandler(this.passwordTextbox_Enter);
            this.passwordTextbox.Leave += new System.EventHandler(this.passwordTextbox_Leave);
            // 
            // registerLabelFake
            // 
            this.registerLabelFake.AutoSize = true;
            this.registerLabelFake.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(217)))), ((int)(((byte)(194)))));
            this.registerLabelFake.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.registerLabelFake.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerLabelFake.ForeColor = System.Drawing.Color.Black;
            this.registerLabelFake.Location = new System.Drawing.Point(224, 551);
            this.registerLabelFake.Name = "registerLabelFake";
            this.registerLabelFake.Size = new System.Drawing.Size(274, 18);
            this.registerLabelFake.TabIndex = 4;
            this.registerLabelFake.Text = "Do you not have an account yet?";
            // 
            // rightPanel
            // 
            this.rightPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rightPanel.BackgroundImage")));
            this.rightPanel.Location = new System.Drawing.Point(635, 12);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(77, 584);
            this.rightPanel.TabIndex = 11;
            // 
            // leftPanel
            // 
            this.leftPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftPanel.BackgroundImage")));
            this.leftPanel.Location = new System.Drawing.Point(12, 12);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(77, 584);
            this.leftPanel.TabIndex = 10;
            // 
            // logoPicturebox
            // 
            this.logoPicturebox.BackgroundImage = global::UIAssignment.Properties.Resources.potentional_logo;
            this.logoPicturebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPicturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logoPicturebox.Location = new System.Drawing.Point(278, 12);
            this.logoPicturebox.Name = "logoPicturebox";
            this.logoPicturebox.Size = new System.Drawing.Size(168, 143);
            this.logoPicturebox.TabIndex = 3;
            this.logoPicturebox.TabStop = false;
            // 
            // accountTypeLabel
            // 
            this.accountTypeLabel.AutoSize = true;
            this.accountTypeLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountTypeLabel.ForeColor = System.Drawing.Color.Black;
            this.accountTypeLabel.Location = new System.Drawing.Point(212, 346);
            this.accountTypeLabel.Name = "accountTypeLabel";
            this.accountTypeLabel.Size = new System.Drawing.Size(148, 22);
            this.accountTypeLabel.TabIndex = 12;
            this.accountTypeLabel.Text = "Account Type";
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(217)))), ((int)(((byte)(194)))));
            this.registerLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerLabel.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(41)))));
            this.registerLabel.Location = new System.Drawing.Point(305, 578);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(116, 18);
            this.registerLabel.TabIndex = 14;
            this.registerLabel.Text = "Sign Up Here!";
            this.registerLabel.Click += new System.EventHandler(this.registerLabel_Click);
            this.registerLabel.MouseEnter += new System.EventHandler(this.registerLabel_MouseEnter);
            this.registerLabel.MouseLeave += new System.EventHandler(this.registerLabel_MouseLeave);
            // 
            // forgotPasswordLabel
            // 
            this.forgotPasswordLabel.AutoSize = true;
            this.forgotPasswordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(217)))), ((int)(((byte)(194)))));
            this.forgotPasswordLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forgotPasswordLabel.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forgotPasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(41)))));
            this.forgotPasswordLabel.Location = new System.Drawing.Point(213, 407);
            this.forgotPasswordLabel.Name = "forgotPasswordLabel";
            this.forgotPasswordLabel.Size = new System.Drawing.Size(154, 18);
            this.forgotPasswordLabel.TabIndex = 15;
            this.forgotPasswordLabel.Text = "Forgot Password?";
            this.forgotPasswordLabel.Click += new System.EventHandler(this.forgotPasswordLabel_Click);
            this.forgotPasswordLabel.MouseEnter += new System.EventHandler(this.forgotPasswordLabel_MouseEnter);
            this.forgotPasswordLabel.MouseLeave += new System.EventHandler(this.forgotPasswordLabel_MouseLeave);
            // 
            // employeeRadioButton
            // 
            this.employeeRadioButton.AutoSize = true;
            this.employeeRadioButton.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(41)))));
            this.employeeRadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.employeeRadioButton.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeRadioButton.Location = new System.Drawing.Point(364, 371);
            this.employeeRadioButton.Name = "employeeRadioButton";
            this.employeeRadioButton.Size = new System.Drawing.Size(105, 22);
            this.employeeRadioButton.TabIndex = 3;
            this.employeeRadioButton.Text = "Employee";
            this.employeeRadioButton.UnCheckedColor = System.Drawing.Color.Black;
            this.employeeRadioButton.UseVisualStyleBackColor = true;
            // 
            // customerRadioButton
            // 
            this.customerRadioButton.AutoSize = true;
            this.customerRadioButton.Checked = true;
            this.customerRadioButton.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(41)))));
            this.customerRadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.customerRadioButton.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerRadioButton.Location = new System.Drawing.Point(216, 371);
            this.customerRadioButton.Name = "customerRadioButton";
            this.customerRadioButton.Size = new System.Drawing.Size(106, 22);
            this.customerRadioButton.TabIndex = 2;
            this.customerRadioButton.TabStop = true;
            this.customerRadioButton.Text = "Customer";
            this.customerRadioButton.UnCheckedColor = System.Drawing.Color.Black;
            this.customerRadioButton.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(217)))), ((int)(((byte)(194)))));
            this.ClientSize = new System.Drawing.Size(724, 608);
            this.Controls.Add(this.forgotPasswordLabel);
            this.Controls.Add(this.registerLabel);
            this.Controls.Add(this.accountTypeLabel);
            this.Controls.Add(this.employeeRadioButton);
            this.Controls.Add(this.customerRadioButton);
            this.Controls.Add(this.registerLabelFake);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.logoPicturebox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.usernameTextbox);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.PictureBox logoPicturebox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Label registerLabelFake;
        private CustomRadioButton customerRadioButton;
        private CustomRadioButton employeeRadioButton;
        private System.Windows.Forms.Label accountTypeLabel;
        private System.Windows.Forms.Label registerLabel;
        private System.Windows.Forms.Label forgotPasswordLabel;
    }
}
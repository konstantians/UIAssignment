
namespace UIAssignment.Forms.CommonForms
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.repeatPasswordLabel = new System.Windows.Forms.Label();
            this.repeatPasswordTextbox = new System.Windows.Forms.TextBox();
            this.accountTypeLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.registerButton = new System.Windows.Forms.Button();
            this.recoveryQuestionLabel = new System.Windows.Forms.Label();
            this.recoveryAnswerLabel = new System.Windows.Forms.Label();
            this.recoveryAnswerTextbox = new System.Windows.Forms.TextBox();
            this.recoveryQuestionCombobox = new System.Windows.Forms.ComboBox();
            this.logoPicturebox = new System.Windows.Forms.PictureBox();
            this.employeeRadioButton = new UIAssignment.CustomRadioButton();
            this.customerRadioButton = new UIAssignment.CustomRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftPanel.BackgroundImage")));
            this.leftPanel.Location = new System.Drawing.Point(12, 12);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(77, 542);
            this.leftPanel.TabIndex = 11;
            // 
            // rightPanel
            // 
            this.rightPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("rightPanel.BackgroundImage")));
            this.rightPanel.Location = new System.Drawing.Point(635, 12);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(77, 542);
            this.rightPanel.TabIndex = 12;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.Black;
            this.usernameLabel.Location = new System.Drawing.Point(109, 180);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(161, 22);
            this.usernameLabel.TabIndex = 14;
            this.usernameLabel.Text = "Enter Username";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextbox.Location = new System.Drawing.Point(113, 205);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(222, 26);
            this.usernameTextbox.TabIndex = 1;
            this.usernameTextbox.Enter += new System.EventHandler(this.usernameTextbox_Enter);
            this.usernameTextbox.Leave += new System.EventHandler(this.usernameTextbox_Leave);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.Color.Black;
            this.passwordLabel.Location = new System.Drawing.Point(109, 270);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(164, 22);
            this.passwordLabel.TabIndex = 16;
            this.passwordLabel.Text = "Enter Password";
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextbox.Location = new System.Drawing.Point(113, 295);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(222, 26);
            this.passwordTextbox.TabIndex = 2;
            this.passwordTextbox.Enter += new System.EventHandler(this.passwordTextbox_Enter);
            this.passwordTextbox.Leave += new System.EventHandler(this.passwordTextbox_Leave);
            // 
            // repeatPasswordLabel
            // 
            this.repeatPasswordLabel.AutoSize = true;
            this.repeatPasswordLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatPasswordLabel.ForeColor = System.Drawing.Color.Black;
            this.repeatPasswordLabel.Location = new System.Drawing.Point(109, 365);
            this.repeatPasswordLabel.Name = "repeatPasswordLabel";
            this.repeatPasswordLabel.Size = new System.Drawing.Size(179, 22);
            this.repeatPasswordLabel.TabIndex = 18;
            this.repeatPasswordLabel.Text = "Repeat Password";
            // 
            // repeatPasswordTextbox
            // 
            this.repeatPasswordTextbox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatPasswordTextbox.Location = new System.Drawing.Point(113, 390);
            this.repeatPasswordTextbox.Name = "repeatPasswordTextbox";
            this.repeatPasswordTextbox.Size = new System.Drawing.Size(222, 26);
            this.repeatPasswordTextbox.TabIndex = 3;
            this.repeatPasswordTextbox.Enter += new System.EventHandler(this.repeatPasswordTextbox_Enter);
            this.repeatPasswordTextbox.Leave += new System.EventHandler(this.repeatPasswordTextbox_Leave);
            // 
            // accountTypeLabel
            // 
            this.accountTypeLabel.AutoSize = true;
            this.accountTypeLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountTypeLabel.ForeColor = System.Drawing.Color.Black;
            this.accountTypeLabel.Location = new System.Drawing.Point(388, 365);
            this.accountTypeLabel.Name = "accountTypeLabel";
            this.accountTypeLabel.Size = new System.Drawing.Size(148, 22);
            this.accountTypeLabel.TabIndex = 21;
            this.accountTypeLabel.Text = "Account Type";
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(41)))));
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(213, 506);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(122, 47);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            this.cancelButton.Enter += new System.EventHandler(this.cancelButton_Enter);
            this.cancelButton.Leave += new System.EventHandler(this.cancelButton_Leave);
            this.cancelButton.MouseEnter += new System.EventHandler(this.cancelButton_MouseEnter);
            this.cancelButton.MouseLeave += new System.EventHandler(this.cancelButton_MouseLeave);
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(41)))));
            this.registerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerButton.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.ForeColor = System.Drawing.Color.Black;
            this.registerButton.Location = new System.Drawing.Point(376, 506);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(122, 47);
            this.registerButton.TabIndex = 9;
            this.registerButton.Text = "Sign Up";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            this.registerButton.Enter += new System.EventHandler(this.registerButton_Enter);
            this.registerButton.Leave += new System.EventHandler(this.registerButton_Leave);
            this.registerButton.MouseEnter += new System.EventHandler(this.registerButton_MouseEnter);
            this.registerButton.MouseLeave += new System.EventHandler(this.registerButton_MouseLeave);
            // 
            // recoveryQuestionLabel
            // 
            this.recoveryQuestionLabel.AutoSize = true;
            this.recoveryQuestionLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoveryQuestionLabel.ForeColor = System.Drawing.Color.Black;
            this.recoveryQuestionLabel.Location = new System.Drawing.Point(388, 180);
            this.recoveryQuestionLabel.Name = "recoveryQuestionLabel";
            this.recoveryQuestionLabel.Size = new System.Drawing.Size(199, 22);
            this.recoveryQuestionLabel.TabIndex = 25;
            this.recoveryQuestionLabel.Text = "Recovery Question";
            // 
            // recoveryAnswerLabel
            // 
            this.recoveryAnswerLabel.AutoSize = true;
            this.recoveryAnswerLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoveryAnswerLabel.ForeColor = System.Drawing.Color.Black;
            this.recoveryAnswerLabel.Location = new System.Drawing.Point(388, 270);
            this.recoveryAnswerLabel.Name = "recoveryAnswerLabel";
            this.recoveryAnswerLabel.Size = new System.Drawing.Size(182, 22);
            this.recoveryAnswerLabel.TabIndex = 27;
            this.recoveryAnswerLabel.Text = "Recovery Answer";
            // 
            // recoveryAnswerTextbox
            // 
            this.recoveryAnswerTextbox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoveryAnswerTextbox.Location = new System.Drawing.Point(392, 295);
            this.recoveryAnswerTextbox.Name = "recoveryAnswerTextbox";
            this.recoveryAnswerTextbox.Size = new System.Drawing.Size(222, 26);
            this.recoveryAnswerTextbox.TabIndex = 5;
            this.recoveryAnswerTextbox.Enter += new System.EventHandler(this.recoveryAnswerTextbox_Enter);
            this.recoveryAnswerTextbox.Leave += new System.EventHandler(this.recoveryAnswerTextbox_Leave);
            // 
            // recoveryQuestionCombobox
            // 
            this.recoveryQuestionCombobox.BackColor = System.Drawing.Color.White;
            this.recoveryQuestionCombobox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoveryQuestionCombobox.FormattingEnabled = true;
            this.recoveryQuestionCombobox.Items.AddRange(new object[] {
            "Who is your best friend?",
            "What is your nickname?",
            "What is your favourite food?",
            "What is your favourite sport?"});
            this.recoveryQuestionCombobox.Location = new System.Drawing.Point(392, 205);
            this.recoveryQuestionCombobox.Name = "recoveryQuestionCombobox";
            this.recoveryQuestionCombobox.Size = new System.Drawing.Size(222, 28);
            this.recoveryQuestionCombobox.TabIndex = 4;
            // 
            // logoPicturebox
            // 
            this.logoPicturebox.BackColor = System.Drawing.Color.White;
            this.logoPicturebox.BackgroundImage = global::UIAssignment.Properties.Resources.TranspareWithoutTextLogo;
            this.logoPicturebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPicturebox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logoPicturebox.Location = new System.Drawing.Point(250, 12);
            this.logoPicturebox.Name = "logoPicturebox";
            this.logoPicturebox.Size = new System.Drawing.Size(220, 143);
            this.logoPicturebox.TabIndex = 28;
            this.logoPicturebox.TabStop = false;
            // 
            // employeeRadioButton
            // 
            this.employeeRadioButton.AutoSize = true;
            this.employeeRadioButton.CheckedColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(41)))));
            this.employeeRadioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.employeeRadioButton.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.employeeRadioButton.Location = new System.Drawing.Point(509, 394);
            this.employeeRadioButton.Name = "employeeRadioButton";
            this.employeeRadioButton.Size = new System.Drawing.Size(105, 22);
            this.employeeRadioButton.TabIndex = 7;
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
            this.customerRadioButton.Location = new System.Drawing.Point(392, 394);
            this.customerRadioButton.Name = "customerRadioButton";
            this.customerRadioButton.Size = new System.Drawing.Size(106, 22);
            this.customerRadioButton.TabIndex = 6;
            this.customerRadioButton.TabStop = true;
            this.customerRadioButton.Text = "Customer";
            this.customerRadioButton.UnCheckedColor = System.Drawing.Color.Black;
            this.customerRadioButton.UseVisualStyleBackColor = true;
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(217)))), ((int)(((byte)(194)))));
            this.ClientSize = new System.Drawing.Size(724, 566);
            this.Controls.Add(this.logoPicturebox);
            this.Controls.Add(this.recoveryQuestionCombobox);
            this.Controls.Add(this.recoveryAnswerTextbox);
            this.Controls.Add(this.recoveryAnswerLabel);
            this.Controls.Add(this.recoveryQuestionLabel);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.employeeRadioButton);
            this.Controls.Add(this.accountTypeLabel);
            this.Controls.Add(this.customerRadioButton);
            this.Controls.Add(this.repeatPasswordTextbox);
            this.Controls.Add(this.repeatPasswordLabel);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RegisterForm_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RegisterForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Label repeatPasswordLabel;
        private System.Windows.Forms.TextBox repeatPasswordTextbox;
        private CustomRadioButton customerRadioButton;
        private System.Windows.Forms.Label accountTypeLabel;
        private CustomRadioButton employeeRadioButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Label recoveryQuestionLabel;
        private System.Windows.Forms.Label recoveryAnswerLabel;
        private System.Windows.Forms.TextBox recoveryAnswerTextbox;
        private System.Windows.Forms.ComboBox recoveryQuestionCombobox;
        private System.Windows.Forms.PictureBox logoPicturebox;
    }
}
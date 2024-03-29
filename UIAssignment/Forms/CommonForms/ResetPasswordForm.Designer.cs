﻿
namespace UIAssignment.Forms.CommonForms
{
    partial class ResetPasswordForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPasswordForm));
            this.leftPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.repeatPasswordLabel = new System.Windows.Forms.Label();
            this.repeatPasswordTextbox = new System.Windows.Forms.TextBox();
            this.recoveryQuestionLabel = new System.Windows.Forms.Label();
            this.recoveryAnswerTextbox = new System.Windows.Forms.TextBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.logoPicturebox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("leftPanel.BackgroundImage")));
            this.leftPanel.Location = new System.Drawing.Point(12, 12);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(77, 560);
            this.leftPanel.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(635, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(77, 560);
            this.panel1.TabIndex = 13;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.ForeColor = System.Drawing.Color.Black;
            this.passwordLabel.Location = new System.Drawing.Point(209, 346);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(164, 22);
            this.passwordLabel.TabIndex = 17;
            this.passwordLabel.Text = "Enter Password";
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextbox.Location = new System.Drawing.Point(213, 371);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.Size = new System.Drawing.Size(292, 26);
            this.passwordTextbox.TabIndex = 2;
            this.passwordTextbox.Enter += new System.EventHandler(this.passwordTextbox_Enter);
            this.passwordTextbox.Leave += new System.EventHandler(this.passwordTextbox_Leave);
            // 
            // repeatPasswordLabel
            // 
            this.repeatPasswordLabel.AutoSize = true;
            this.repeatPasswordLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatPasswordLabel.ForeColor = System.Drawing.Color.Black;
            this.repeatPasswordLabel.Location = new System.Drawing.Point(209, 434);
            this.repeatPasswordLabel.Name = "repeatPasswordLabel";
            this.repeatPasswordLabel.Size = new System.Drawing.Size(179, 22);
            this.repeatPasswordLabel.TabIndex = 19;
            this.repeatPasswordLabel.Text = "Repeat Password";
            // 
            // repeatPasswordTextbox
            // 
            this.repeatPasswordTextbox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repeatPasswordTextbox.Location = new System.Drawing.Point(213, 459);
            this.repeatPasswordTextbox.Name = "repeatPasswordTextbox";
            this.repeatPasswordTextbox.Size = new System.Drawing.Size(292, 26);
            this.repeatPasswordTextbox.TabIndex = 3;
            this.repeatPasswordTextbox.Enter += new System.EventHandler(this.repeatPasswordTextbox_Enter);
            this.repeatPasswordTextbox.Leave += new System.EventHandler(this.repeatPasswordTextbox_Leave);
            // 
            // recoveryQuestionLabel
            // 
            this.recoveryQuestionLabel.AutoSize = true;
            this.recoveryQuestionLabel.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoveryQuestionLabel.ForeColor = System.Drawing.Color.Black;
            this.recoveryQuestionLabel.Location = new System.Drawing.Point(209, 264);
            this.recoveryQuestionLabel.Name = "recoveryQuestionLabel";
            this.recoveryQuestionLabel.Size = new System.Drawing.Size(16, 22);
            this.recoveryQuestionLabel.TabIndex = 26;
            this.recoveryQuestionLabel.Text = "-";
            // 
            // recoveryAnswerTextbox
            // 
            this.recoveryAnswerTextbox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoveryAnswerTextbox.Location = new System.Drawing.Point(213, 289);
            this.recoveryAnswerTextbox.Name = "recoveryAnswerTextbox";
            this.recoveryAnswerTextbox.Size = new System.Drawing.Size(292, 26);
            this.recoveryAnswerTextbox.TabIndex = 1;
            this.recoveryAnswerTextbox.Enter += new System.EventHandler(this.recoveryAnswerTextbox_Enter);
            this.recoveryAnswerTextbox.Leave += new System.EventHandler(this.recoveryAnswerTextbox_Leave);
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(41)))));
            this.confirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmButton.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.ForeColor = System.Drawing.Color.Black;
            this.confirmButton.Location = new System.Drawing.Point(383, 525);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(122, 47);
            this.confirmButton.TabIndex = 5;
            this.confirmButton.Text = "Confirn";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            this.confirmButton.Enter += new System.EventHandler(this.confirmButton_Enter);
            this.confirmButton.Leave += new System.EventHandler(this.confirmButton_Leave);
            this.confirmButton.MouseEnter += new System.EventHandler(this.confirmButton_MouseEnter);
            this.confirmButton.MouseLeave += new System.EventHandler(this.confirmButton_MouseLeave);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.ForeColor = System.Drawing.Color.Black;
            this.usernameLabel.Location = new System.Drawing.Point(209, 180);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(105, 22);
            this.usernameLabel.TabIndex = 30;
            this.usernameLabel.Text = "Username";
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Enabled = false;
            this.usernameTextbox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextbox.Location = new System.Drawing.Point(213, 205);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.ReadOnly = true;
            this.usernameTextbox.Size = new System.Drawing.Size(292, 26);
            this.usernameTextbox.TabIndex = 31;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(41)))));
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(213, 525);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(122, 47);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            this.cancelButton.Enter += new System.EventHandler(this.cancelButton_Enter);
            this.cancelButton.Leave += new System.EventHandler(this.cancelButton_Leave);
            this.cancelButton.MouseEnter += new System.EventHandler(this.cancelButton_MouseEnter);
            this.cancelButton.MouseLeave += new System.EventHandler(this.cancelButton_MouseLeave);
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
            this.logoPicturebox.TabIndex = 32;
            this.logoPicturebox.TabStop = false;
            // 
            // ResetPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(217)))), ((int)(((byte)(194)))));
            this.ClientSize = new System.Drawing.Size(724, 586);
            this.Controls.Add(this.logoPicturebox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.usernameTextbox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.recoveryAnswerTextbox);
            this.Controls.Add(this.recoveryQuestionLabel);
            this.Controls.Add(this.repeatPasswordTextbox);
            this.Controls.Add(this.repeatPasswordLabel);
            this.Controls.Add(this.passwordTextbox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.leftPanel);
            this.Name = "ResetPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResetPasswordForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ResetPasswordForm_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ResetPasswordForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.logoPicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Label repeatPasswordLabel;
        private System.Windows.Forms.TextBox repeatPasswordTextbox;
        private System.Windows.Forms.Label recoveryQuestionLabel;
        private System.Windows.Forms.TextBox recoveryAnswerTextbox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.PictureBox logoPicturebox;
    }
}
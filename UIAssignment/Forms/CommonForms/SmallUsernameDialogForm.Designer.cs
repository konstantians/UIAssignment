
namespace UIAssignment.Forms.CommonForms
{
    partial class SmallUsernameDialogForm
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
            this.accountUsernameLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.accountUsernameTextbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // accountUsernameLabel
            // 
            this.accountUsernameLabel.AutoSize = true;
            this.accountUsernameLabel.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountUsernameLabel.ForeColor = System.Drawing.Color.Black;
            this.accountUsernameLabel.Location = new System.Drawing.Point(46, 9);
            this.accountUsernameLabel.Name = "accountUsernameLabel";
            this.accountUsernameLabel.Size = new System.Drawing.Size(315, 22);
            this.accountUsernameLabel.TabIndex = 15;
            this.accountUsernameLabel.Text = "Type Your Account\'s Username";
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(41)))));
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(16, 94);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(143, 47);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            this.cancelButton.Enter += new System.EventHandler(this.cancelButton_Enter);
            this.cancelButton.Leave += new System.EventHandler(this.cancelButton_Leave);
            this.cancelButton.MouseEnter += new System.EventHandler(this.cancelButton_MouseEnter);
            this.cancelButton.MouseLeave += new System.EventHandler(this.cancelButton_MouseLeave);
            // 
            // confirmButton
            // 
            this.confirmButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(53)))), ((int)(((byte)(41)))));
            this.confirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.confirmButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.confirmButton.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmButton.ForeColor = System.Drawing.Color.Black;
            this.confirmButton.Location = new System.Drawing.Point(252, 94);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(142, 47);
            this.confirmButton.TabIndex = 3;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = false;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            this.confirmButton.Enter += new System.EventHandler(this.confirmButton_Enter);
            this.confirmButton.Leave += new System.EventHandler(this.confirmButton_Leave);
            this.confirmButton.MouseEnter += new System.EventHandler(this.confirmButton_MouseEnter);
            this.confirmButton.MouseLeave += new System.EventHandler(this.confirmButton_MouseLeave);
            // 
            // accountUsernameTextbox
            // 
            this.accountUsernameTextbox.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountUsernameTextbox.Location = new System.Drawing.Point(16, 46);
            this.accountUsernameTextbox.Name = "accountUsernameTextbox";
            this.accountUsernameTextbox.Size = new System.Drawing.Size(378, 26);
            this.accountUsernameTextbox.TabIndex = 1;
            this.accountUsernameTextbox.Enter += new System.EventHandler(this.accountUsernameTextbox_Enter);
            this.accountUsernameTextbox.Leave += new System.EventHandler(this.accountUsernameTextbox_Leave);
            // 
            // SmallUsernameDialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(217)))), ((int)(((byte)(194)))));
            this.ClientSize = new System.Drawing.Size(406, 154);
            this.Controls.Add(this.accountUsernameTextbox);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.accountUsernameLabel);
            this.Name = "SmallUsernameDialogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SmallUsernameDialogForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SmallUsernameDialogForm_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SmallUsernameDialogForm_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label accountUsernameLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.TextBox accountUsernameTextbox;
    }
}
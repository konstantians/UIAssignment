
namespace UIAssignment
{
    partial class MapForm
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
            this.menuFormLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // menuFormLabel
            // 
            this.menuFormLabel.AutoSize = true;
            this.menuFormLabel.Font = new System.Drawing.Font("Lucida Bright", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuFormLabel.Location = new System.Drawing.Point(350, 27);
            this.menuFormLabel.Name = "menuFormLabel";
            this.menuFormLabel.Size = new System.Drawing.Size(119, 22);
            this.menuFormLabel.TabIndex = 0;
            this.menuFormLabel.Text = "Menu Form";
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(217)))), ((int)(((byte)(194)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuFormLabel);
            this.Name = "MapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MapForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label menuFormLabel;
    }
}
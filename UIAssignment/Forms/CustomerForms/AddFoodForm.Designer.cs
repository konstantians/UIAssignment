namespace UIAssignment.Forms.CustomerForms
{
    partial class AddFoodForm
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
            this.addToCartButton = new UIAssignment.Resources.Cool_button();
            this.minusFoodButton = new UIAssignment.Resources.Cool_button();
            this.plusFoodButton = new UIAssignment.Resources.Cool_button();
            this.counterFoodLabel = new System.Windows.Forms.Label();
            this.foodImagePictureBox = new System.Windows.Forms.PictureBox();
            this.foodDeliveryTimeValueLabel = new System.Windows.Forms.Label();
            this.foodIngredientsValueLabel = new System.Windows.Forms.Label();
            this.foodPriceValueLabel = new System.Windows.Forms.Label();
            this.foodTitleValueLabel = new System.Windows.Forms.Label();
            this.foodTitleLabel = new System.Windows.Forms.Label();
            this.foodIngredientsLabel = new System.Windows.Forms.Label();
            this.foodDeliveryTimeLabel = new System.Windows.Forms.Label();
            this.foodPriceLabel = new System.Windows.Forms.Label();
            this.foodFinalPriceLabel = new System.Windows.Forms.Label();
            this.foodFinalPriceValueLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.foodImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // addToCartButton
            // 
            this.addToCartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addToCartButton.BackColor = System.Drawing.Color.Transparent;
            this.addToCartButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.addToCartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addToCartButton.BorderColor = System.Drawing.Color.Black;
            this.addToCartButton.BorderRadius = 0;
            this.addToCartButton.BorderSize = 3;
            this.addToCartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addToCartButton.FlatAppearance.BorderSize = 0;
            this.addToCartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addToCartButton.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addToCartButton.ForeColor = System.Drawing.Color.Black;
            this.addToCartButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addToCartButton.Location = new System.Drawing.Point(212, 357);
            this.addToCartButton.Margin = new System.Windows.Forms.Padding(2);
            this.addToCartButton.Name = "addToCartButton";
            this.addToCartButton.Size = new System.Drawing.Size(190, 35);
            this.addToCartButton.TabIndex = 13;
            this.addToCartButton.Text = "Προσθήκη Στο Καλάθι";
            this.addToCartButton.TextColor = System.Drawing.Color.Black;
            this.addToCartButton.UseVisualStyleBackColor = false;
            this.addToCartButton.Click += new System.EventHandler(this.addToCartButton_Click_1);
            // 
            // minusFoodButton
            // 
            this.minusFoodButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.minusFoodButton.BackColor = System.Drawing.Color.Transparent;
            this.minusFoodButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.minusFoodButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.minusFoodButton.BorderColor = System.Drawing.Color.Black;
            this.minusFoodButton.BorderRadius = 0;
            this.minusFoodButton.BorderSize = 3;
            this.minusFoodButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minusFoodButton.FlatAppearance.BorderSize = 0;
            this.minusFoodButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minusFoodButton.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minusFoodButton.ForeColor = System.Drawing.Color.Black;
            this.minusFoodButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.minusFoodButton.Location = new System.Drawing.Point(12, 358);
            this.minusFoodButton.Margin = new System.Windows.Forms.Padding(2);
            this.minusFoodButton.Name = "minusFoodButton";
            this.minusFoodButton.Size = new System.Drawing.Size(35, 35);
            this.minusFoodButton.TabIndex = 15;
            this.minusFoodButton.Text = "-";
            this.minusFoodButton.TextColor = System.Drawing.Color.Black;
            this.minusFoodButton.UseVisualStyleBackColor = false;
            this.minusFoodButton.Click += new System.EventHandler(this.minusFoodButton_Click);
            // 
            // plusFoodButton
            // 
            this.plusFoodButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.plusFoodButton.BackColor = System.Drawing.Color.Transparent;
            this.plusFoodButton.BackgroundColor = System.Drawing.Color.Transparent;
            this.plusFoodButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.plusFoodButton.BorderColor = System.Drawing.Color.Black;
            this.plusFoodButton.BorderRadius = 0;
            this.plusFoodButton.BorderSize = 3;
            this.plusFoodButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.plusFoodButton.FlatAppearance.BorderSize = 0;
            this.plusFoodButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.plusFoodButton.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plusFoodButton.ForeColor = System.Drawing.Color.Black;
            this.plusFoodButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.plusFoodButton.Location = new System.Drawing.Point(71, 358);
            this.plusFoodButton.Margin = new System.Windows.Forms.Padding(2);
            this.plusFoodButton.Name = "plusFoodButton";
            this.plusFoodButton.Size = new System.Drawing.Size(35, 35);
            this.plusFoodButton.TabIndex = 16;
            this.plusFoodButton.Text = "+";
            this.plusFoodButton.TextColor = System.Drawing.Color.Black;
            this.plusFoodButton.UseVisualStyleBackColor = false;
            this.plusFoodButton.Click += new System.EventHandler(this.plusFoodButton_Click);
            // 
            // counterFoodLabel
            // 
            this.counterFoodLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.counterFoodLabel.AutoSize = true;
            this.counterFoodLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterFoodLabel.Location = new System.Drawing.Point(52, 367);
            this.counterFoodLabel.Name = "counterFoodLabel";
            this.counterFoodLabel.Size = new System.Drawing.Size(14, 16);
            this.counterFoodLabel.TabIndex = 17;
            this.counterFoodLabel.Text = "1";
            // 
            // foodImagePictureBox
            // 
            this.foodImagePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.foodImagePictureBox.BackgroundImage = global::UIAssignment.Properties.Resources.ΛουκάνικοΧωριάτικοΜερίδαBigger;
            this.foodImagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.foodImagePictureBox.Location = new System.Drawing.Point(12, 12);
            this.foodImagePictureBox.Name = "foodImagePictureBox";
            this.foodImagePictureBox.Size = new System.Drawing.Size(390, 182);
            this.foodImagePictureBox.TabIndex = 14;
            this.foodImagePictureBox.TabStop = false;
            // 
            // foodDeliveryTimeValueLabel
            // 
            this.foodDeliveryTimeValueLabel.AutoSize = true;
            this.foodDeliveryTimeValueLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodDeliveryTimeValueLabel.Location = new System.Drawing.Point(80, 301);
            this.foodDeliveryTimeValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.foodDeliveryTimeValueLabel.Name = "foodDeliveryTimeValueLabel";
            this.foodDeliveryTimeValueLabel.Size = new System.Drawing.Size(87, 16);
            this.foodDeliveryTimeValueLabel.TabIndex = 90;
            this.foodDeliveryTimeValueLabel.Text = "Placeholder";
            // 
            // foodIngredientsValueLabel
            // 
            this.foodIngredientsValueLabel.AutoSize = true;
            this.foodIngredientsValueLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodIngredientsValueLabel.Location = new System.Drawing.Point(80, 262);
            this.foodIngredientsValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.foodIngredientsValueLabel.Name = "foodIngredientsValueLabel";
            this.foodIngredientsValueLabel.Size = new System.Drawing.Size(87, 16);
            this.foodIngredientsValueLabel.TabIndex = 89;
            this.foodIngredientsValueLabel.Text = "Placeholder";
            // 
            // foodPriceValueLabel
            // 
            this.foodPriceValueLabel.AutoSize = true;
            this.foodPriceValueLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodPriceValueLabel.Location = new System.Drawing.Point(80, 236);
            this.foodPriceValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.foodPriceValueLabel.Name = "foodPriceValueLabel";
            this.foodPriceValueLabel.Size = new System.Drawing.Size(87, 16);
            this.foodPriceValueLabel.TabIndex = 88;
            this.foodPriceValueLabel.Text = "Placeholder";
            // 
            // foodTitleValueLabel
            // 
            this.foodTitleValueLabel.AutoSize = true;
            this.foodTitleValueLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodTitleValueLabel.Location = new System.Drawing.Point(81, 209);
            this.foodTitleValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.foodTitleValueLabel.Name = "foodTitleValueLabel";
            this.foodTitleValueLabel.Size = new System.Drawing.Size(87, 16);
            this.foodTitleValueLabel.TabIndex = 87;
            this.foodTitleValueLabel.Text = "Placeholder";
            // 
            // foodTitleLabel
            // 
            this.foodTitleLabel.AutoSize = true;
            this.foodTitleLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodTitleLabel.Location = new System.Drawing.Point(12, 209);
            this.foodTitleLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.foodTitleLabel.Name = "foodTitleLabel";
            this.foodTitleLabel.Size = new System.Drawing.Size(62, 16);
            this.foodTitleLabel.TabIndex = 86;
            this.foodTitleLabel.Text = "Τίτλος :";
            // 
            // foodIngredientsLabel
            // 
            this.foodIngredientsLabel.AutoSize = true;
            this.foodIngredientsLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodIngredientsLabel.Location = new System.Drawing.Point(12, 262);
            this.foodIngredientsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.foodIngredientsLabel.Name = "foodIngredientsLabel";
            this.foodIngredientsLabel.Size = new System.Drawing.Size(58, 16);
            this.foodIngredientsLabel.TabIndex = 85;
            this.foodIngredientsLabel.Text = "Υλικά :";
            // 
            // foodDeliveryTimeLabel
            // 
            this.foodDeliveryTimeLabel.AutoSize = true;
            this.foodDeliveryTimeLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodDeliveryTimeLabel.Location = new System.Drawing.Point(12, 301);
            this.foodDeliveryTimeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.foodDeliveryTimeLabel.Name = "foodDeliveryTimeLabel";
            this.foodDeliveryTimeLabel.Size = new System.Drawing.Size(64, 16);
            this.foodDeliveryTimeLabel.TabIndex = 84;
            this.foodDeliveryTimeLabel.Text = "Χρόνος :";
            // 
            // foodPriceLabel
            // 
            this.foodPriceLabel.AutoSize = true;
            this.foodPriceLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodPriceLabel.Location = new System.Drawing.Point(12, 236);
            this.foodPriceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.foodPriceLabel.Name = "foodPriceLabel";
            this.foodPriceLabel.Size = new System.Drawing.Size(51, 16);
            this.foodPriceLabel.TabIndex = 83;
            this.foodPriceLabel.Text = "Τιμή :";
            // 
            // foodFinalPriceLabel
            // 
            this.foodFinalPriceLabel.AutoSize = true;
            this.foodFinalPriceLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodFinalPriceLabel.Location = new System.Drawing.Point(9, 327);
            this.foodFinalPriceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.foodFinalPriceLabel.Name = "foodFinalPriceLabel";
            this.foodFinalPriceLabel.Size = new System.Drawing.Size(105, 16);
            this.foodFinalPriceLabel.TabIndex = 91;
            this.foodFinalPriceLabel.Text = "Τελική Τιμή :";
            // 
            // foodFinalPriceValueLabel
            // 
            this.foodFinalPriceValueLabel.AutoSize = true;
            this.foodFinalPriceValueLabel.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foodFinalPriceValueLabel.Location = new System.Drawing.Point(118, 327);
            this.foodFinalPriceValueLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.foodFinalPriceValueLabel.Name = "foodFinalPriceValueLabel";
            this.foodFinalPriceValueLabel.Size = new System.Drawing.Size(87, 16);
            this.foodFinalPriceValueLabel.TabIndex = 92;
            this.foodFinalPriceValueLabel.Text = "Placeholder";
            // 
            // AddFoodForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 404);
            this.Controls.Add(this.foodFinalPriceValueLabel);
            this.Controls.Add(this.foodFinalPriceLabel);
            this.Controls.Add(this.foodDeliveryTimeValueLabel);
            this.Controls.Add(this.foodIngredientsValueLabel);
            this.Controls.Add(this.foodPriceValueLabel);
            this.Controls.Add(this.foodTitleValueLabel);
            this.Controls.Add(this.foodTitleLabel);
            this.Controls.Add(this.foodIngredientsLabel);
            this.Controls.Add(this.foodDeliveryTimeLabel);
            this.Controls.Add(this.foodPriceLabel);
            this.Controls.Add(this.counterFoodLabel);
            this.Controls.Add(this.plusFoodButton);
            this.Controls.Add(this.minusFoodButton);
            this.Controls.Add(this.foodImagePictureBox);
            this.Controls.Add(this.addToCartButton);
            this.Name = "AddFoodForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddFoodForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddFoodForm_FormClosing_1);
            ((System.ComponentModel.ISupportInitialize)(this.foodImagePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Resources.Cool_button addToCartButton;
        private System.Windows.Forms.PictureBox foodImagePictureBox;
        private Resources.Cool_button minusFoodButton;
        private Resources.Cool_button plusFoodButton;
        private System.Windows.Forms.Label counterFoodLabel;
        private System.Windows.Forms.Label foodDeliveryTimeValueLabel;
        private System.Windows.Forms.Label foodIngredientsValueLabel;
        private System.Windows.Forms.Label foodPriceValueLabel;
        private System.Windows.Forms.Label foodTitleValueLabel;
        private System.Windows.Forms.Label foodTitleLabel;
        private System.Windows.Forms.Label foodIngredientsLabel;
        private System.Windows.Forms.Label foodDeliveryTimeLabel;
        private System.Windows.Forms.Label foodPriceLabel;
        private System.Windows.Forms.Label foodFinalPriceLabel;
        private System.Windows.Forms.Label foodFinalPriceValueLabel;
    }
}
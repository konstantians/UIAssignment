using DataAccess.Logic;
using DataAccess.Models;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UIAssignment.Forms.CustomerForms
{
    public partial class AddFoodForm : Form
    {
        private int foodCount = 1;
        Food Food = new Food();
        public AddFoodForm(Food food)
        {
            InitializeComponent();
            //get the rest of the information for the food
            food = OrderDataAccess.GetFood(food.FoodName);
            Food = food;
            
            ActiveUser.Customer.FoodAndCountPairs.TryGetValue(food,out foodCount);
            addToCartButton.Text = foodCount == 0 ? "Προσθήκη Στο Καλάθι" : "Ανανέωση Καλαθιού"; 
            foodCount = foodCount > 1 ? foodCount : 1;
            string newResourceName = food.FoodImage + "Bigger";
            Image newImage = Properties.Resources.ResourceManager.GetObject(newResourceName) as Image;
            foodImagePictureBox.BackgroundImage = newImage;
            foodTitleValueLabel.Text = food.FoodName;
            foodPriceValueLabel.Text = $"{food.PricePerUnit}\u20AC";
            string formattedFoodDescription = food.Description.Replace("\\n", Environment.NewLine);
            foodIngredientsValueLabel.Text = formattedFoodDescription;
            foodDeliveryTimeValueLabel.Text = $"{food.PreparationTime} λεπτά";
            foodFinalPriceValueLabel.Text = $"{food.PricePerUnit * foodCount}\u20AC";

            counterFoodLabel.Text = foodCount.ToString();
        }

        private void addToCartButton_Click_1(object sender, EventArgs e)
        {
            ActiveUser.Customer.FoodAndCountPairs.Remove(Food);
            ActiveUser.Customer.FoodAndCountPairs.Add(Food, foodCount);
            ActiveUser.NeedsToBeNotifiedAboutOrder = true;
            if (addToCartButton.Text == "Προσθήκη Στο Καλάθι")
                MessageBox.Show("Το αντικείμενο προστέθηκε στο καλάθι επιτυχώς!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Το καλάθι ανανεώθηκε επιτυχώς!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void AddFoodForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Form form1 = Application.OpenForms[1];
            Form form2 = Application.OpenForms[2];
            form1.SuspendLayout();
            form2.SuspendLayout();
            form1.Enabled = true;
            form2.Enabled = true;
            form1.ResumeLayout();
            form2.ResumeLayout();
        }

        private void minusFoodButton_Click(object sender, EventArgs e)
        {
            if (foodCount <= 1)
                return;
            counterFoodLabel.Text = (--foodCount).ToString();
            foodFinalPriceValueLabel.Text = $"{Food.PricePerUnit * foodCount}\u20AC";
        }

        private void plusFoodButton_Click(object sender, EventArgs e)
        {
            if (foodCount >= 9)
                return;
            counterFoodLabel.Text = (++foodCount).ToString();
            foodFinalPriceValueLabel.Text = $"{Food.PricePerUnit * foodCount}\u20AC";
        }
    }
}

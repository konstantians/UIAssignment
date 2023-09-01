using DataAccess.Logic;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using UIAssignment.Resources;

namespace UIAssignment.Forms.CommonForms
{
    public partial class RestaurantForm : ChildForm
    {
        List<Food> allFoods = new List<Food>();
        List<Food> loadedFoods = new List<Food>();
        private ResourceManager resourceManager = Properties.Resources.ResourceManager;
        private int radioButtonSequenceCount = 0;
        private string wasCheckedInitially = "predetermined";
        private int currentStartingPoint = 0;
        public RestaurantForm()
        {
            InitializeComponent();
            allFoods = OrderDataAccess.GetFoods();
            loadedFoods = allFoods;
            loadSpecificFoodsBasedOnLimit(0,loadedFoods);
        }

        public override bool UnsavedChangesDetected()
        {
            return false;
        }

        private void firstFoodSectionButton_Click(object sender, System.EventArgs e)
        {
            currentStartingPoint = 0;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(0, loadedFoods);
        }

        private void secondFoodSectionButton_Click(object sender, System.EventArgs e)
        {
            currentStartingPoint = 3;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(3, loadedFoods);
        }

        private void thirdFoodSectionButton_Click(object sender, System.EventArgs e)
        {
            currentStartingPoint = 6;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(6, loadedFoods);
        }

        private void fourthFoodSectionButton_Click(object sender, System.EventArgs e)
        {
            currentStartingPoint = 9;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(9, loadedFoods);
        }

        private void fifthFoodSectionButton_Click(object sender, System.EventArgs e)
        {
            currentStartingPoint = 12;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(12, loadedFoods);
        }

        private void sixthFoodSectionButton_Click(object sender, System.EventArgs e)
        {
            currentStartingPoint = 15;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(15, loadedFoods);
        }

        private void seventhFoodSectionButton_Click(object sender, System.EventArgs e)
        {
            currentStartingPoint = 18;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(18, loadedFoods);
        }

        private void eighthfoodSectionButton_Click(object sender, System.EventArgs e)
        {
            currentStartingPoint = 21;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(21, loadedFoods);
        }

        private void ninthFoodSectionButton_Click(object sender, System.EventArgs e)
        {
            currentStartingPoint = 24;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(24, loadedFoods);
        }

        private void tenthFoodSectionButton_Click(object sender, System.EventArgs e)
        {
            currentStartingPoint = 27;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(27, loadedFoods);
        }

        private void loadSpecificFoodsBasedOnLimit(int startingPoint, List<Food> listOfFoods)
        {
            int counter = 0;
            
            foreach (Food food in listOfFoods)
            {
                if (counter < startingPoint)
                {
                    counter++;
                    continue;
                }
                else if(counter >= startingPoint && counter < startingPoint + 3)
                {
                    setFoodSection(counter % 3, food, false);
                    counter++;
                    continue;
                }
                break;
            }

            //check if there are not enough foods to fill all the sections 
            for(int i = counter; i < startingPoint + 3; i++)
                setFoodSection(i % 3, null, true);
        }

        private void setFoodSection(int sectionNumber, Food food, bool doNotFill)
        {

            System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
            
            if (sectionNumber == 0)
                panel = foodsPanel.Controls.OfType<System.Windows.Forms.Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "firstFoodPanel");
            
            else if(sectionNumber == 1)
                panel = foodsPanel.Controls.OfType<System.Windows.Forms.Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "secondFoodPanel");
            
            else
                panel = foodsPanel.Controls.OfType<System.Windows.Forms.Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "thirdFoodPanel");

            if (doNotFill)
            {
                panel.Controls.OfType<System.Windows.Forms.Label>().FirstOrDefault(label => label.Name.Contains("TitleValueLabel")).Text = "";
                panel.Controls.OfType<System.Windows.Forms.Label>().FirstOrDefault(label => label.Name.Contains("PriceValueLabel")).Text = "";
                panel.Controls.OfType<System.Windows.Forms.Label>().FirstOrDefault(label => label.Name.Contains("IngredientsValueLabel")).Text = "";
                panel.Controls.OfType<System.Windows.Forms.Label>().FirstOrDefault(label => label.Name.Contains("TimeValueLabel")).Text = "";
                panel.Controls.OfType<System.Windows.Forms.PictureBox>().FirstOrDefault().BackgroundImage = null;
                return;
            }

            System.Drawing.Image resourceObject = (System.Drawing.Image)resourceManager.GetObject(food.FoodImage);
            panel.Controls.OfType<System.Windows.Forms.Label>().FirstOrDefault(label => label.Name.Contains("TitleValueLabel")).Text = food.FoodName;
            panel.Controls.OfType<System.Windows.Forms.Label>().FirstOrDefault(label => label.Name.Contains("PriceValueLabel")).Text = $"{food.PricePerUnit}\u20AC";
            string formattedFoodDescription = food.Description.Replace("\\n", Environment.NewLine);
            panel.Controls.OfType<System.Windows.Forms.Label>().FirstOrDefault(label => label.Name.Contains("IngredientsValueLabel")).Text = formattedFoodDescription;
            panel.Controls.OfType<System.Windows.Forms.Label>().FirstOrDefault(label => label.Name.Contains("TimeValueLabel")).Text = $"{food.PreparationTime} λεπτά";
            panel.Controls.OfType<System.Windows.Forms.PictureBox>().FirstOrDefault().BackgroundImage = resourceObject;
            panel.Controls.OfType<System.Windows.Forms.PictureBox>().FirstOrDefault().BackgroundImageLayout = 
                    food.Category == "Νερά Και Αναψυκτικά" || food.Category == "Μπύρες" ? System.Windows.Forms.ImageLayout.Center : System.Windows.Forms.ImageLayout.Stretch;
        }

        private void predeterminedFilterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadioButtons("predetermined");
        }

        private void priceAscendingFilterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadioButtons("ascendingPrice");
        }

        private void priceDescendingFilterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadioButtons("descendingPrice");
        }

        private void deliveryTimeFilterRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ChangeRadioButtons("deliveryTime");
        }

        public void ChangeRadioButtons(string isCurrentlyChecked) {
            if (radioButtonSequenceCount == 1)
            {
                radioButtonSequenceCount = 0;
                return;
            }
            //otherwise change the correct radio button and set the no-change marker
            if (predeterminedFilterRadioButton.Checked && wasCheckedInitially == "predetermined")
            {
                predeterminedFilterRadioButton.Checked = false;
                wasCheckedInitially = isCurrentlyChecked;
            }
            else if (priceAscendingFilterRadioButton.Checked && wasCheckedInitially == "ascendingPrice")
            {
                priceAscendingFilterRadioButton.Checked = false;
                wasCheckedInitially = isCurrentlyChecked;
            }
            else if (priceDescendingFilterRadioButton.Checked && wasCheckedInitially == "descendingPrice")
            {
                priceDescendingFilterRadioButton.Checked = false;
                wasCheckedInitially = isCurrentlyChecked;
            }
            else if (deliveryTimeFilterRadioButton.Checked && wasCheckedInitially == "deliveryTime")
            {
                deliveryTimeFilterRadioButton.Checked = false;
                wasCheckedInitially = isCurrentlyChecked;
            }

            radioButtonSequenceCount = 0;
        }

        private void applyFiltersButton_Click(object sender, EventArgs e)
        {
            List<string> allowedCategories = new List<string>();
            if (saladsFilterToggleButton.Checked)
                allowedCategories.Add("Σαλάτες");
            if (burgersAndClubSandwitchsFilterToggleButton.Checked)
                allowedCategories.Add("Burgers Και Club Sandwitch");
            if (souvlakiaFilterToggleButton.Checked)
                allowedCategories.Add("Σουβλάκια");
            if (meridesFilterToggleButton.Checked)
                allowedCategories.Add("Μερίδες");
            if (waterAndDrinksFilterToggleButton.Checked)
                allowedCategories.Add("Νερά Και Αναψυκτικά");
            if (biersFilterToggleButton.Checked)
                allowedCategories.Add("Μπύρες");

            loadedFoods = allFoods.FindAll(food => allowedCategories.Contains(food.Category));

            if (priceAscendingFilterRadioButton.Checked)
                loadedFoods = loadedFoods.OrderBy(food => food.PricePerUnit).ToList();
            else if(priceDescendingFilterRadioButton.Checked)
                loadedFoods = loadedFoods.OrderByDescending(food => food.PricePerUnit).ToList();
            else if(deliveryTimeFilterRadioButton.Checked)
                loadedFoods = loadedFoods.OrderBy(food => food.PreparationTime).ToList();

            searchCustomTextBox.Texts = "";
            loadSpecificFoodsBasedOnLimit(currentStartingPoint, loadedFoods);
        }

        private void setStyleForCurrentSectionButton()
        {
            List<Cool_button> sectionButtons = foodsPanel.Controls.OfType<Cool_button>().Where(button => button.Name.Contains("SectionButton")).
                OrderBy(sectionButton => Int32.Parse(sectionButton.Text)).ToList();
            int counter = 0;
            foreach (Cool_button sectionButton in sectionButtons)
            {
                //found the previous
                if (sectionButton.BackgroundImage != null)
                {
                    sectionButton.BackgroundImage = null;
                    sectionButton.TextColor = System.Drawing.Color.Black;
                    sectionButton.BorderColor = System.Drawing.Color.Black;
                }
                //found the current
                else if (counter == currentStartingPoint)
                {
                    sectionButton.BackgroundImage = Properties.Resources.BlackMarbleBackground;
                    sectionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    sectionButton.TextColor = System.Drawing.Color.White;
                    sectionButton.BorderColor = System.Drawing.Color.Gray;
                }

                counter += 3;
            }
        }

        private void searchCustomButton_Click(object sender, EventArgs e)
        {
            //TODO problem with σ in the end of the word(maybe fix it) and toning
            loadedFoods = loadedFoods.FindAll(food =>  food.FoodName.ToLower().
            Contains(searchCustomTextBox.Texts.Trim().ToLower())).ToList();
            loadSpecificFoodsBasedOnLimit(currentStartingPoint, loadedFoods);
        }

        private void firstFoodPanel_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            AddFoodForm addFoodForm = new AddFoodForm();
            addFoodForm.Show();
        }

        private void secondFoodPanel_Click(object sender, EventArgs e)
        {

        }

        private void thirdFoodPanel_Click(object sender, EventArgs e)
        {

        }
    }
}

using DataAccess.Logic;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using UIAssignment.Resources;

namespace UIAssignment.Forms.CustomerForms
{
    public partial class CartForm : ChildForm
    {
        private int currentStartingPoint = 0;
        private int currentOrderDetailsStartingPoint = 0; 
        private ResourceManager resourceManager = Properties.Resources.ResourceManager;
        private int formsCount = 0;
        public CartForm()
        {
            InitializeComponent();
            DoubleBufferingForForms.SetDoubleBuffer(chosenFoodsPanel, true);
            DoubleBufferingForForms.SetDoubleBuffer(orderDetailsPanel, true);
            DoubleBufferingForForms.SetDoubleBuffer(firstFoodPanel, true);
            DoubleBufferingForForms.SetDoubleBuffer(secondFoodPanel, true);
            DoubleBufferingForForms.SetDoubleBuffer(thirdFoodPanel, true);

            setFinalLabels();
            loadSpecificFoodsBasedOnLimit(0, ActiveUser.Customer.FoodAndCountPairs.Keys.ToList());
            loadOrderDetailsSection(0);

            if (currentOrderDetailsStartingPoint + 5 >= ActiveUser.Customer.FoodAndCountPairs.Count)
                nextOrderSectionButtonIcon.Enabled = false;

            formsCount = Application.OpenForms.Count;
        }

        private void completeOrderButton_MouseEnter(object sender, EventArgs e)
        {
            completeOrderButton.BackgroundImage = Properties.Resources.BlackMarbleBackground;
            completeOrderButton.TextColor = Color.White;
        }

        private void completeOrderButton_MouseLeave(object sender, EventArgs e)
        {
            completeOrderButton.BackgroundImage = null;
            completeOrderButton.TextColor = Color.Black;
        }

        public override bool UnsavedChangesDetected()
        {
            if (ActiveUser.Customer.FoodAndCountPairs.Count > 0 && ActiveUser.NeedsToBeNotifiedAboutOrder)
            {
                MessageBox.Show("Έχετε αντικείμενα στο καλάθι σας.\nΘα παραμείνουν εκεί μέχρι να αποσυνδεθείτε ή να ολοκληρώσετε την παραγγελία σας.",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActiveUser.NeedsToBeNotifiedAboutOrder = false;
            }
            return false;
        }

        private void firstFoodSectionButton_Click(object sender, EventArgs e)
        {
            currentStartingPoint = 0;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(0, ActiveUser.Customer.FoodAndCountPairs.Keys.ToList());
        }

        private void secondFoodSectionButton_Click(object sender, EventArgs e)
        {
            currentStartingPoint = 3;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(3, ActiveUser.Customer.FoodAndCountPairs.Keys.ToList());
        }

        private void thirdFoodSectionButton_Click(object sender, EventArgs e)
        {
            currentStartingPoint = 6;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(6, ActiveUser.Customer.FoodAndCountPairs.Keys.ToList());
        }

        private void fourthFoodSectionButton_Click(object sender, EventArgs e)
        {
            currentStartingPoint = 9;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(9, ActiveUser.Customer.FoodAndCountPairs.Keys.ToList());
        }

        private void fifthFoodSectionButton_Click(object sender, EventArgs e)
        {
            currentStartingPoint = 12;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(12, ActiveUser.Customer.FoodAndCountPairs.Keys.ToList());
        }

        private void sixthFoodSectionButton_Click(object sender, EventArgs e)
        {
            currentStartingPoint = 15;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(15, ActiveUser.Customer.FoodAndCountPairs.Keys.ToList());
        }

        private void seventhFoodSectionButton_Click(object sender, EventArgs e)
        {
            currentStartingPoint = 18;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(18, ActiveUser.Customer.FoodAndCountPairs.Keys.ToList());
        }

        private void eighthFoodSectionButton_Click(object sender, EventArgs e)
        {
            currentStartingPoint = 21;
            setStyleForCurrentSectionButton();
            loadSpecificFoodsBasedOnLimit(21, ActiveUser.Customer.FoodAndCountPairs.Keys.ToList());
        }

        private void setStyleForCurrentSectionButton()
        {
            List<Cool_button> sectionButtons = chosenFoodsPanel.Controls.OfType<Cool_button>().Where(button => button.Name.Contains("SectionButton")).
                OrderBy(sectionButton => Int32.Parse(sectionButton.Text)).ToList();
            int counter = 0;
            foreach (Cool_button sectionButton in sectionButtons)
            {
                //found the current
                if (counter == currentStartingPoint)
                {
                    sectionButton.BackgroundImage = Properties.Resources.BlackMarbleBackground;
                    sectionButton.BackgroundImageLayout = ImageLayout.Stretch;
                    sectionButton.TextColor = Color.White;
                    sectionButton.BorderColor = Color.Gray;
                }
                //found the previous
                else if (sectionButton.BackgroundImage != null)
                {
                    sectionButton.BackgroundImage = null;
                    sectionButton.TextColor = Color.Black;
                    sectionButton.BorderColor = Color.Black;
                }

                counter += 3;
            }
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
                else if (counter >= startingPoint && counter < startingPoint + 3)
                {
                    setFoodSection(counter % 3, food, false);
                    counter++;
                    continue;
                }
                break;
            }

            //check if there are not enough foods to fill all the sections 
            for (int i = counter; i < startingPoint + 3; i++)
                setFoodSection(i % 3, null, true);
        }

        private void setFoodSection(int sectionNumber, Food food, bool doNotFill)
        {

            Panel panel = new Panel();

            if (sectionNumber == 0)
                panel = chosenFoodsPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "firstFoodPanel");

            else if (sectionNumber == 1)
                panel = chosenFoodsPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "secondFoodPanel");

            else
                panel = chosenFoodsPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "thirdFoodPanel");

            if (doNotFill)
            {
                panel.Enabled = false;
                panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("TitleValueLabel")).Text = "";
                panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("PriceValueLabel")).Text = "";
                panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("TimeValueLabel")).Text = "";
                panel.Controls.OfType<PictureBox>().FirstOrDefault().BackgroundImage = null;
                return;
            }

            if (!panel.Enabled)
                panel.Enabled = true;
            Image resourceObject = (Image)resourceManager.GetObject(food.FoodImage);
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("TitleValueLabel")).Text = food.FoodName;
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("PriceValueLabel")).Text = $"{food.PricePerUnit}\u20AC";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("TimeValueLabel")).Text = $"{food.PreparationTime} λεπτά";
            panel.Controls.OfType<PictureBox>().FirstOrDefault().BackgroundImage = resourceObject;
            panel.Controls.OfType<PictureBox>().FirstOrDefault().BackgroundImageLayout =
                    food.Category == "Νερά Και Αναψυκτικά" || food.Category == "Μπύρες" ? ImageLayout.Center : ImageLayout.Stretch;
        }

        private void loadOrderDetailsSection(int startingPoint)
        {
            int counter = 0;

            foreach (Food food in ActiveUser.Customer.FoodAndCountPairs.Keys.ToList())
            {
                if (counter < startingPoint)
                {
                    counter++;
                    continue;
                }
                else if (counter >= startingPoint && counter < startingPoint + 5)
                {
                    ActiveUser.Customer.FoodAndCountPairs.TryGetValue(food, out int foodCount);
                    setOrderDetailSection(counter % 5, food, foodCount, false);
                    counter++;
                    continue;
                }
                break;
            }

            //check if there are not enough foods to fill all the sections 
            for (int i = counter; i < startingPoint + 5; i++)
                setOrderDetailSection(i % 5, null, 0, true);
        }

        private void setOrderDetailSection(int sectionNumber, Food food, int foodCount, bool doNotFill)
        {

            Panel panel = new Panel();

            if (sectionNumber == 0)
                panel = orderDetailsPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "orderDetailsSectionOne");
            else if (sectionNumber == 1)
                panel = orderDetailsPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "orderDetailsSectionTwo");
            else if (sectionNumber == 2)
                panel = orderDetailsPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "orderDetailsSectionThree");
            else if (sectionNumber == 3)
                panel = orderDetailsPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "orderDetailsSectionFour");
            else
                panel = orderDetailsPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "orderDetailsSectionFive");

            if (doNotFill)
            {
                panel.Hide();
                return;
            }

            if (!panel.Visible)
                panel.Show();
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("foodTitleOrderDetailsValue")).Text = food.FoodName;
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("foodFinalPriceValueLabel")).Text = $"{(food.PricePerUnit * foodCount):F3}\u20AC";
            panel.Controls.OfType<Cool_button>().FirstOrDefault(label => label.Name.Contains("foodCounterIcon")).Text = foodCount.ToString();
        }

        private void previousOrderSectionButtonIcon_Click(object sender, EventArgs e)
        {
            currentOrderDetailsStartingPoint -= 5;
            loadOrderDetailsSection(currentOrderDetailsStartingPoint);
            if(currentOrderDetailsStartingPoint <= 0)
                previousOrderSectionButtonIcon.Enabled = false;

            //enable the next button if it had disabled itself
            if (!nextOrderSectionButtonIcon.Enabled)
                nextOrderSectionButtonIcon.Enabled = true;
        }

        private void nextOrderSectionButtonIcon_Click(object sender, EventArgs e)
        {
            currentOrderDetailsStartingPoint += 5;
            loadOrderDetailsSection(currentOrderDetailsStartingPoint);
            if (currentOrderDetailsStartingPoint + 5 >= ActiveUser.Customer.FoodAndCountPairs.Count)
                nextOrderSectionButtonIcon.Enabled = false;

            //enable the previous button if it had disabled itself
            if (!previousOrderSectionButtonIcon.Enabled)
                previousOrderSectionButtonIcon.Enabled = true;
        }

        private void editIconOne_Click(object sender, EventArgs e)
        {
            handleEditOfChosenFood(orderDetailsSectionOne);
        }

        private void editIconTwo_Click(object sender, EventArgs e)
        {
            handleEditOfChosenFood(orderDetailsSectionTwo);
        }

        private void editIconThree_Click(object sender, EventArgs e)
        {
            handleEditOfChosenFood(orderDetailsSectionThree);
        }

        private void editIconFour_Click(object sender, EventArgs e)
        {
            handleEditOfChosenFood(orderDetailsSectionFour);
        }

        private void editIconFive_Click(object sender, EventArgs e)
        {
            handleEditOfChosenFood(orderDetailsSectionFive);
        }

        private void trashIconOne_Click(object sender, EventArgs e)
        {
            handleDeleteOfChosenFood(orderDetailsSectionOne);
        }

        private void trashIconTwo_Click(object sender, EventArgs e)
        {
            handleDeleteOfChosenFood(orderDetailsSectionTwo);
        }

        private void trashIconThree_Click(object sender, EventArgs e)
        {
            handleDeleteOfChosenFood(orderDetailsSectionThree);
        }

        private void trashIconFour_Click(object sender, EventArgs e)
        {
            handleDeleteOfChosenFood(orderDetailsSectionFour);
        }

        private void trashIconFive_Click(object sender, EventArgs e)
        {
            handleDeleteOfChosenFood(orderDetailsSectionFive);
        }

        private void handleEditOfChosenFood(Panel panel)
        {
            string foodName = panel.Controls.OfType<Label>()
                .FirstOrDefault(label => label.Name.Contains("foodTitleOrderDetailsValue")).Text;
            this.Enabled = false;
            Application.OpenForms[1].Enabled = false;
            AddFoodForm addFoodForm = new AddFoodForm(OrderDataAccess.GetFood(foodName));
            addFoodForm.Show();
            checkForItemsChangeTimer.Enabled = true;
        }

        private void handleDeleteOfChosenFood(Panel panel)
        {
            string foodName = panel.Controls.OfType<Label>()
                .FirstOrDefault(label => label.Name.Contains("foodTitleOrderDetailsValue")).Text;
            ActiveUser.Customer.FoodAndCountPairs.Remove(OrderDataAccess.GetFood(foodName));

            setFinalLabels();
            //return at the beginning
            currentOrderDetailsStartingPoint = 0;
            loadSpecificFoodsBasedOnLimit(0, ActiveUser.Customer.FoodAndCountPairs.Keys.ToList());
            loadOrderDetailsSection(0);
        }

        private void setFinalLabels()
        {
            double finalPrice = 0;
            int finalOrderTime = 0;
            foreach (KeyValuePair<Food, int> kvp in ActiveUser.Customer.FoodAndCountPairs)
            {
                finalPrice += kvp.Value * kvp.Key.PricePerUnit;
                if (finalOrderTime < kvp.Key.PreparationTime)
                {
                    finalOrderTime = kvp.Key.PreparationTime;
                }
            }
            if(ActiveUser.Customer.FoodAndCountPairs.Count > 0)
                finalOrderTime += 10;

            string formatedFinalOrderTotalString = finalPrice >= 10 ? $"{finalPrice:F3}\u20AC" : $"0{finalPrice:F3}\u20AC";
            orderTotalValueLabel.Text = formatedFinalOrderTotalString;
            string formatedFinalOrderTimeString = finalOrderTime >= 10 ? $"{finalOrderTime} λεπτά" : $"0{finalOrderTime} λεπτά";
            finalDeliveryTimeValueLabel.Text = formatedFinalOrderTimeString;
        }

        private void completeOrderButton_Click(object sender, EventArgs e)
        {
            //if there are no items in the cart(because the user removed them all)
            if (ActiveUser.Customer.FoodAndCountPairs.Count == 0)
            {
                MessageBox.Show("Για να είναι έγγυρη μία παραγγελία πρέπει να υπάρχει τουλάχιστον ένα αντικείμενο στο καλάθι σας.", "Άδειο Καλάθι", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Order order = new Order();
            order.CustomerName = ActiveUser.Customer.Username;
            order.Foods = ActiveUser.Customer.FoodAndCountPairs.Keys.ToList();
            order.IssuedDate = DateTime.Now;
            foreach (KeyValuePair<Food,int> foodAndCount in ActiveUser.Customer.FoodAndCountPairs)
            {
                order.FoodQuantities.Add(foodAndCount.Key.FoodName, foodAndCount.Value);
                order.FinalPrice += foodAndCount.Key.PricePerUnit * foodAndCount.Value;
            }

            bool successfulOrderCompletion = OrderDataAccess.CreateOrder(order);
            if (!successfulOrderCompletion)
            {
                MessageBox.Show($"δυστηχώς η παραγγελία σας δεν έγινε αποδεκτή από το σύστημα. Παρακαλώ περιμένετε μερικά λεπτά πριν ξαναδοκιμάσετε.", "Αποτυχής Παραγγελία", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ActiveUser.Customer.FoodAndCountPairs.Clear();
            ActiveUser.Customer.Orders.Add(order);

            MessageBox.Show($"Η παραγγελία σας ολοκληρώθηκε επιτυχώς και θα παραδοθεί στο δωμάτιο σας σε περίπου {finalDeliveryTimeValueLabel.Text} λεπτά.", "Επιτυχής Παραγγελία", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ActiveUser.OpenOrderForm = true;
        }

        private void checkForItemsChangeTimer_Tick(object sender, EventArgs e)
        {
            if (formsCount + 1 == Application.OpenForms.Count)
                return;

            setFinalLabels();
            //return at the beginning
            currentOrderDetailsStartingPoint = 0;
            loadSpecificFoodsBasedOnLimit(0, ActiveUser.Customer.FoodAndCountPairs.Keys.ToList());
            loadOrderDetailsSection(0);
            checkForItemsChangeTimer.Enabled = false;
        }
    }
}

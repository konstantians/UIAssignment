using DataAccess.Logic;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using UIAssignment.Resources;

namespace UIAssignment.Forms.CustomerForms
{
    public partial class OrdersForm : ChildForm
    {
        List<Order> orders = ActiveUser.Customer.Orders;
        Order currentOrder = new Order();
        private ResourceManager resourceManager = Properties.Resources.ResourceManager;
        private int currentStartingPoint = 0;
        //changes when you go forward and backwards on the orders menu
        private int orderSectionCount = 0;
        private int counterOfChosenOrder = 1;
        private int initialXLocation = 0;

        public OrdersForm()
        {
            InitializeComponent();
            ActiveUser.OpenOrderForm = false;
            DoubleBufferingForForms.SetDoubleBuffer(chosenFoodsPanel, true);
            DoubleBufferingForForms.SetDoubleBuffer(allOrdersPanel, true);
            DoubleBufferingForForms.SetDoubleBuffer(firstFoodPanel, true);
            DoubleBufferingForForms.SetDoubleBuffer(secondFoodPanel, true);
            DoubleBufferingForForms.SetDoubleBuffer(thirdFoodPanel, true);
            initialXLocation = chosenOrderTitleLabel.Location.X;

            if (orders.Count == 0)
            {
                currentOrder = null;
                currentStartingPoint = -1;
                setStyleForCurrentSectionButton();
                loadAllOrdersSection(0);
                loadSpecificFoodsBasedOnLimit(0, new Dictionary<string, int>(), new List<Food>());
                nextOrderSectionButtonIcon.Enabled = false;
                return;
            }
            currentOrder = orders.FirstOrDefault();
            setStyleForCurrentSectionButton();
            loadAllOrdersSection(0);
            loadSpecificFoodsBasedOnLimit(0, currentOrder.FoodQuantities, currentOrder.Foods);
            if (orderSectionCount + 6 >= ActiveUser.Customer.Orders.Count)
                nextOrderSectionButtonIcon.Enabled = false;
        }

        private void loadSpecificFoodsBasedOnLimit(int startingPoint, Dictionary<string,int> foodQuantities, List<Food> listOfFoods)
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
                    foodQuantities.TryGetValue(food.FoodName, out int foodQuantity);
                    setFoodSection(counter % 3, food, foodQuantity,false);
                    counter++;
                    continue;
                }
                break;
            }

            chosenOrderTitleLabel.Text = counter != 0 ?
                $"Πιάτα Παραγγελίας {counterOfChosenOrder}" : "Δεν Υπάρχουν Παραγγελίες";
            chosenOrderTitleLabel.Location = chosenOrderTitleLabel.Text == "Δεν Υπάρχουν Παραγγελίες" ?
               new Point(initialXLocation - 35, chosenOrderTitleLabel.Location.Y) : chosenOrderTitleLabel.Location; 

            //check if there are not enough foods to fill all the sections 
            for (int i = counter; i < startingPoint + 3; i++)
                setFoodSection(i % 3, null, 0,true);
        }

        private void setFoodSection(int sectionNumber,Food food, int foodQuantity, bool doNotFill)
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
                panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("TitleValueLabel")).Text = "";
                panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("PriceValueLabell")).Text = "";
                panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("TimeValueLabel")).Text = "";
                panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("CounterValueLabel")).Text = "";
                panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("FinalPriceValueLabel")).Text = "";
                panel.Controls.OfType<PictureBox>().FirstOrDefault().BackgroundImage = null;
                panel.Enabled = false;
                return;
            }

            if (!panel.Enabled)
                panel.Enabled = true;
            Image resourceObject = (Image)resourceManager.GetObject(food.FoodImage);
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("TitleValueLabel")).Text = food.FoodName;
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("PriceValueLabell")).Text = $"{food.PricePerUnit}\u20AC";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("TimeValueLabel")).Text = $"{food.PreparationTime} λεπτά";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("CounterValueLabel")).Text = $"{foodQuantity} τεμάχια";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("FinalPriceValueLabel")).Text = $"{food.PricePerUnit * foodQuantity}\u20AC";
            panel.Controls.OfType<PictureBox>().FirstOrDefault().BackgroundImage = resourceObject;
            panel.Controls.OfType<PictureBox>().FirstOrDefault().BackgroundImageLayout =
                    food.Category == "Νερά Και Αναψυκτικά" || food.Category == "Μπύρες" ? ImageLayout.Center : ImageLayout.Stretch;
        }

        public override bool UnsavedChangesDetected()
        {
            return false;
        }

        private void loadAllOrdersSection(int startingPoint)
        {
            int counter = 0;

            foreach (Order order in orders)
            {
                if (counter < startingPoint)
                {
                    counter++;
                    continue;
                }
                else if (counter >= startingPoint && counter < startingPoint + 6)
                {
                    //ActiveUser.Customer.FoodAndCountPairs.TryGetValue(order, out int foodCount);
                    setOrderDetailSection(counter % 6, order, false);
                    counter++;
                    continue;
                }
                break;
            }

            //check if there are not enough foods to fill all the sections 
            for (int i = counter; i < startingPoint + 6; i++)
                setOrderDetailSection(i % 6, null, true);
        }

        private void setOrderDetailSection(int sectionNumber, Order order, bool doNotFill)
        {

            Panel panel = new Panel();

            if (sectionNumber == 0)
                panel = allOrdersPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "orderDetailsSectionOne");
            else if (sectionNumber == 1)
                panel = allOrdersPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "orderDetailsSectionTwo");
            else if (sectionNumber == 2)
                panel = allOrdersPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "orderDetailsSectionThree");
            else if (sectionNumber == 3)
                panel = allOrdersPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "orderDetailsSectionFour");
            else if(sectionNumber == 4)
                panel = allOrdersPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "orderDetailsSectionFive");
            else
                panel = allOrdersPanel.Controls.OfType<Panel>().FirstOrDefault(tempPanel => tempPanel.Name == "orderDetailsSectionSix");

            if (doNotFill)
            {
                panel.Hide();
                return;
            }

            if (!panel.Visible)
                panel.Show();
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("OrderDateValueLabel")).Text = order.IssuedDate.ToString("dd/MM/yy HH:mm");
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("OrderTimeDeliveryValueLabel")).Text = 
                $"{(order.Foods.Max(food => food.PreparationTime) + 10)} λεπτά";
            panel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("OrderFinalPriceValueeLabel")).Text = $"{order.FinalPrice:F3}\u20AC";
            Panel bannerPanel = panel.Controls.OfType<Panel>().FirstOrDefault(insidePanel => insidePanel.Name.Contains("SectionBannerPanel"));
            bannerPanel.Controls.OfType<Label>().FirstOrDefault(label => label.Name.Contains("SectionBannerLabel")).Text = $"{sectionNumber + 1 + orderSectionCount}";
        }

        private void trashIconOne_Click(object sender, EventArgs e)
        {
            trashIconButtonStandardActions(0);
        }

        private void trashIconTwo_Click(object sender, EventArgs e)
        {
            trashIconButtonStandardActions(1);
        }

        private void trashIconThree_Click(object sender, EventArgs e)
        {
            trashIconButtonStandardActions(2);
        }

        private void trashIconFour_Click(object sender, EventArgs e)
        {
            trashIconButtonStandardActions(3);
        }

        private void trashIconFive_Click(object sender, EventArgs e)
        {
            trashIconButtonStandardActions(4);
        }

        private void trashIconSix_Click(object sender, EventArgs e)
        {
            trashIconButtonStandardActions(5);
        }

        private void trashIconButtonStandardActions(int sectionNumber)
        {
            // Display a message box with "Yes" and "No" buttons
            DialogResult result = MessageBox.Show("Είστε Σίγουροι ότι θέλετε να ακυρώσετε την παραγγελία σας?",
                "Επιβαβαίωση Ακύρωσης Παραγγελίας", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {

                OrderDataAccess.DeleteOrder(ActiveUser.Customer.Orders[sectionNumber + orderSectionCount].CustomerName,
                    ActiveUser.Customer.Orders[sectionNumber + orderSectionCount].IssuedDate);
                orders.Remove(ActiveUser.Customer.Orders[sectionNumber + orderSectionCount]);
                currentOrder = orders.Count > 0 ? orders[0] : null;
                currentStartingPoint = currentOrder != null ? 0 : -1;
                counterOfChosenOrder = 1;
                orderSectionCount = 0;

                loadAllOrdersSection(orderSectionCount);
                setStyleForCurrentSectionButton();
                //if it was the last order
                if (currentOrder == null)
                {
                    loadSpecificFoodsBasedOnLimit(0, new Dictionary<string, int>(), new List<Food>());
                    previousOrderSectionButtonIcon.Enabled = false;
                    return;
                }
                //otherwise..
                loadSpecificFoodsBasedOnLimit(0, currentOrder.FoodQuantities, currentOrder.Foods);
                //check if the next button should be disabled
                if (orderSectionCount + 6 < ActiveUser.Customer.Orders.Count)
                    nextOrderSectionButtonIcon.Enabled = true;
                previousOrderSectionButtonIcon.Enabled = false;
            }
        }

        private void firstFoodSectionButton_Click(object sender, EventArgs e)
        {
            standarStepsForSectionButtons(0);
        }

        private void secondFoodSectionButton_Click(object sender, EventArgs e)
        {
            standarStepsForSectionButtons(3);
        }

        private void thirdFoodSectionButton_Click(object sender, EventArgs e)
        {
            standarStepsForSectionButtons(6);
        }

        private void fourthFoodSectionButton_Click(object sender, EventArgs e)
        {
            standarStepsForSectionButtons(9);
        }

        private void fifthFoodSectionButton_Click(object sender, EventArgs e)
        {
            standarStepsForSectionButtons(12);
        }

        private void sixthFoodSectionButton_Click(object sender, EventArgs e)
        { 
            standarStepsForSectionButtons(15);
        }

        private void seventhFoodSectionButton_Click(object sender, EventArgs e)
        {
            standarStepsForSectionButtons(18);
        }

        private void eighthFoodSectionButton_Click(object sender, EventArgs e)
        {
            standarStepsForSectionButtons(21);
        }

        private void standarStepsForSectionButtons(int startingPoint)
        {
            currentStartingPoint = currentStartingPoint != -1 ? startingPoint : -1;
            setStyleForCurrentSectionButton();

            if (currentOrder == null)
            {
                loadSpecificFoodsBasedOnLimit(0, new Dictionary<string, int>(), new List<Food>());
                return;
            }
            loadSpecificFoodsBasedOnLimit(startingPoint, currentOrder.FoodQuantities, currentOrder.Foods);
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

        private void orderDetailsSectionOne_Click(object sender, EventArgs e)
        {
            standarStepsForOrderSection(0);
        }

        private void orderDetailsSectionTwo_Click(object sender, EventArgs e)
        {
            standarStepsForOrderSection(1);
        }

        private void orderDetailsSectionThree_Click(object sender, EventArgs e)
        {
            standarStepsForOrderSection(2);
        }

        private void orderDetailsSectionFour_Click(object sender, EventArgs e)
        {
            standarStepsForOrderSection(3);
        }

        private void orderDetailsSectionFive_Click(object sender, EventArgs e)
        {
            standarStepsForOrderSection(4);
        }

        private void orderDetailsSectionSix_Click(object sender, EventArgs e)
        {
            standarStepsForOrderSection(5);
        }

        private void standarStepsForOrderSection(int currentOrderNumber)
        {
            currentStartingPoint = 0;
            currentOrder = orders[orderSectionCount + currentOrderNumber];
            counterOfChosenOrder = currentOrderNumber + 1 + orderSectionCount;
            setStyleForCurrentSectionButton();
            loadAllOrdersSection(orderSectionCount);
            loadSpecificFoodsBasedOnLimit(0, currentOrder.FoodQuantities, currentOrder.Foods);
        }

        private void previousOrdersSectionButtonIcon_Click(object sender, EventArgs e)
        {
            orderSectionCount -= 6;
            loadAllOrdersSection(orderSectionCount);

            if (orderSectionCount <= 0)
                previousOrderSectionButtonIcon.Enabled = false;

            //enable the next button if it had disabled itself
            if (!nextOrderSectionButtonIcon.Enabled)
                nextOrderSectionButtonIcon.Enabled = true;
        }

        private void nextOrdersSectionButtonIcon_Click(object sender, EventArgs e)
        {
            orderSectionCount += 6;
            loadAllOrdersSection(orderSectionCount);

            if (orderSectionCount + 6 >= ActiveUser.Customer.Orders.Count)
                nextOrderSectionButtonIcon.Enabled = false;

            //enable the previous button if it had disabled itself
            if (!previousOrderSectionButtonIcon.Enabled)
                previousOrderSectionButtonIcon.Enabled = true;
        }
    }
}

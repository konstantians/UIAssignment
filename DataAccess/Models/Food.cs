namespace DataAccess.Models
{
    public class Food
    {
        public string FoodName { get; set; }
        public double PricePerUnit { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int PreparationTime { get; set; }
        public string FoodImage { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Food))
                return false;

            Food otherFood = (Food)obj;

            return FoodName == otherFood.FoodName
                && PricePerUnit == otherFood.PricePerUnit
                && Category == otherFood.Category
                && Description == otherFood.Description
                && PreparationTime == otherFood.PreparationTime
                && FoodImage == otherFood.FoodImage;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 31 + FoodName.GetHashCode();
            hash = hash * 31 + PricePerUnit.GetHashCode();
            hash = hash * 31 + Category.GetHashCode();
            hash = hash * 31 + Description.GetHashCode();
            hash = hash * 31 + PreparationTime.GetHashCode();
            hash = hash * 31 + FoodImage.GetHashCode();
            return hash;
        }
    }
}


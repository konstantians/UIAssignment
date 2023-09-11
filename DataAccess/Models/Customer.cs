using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Customer : User
    {
        public Room Room { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        /// <summary>
        /// Used For The Cart
        /// </summary>
        public Dictionary<Food, int> FoodAndCountPairs { get; set; } = new Dictionary<Food, int>();
    }
}

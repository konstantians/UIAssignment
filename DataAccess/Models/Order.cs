using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Order
    {
        public DateTime IssuedDate { get; set; }
        public List<Food> Foods { get; set; } = new List<Food>();
        public Dictionary<string, int> FoodQuantities { get; set; } = new Dictionary<string, int>();
        public double FinalPrice { get; set; }
        public string CustomerName { get; set; }
    }
}

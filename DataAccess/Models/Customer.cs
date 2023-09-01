using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Customer : User
    {
        public Room Room { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Customer : User
    {
        public Room Room { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Employee : User
    {
        public List<Room> Room { get; set; } = new List<Room>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}

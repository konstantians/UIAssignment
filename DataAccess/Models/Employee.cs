using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Employee : User
    {
        public List<Room> Rooms { get; set; } = new List<Room>();
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}

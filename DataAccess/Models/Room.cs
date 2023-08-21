using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public double RoomTemperature { get; set; }
        public bool IsTelevisionOn { get; set; }
        public TroyanHorse TroyanHorse { get; set; }
        public Pool Pool { get; set; }
        public Radio Radio { get; set; }
    }
}

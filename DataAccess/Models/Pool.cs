using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Pool
    {
        public int PoolId { get; set; }
        public double PoolTemperature { get; set; }
        public int WaterLevel { get; set; }
        public PoolAlert PoolAlert { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class PoolAlert
    {
        public int PoolAlertId { get; set; }
        public DateTime From { get; set; }
        public DateTime Until { get; set; }
        public string SoundTrack { get; set; }
        public bool IsPoolAlertOn { get; set; }
    }
}

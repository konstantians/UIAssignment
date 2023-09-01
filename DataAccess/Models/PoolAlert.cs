using System;

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

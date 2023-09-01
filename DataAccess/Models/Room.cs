namespace DataAccess.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomTemperature { get; set; }
        public int RoomLighting { get; set; }
        public TroyanHorse TroyanHorse { get; set; }
        public Pool Pool { get; set; }
        public Radio Radio { get; set; }
        public Television Television { get; set; }
    }
}

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

namespace DataAccess.Models
{
    public class Radio
    {
        public int RadioId { get; set; }
        public string RadioSong { get; set; }
        public int RadioVolume { get; set; }
        public bool IsRadioOn { get; set; }

        public override bool Equals(object obj)
        {
            //check if the other object is null or is of a different type
            //and if yes return false
            if (obj == null || GetType() != obj.GetType())
                return false;

            //check the values
            Radio otherRadio = (Radio)obj;
            return RadioId == otherRadio.RadioId &&
                   RadioSong == otherRadio.RadioSong &&
                   RadioVolume == otherRadio.RadioVolume &&
                   IsRadioOn == otherRadio.IsRadioOn;
        }

        public override int GetHashCode()
        {
            int hash = 17; // Choose a prime number as the initial hash code
            hash = hash * 31 + RadioId.GetHashCode();
            hash = hash * 31 + RadioSong.GetHashCode();
            hash = hash * 31 + RadioVolume.GetHashCode();
            hash = hash * 31 + IsRadioOn.GetHashCode();
            return hash;
        }
    }
}

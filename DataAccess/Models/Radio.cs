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
    }
}

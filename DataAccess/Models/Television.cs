namespace DataAccess.Models
{
    public class Television
    {
        public int TelevisionId { get; set; }
        public string TelevisionProgram { get; set; }
        public int TelevisionVolume { get; set; }
        public bool IsTelevisionOn { get; set; }

        public override bool Equals(object obj)
        {
            //check if the other object is null or is of a different type
            //and if yes return false
            if (obj == null || GetType() != obj.GetType())
                return false;

            //check the values
            Television otherRadio = (Television)obj;
            return TelevisionId == otherRadio.TelevisionId &&
                   TelevisionProgram == otherRadio.TelevisionProgram &&
                   TelevisionVolume == otherRadio.TelevisionVolume &&
                   IsTelevisionOn == otherRadio.IsTelevisionOn;
        }
    }
}

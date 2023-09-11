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
            if (obj == null || GetType() != obj.GetType())
                return false;

            Television otherTelevision = (Television)obj;

            return TelevisionId == otherTelevision.TelevisionId &&
                   TelevisionProgram == otherTelevision.TelevisionProgram &&
                   TelevisionVolume == otherTelevision.TelevisionVolume &&
                   IsTelevisionOn == otherTelevision.IsTelevisionOn;
        }

        public override int GetHashCode()
        {
            int hash = 17; // Choose a prime number as the initial hash code
            hash = hash * 31 + TelevisionId.GetHashCode();
            hash = hash * 31 + TelevisionProgram.GetHashCode();
            hash = hash * 31 + TelevisionVolume.GetHashCode();
            hash = hash * 31 + IsTelevisionOn.GetHashCode();
            return hash;
        }
    }
}

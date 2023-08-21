using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Radio
    {
        public int RadioId { get; set; }
        public string RadioSong { get; set; }
        public double RadioVolume { get; set; }
        public bool IsRadioOn { get; set; }
    }
}

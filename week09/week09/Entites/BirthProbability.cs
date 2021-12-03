using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week09.Entites
{
     public class BirthProbability
    {
        public int NmbrOfChild{ get; set; }
        public int Age { get; set; }
        public double P { get; set; }
        public Gender Gender { get; internal set; }
    }
}

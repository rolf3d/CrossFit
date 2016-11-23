using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossFit.Model
{
    public class Wod
    {
        public string wodname { get; set; }
        public string beskrivelse { get; set; }
        public string movement1 { get; set; }
        public string movement2 { get; set; }
        public int number { get; set; }

        public override string ToString()
        {
            return "Navn: " + wodname + " \n" + "Beskrivelse: " + beskrivelse + " \n" + "Øvelse 1: " + movement1 + "\n" + "Øvelse 2: " + movement2 + "\n" + "Nummer: " + number;
        }
    }
}

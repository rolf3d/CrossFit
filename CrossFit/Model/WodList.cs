using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CrossFit.Model
{
    public class WodList : ObservableCollection<Wod>
    {
        public WodList() : base()
        {
            var work1 = new Wod();
            
            this.Add(new Wod() {wodname = "Annie",beskrivelse = "Fed Fed øvelse",gender = true,movement1 = "hop på stedet",movement2 = "Op og ned",number = 1});
            this.Add(new Wod() {wodname = "Lynda", beskrivelse = "Nice nem øvelse", gender = false, movement1 = "Ned og ligge og rul rundt", movement2 = "løb på stedet", number = 2});
            this.Add(new Wod() {wodname = "Sanne", beskrivelse = "En nem og kort øvelse", gender = true,movement1 = "øvelse beskrivelse 1",movement2 = "øvelse beskrivele 2",number = 3});
            
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Windows.Devices.Bluetooth.Background;
using Newtonsoft.Json;


namespace CrossFit.Model
{
    public class WodList : ObservableCollection<Wod>
    {
        public WodList() : base()
        {

            //this.Add(new Wod() {wodname = "Annie",beskrivelse = "Fed Fed øvelse",movement1 = "hop på stedet",movement2 = "Op og ned",number = 1});
            //this.Add(new Wod() {wodname = "Lynda", beskrivelse = "Nice nem øvelse", movement1 = "Ned og ligge og rul rundt", movement2 = "løb på stedet", number = 2});
            //this.Add(new Wod() {wodname = "Sanne", beskrivelse = "En nem og kort øvelse",movement1 = "øvelse beskrivelse 1",movement2 = "øvelse beskrivele 2",number = 3});

        }

        public void LoadJsonText(string jsonText)
        {

            List<Wod> nuListe = JsonConvert.DeserializeObject<List<Wod>>(jsonText);

            foreach (var wod in nuListe)
            {
                this.Add(wod);
            }
        }
        /// <summary>
        /// Laver liste fra C# til json text
        /// </summary>
        /// <returns></returns>
        public string GetJson()
        {
            string JsonWodListe = JsonConvert.SerializeObject(this);
            return JsonWodListe;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrossFit.Model;
using Newtonsoft.Json;


namespace CrossFit.ViewModel
{
    public class WodViewModel : INotifyPropertyChanged
    {
        public string JsonWodListe { get; set; }
        public Model.WodList WodListe { get; set; }
        List<Wod> CsharpListe = new List<Wod>();
        //public RelayCommand AddWodCommand { get; set; }

        private Model.Wod valgtWorkOut;

        public Model.Wod ValgtWorkOut
        {
            get { return valgtWorkOut; }
            set{ valgtWorkOut = value; 
                OnPropertyChanged(nameof(ValgtWorkOut));
            }
        }

        public AddWodCommand AddWodCommand { get; set; }
        //public RelayCommand RemoveCommand { get; set; }
        public RemoveWodCommand RemoveWodCommand { get; set; }
        public SaveWodCommand SaveWodCommand { get; set; }
        public LoadWodCommand LoadWodCommand { get; set; }
        public Model.Wod NewWod { get; set; }



        public WodViewModel()
        {
            NewWod = new Model.Wod();
            WodListe = new Model.WodList();
            valgtWorkOut = new Model.Wod();
            AddWodCommand = new AddWodCommand(AddNewWod);
            RemoveWodCommand = new RemoveWodCommand(RemoveWod);
            SaveWodCommand = new SaveWodCommand(SaveWodList);
            //LoadWodCommand = new LoadWodCommand(LoadWodListe);
           
        }

        public void AddNewWod()
        {
            
            WodListe.Add(NewWod);
        }

        public void RemoveWod()
        {
            WodListe.Remove(ValgtWorkOut);
        }

        public void SaveWodList()
        {
           string JsonWodListe = JsonConvert.SerializeObject(WodListe);
            
        }

        //public void LoadWodListe()
        //{
        //    CsharpListe = JsonConvert.DeserializeObject<List<Wod>>(JsonWodListe);
        //}
        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

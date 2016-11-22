using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrossFit.Model;


namespace CrossFit.ViewModel
{
    public class WodViewModel : INotifyPropertyChanged
    {
        public Model.WodList WodListe { get; set; }

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
        public RelayCommand RemoveCommand { get; set; }
        public RemoveWodCommand RemoveWodCommand { get; set; }

        public Model.Wod NewWod { get; set; }



        public WodViewModel()
        {
            NewWod = new Model.Wod();
            WodListe = new Model.WodList();
            valgtWorkOut = new Model.Wod();
            AddWodCommand = new AddWodCommand(AddNewWod);
            RemoveWodCommand = new RemoveWodCommand(RemoveWod);
        }

        public void AddNewWod()
        {
            WodListe.Add(NewWod);
        }

        public void RemoveWod()
        {
            WodListe.Remove(ValgtWorkOut);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

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

        private Model.Wod valgtWorkOut;

        public Model.Wod ValgtWorkOut
        {
            get { return valgtWorkOut; }
            set{ valgtWorkOut = value; 
                OnPropertyChanged(nameof(ValgtWorkOut));
            }
        }

        public Model.Wod NewWod { get; set; }



        public WodViewModel()
        {
            WodListe = new Model.WodList();
            valgtWorkOut = new Model.Wod();
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

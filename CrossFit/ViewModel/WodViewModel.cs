using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using CrossFit.Model;
using Newtonsoft.Json;


namespace CrossFit.ViewModel
{
    public class WodViewModel : INotifyPropertyChanged
    {
        public Model.WodList WodListe { get; set; }
        List<Wod> CsharpListe = new List<Wod>();

        private Model.Wod valgtWorkOut;

        public Model.Wod ValgtWorkOut
        {
            get { return valgtWorkOut; }
            set
            {
                valgtWorkOut = value;
                OnPropertyChanged(nameof(ValgtWorkOut));
            }
        }

        public RelayCommand AddWodCommand { get; set; }
        public RelayCommand RemoveWodCommand { get; set; }
        public RelayCommand SaveWodCommand { get; set; }
        public RelayCommand LoadWodCommand { get; set; }
        public Model.Wod NewWod { get; set; }

        StorageFolder localfolder = null;
        private readonly string filnavn = "JsonText.json";

        public WodViewModel()
        {
            NewWod = new Model.Wod();
            WodListe = new Model.WodList();
            valgtWorkOut = new Model.Wod();
            AddWodCommand = new RelayCommand(AddNewWod);
            RemoveWodCommand = new RelayCommand(RemoveWod);
            localfolder = ApplicationData.Current.LocalFolder;
            SaveWodCommand = new RelayCommand(GemDataTilDiskAsync);
            LoadWodCommand = new RelayCommand(HentDataFraDiskAsync);
        }

        public void AddNewWod()
        {

            WodListe.Add(NewWod);

        }

        public void RemoveWod()
        {
            WodListe.Remove(ValgtWorkOut);
        }

        /// <summary>
        /// Hent Json texten fra en fil og brug metoden fra klasse der konvertere.
        /// </summary>
        public async void HentDataFraDiskAsync()
        {
            try
            {

                StorageFile file = await localfolder.GetFileAsync(filnavn);
                string jsonText = await FileIO.ReadTextAsync(file);
                //this.WodListe.Clear();
                WodListe.LoadJsonText(jsonText);
            }
            catch (Exception)
            {
                MessageDialog besked = new MessageDialog("Den kunne ikke finde listen eller listen er tom!. ");
                await besked.ShowAsync();

            }

        }
        /// <summary>
        /// Gemmer Json data til fil i localfolder JsonText.json
        /// </summary>
        public async void GemDataTilDiskAsync()
        {
            string jsonText = this.WodListe.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

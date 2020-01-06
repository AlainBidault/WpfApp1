using Cartes;
using Jeu;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace MemoryWPF.Vue
{
    internal class MemoryVueModel<T> : INotifyPropertyChanged where T : CartePourMemory
    //internal class MemoryVueModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        //private Jeu.Memory<T> _Jeu;
        private string _Indications;
        //private ObservableCollection<string> _JeuString;
        private ObservableCollection<T> _Jeu;
        public event PropertyChangedEventHandler PropertyChanged;


        public MemoryVueModel(ObservableCollection<T> jeu)
        {            
            _Jeu = jeu;
            /*ObservableCollection<Carte32> cartes = new ObservableCollection<Carte32>();
            cartes.Add(new Carte32(Valeur.AS, Atout.CARREAU));
            cartes.Add(new Carte32(Valeur.AS, Atout.PIQUE));
            cartes.Add(new Carte32(Valeur.AS, Atout.TREFLE));
            cartes.Add(new Carte32(Valeur.AS, Atout.COEUR));
            Jeu = cartes;
            ObservableCollection<string> cartesS = new ObservableCollection<string>();
            cartesS.Add(new Carte32(Valeur.AS, Atout.CARREAU).ToString());
            cartesS.Add(new Carte32(Valeur.AS, Atout.PIQUE).ToString());
            cartesS.Add(new Carte32(Valeur.AS, Atout.TREFLE).ToString());
            cartesS.Add(new Carte32(Valeur.AS, Atout.COEUR).ToString());
            JeuString = cartesS;*/
        }

        protected void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));                
            }
        }

        public ObservableCollection<T> Jeu
        {
            //get { return new ObservableCollection<ICarte>(_Jeu.GetCartes()); }
            get { return _Jeu; }
            set { _Jeu = value; OnPropertyChanged("Jeu"); }
        }

        /*public ObservableCollection<string> JeuString
        {
            //get { return new ObservableCollection<ICarte>(_Jeu.GetCartes()); }
            get { return _JeuString; }
            set { _JeuString = value; OnPropertyChanged("JeuString"); }
        }*/

        public string Indications
        {
            get { return _Indications; }
            set { _Indications = value; OnPropertyChanged("Indications"); }
        }
    }
}
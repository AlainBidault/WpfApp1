using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnes
{
    public class Personne : INotifyPropertyChanged
    {
        private string nom = "COURGE"; // attribut utilisé dans un binding
        private string prenom = "Michel"; // attribut utilisé dans un binding

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; OnPropertyChanged("Qqn.Prenom"); }// On appelle la méthode si le nom change
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; OnPropertyChanged("Qqn.Nom"); }// On appelle la méthode si le nom change
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string nomPropriete)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nomPropriete));
            }
        }

        public List<String> LesEnfants()
        {
            List<String> rep = new List<string>(4);
            rep.Add("Simon");
            rep.Add("Timon");
            rep.Add("Limon");
            rep.Add("Pimon");
            return rep;
        }

        public override string ToString()
        {            
            return Prenom+" "+Nom;
        }

    }
}

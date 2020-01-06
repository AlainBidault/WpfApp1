using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personnes
{
    public class Personne1
    {

        private string nom = "PASTEQUE"; // attribut utilisé dans un binding
        private string prenom = "Albert"; // attribut utilisé dans un binding

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }// On appelle la méthode si le nom change
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }// On appelle la méthode si le nom change
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
            return Prenom + " " + Nom;
        }

    }
}

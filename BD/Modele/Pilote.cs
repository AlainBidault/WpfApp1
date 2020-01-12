using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.Modele
{
    class Pilote
    {
        public int NumPil { get; set;  }
        public string NomPil { get; set; }
        public string Adresse { get; set; }
        public int Salaire { get; set; }

        public Pilote(int numPil, string nomPil, string adresse, int salaire)
        {
            NumPil = numPil;
            NomPil = nomPil;
            Adresse = adresse;
            Salaire = salaire;
        }

        public override string ToString()
        {
            return NumPil+NomPil+Adresse+Salaire;
        }
    }

}

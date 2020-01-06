using Cartes;
using Paquets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joueurs
{
    public class JoueurPlusOuMoins:Joueur
    {
        private Paquet32 paquet;

        public Paquet32 Paquet
        {
            get { return paquet; }
            set { paquet = value; }
        }

        public JoueurPlusOuMoins(string nom):base(nom)
        {
            //this.nom = nom;
            this.paquet = new Paquet32(false);
        }

        public override void AjouterPoints()
        {
            base.score += 2;
        }

        public override void OterPoints()
        {
            base.score -= 1;
        }
    }
}

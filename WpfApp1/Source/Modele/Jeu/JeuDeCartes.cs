using Joueurs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu
{
    public abstract class JeuDeCartes
    {
        protected List<IJoueur> joueurs;

        public List<IJoueur> Joueurs
        {
            get { return joueurs; }
            set { joueurs = value; }
        }

        public JeuDeCartes()
        {            
            joueurs = new List<IJoueur>();
        }

        public abstract void Add(String nom);
        public abstract void Jouer();
    }
}

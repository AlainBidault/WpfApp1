using Cartes;
using Paquets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Joueurs
{
    public class JoueurMemory<T>:Joueur where T:CartePourMemory
    {
        private Paquet<T> main;

        public Paquet<T> Main
        {
            get { return main; }
            set { main = value; }
        }

        public JoueurMemory(string nom, Paquet<T> paquet):base(nom)
        {
            this.main = paquet;
        }

        public void AddCarteGagnee(T carte)
        {
            this.AjouterPoints();
            this.main.Add(carte);
        }

        public override void AjouterPoints()
        {
            base.score += 1;
        }

        public override void OterPoints() // non utilisée
        {
            base.score -= 1;
        }
    }
}

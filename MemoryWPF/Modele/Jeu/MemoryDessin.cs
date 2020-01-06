using Cartes;
using Joueurs;
using Paquets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu
{
    public class MemoryDessin:Memory<CarteDessin>
    {
        public MemoryDessin(int n) : base()
        {
            base.paquet = new PaquetDessin(n);
        }
        public override void Add(string nom)
        {
            base.joueurs.Add(new JoueurMemory<CarteDessin>(nom, new PaquetDessin(0)));
        }

    }
}

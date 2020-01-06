using Cartes;
using Joueurs;
using Paquets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu
{
    public class Memory32:Memory<Carte32>
    {
        public Memory32() : base()
        {
            base.paquet = new Paquet32(false);
        }

        public override void Add(string nom)
        {
            base.joueurs.Add(new JoueurMemory<Carte32>(nom, new Paquet32(true)));
        }
    }
}

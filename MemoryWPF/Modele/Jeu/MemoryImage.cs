using Cartes;
using Joueurs;
using Paquets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jeu
{
    public class MemoryImage:Memory<CarteImage>
    {
        public MemoryImage(int n) : base()
        {
            base.paquet = new PaquetImage(6);
        }
        public override void Add(string nom)
        {
            base.joueurs.Add(new JoueurMemory<CarteImage>(nom, new PaquetImage(0)));
        }

    }
}

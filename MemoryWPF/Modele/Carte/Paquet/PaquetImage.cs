using Cartes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paquets
{
    class PaquetImage:Paquet<CarteImage>
    {
        public PaquetImage(int n) : base()
        {
            cartes = new List<CarteImage>(8);
            if (n > 0)
            {
                cartes.Add(new CarteImage("faille.jpeg"));
                cartes.Add(new CarteImage("faille.jpeg"));
                cartes.Add(new CarteImage("porte.jpeg"));
                cartes.Add(new CarteImage("porte.jpeg"));
                cartes.Add(new CarteImage("dragon.jpeg"));
                cartes.Add(new CarteImage("dragon.jpeg"));
                cartes.Add(new CarteImage("tresor.jpeg"));
                cartes.Add(new CarteImage("tresor.jpeg"));
            }
            this.Shuffle();
        }

    }
}

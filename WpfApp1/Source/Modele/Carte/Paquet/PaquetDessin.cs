using Cartes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paquets
{
    class PaquetDessin:Paquet<CarteDessin>
    {
        public PaquetDessin(int n) : base()
        {
            cartes = new List<CarteDessin>(n*2);
            for (int i = 0; i < n; i++)
            {
                // TODO attention, gérer le nombre de Dessin
                cartes.Add(new CarteDessin((Dessin)i));
                cartes.Add(new CarteDessin((Dessin)i));
            }
            this.Shuffle();
        }

    }
}

using System;
using Cartes;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Paquets
{
    public class Paquet32:Paquet<Carte32> 
    {
        //Une déclaration de constante ou de type est implicitement un membre statique.
        private const int NBR_CARTES = (int)Valeur.size * (int)Atout.size;       

        
        public Paquet32(bool vide) : base()
        {
            cartes = new List<Carte32>(NBR_CARTES);
            if (!vide)
            {
                for (int i = 0; i < (int)Valeur.size; i++)
                {
                    for (int j = 0; j < (int)Atout.size; j++)
                    {
                        cartes.Add(new Carte32((Valeur)i + 7, (Atout)j));
                    }
                }
                this.Shuffle();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Cartes
{
    public abstract class CartePourMemory:Carte
    {
        public abstract bool EstCompatible(CartePourMemory c);

        public bool Gagnee
        {
            get;set;
        }

        public override string ToString()
        {
            string rep = base.ToString();
            if (Gagnee)
            {
                rep = "      ";
            }
            return rep;
        }
    }
}

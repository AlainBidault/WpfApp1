using System;
using System.Collections.Generic;
using System.Text;

namespace Cartes
{
    public abstract class CartePourMemory:Carte
    {
        public abstract bool EstCompatible(CartePourMemory c);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cartes
{
    public class Carte32: CartePourMemory
    {
        private Valeur valeur;
        private Atout atout;

        public Valeur Valeur
        {
            get { return valeur; }
            set { valeur = value; }
        }

        public Atout Atout
        {
            get { return atout; }
            set { atout = value; }
        }

        public Carte32(Valeur valeur, Atout atout):base()
        {
            this.valeur = valeur;
            this.atout = atout;
        }       
       
        protected override string GetFace()
        {
            return "/" + valeur + "/" + atout;
        }

        public override bool EstCompatible(CartePourMemory c)
        {
            Carte32 c32 = (Carte32)c;
            return this.Valeur.Equals(c32.Valeur) && this.CouleurCompatible(c32);
        }

        private bool CouleurCompatible(Carte32 c32)
        {
            return ( this.atout.Equals(c32.atout)
                    || ((this.atout == Atout.CARREAU) && c32.atout.Equals(Atout.COEUR))
                    || (this.atout.Equals(Atout.COEUR) && c32.atout.Equals(Atout.CARREAU))
                    || (this.atout.Equals(Atout.TREFLE) && c32.atout.Equals(Atout.PIQUE))
                    || (this.atout.Equals(Atout.PIQUE) && c32.atout.Equals(Atout.TREFLE))
                   );
        }
    }
    // (Valeur) i
    // (int) Valeur.size
    public enum Valeur :int {
        SEPT=7, HUIT, NEUF, DIX, VALET, DAME, ROI, AS, size=8
    }

    public enum Atout :int
    {
        PIQUE, COEUR, CARREAU, TREFLE, size=4
    }



}

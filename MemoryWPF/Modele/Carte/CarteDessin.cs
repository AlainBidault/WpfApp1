using Cartes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartes
{
    public class CarteDessin : CartePourMemory
    {
        private Dessin motif;

        public Dessin Motif
        {
            get { return motif; }
            set { motif = value; }
        }

        public CarteDessin(Dessin motif):base()
        {
            this.motif = motif;
        }

        protected override string GetFace()
        {
            return motif+"";
        }

        public override bool EstCompatible(CartePourMemory c)
        {            
            return this.motif.Equals(((CarteDessin)c).motif);
        }

    }

    public enum Dessin:int
    {
        MAISON, SOLEIL, VOITURE, CHIEN, FLEUR, NUAGE, size=6
    }
}
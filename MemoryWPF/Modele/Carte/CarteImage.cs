using Cartes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cartes
{
    public class CarteImage : CartePourMemory
    {
        private string face;
        private string url;

        public CarteImage(string motif):base()
        {
            Dos = "dos.jpg";
            this.face = motif;
        }

        protected override string GetFace()
        {
            return face;
        }

        public string Url
        {
            get { return "./photos/" + ToString(); }
            set {url = value;            }
        }

        public override bool EstCompatible(CartePourMemory c)
        {            
            return this.face.Equals(((CarteImage)c).face);
        }

    }
    
}
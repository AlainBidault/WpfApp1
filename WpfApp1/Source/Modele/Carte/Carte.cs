namespace Cartes
{

    public abstract class Carte : ICarte
    {
        private bool visible;
        private string dos = "*****";
        protected abstract string GetFace();

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        public string Dos
        {
            get { return dos; }
            set { dos = value; }
        }

        protected Carte()
        {
            this.visible = false;
        }

        public void Tourne()
        {
            this.visible = !this.visible;
        }

        public override string ToString()
        {
            string rep = dos;
            if (this.visible) // mettre un not pour simplifier les tests.
            {
                rep = GetFace();
            }
            return rep;
        }


    }
}
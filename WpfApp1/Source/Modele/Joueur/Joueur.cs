namespace Joueurs
{
    public abstract class Joueur:IJoueur
    {
        protected int score;
        private string nom;

        public abstract void AjouterPoints();
        public abstract void OterPoints();

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public Joueur(string nom)
        {
            this.nom = nom;
            this.score = 0;
        }

    }
}
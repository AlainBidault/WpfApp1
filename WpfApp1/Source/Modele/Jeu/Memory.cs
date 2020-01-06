
using Cartes;
using Exceptions;
using Joueurs;
using Paquets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Exceptions.SaisieException;

namespace Jeu
{
    public abstract class Memory<T>:JeuDeCartes where T:CartePourMemory
    {
        protected IPaquet<T> paquet;
        private int indiceJoueurCourant = 0;
        private JoueurMemory<T> joueurCourant = null;

        public IPaquet<T> Paquet
        {
            get { return paquet; }
            set { paquet = value; }
        }

        public override void Jouer()
        {
            // TODO attention si la liste de joueurs est vide !
            bool fini = false;
            joueurCourant = (JoueurMemory<T>)joueurs[0];
            while (!fini)
            {
                int[] deuxChoix = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    AfficherPaquet();
                    //int choix = SaisirPositionCarte();
                    int choix = SaisirPositionCarteAvecException();
                    deuxChoix[i] = choix;
                    paquet.Get(choix).Tourne();
                }
                AfficherPaquet();
                if (paquet.Get(deuxChoix[0]).EstCompatible(paquet.Get(deuxChoix[1])))
                {
                    for (int i = 0; i < 2; i++)
                    {
                        T carte = paquet.Remove(deuxChoix[i]);
                        joueurCourant.AddCarteGagnee(carte);
                    }
                    fini = PlateauVide();
                    if (!fini)
                    {
                        Console.WriteLine(joueurCourant.Nom + ", encore à toi de jouer");
                    }
                }
                else
                {
                    //sinon on change de joueur
                    indiceJoueurCourant = (indiceJoueurCourant + 1) % joueurs.Count;
                    joueurCourant = (JoueurMemory<T>)joueurs[indiceJoueurCourant];
                    Console.WriteLine(joueurCourant.Nom + ", à toi de jouer");
                    for (int i = 0; i < 2; i++)
                    {
                        paquet.Get(deuxChoix[i]).Tourne();
                    }
                }
                Console.ReadKey();
            }
            AfficherScores();
            Console.ReadKey();
        }

        private void AfficherScores()
        {
            Console.WriteLine("fin du jeu");
            for (int i = 0; i < joueurs.Count; i++)
            {
                Console.WriteLine(joueurs[i].Nom+ ", score : " + joueurs[i].Score);
            }
            
        }

        private bool PlateauVide()
        {
            bool vide = true;
            int i = 0;
            while(vide && i<paquet.Count())
            {
                vide = paquet.Get(i++)==default(T);
            }
            return vide;
        }

        private void AfficherPaquet()
        {
            Console.Clear();
            string unEmplacement;
            for (int i = 0; i < paquet.Count(); i++)
            {
                unEmplacement = "";
                T carte = paquet.Get(i);
                if (carte != default(T))
                {
                    if (i < 10)
                    {
                        unEmplacement += " ";
                    }
                    unEmplacement += (i + 1) + ": " + carte + " ";
                }
                unEmplacement = unEmplacement.PadRight(19, ' ');
                if (i%5==4)
                {
                    unEmplacement += "\n";
                }
                Console.Write(unEmplacement);
            }
            Console.WriteLine("");
        }

        private int SaisirPositionCarte()
        {
            bool valide = false;
            int n=0;
            while (!valide)
            {
                string numero = Console.ReadLine();
                valide = int.TryParse(numero, out n)
                        && (n > 0) && (n <= paquet.Count())
                        && paquet.Get(n - 1)!=null
                        && !paquet.Get(n-1).Visible;
                if (!valide) { 
                    Console.WriteLine(numero + " invalide");
                }
            }
            return n-1;

        }
        private int SaisirPositionCarteAvecException()
        {
            bool valide = false;
            int n = 0;
            while (!valide)
            {
                try
                {
                    n=LireEntier();
                    valide = true;
                }
                catch (SaisieException se)
                {
                    Console.WriteLine(se.Explication);

                }
            }
            return n - 1;

        }

        private int LireEntier()
        {
            string numero = Console.ReadLine();
            if (!int.TryParse(numero, out int n))
            {
                throw new SaisieException(ErreurSaisie.PAS_UN_NOMBRE);
            }
            if ((n <= 0) || (n > paquet.Count()))
            {
                throw new SaisieException(ErreurSaisie.MAUVAIS_INTERVALLE);
            }
            if (paquet.Get(n - 1) == default(T))
            {
                throw new SaisieException(ErreurSaisie.CARTE_ABSENTE);
            }
            if (paquet.Get(n - 1).Visible)
            {
                throw new SaisieException(ErreurSaisie.CARTE_RETOURNEE);
            }
            return n;
        }
    }
}

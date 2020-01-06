using Paquets;
using Cartes;
using Joueurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu
{
    public class PlusOuMoins:JeuDeCartes
    {
       public PlusOuMoins()
        {
            // TODO uniformiser
            JoueurPlusOuMoins j = new JoueurPlusOuMoins("Han Solo");
            Console.WriteLine("le paquet" + j.Paquet);
            joueurs.Add(j);
        }

        public override void Add(string nom)
        {
            joueurs.Add(new JoueurPlusOuMoins(nom));
        }

        public override void Jouer()
        {

            bool fini = false;
            int i = 1;
            JoueurPlusOuMoins j = (JoueurPlusOuMoins) joueurs[0];
            Paquet32 paquet = j.Paquet;
            Carte32 cPrecedente = paquet.Get(0);
            while (!fini)
            {
                cPrecedente.Tourne();
                Carte32 cSuivante = paquet.Get(i);
                Console.WriteLine("plus + ou moins - ou quitte q ?" + cPrecedente);
                string rep = Console.ReadLine();
                fini = rep.Equals("q");
                if (!fini)
                {
                    if ((rep.Equals("+") && (cSuivante.Valeur >= cPrecedente.Valeur))
                        || (rep.Equals("-") && (cSuivante.Valeur <= cPrecedente.Valeur)))
                    {
                        Console.WriteLine("Bravo !");
                        j.AjouterPoints();
                    }
                    else
                    {
                        Console.WriteLine("Perdu !");
                        j.OterPoints();
                    }
                    cPrecedente = cSuivante;
                    i += 1;
                    fini = (i == paquet.Count());
                }
       
            }
            Console.WriteLine("votre score : "+j.Score);
            Console.ReadKey();
        }
    }
}

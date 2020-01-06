using Cartes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paquets
{
    public abstract class Paquet<T>:IPaquet<T>  where T : ICarte
    {

        // Patron de Concept / Design Pattern : façade
        protected List<T> cartes;

        public List<T> Cartes
        {
            get { return cartes; }
            set { cartes = value; }
        }

        public T Get(int i)
        {
            // permet Paquet p1; p1.Get(5) plutôt que p1.Cartes[5]
            return this.cartes[i];
        }

        public int Count()
        {
            return cartes.Count;
        }

        public T Remove(int i)
        {
            T c = cartes[i];
            cartes[i] = default(T);
            return c;
        }

        public void Add(T c)
        {
            cartes.Add(c);
        }

        public void Shuffle()
        {
            Random rnd = new Random();
            T cSauv;
            for (int i = 0; i < cartes.Count; i++)
            {
                int k = rnd.Next(cartes.Count);
                cSauv = cartes[i];
                cartes[i] = cartes[k];
                cartes[k] = cSauv;
            }
        }

        public override string ToString()
        {
            string rep = "";
            for (int i = 0; i < cartes.Count; i++)
            {
                rep += cartes[i] + "\n";
            }
            return rep;
        }

       
    }
}

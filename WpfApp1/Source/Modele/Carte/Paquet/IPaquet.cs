using Cartes;
using System.Collections.Generic;

namespace Paquets
{
    public interface IPaquet<T> where T : ICarte
    {

        List<T> Cartes
        {
            get;
            set;
        }

        int Count();
        T Get(int i);
        T Remove(int v); // RemoveAt(v)
        void Add(T carte);
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Exceptions
{
    public class SaisieException : Exception
    {
        public ErreurSaisie Erreur
        {
            get;
            set;
        }

        public string Explication
        {
            get;
            set;
        }


        public SaisieException(ErreurSaisie erreur)
        {
            this.Erreur = erreur;
            switch (erreur)
            {
                case ErreurSaisie.MAUVAIS_INTERVALLE: this.Explication = "ce numéro de carte est hors limite";break;
                case ErreurSaisie.CARTE_ABSENTE: this.Explication = "carte déjà retirée"; break;
                case ErreurSaisie.CARTE_RETOURNEE: this.Explication = "carte déjà visible"; break;
                default:
                    this.Explication = "problème de saisie";
                    break;
            }
        }

        public enum ErreurSaisie
    {
        MAUVAIS_INTERVALLE, CARTE_ABSENTE, CARTE_RETOURNEE, PAS_UN_NOMBRE
    }
    }
}
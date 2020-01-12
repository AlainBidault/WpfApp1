using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.dao
{
    using System.Data.SqlClient;
    class Connexion
    {
        private static SqlConnection LaConnexion { get; set; } = null;
        private static string Login { get; set; } = null;
        private static string MDP { get; set; } = null;

        public static void ConnecterUtilisateur(string login, string mdp)
        {
            Login = login;
            MDP = mdp;
        }

        public static void DeconnecterUtilisateur()
        {
            Login = null;
            MDP = null;
        }

        public static void close()
        {
            LaConnexion.Close();
            LaConnexion = null;
        }

        public static SqlConnection GetInstance()
        {
            // Préparation de la connexion à la base de données
            if (Login != null)
            {
                if (LaConnexion == null)
                {
                    string serveur = "Data Source = DESKTOP-7PVLFSQ\\SQLEXPRESS;";
                    string bd = "Initial Catalog=aeronautique;";
                    string login = "User Id=" + Login + ";";
                    string mdp = "Password=" + MDP + ";";
                    string connectionString = serveur + bd + login + mdp;
                    LaConnexion = new SqlConnection(connectionString);
                    try
                    {
                        // Connexion à la base de données
                        LaConnexion.Open();
                        Console.WriteLine("************* connecté ******************");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("######  PROBLEME " + ex.Message);
                    }
                }
            }
            return LaConnexion;
        }

        private Connexion() { }

    }      
}


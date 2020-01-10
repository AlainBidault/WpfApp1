using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursABI.dao
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
                    string serveur = "Data Source = DESKTOP - 7PVLFSQ\\SQLEXPRESS;";
                    string bd = "Initial Catalog=aeronautique;";
                    string login = "User Id="+Login+";";
                    string mdp = "Password="+MDP+";";
                    string connectionString = serveur + bd + login + mdp;
                    LaConnexion = new SqlConnection(connectionString);
                    try
                    {
                        // Connexion à la base de données
                        LaConnexion.Open();
                        Console.WriteLine("connecté");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("PROBLEME " + ex.Message);
                    }
                }
            }
            return LaConnexion;
        }

        private Connexion() { }

        /*
         * Le CRUD ci-dessous pourrait être dans un autre fichier PiloteDAO.cs
         */


        public static void Create() // un objet C# de type pilote devrait être passé
        {
            SqlCommand command = Connexion.GetInstance().CreateCommand();
            // Définition de la requête
            command.CommandText = "INSERT INTO PILOTE (nompil,adr,sal) VALUES (@nom, @adr,@sal)";
            command.Parameters.AddWithValue("@nom", "Faraday");
            command.Parameters.AddWithValue("@adr", "Dijon");
            command.Parameters.AddWithValue("@sal", 15999);

            // Exécution de la requête de modification de la base
            command.ExecuteNonQuery();
        }

        public static void Read(int id)
        {
            SqlCommand command = Connexion.GetInstance().CreateCommand();
            command.CommandText = "SELECT * FROM PILOTE WHERE numpil=@id";
            command.Parameters.AddWithValue("@id", id);
            // Lecture des résultats, exécution de la requête de lecture
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read()) // une seule réponse
            {
                Console.WriteLine(dataReader["nompil"]);
            }
            dataReader.Close();
        }

        public static void Update() // un objet pilote C# de type pilote devrait être passé
        {
            SqlCommand command = Connexion.GetInstance().CreateCommand();
            // Définition de la requête
            command.CommandText = "UPDATE PILOTE SET nomPil = @nom, Adr = @adr, sal = @sal WHERE numPil=@id";
            command.Parameters.AddWithValue("@nom", "Faraday"); //("@nom", pilote.Nom)
            command.Parameters.AddWithValue("@adr", "Dijon");//("@adr", pilote.Adresse)
            command.Parameters.AddWithValue("@sal", 15999);//("@sal", pilote.Salaire)

            // Exécution de la requête de modification de la base
            command.ExecuteNonQuery();
        }

        public static void Delete(int id) // un objet C# de type pilote devrait être passé
        {
            SqlCommand command = Connexion.GetInstance().CreateCommand();
            // Définition de la requête
            command.CommandText = "DELETE FROM PILOTE WHERE numPil= @id";
            command.Parameters.AddWithValue("@id", id);


            // Exécution de la requête de modification de la base
            command.ExecuteNonQuery();
        }

        /*
         * Si on préfère s'embêter avec la gestion des types SQL vs C# (aucune raison de le faire)
         */
        public static void Read0(int id)
        {
            SqlCommand command = Connexion.GetInstance().CreateCommand();
            command.CommandText = "SELECT * FROM PILOTE WHERE id='" + id + "'";

            // Lecture des résultats, exécution de la requête de lecture
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read()) // une seule réponse
            {
                Console.WriteLine(dataReader["nompil"]);
            }
            dataReader.Close();
        }        

        /*
         * Une autre requête quelconque qui interroge pilote
         */
        public static void Query()
        {
            SqlCommand command = Connexion.GetInstance().CreateCommand();
            command.CommandText = "SELECT * FROM PILOTE WHERE numpil > @id";
            command.Parameters.AddWithValue("@id", 3);

            // Lecture des résultats, exécution de la requête de lecture
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read()) // potentiellement plusieurs réponses, voire aucune
            {
                Console.WriteLine(dataReader["nompil"]);
            }
            dataReader.Close();
        }

    }
}


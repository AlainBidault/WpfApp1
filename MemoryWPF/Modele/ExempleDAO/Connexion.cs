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

        public static SqlConnection GetInstance() {
            // Préparation de la connexion à la base de données
            if (LaConnexion == null) {
                string connectionString = "Data Source=DESKTOP-7PVLFSQ\\SQLEXPRESS;Initial Catalog=aeronautique;User Id=AlainB;Password=toto;";
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
            return LaConnexion;
        }

        private Connexion() { }

        public static void Query1()
        {
            SqlCommand command = Connexion.GetInstance().CreateCommand();
            command.CommandText = "SELECT * FROM PILOTE";

            // Lecture des résultats
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine(dataReader["nompil"]);
            }
            dataReader.Close();
        }

        public static void Query2()
        {
            SqlCommand command = Connexion.GetInstance().CreateCommand();
            command.CommandText = "SELECT * FROM PILOTE WHERE numpil > @id";
            command.Parameters.AddWithValue("@id", 3);

            // Lecture des résultats
            SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine(dataReader["nompil"]);
            }
            dataReader.Close();
        }

        public static void Update()
        {
            SqlCommand command = Connexion.GetInstance().CreateCommand();
            // Définition de la requête
            command.CommandText = "INSERT INTO PILOTE (nompil,adr,sal) VALUES (@nom, @adr,@sal)";
            command.Parameters.AddWithValue("@nom", "Faraday");
            command.Parameters.AddWithValue("@adr", "Dijon");
            command.Parameters.AddWithValue("@sal", 15999);

            // Exécution de la requête
            command.ExecuteNonQuery();
        }

    }
}


using BD.Modele;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD.dao
{
    class PiloteDAO
    {

        /*
         * Le CRUD ci-dessous pourrait être dans un autre fichier PiloteDAO.cs
         * CREATE TABLE [dbo].[PILOTE](
	[numpil] [int] IDENTITY(1,1) NOT NULL,
	[nompil] [varchar](50) NULL,
	[adr] [varchar](50) NULL,
	[sal] [int] NULL,
         * 
         */


        public static void Create(Pilote pilote) //un objet C# de type pilote doit  être passé
        {
            SqlCommand command = Connexion.GetInstance().CreateCommand();
            // Définition de la requête
            command.CommandText = "INSERT INTO PILOTE (nompil,adr,sal) VALUES (@nom, @adr,@sal)";
            command.Parameters.AddWithValue("@nom", pilote.NomPil);
            command.Parameters.AddWithValue("@adr", pilote.Adresse);
            command.Parameters.AddWithValue("@sal", pilote.Salaire);

            // Exécution de la requête de modification de la base
            command.ExecuteNonQuery();

            //TODO récupérer l'id généré
        }

        public static Pilote Read(int id) // un objet C# de type pilote peut aussi être passé
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
            Pilote pilote = new Pilote((int)dataReader["numpil"], (string)dataReader["nompil"],
                (string)dataReader["adr"], (int)dataReader["sal"]);
            dataReader.Close();
            return pilote;
        }

        public static void Update(Pilote pilote) //un objet pilote C# de type pilote doit être passé
        {
            SqlCommand command = Connexion.GetInstance().CreateCommand();
            // Définition de la requête
            command.CommandText = "UPDATE PILOTE SET nomPil = @nom, Adr = @adr, sal = @sal WHERE numPil=@id";
            command.Parameters.AddWithValue("@nom", pilote.NomPil);
            command.Parameters.AddWithValue("@adr", pilote.Adresse);
            command.Parameters.AddWithValue("@sal", pilote.Salaire);
            command.Parameters.AddWithValue("@id", pilote.NumPil);

            // Exécution de la requête de modification de la base
            command.ExecuteNonQuery();
        }

        public static void Delete(int id) // un objet C# de type pilote peut aussi être passé
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
        public static Pilote Read0(int id)
        {
            SqlCommand command = Connexion.GetInstance().CreateCommand();
            command.CommandText = "SELECT * FROM PILOTE WHERE numpil='" + id + "'";

            // Lecture des résultats, exécution de la requête de lecture
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read()) // une seule réponse
            {
                Console.WriteLine(dataReader["nompil"]);
            }
            Pilote pilote = new Pilote((int)dataReader["numpil"], (string)dataReader["nompil"],
                (string)dataReader["adr"], (int)dataReader["sal"]);
            dataReader.Close();
            return pilote;
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

namespace BD.Modele.ExempleDAO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /*
     * La façon la plus simple, en C#, de se connecter avec la BD sera d'utiliser Entity Data Model et Linq.
     * Vous pourrez générer votre modèle directement à partir de votre BD SQL Express.
     * Pensez à activer SQL Server Browser pour la détection automatique.
     * J'ai testé pour vous la façon "code first à partir de la BD".
     * Vous trouverez dans App.config les paramètres de connexion à la BD (dont serveur + user/mot de passe)
     */

    public partial class ModelPilote : DbContext
    {
        public ModelPilote()
            : base("name=ModelPilote1")
        {
        }

        public virtual DbSet<PILOTE> PILOTE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PILOTE>()
                .Property(e => e.nompil)
                .IsUnicode(false);

            modelBuilder.Entity<PILOTE>()
                .Property(e => e.adr)
                .IsUnicode(false);
        }
    }
}

namespace BD.Modele.ExempleDAO
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    /*
     * La fa�on la plus simple, en C#, de se connecter avec la BD sera d'utiliser Entity Data Model et Linq.
     * Vous pourrez g�n�rer votre mod�le directement � partir de votre BD SQL Express.
     * Pensez � activer SQL Server Browser pour la d�tection automatique.
     * J'ai test� pour vous la fa�on "code first � partir de la BD".
     * Vous trouverez dans App.config les param�tres de connexion � la BD (dont serveur + user/mot de passe)
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

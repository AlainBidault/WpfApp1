namespace BD.Modele.ExempleDAO
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    /*
     * La façon la plus simple, en C#, de se connecter avec la BD sera d'utiliser Entity Data Model et Linq.
     * Vous pourrez générer votre modèle directement à partir de votre BD SQL Express.
     * Pensez à activer SQL Server Browser pour la détection automatique.
     * J'ai testé pour vous la façon "code first à partir de la BD".
     */

    [Table("PILOTE")]
    public partial class PILOTE
    {
        [Key]
        public int numpil { get; set; }

        [StringLength(50)]
        public string nompil { get; set; }

        [StringLength(50)]
        public string adr { get; set; }

        public int? sal { get; set; }

        public override string ToString()
        {
            return "*"+numpil + nompil + adr + sal;
        }
    }
}

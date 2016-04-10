namespace AxadoTeste.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarrierRating")]
    public partial class CarrierRating
    {
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal id_Carrier { get; set; }

        [Column(TypeName = "numeric")]
        public decimal id_User { get; set; }

        public int Rating { get; set; }

        public virtual Carrier Carrier { get; set; }

        public virtual User User { get; set; }
    }
}
